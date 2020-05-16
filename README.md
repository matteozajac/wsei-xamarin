# Laboratorium 5

## Zagadnienia 

- Komponent mapy

## Zadania 

### 1. Pusty ekran przygotowany pod osadzenie mapy.
- Dodaj nowy widok content page o nazwie - MapPage
- Dodaj nowo dodaną stronę jako tab w pliku RootTabbedPage.xaml
- Dodaj ikonę mapy do AirMonitor.Android.Resources.drawable i nazwij ją np. baseline_map_black_24.png
- Podmień tytuł i ikonę w pliku RootTabbedPage.xaml
- Uruchom aplikację i sprawdź zcy masz nową kartę na dole ekranu.

### 2. Dodanie pakietu mapy
- Za pomocą menadżera NuGet dodaj pakiet: Xamarin.Forms.Maps
- W pliku AirMonitor.Android.MainActivity.cs poniżej wywołania funkcji `Xamarin.Forms.Forms.Init`; dodaj kod inicjalizacyjny z pakietu mapy - `Xamarin.FormsMaps.Init`;


### 3. Konfiguracja Google Maps
- Utwórz klucz API map Google wg instrukcji https://developers.google.com/maps/documentation/android-sdk/get-api-key	
- Dodaj do AirMonitor.Android.Properties/AndroidManifest.xml element:
`<application ...>`
 `   <meta-data android:name="com.google.android.geo.API_KEY" android:value="PASTE-YOUR-API-KEY-HERE" />`
    `<meta-data android:name="com.google.android.gms.version" android:value="@integer/google_play_services_version" />`
    `<uses-library android:name="org.apache.http.legacy" android:required="false" />    `
`</application>`
- Jeśli wcześniej tego nie robiłeś w AndroidManifest.xml dodaj pozwolenia dotyczące lokalzacji:
  `<uses-permission android:name="android.permission.ACCESS_COARSE_LOCATION" />`
  `<uses-permission android:name="android.permission.ACCESS_FINE_LOCATION" />`
- Andorid w wersji 6.0 kub wyższej wymaga żądanie pozwolenia o pozwolenia w czesie działania aplikacji. Dodaj kod odpowiedzialny za żądanie na podstawie poradnika: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/map/setup#request-runtime-location-permissions
- W pliku MapPage.xaml dodaj do ContentPage.Content komponent mapy -` <maps:Map x:Name="map" /> `oraz dołóż deklaracje namespace albo Alt+Enter i wybierz Xamarin.Forms.Map, albo dodaj do taga Content Page - `xmlns:maps="clr-namespace:Xamarin.Forms.Maps;assembly=Xamarin.Forms.Maps"`
- W tym momencie uruchom aplikację. Powinieneś zobaczyć nowo dodany widokmapę pod zakładką Map. To już dobry symptom jeśli działa.

### 4. Elementy na mapie
- W pliku MapPage.xaml w komponencie mapy dodaj tag `IsShowingUser="True"`. Teraz powinieneś w prawym górnym rogu mapy zobaczyć przycisk do centrowania na Twoją lokalizację.
- Teraz dodamy pinezki na mapę. Są dwie opcje, albo dodajemy pojedynczo, albo bindujemy podobnie jak w liście. Zastosujemy drugie podejście.
- Spójrz na kod który dodamy w MapPage.xaml:
	`	<maps:Map x:Name="map"
                  IsShowingUser="True"
                  ItemsSource="{Binding Locations}"
                  >
            <maps:Map.ItemTemplate>
                <DataTemplate>
                    <maps:Pin Position="{Binding Position}"
                              Address="{Binding Address}"
                              Label="{Binding Description}" 
                              />
                </DataTemplate>
            </maps:Map.ItemTemplate>
        </maps:Map>`
