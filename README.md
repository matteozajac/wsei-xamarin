# Laboratorium 2  
  
## Zagadnienia  
  
- Style XAML  
  
- Nawigacja  
  
- MVVM  
  
## Zadania  
  
### 1. Wydziel style z kontrolek do Resource’ów  
  
- W wydzielonej kontrolce z poprzednich ćwiczeń wydziel style Label w tym samym pliku do sekcji Resources stosując style niejawne.  
  
- W MainPage.xaml wydziel wszystkie style do App.xaml jako style jawne  
  
- Zwróć uwagę, że Label i Span mimo podobnych właściwości potrzebują oddzielnych styli.  
  
- Wydziel kolory jako oddzielne zasoby (tag Color) w App.xaml  
  
-  Aby utrzymać porządek przenieś style z App.xaml do oddzielnych plików: kolory do Colors.xaml, a pozostałe style do Styles.xaml. Następnie dołącz te pliki do App.xaml za pomocą MergedDictionaries.  
  
### 2. Stwórz nawigację hierarchiczną  
  
- Zmień nazwę strony MainPage na DetailsPage – zmień nazwę pliku, nazwę klasy i konstruktora w DetailsPage.xaml.cs oraz nazwa klasy w DetailsPage.xaml w atrybucie x:Class.  
  
- Dodaj nową stronę z szablonu typu ContentPage (pliki xaml i xaml.cs) i nazwij ją HomePage  
  
- Na HomePage dodaj kontrolkę Button. W podpiętej akcji wywołaj nawigację Push do DetailsPage używając właściwości Navigation.  
  
- W App.xaml.cs zamień MainPage na HomePage. Opakuj HomePage w NavigationPage.  
  
### 3. Stwórz nawigację z zakładkami  
  
- Dodaj nową stronę typu TabbedPage  
  
- Ustaw ją jako stronę główną w App.xaml.cs  
  
- Dodaj nową stronę typu ContentPage (xaml) i nazwij ją SettingsPage  
  
- Dodaj HomePage i SettinsPage jako zakładki do TabbedPage (w xaml) i opakuj je w NavigationPage. Dodaj do nich tytuł i ikonki.  
  
- Na Androidzie TabbedPage pokazuje się domyślnie na górze strony. Przenieś zakładki na dół dzięki właściwości TabbedPage.ToolbarPlacement.  
  
### 4. Zastosuj wzorzec MVVM dla HomePage  
  
- Stwórz folder ViewModels, w nim plik HomeViewModel.cs, a w nim klasę HomeViewModel.  
  
- W HomeViewModel dodaj konstruktor przyjmujący parametr typu Xamarin.Forms.INavigation - zapisz go w polu klasy.  
  
- Stwórz komendę ICommand do nawigacji do strony szczegółów. W niej użyj pola INavigation i metody PushAsync – tak jak do tej pory robiliśmy to w HomePage.xaml.cs.  
  
- W HomePage.xaml.cs, w konstruktorze przypisz do właściwości BindingContext nową instancję HomeViewModel. Usu również metodę obsługującą kliknięcie przycisku.  
  
- W HomePage.xaml usuń z przycisku atrybut Clicked i zbinduj do atrybutu Command pole z view modelu.  
  
### 5. Zastosuj wzorzec MVVM dla DetailsPage  
  
- Stwórz DetailsViewModel i połącz z DetailsPage - możesz to tym razem zrobić w xaml.  
  
- Zaimplementuj właściwość typu int (razem z polem) dla wartości CAQI.  
  
- Zaimplementuj w view modelu interfejs INotifyPropertyChanged, żeby mieć możliwość informować widok o zmianach w view modelu.  
  
- Wywołaj powiadomienie o zmianie w setterze powyższej właściwości.  
  
- Zbinduj właściwość do atrybutu Text kontrolki Label w DetailsPage.xaml  
  
- Potwórz powyższe (właściwość + bindowanie) dla wszystkich dynamicznych wartości na tej stronie.  
  
- Przy wilgotności powietrza mamy wartość na sliderze oraz wartość procentową. Zaimplentuj tylko jedną właściwość, np. Dla wartości na sliderze i dodaj konwerter (IValueConverter), który będzie zmieniać tę wartość na procent. Zaimportuj konwerter na stronie xaml i użyj go w bindowaniu.  
  
- Niektóre kontrolki Label mają pewne (proste) formatowanie, jak “(135%)”. Zbinduj tu samą wartość, a format (tutaj “({numer}%)”) ustaw za pomocą składni StringFormat.  
  
- StringFormat możesz również łączyć z konwerterem.  
  
##  Przydatne materiały:  
- Style niejawne: https://docs.microsoft.com/pl-pl/xamarin/xamarin-forms/user-interface/styles/xaml/implicit  
- Style jawne: https://docs.microsoft.com/pl-pl/xamarin/xamarin-forms/user-interface/styles/xaml/explicit  
- Przykłady zasobów (Style, Color): https://docs.microsoft.com/pl-pl/xamarin/xamarin-forms/xaml/resource-dictionaries  
- MergedDictionaries: https://docs.microsoft.com/pl-pl/xamarin/xamarin-forms/xaml/resource-dictionaries#merged-resource-dictionaries  
- Nawigacja hierarchiczna: https://docs.microsoft.com/pl-pl/xamarin/xamarin-forms/app-fundamentals/navigation/hierarchical  
- Nawigacja z zakładkami: https://docs.microsoft.com/pl-pl/xamarin/xamarin-forms/app-fundamentals/navigation/tabbed-page  
- Zakładki na dole: https://docs.microsoft.com/pl-pl/xamarin/xamarin-forms/platform/android/tabbedpage-toolbar-placement-color  
- MVVM, bindowanie, komendy: https://docs.microsoft.com/pl-pl/xamarin/xamarin-forms/enterprise-application-patterns/mvvm  
- Powiadamianie widoku o zmianie w view modelu, INotifyPropertyChanged: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/xaml/xaml-basics/data-bindings-to-mvvm   
- Konwertery, IValueConverter: https://docs.microsoft.com/pl-pl/xamarin/xamarin-forms/app-fundamentals/data-binding/converters   
- StringFormat w bindowaniu: https://docs.microsoft.com/pl-pl/xamarin/xamarin-forms/app-fundamentals/data-binding/string-formatting  
  
##  Dodatkowe materiały:  
- Style XAML: https://docs.microsoft.com/pl-pl/xamarin/xamarin-forms/user-interface/styles/xaml/index  
- Style CSS: https://docs.microsoft.com/pl-pl/xamarin/xamarin-forms/user-interface/styles/css/index  
- Typy nawigacji: https://docs.microsoft.com/pl-pl/xamarin/xamarin-forms/app-fundamentals/navigation/