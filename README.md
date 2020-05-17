# Laboratorium 4 

## Zagadnienia 

- Lokalna baza danych – SQLite 

## Zadania 

### 1. Zainstaluj paczkę do bazy danych. 

- Zainstaluj do projektu wspólnego oraz androidowego paczkę nuget sqlite-net-pcl. 

### 2. Stwórz model bazy danych. 

- Paczka, której używamy nie wspiera relacji, musimy więc stworzyć je ręcznie. Nie możemy polegać na właściwościach o pożądanym typie, tylko na kluczach. 

- Nie możemy przechowywać także list, więc najlepiej przerobić je na właściwość typu string i zserializować np. do jsona. 

- Możemy użyć istniejących klas AirQualityIndex, AirQualityStandard i MeasurementValue. Dodajmy tylko do nich właściwość Id typu int z atrybutami PrimaryKey i AutoIncrement. 

- Dla klas Installation, MeasurementItem i Measurement stwórzmy nowe klasy, np. z dopiskiem Entity w nazwie.  

- W każdej musimy dodać Id. W InstallationEntity Id można dać jako string (dostajemy je z API). 

- W InstallationEntity Location i Address można dać jako string - będziemy je serializować do jsona.  

- W MeasurementItemEntity wszystkie właściwości, które są tablicami, zamieniamy na stringi. Będziemy serializować do nich listy Id z właściwości Values, Indexes i Standards. 

- W MeasurementEntity właściwości Current i Installation zamieniamy na ich Id (typ int). 

- Reszta właściwości może pozostać bez zmian. 

- Do wszystkich klas dodaj konstruktor bez parametrów. Później będziemy dodawać inne konstruktory, ale konstruktor bez parametrów też jest wymagany przez biblioteki do jsona i sqlita. 

### 3. Dodaj klasę pomocniczą do bazy danych. 

- Dodaj nową klasę DatabaseHelper. 

- Utwórz w nim połączenie do bazy SQLiteConnection i zapisz je w polu klasy. Żeby uniknąć problemów z wielowątkowością użyj flag SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex do otwarcia połączenia. 

- Stwórz tabele dla wszystkich niezbędnych klas: InstallationEntity, MeasurementEntity, MeasurementItemEntity, MeasurementValue, AirQualityIndex, AirQualityStandard. 

- Stwórz instancję klasy pomocniczej w App.xaml.cs, wywołaj metodę inicjaluzującą (to co robiliśmy w punktach wyżej) przed wczytaniem pierwszej strony i zapisz w statycznym polu - będziesz go później używać wszędzie, gdzie będziesz chciał skorzystać z bazy. 

### 4. Użyj klasy pomocniczej do zapisywania instalacji z API Airly. 

- Stwórz w klasie pomocniczej nową metodę do zapisu danych. 

- W parametrze przekazuj listę obiektów Installation. 

- Przemapuj te obiekty na InstallationEntity. Możesz stworzyć odpowiedni konstruktor w InstallationEntity. 

- W transakcji, wyczyść tabelę i zapisz nowe dane. 

- Wywołaj metodę po pobraniu instalacji z api. 

### 5. Użyj klasy pomocniczej do zapisywania pomiarów z API Airly. 

- Stwórz w klasie pomocniczej nową metodę do zapisu danych. 

- W parametrze przekazuj listę obiektów Measurement. 

- Wykonuj wszystkie operacje w transakcji. 

- Usuń wszystkie poprzednie dane ze wszystkich tabel, oprócz tabeli z instalacjami. 

- W pętli, dla każdego pomiaru: 

- Dodaj do bazy metodą InsertAll dane z właściwości Values, Indexes i Standards (dla obecnego pomiaru - właściwość Current). W InsertAll możesz przekazać w drugim parametrze, żeby nie używać transakcji – i tak już w jednej jesteśmy. Właściwości Id w dodanych obiektach ustawią się na nowe wartości. 

- Przemapuj właściwość Current na MeasurementItemEntity i dodaj do bazy. 

- Stwórz i wypełnij obiekt MeasurementEntity i dodaj go do bazy. 

- Wywołaj metodę po pobraniu instalacji z api. 

### 6. Użyj klasy pomocniczej do odczytywania instalacji. 

- W nowej metodzie pobierz z bazy wszystkie obiekty typu InstallationEntity. Przemapuj je na typ Installation (np. przez odpowiedni konstruktor) i zwróć. 

- Do właściwości Address i Location będziesz musiał zdeserializować jsona. 

### 7. Użyj klasy pomocniczej do odczytywania pomiarów. 

- W nowej metodzie pobierz z bazy wszystkie obiekty typu MeasurementEntity. 

- Dla każdego id instalacji pobierz z bazy InstallationEntity o takim kluczu i przemapuj na typ Installation. 

- Dla każdego id obecnego MeasurementItemEntity, pobierz obiekt o takim kluczu z bazy i stwórz z niego MeasurementItem. 