- Mamy parametr ItemsSource. Jak się domyślasz jeszcze nie istnieje, ale zaraz go dodasz. Wewnątrz mamy template, któy obsługuje wyświetlanie już samej pinezki. Ma ona parametry takie jak pozycja, adres i opis.
- Teraz jak kwestię widoku mamy ograną pobawmy się modelem danych. W tym celu w pakiecie AirMonitor.Models utwórz klasę MapLocation. Powinnaa ona zawierać pola jak: Address (typu string), Description (typu string) oraz Position(typu Xamarin.Forms.Maps.Position). Pamiętaj, aby klasa była widoczna spoza pakietu. W tym celu dodaj modyfikator widoczności public przed nazwą klasy.
- Teraz z modelu przechodzimy do viewmodelu. Jak dobrze pamiętasz z laboratorium 3 o listach w ViewModelu musimy utworzyć listę Locations która zawiera elementy nowo dodanego MapLocation. Ale słusznie możesz się zastanawiać w jakim view modelu to zrobić. Możemy utworzyć nowy, ale kod do pobierania danych już mamy w HomeViewModel. I to właśnie w nim dodaj tą listę Locations na wzór listy Items. Masz rację, tutaj łamiemy SOLID, możemy zastosować dziedziczenie, wstrzykiwanie zależności. Jednak na cele dzisiejszych ćwiczeń wystarczy jak zrobisz w taki sposób.
- Mając już pole public List<MapLocation> Locations możemy przystąpić do uzupełnenia tego w momencie kiedy przychodzą do aplikacji dane z API czy bazy danych.
Poniżej przypisania: Items = new List<Measurement>(data); 
Dodaj kod uzupełniający Locations.
`Locations = Items.Select(i => new MapLocation { 
	Address = i.Installation.Address.Description,
	Description = "CAQI: " + i.CurrentDisplayValue,
	Position = new Position(i.Installation.Location.Latitude, i.Installation.Location.Longitude)            
}).ToList();`
- Jesteś na dobrej drodze do zobaczenia danych na mapie. Teraz wystarczy, że w pliku MapPage.xaml.cs zbindujesz HomeViewModel. Jeśli masz problem zobacz jak zostało to zrobione w klasie HomePage.xaml.cs.
- Voila! Uruchom program i zobacz pinezki na mapię wokół Twojej lokalizacji. Klinkij na nią i zobaczysz InfoWindow z podstawowymi parametrami.

### 5. Przejście na szczegóły
- Ostatnią częścią dzisiejszego laboratorium będzie przejście na szczegóły z ekranu mapy.
- Dodaj parametr InfoWindowClicked w widoku pinezki
`	<maps:Pin Position="{Binding Position}"
	              Address="{Binding Address}"
	              Label="{Binding Description}" 
	              InfoWindowClicked="InfoWindow_ItemTapped"
	              />`
- Teraz stwórz metodę `InfoWindow_ItemTapped` w pliku MapPage.xaml.cs. Jej sygnatura powinna przypominać tą, która jest w pliku HomePage.xaml.cs i odpowiada za kliknięcie na liście.
- Mam złą informację. Nie możemy wywołąć tej samej komendy jak w przypadku kliknięcia na liście. Tam mieliśmy dostęp do obiektu Measurment. W momencie kliknięcia na mapę dostajemy jako event obiekt typu Pin. Nie załamujemy się i alternatywnym rozwiązaniem jest stworzenie nowej, własnej komendy w HomeViewModel np. InfoWindowClickedCommand na wzór GoToDetailsCommand.
- Co prawda nie mamy dostępu do obiektu measurment, ale mam dostęp do wszystkich pól z klasy Pin. Mamy między innymi dostęp do pola adres. Więc właśnie adres przekażmy jako string to ViewModelu
`_viewModel.InfoWindowClickedCommand.Execute((sender as Xamarin.Forms.Maps.Pin).Address);`
- A w ViewModelu wystarczy, że znajdziemy MEasurment z listy Items o danym adresie. Można to zrobić np. w ten sposób:
          ` Measurement item = Items.First<Measurement>(i => i.Installation.Address.Description.Equals(address));`
- Mając measurment możemy już wywołać funkcję, która otwiera nam widok szczegółowy.
- Uruchom, sprawdź czy działa, kliknij w pinezkę, okienko na mapie i zobacz ekran szczegółów.


### Przydatne materiały:
- https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/map/setup
- https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/map/map
- https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/map/pins

### Dodatkowe materiały:
- Jeśli chcesz zmodyfikować kolor pinezki, aby odpowiadał stanowi powietrze spróuj zrobić CustomRenderer https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/custom-renderer/map/customized-pin
 
