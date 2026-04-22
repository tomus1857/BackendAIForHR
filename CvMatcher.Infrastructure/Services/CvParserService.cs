using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using UglyToad.PdfPig;

public class CvParserService : ICvParserService
{
    private readonly ICvRepository _cvRepository;
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public CvParserService(ICvRepository cvRepository, HttpClient httpClient, IConfiguration config)
    {
        _cvRepository = cvRepository;
        _httpClient = httpClient;
        _apiKey = config["ApiKeys:OpenAI"] ?? throw new ArgumentNullException("OpenAI API key is not configured.");
    }

    public async Task<string> ParseCvAsync(string extractedText)
    {
        var prompt = $@"
        Wyodrębnij ustrukturyzowane dane z tego CV.

        Zwróć WYŁĄCZNIE poprawny JSON:
        - skills (tablica)
        - experienceYears (liczba)
        - education (string)
        - languages (tablica)

        CV:
        {extractedText}
        ";
        var requestBody = new
        {
            model = "gpt-4o-mini",
            messages = new[]
            {
                new
                {
                    role = "system",
                    content = "Jesteś parserem CV. Zwracaj WYŁĄCZNIE poprawny JSON bez żadnych dodatkowych komentarzy."
                },
                new
                {
                    role = "user",
                    content = prompt
                }
            },
            temperature = 0.2
        };
        var json = JsonSerializer.Serialize(requestBody);
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(responseString);
        var content = doc.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();
        return content ?? throw new Exception("No content in OpenAI response.");
    }

    public async Task<string> ExtractTextAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            throw new ArgumentException("File is null or empty.");
        }
        using var stream = file.OpenReadStream();
        var sb = new StringBuilder();
        using (var pdf = PdfDocument.Open(stream))
        {
            foreach (var page in pdf.GetPages())
            {
                sb.AppendLine(page.Text);
            }
        }
        return await Task.FromResult(sb.ToString());
    }

}