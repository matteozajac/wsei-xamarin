# Laboratorium 3
  
## Zagadnienia  
  
- Widok listy (ListView)

- Połączenie z API i pobieranie danych

- Rejestracja do Airly API
  
## Zadania  

### 1. Zarejestruj się do api Airly - Adres: https://developer.airly.eu

- Załóż konto i zapoznaj się z sekcją Concepts w dokumentacji.

### 2. Pobierz swoją lokalizację z telefonu.

- Wykorzystaj element Geolocation biblioteki Xamarin.Essentials (jest domyślnie zainstalowana w nowym projekcie Xamarin.Forms przez nuget) do pobrania własnej lokalizacji - będzie potrzebna do zapyta w Airly API.

### 3. Stwórz zapytania do API Airly.

- UWAGA: Api Airly ma limit 100 requestów na dzien. Pamiętaj, żeby nie przekroczyć limitu albo będzie ci trudniej dokonczyć ćwiczenie.

- Wykorzystaj klasę HttpClient do obsługi requestów do API.

- Dodaj do instancji HttpClient niezbędne nagłówki (wymienione w dokumentacji).

- Wykonaj zapytanie Get do endpointu: Installations -> Nearest - najlepiej utwórz limit zwracanych wyników na 1. Na razie więcej nie będzie potrzebne.

- Wyciągnij odpowiedź jako string. Na tej podstawie stwórz modele takie same jak zwrócone dane.

- Parsuj odpowiedź z HttpClient za pomocą biblioteki Newtonsoft.Json (pobierz ją z nugeta) na klasy, które stworzyłeś.

- Powtórz powyższe czynności dla innego endpointa z API: Measurements -> By ID - będziesz do niego potrzebował Id instalacji, które dostaniesz z pierwszego zapytania – najlepiej wykonać takie zapytania w pętli dla każdego id (w razie jak będziemy pobierać ich więcej).

- Proponowane modele: Measurement, MeasurementItem, MeasurementValue, AirQualityIndex, AirQualityStandard, Installation, Address

- Kontroluj ilość zapytan, która ci pozostała (wykorzystaj nagłówek X-RateLimit-Remaining-day - więcej w dokumentacji Airly).

- Pamiętaj o obsłudze błędów przy robieniu zapytania, a także o sprawdzaniu zwróconego kodu http.

- Możesz użyć UriBuilder i HttpUtility.ParseQueryString do stworzenia adresu url do zapytania, żeby zachować porządek.

### 4. View model – lista elementów.

- Z DetailsViewModel wydziel SetPropety i inne zależne rzeczy (w tym implementowany interfejs) do klasy bazowej, np. BaseViewModel – niech oba nasze view modele po nim dziedziczą.

- W HomeViewModel stwórz właściwość listy z elementami takiego typu, jaki pobierasz w punkcie powyżej z api Airly (typ na który rzutujesz jsona z drugiego zapytania – do Measurements -> By ID).

- Przypisz do właściwości pobrane elementy (lub na razie jakieś testowe, jeśli nie robisz punktów po kolei).

- W typie elementu z listy dodaj referencję do instalacji, do której się ona odnosi (a więc Measurement powinien mieć odniesienie do Installation - będziemy potrzebować obu tych danych na widoku).

### 5. Stworzenie widoku listy

- Na stronie HomePage.xaml zamien przycisk na kontrolkę ListView.

- Dodaj bindowanie do właściwości ItemsSource z właściwości z poprzedniego punktu w view modelu.

- Dodaj do listy ItemTemplate - może to być najprostszy TextCell lub własny widok stworzony z ViewCell.

- W komórce w ItemTemplate zbinduj wartości z pojedynczych elementów z właściwości w view modelu (zbindowanego do ItemsSource listy). Możesz np. zbindować adres i obecną wartość CAQI (indeks w api).

### 6. Zaktualizuj odnośnik do strony szczegółów.

- W ListView dodaj atrybut ItemTapped.

- W handlerze, który utworzył się w HomePage.xaml.cs wywołaj komendę GoToDetailsCommand.Execute z view modelu – view model możesz uzyskać z właściwości BindingContext (rzutowanie).

