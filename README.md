# Laboratorium 1
## Zagadnienia
•	Warunki zaliczenia
•	Wprowadzenie do Xamarin.Forms
•	Stworzenie pierwszego projektu i omówienie struktury
•	Stworzenie strony z podstawowymi kontrolkami
•	Podstawy gita i GitHuba

## Zadania
### 1.	Stworzenie pierwszego projektu Xamarin.Forms
a.	W Visual Studio 2019 kliknij „Create a new project” i wyszukaj “Xamarin.Forms”
b.	Wybierz “Mobile App (Xamarin.Forms)” I kliknij Next
c.	Wpisz nazwę projektu I kliknij Create
d.	W kolejnym okienku wybierz szablon „Blank” i zaznacz platformy Android oraz iOS. Kliknij Ok.
e.	Wybierz projekt Androida jako startowy i uruchom go w emulatorze.
### 2.	Przejrzyj nowy projekt i zapoznaj się z jego elementami
a.	Projekt „AirMonitor”:
i.	App.xaml – plik z zasobami globalnymi na poziomie aplikacji
ii.	App.xaml.cs – punkt wejściowy aplikacji Xamarin.Forms, ustawiamy mu stronę startową, możemy też zareagować na zdarzenia cyklu życia aplikacji
iii.	MainPage.xaml – Przykładowa główna strona aplikacji (plik definiowania wyglądu)
iv.	MainPage.xaml.cs - Przykładowa główna strona aplikacji (plik z logiką strony)
b.	Projekt „AirMonitor.Android”:
i.	Properties/AndroidManifest.xml – podstawowy plik konfiguracyjny aplikacji Android, dostępny również w formie graficznej z poziomu właściwości projektu
ii.	Assets – folder przeznaczony do zasobów i mediów, np. pliki dźwiękowe, czy tekstowe.
iii.	Resources – folder, w którym umieszczamy większość zasobów aplikacji, jak ikony, teksty, style, wygląd stron, itd.
iv.	MainActivity.cs – Aktywność, punkt wejściowy aplikacji Android
c.	Projekt „AirMonitor.iOS”:
i.	Asset Catalogs – miejsce, gdzie dodajemy zasoby aplikacji, jak np. ikony
ii.	Resources – folder na zasoby, które nie pasują do Asset Catalog, jak launch screen, czcionki, czy pliki dźwiękowe lub konfiguracyjne
iii.	Resources/LaunchSreen.storyboard – launch screen/splash screen aplikacji, pierwszy ekran, który użytkownik widzi, po kliknięciu w ikonę aplikacji
iv.	AppDelegate.cs – klasa przetwarzająca zdarzenia systemowe
v.	Entitlements.plist – plik, w którym definiujemy dodatkowe usługi i funkcjonalności aplikacji, np. korzystanie z iCloud, powiadomień push, HomeKit
vi.	Info.plist – plik z ustawieniami aplikacji, np. wersja, nazwa
vii.	Main.cs – punkt wejściowy aplikacji iOS
### 3.	Zapoznaj się z narzędziami kontroli wersji w Visual Studio.
a.	Dodaj projekt do kontroli wersji (git):
i.	File -> Add to Source Control
b.	Dostosuj opcje gita:
i.	W oknie Team Explorer wybierz Settings -> Repository Settings i wprowadź swoje dane (imię i email), które będą powiązane z commitami.
c.	Pierwszy commit:
i.	Zrób pierwszą zmianę w kodzie (np. Zmień tekst w MainPage.xml)
ii.	W Team Explorer wybierz Changes i przejrzyj zmiany.
iii.	Zmiany mogą być w dwóch stanach przed commitem: unstaged i staged. Zmiany w stanie unstaged nie zostaną zacommitowane, musimy więc przenieść je to stanu staged. Zrobimy to plusem na prawo od napisu Changes lub w menu PPM.
iv.	Każdy commit musi mieć wiadomość. Wpisujemy wiadomość w polu na górze.
v.	Klikamy Commit Staged.
d.	Pamiętajmy, żeby robić commity regularnie, np. po każdej większej zmianie, czy skoczonej funkcjonalności (lub jeśli jest ona duża to również w trakcie).
e.	Pushowanie zmian:
i.	Commity są u nas lokalnie na komputerze. Musimy wypushować zmiany na serwer, żeby inni mogli je pobierać.
ii.	Załóż konto na GitHubie: https://github.com
iii.	Stwórz tam repozytorium (publiczne)
iv.	Skopiuj adres repozytorium w formacie: https://github.com/[nazwa_uzytkownika]/[nazwa_repozytorium].git)
v.	W Visual Studio w Team Explorer -> Settings -> Repository Settings -> Remotes dodaj adres z nazwą “origin” (bez cudzysłowów)
vi.	W Team Explorer wybierz Sync i w sekcji Outgoing commits kliknij Push
vii.	Będziesz musiał podać login i hasło do GitHuba. Po tym kroku twoje commity będą dostępne z portalu.
f.	Projekt z zajęć i własny powinny być na bieżąco aktualizowane na GitHubie.
### 4.	Stworzenie strony szczegółów z podstawowymi kontrolkami
a.	Wygląd strony jak na zrzucie poniżej
b.	Użyte kontrolki: ContentPage, ScrollView, StackLayout, Grid, Frame, Label, Span, Image, BoxView, Slider
c.	Podpowiedzi:
i.	Przetestuj aplikację na urządzeniu z mały ekranem/rozdzielczością. Czy zawartość można przewinąć tak, żeby zobaczyć to co nie mieści się na ekranie?
ii.	Całość ułożona jest od góry do dołu w liniach z odstępami. Który layout ma takie zachowanie?
iii.	Jeden z layoutów ma właściwość do zaokrąglenia rogów - możesz go użyć do widoku z zielonym kółkiem.
iv.	Label może wyświetlać sforamtowany tekst (np. część pogrubiona lub z innym rozmiarem czcionki). Użyj tej właściwości zamiast tworzyć kilka Labeli obok siebie.
v.	W Sliderze dla ciśnienia będziesz musiał ustawić wartość minimalną np. na 900 i maksymalną np. na 1100. Czy kolejność tych właściwości ma znaczenie?
vi.	Widoki dla PM 2,5 oraz PM 10 mają równą szerokość i pionową linię między nimi. Jakiego layoutu użyjesz? Musisz zdefiniować 3 kolumny.
vii.	Ikonka “?” po prawej stronie to przycisk - niech po naciśnięciu wyświetla popup z przykładowym wyjaśnieniem czym jest CAQI. Możesz tu użyć wbudowanej metody DisplayAlert.
viii.	Podwidoki dla PM 2,5, PM 10 i kolejnych wyglądają tak samo - mają tytuł i pewną zawartość - stwórz dla nich nową kontrolkę (w oddzielnym pliku) i zaembedu w widoku głównym. W kontrolce użyj BindableProperty w dwóch właściwościach - jedna do zbindowania tytułu, druga do zbindowania dowolnej zawartości (możesz to zostawić na koniec).