- Zdeserializuj wszystkie jsony na tablice intów. 

- Pobierz z bazy obiekty MeasurementValue, AirQualityIndex i AirQualityStandard z kluczami uzyskanymi w punkcie wyżej. 

- Stwórz z tych danych obiekt MeasurementItem 

### 8. Użyj metod do pobierania danych z bazy w kodzie. 

- Chcemy w pierwszej kolejności korzystać z danych w bazie. Jeśli będą one stare, wtedy chcemy pobierać dane z API Airly. Aktualność danych będziemy sprawdzać na podstawie właściwości Current.TillDateTime w pomiarze. Jeśli jest on starszy niż godzina, pobierzemy nowe dane. Jeśli nie, to wyświetlimy dane z bazy (nawet przy ponownym uruchomieniu aplikacji). 

- Zwróć uwagę, że czas w API Airly jest w strefie UTC. 

- W metodzie, gdzie pobierasz instalacje z API Airly (w HomeViewModel), użyj metody do odczytu pomiarów z bazy. Sprawdź czy są tam jakieś pomiary i czy właściwość TillDateTime ma odpowiednią wartość. Na tej postawie albo pobierz dane z API albo z bazy. 

- Zrób podobną rzecz w metodzie, gdzie pobierasz pomiary z API. 

- Właściwość CurrentDisplayValue  w pomiarze możesz mieć zapisane w bazie, ale niekoniecznie. Skoro i tak to obliczamy, to można tego pola nie trzymać w bazie, tylko dalej liczyć tutaj - niezależnie czy dla wyników z API, czy z bazy. 

- Logikę sprawdzającą, czy pobieramy rzeczy z API, czy wczytujemy z bazy, możesz wydzielić do oddzielnej metody, gdyż w obu przypadkach będzie taka sama. 

### 9. Zamknij połączenie do bazy. 

- W aplikacjach mobilnych dobrze jest używać jednego połączenia do bazy i zamykać je dopiero, gdy kończymy z niego korzystać, np. gdy zamykamy aplikację. 

- Zaimplementuj interfejs IDisposable w klasie pomocniczej do bazy danych. 

- W metodzie Dispose wywołuj Dispose na obiekcie połączenia SQLiteConnection i ustaw zmienną na null. 

- Wywołuj metodę Dispose klasy pomocniczej w zdarzeniu cyklu życia aplikacji OnSleep w App.xaml.cs. Ustaw także na null całe pole, w którym był trzymany obiekt klasy pomocniczej. 

- W 2 pozostałych metodach cyklu życia OnStart i OnResume, możesz dodać inicjalizację bazy danych, tak jak w punkcie 3.d. Dodaj sprawdzanie, czy pole, do którego zapisujesz obiekt klasy pomocniczej jest nullem i tylko wtedy inicjalizuj go na nowo. 

### 10. Przenieść operacje z API i bazą danych na inny wątek. 

- Operacje te mogą trochę trwać, dlatego dobrze jest wykonywać je w tle. Użyj do tego metody Task.Run. Najlepiej zrób to na jak najwyższym poziomie, np. w metodzie inicjalizującej dane w HomeViewModel. 

### 11. Dodaj odświeżanie listy wyników. 

- Dodaj mechanizm pull to refresh do list na HomePage.xaml. 

- Ustaw właściwość IsPullToRefreshEnabled na True. 

- Zbinduj RefreshCommand. W komendzie odświeżaj dane dokładnie tak jak przy wczytywaniu strony. Możesz do obecnych metod dodać parametr typu bool, którym będziesz wymuszać odświeżanie (zamiast pobierania danych z bazy), gdy wywołujesz te metody z RefreshCommand. 

- Zbinduj właściwość IsRefreshing. Ustawiaj ją na True na początku RefreshCommand i na False na końcu komendy. 

 

## Przydatne materiały: 

- SQLite ORM: https://github.com/praeclarum/sqlite-net  

- Dodatkowy poradnik do powyższego ORMa: https://docs.microsoft.com/pl-pl/xamarin/android/data-cloud/data-access/using-sqlite-orm  

- Task.Run: https://docs.microsoft.com/pl-pl/dotnet/api/system.threading.tasks.task.run?view=xamarinandroid-7.1  

- IDisposable: https://docs.microsoft.com/pl-pl/dotnet/api/system.idisposable?view=xamarinandroid-7.1  

- Pull to refresh: https://xamarinhelp.com/pull-to-refresh-listview/  

## Dodatkowe materiały: 

- Szyfrowanie bazy: https://github.com/praeclarum/sqlite-net#using-sqlcipher  

- SQLite.Net Extensions - umożliwia relacje: https://www.nuget.org/packages/SQLiteNetExtensions/  

- DB Browser for SQLite - przeglądanie zawartości bazy: https://sqlitebrowser.org

- Przeglądanie plików na androidzie (emulator) - do znalezienia pliku bazy danych (potrzebne Android Studio): https://developer.android.com/studio/debug/device-file-explorer

 

 