- Jako paramter w metodzie Execute przekaż elemenet listy – znajduje się w parametrze ItemTappedEventArgs, we właściwości Item.

- W komendzie w view modelu dodaj argument (Command to klasa generyczna).

- Przekazuj argument z komendy do widoku szczegółów (zmodyfikuj konstruktor) i zapisuj go jako właściwość w DetailsViewModel.

### 7. Zaktualizuj dane na stronie szczegółów.

- Na podstawie przekazanego obiektu z punktu 6 uaktualnij wszystkie właściwości w view modelu strony szczegółów.

- Wartości na stronie szczegółów możesz zaokrąglić za pomocą Math.Round do liczb całkowitych.

- Wartość dla wilgotności powietrza otrzymujemy z api jako procent - wcześniej mieliśmy przygotowaną właściwość pod wartość - dostosuj właściwość (zmien nazwę) i konwerter, tak żeby zamieniał procent na wartość (dzielenie przez 100).

### 8. Utwórz plik konfiguracyjny

- Rzeczy takie jak urle i klucze do api dobrze jest wydzielić z kodu. Utwórz we wspólnym projekcie plik config.json i nadaj mu BuildAction EmbeddedResource.

- W pliku wpisz adres do api i klucz do api.

- Odczytaj plik w App.xaml.cs za pomocą metod GetManifestResourceNames i GetManifestResourceStream z klasy Assembly (wybierz bibliotekę, w której jest umieszczony plik konfiguracyjny) oraz jego zawartość za pomocą StreamReader i JObject.Parse - nie zapomnij zamknąć streamów.

- Odczytane dane z pliku konfiguracyjnego możesz zapisać jako właściwości statyczne w App.xaml.cs.

- Możesz również przenieść do pliku konfiguracyjnego adresy url do konkretnych endpointów - pomyśl jak możesz poradzić sobie z argumentami.

### 9. Dodaj loader.

- Podczas pobierania danych można dodać loader. Użyj kontrolki ActivityIndicator – zbinduj jej właściwości IsRunning i IsVisible do właściwości z view modelu.

- W view modelu stwórz właściwość typu bool, którą będziesz ustawiać/resetować gdy dane się wczytują/już wczytają.
  
  
## Przydatne materiały: 
- Api Airly: https://developer.airly.eu 
- HttpClient: https://docs.microsoft.com/pl-pl/dotnet/api/system.net.http.httpclient?view=xamarinandroid-7.1 
- HttpClient nagłówki: https://stackoverflow.com/a/38077835 
- Kody odpowiedzi http: https://pl.wikipedia.org/wiki/Kod_odpowiedzi_HTTP 
- UriBuilder: https://docs.microsoft.com/pl-pl/dotnet/api/system.uribuilder.query?view=xamarinandroid-7.1 
- HttpUtility.ParseQueryString: https://docs.microsoft.com/pl-pl/dotnet/api/system.web.httputility.parsequerystring?view=xamarinandroid-7.1 
- Jak używać nugeta: https://docs.microsoft.com/pl-pl/nuget/quickstart/install-and-use-a-package-in-visual-studio 
- Xamarin.Essentials Geolocation: https://docs.microsoft.com/pl-pl/xamarin/essentials/geolocation?tabs=android 
- ListView ItemsSource binding: https://stackoverflow.com/a/37727188 
- ListView – wbudowane komórki (TextCell): https://docs.microsoft.com/pl-pl/samples/xamarin/xamarin-forms-samples/userinterface-listview-builtincells/ 
- Komendy z parametrami: https://devblogs.microsoft.com/xamarin/simplifying-events-with-commanding/ 
- Build action: https://docs.microsoft.com/pl-pl/visualstudio/ide/build-actions?view=vs-2019 
- GetManifestResourceStream: https://stackoverflow.com/a/3314213 
- ActivityIndicator: https://docs.microsoft.com/pl-pl/xamarin/xamarin-forms/user-interface/activityindicator

## Dodatkowe materiały: 
- Wydajność ListView: https://docs.microsoft.com/pl-pl/xamarin/xamarin-forms/user-interface/listview/performance
