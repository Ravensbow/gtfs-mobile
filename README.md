# Kuba jeździ ZTMem - mobile
> **Platforma:** Android, ?iOS  
> **Użyte technologie:** C#, Xamarin.Forms  
> **Środowisko pracy:** Windows, Visual Studio 2017 Enterprise  
## Opis: 
Aplikacja mobilna, pozwalająca na sprawdzenie aktualnego rozkładu jazdy dla wybranego przystanku w danym mieście. Jest ona uniwersalna, odczytuje dane pobrane z sieci w formacie tekstowym, które z kolei utrzymane są w konwencji GTFS, powszechnie uznawanej za standard. Obsługuje jeden z dwóch dostępnych formatów przechowywania daty odjazdu, przez co nie działa ze wszystkimi miastami.

## Grafika:
![alt text](https://zapodaj.net/images/bd89f0cf5b448.png)
## Błędy:
- Obsługuje tylko kursy zapisane w pliku odpowadającym dniom tygodnia, a nie odczytuje tych odpowiadających konkretym dniom miesiąca
- Długi czas ładowania danych przy uruchomieniu aplikacji
- Aktualna wersja współpracuje jedynie z miastem Poznań
