CV Matcher AI 🚀

CV Matcher AI to backendowa aplikacja oparta na platformie .NET, której celem jest automatyczna analiza 
i dopasowywanie CV kandydatów z wykorzystaniem sztucznej inteligencji. Projekt łączy podejście Clean Architecture
z nowoczesnymi technikami NLP (Natural Language Processing), umożliwiając przetwarzanie nieustrukturyzowanych 
dokumentów (np. PDF) w uporządkowane dane gotowe do dalszej analizy.

Aplikacja przyjmuje pliki CV, ekstraktuje z nich tekst, a następnie wykorzystuje model językowy do wygenerowania 
strukturalnego opisu kandydata (m.in. umiejętności, doświadczenie, wykształcenie, języki). Dane te mogą być 
dalej używane do budowy systemu dopasowywania kandydatów do ofert pracy, rankingu aplikacji czy wyszukiwania semantycznego.

Projekt został zaprojektowany zgodnie z zasadami Clean Architecture — logika biznesowa jest oddzielona od warstwy 
infrastruktury i API, co pozwala na łatwą rozbudowę (np. o embeddingi, vector database czy integracje z innymi systemami AI).

Główne funkcjonalności:
📄 Upload CV (PDF)
🔍 Ekstrakcja tekstu z dokumentów
🤖 Parsowanie CV do strukturalnego JSON przy użyciu AI
🧠 Przygotowanie pod system dopasowywania kandydatów (AI matching)
🧱 Modularna architektura (API / Application / Domain / Infrastructure)
Cel projektu

Celem projektu jest stworzenie fundamentu pod inteligentny system rekrutacyjny, który automatyzuje analizę CV 
i wspiera proces podejmowania decyzji rekrutacyjnych z wykorzystaniem AI.
