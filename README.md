# Laboratorium 1
## Zagadnienia
- Warunki zaliczenia
-	Wprowadzenie do Xamarin.Forms
-	Stworzenie pierwszego projektu i omówienie struktury
-	Stworzenie strony z podstawowymi kontrolkami
-	Podstawy gita i GitHuba

## Zadania
### 1.	Stworzenie pierwszego projektu Xamarin.Forms
- W Visual Studio 2019 kliknij „Create a new project” i wyszukaj “Xamarin.Forms”
- Wybierz “Mobile App (Xamarin.Forms)” I kliknij Next
- Wpisz nazwę projektu I kliknij Create
- W kolejnym okienku wybierz szablon „Blank” i zaznacz platformy Android oraz iOS. Kliknij Ok.
- Wybierz projekt Androida jako startowy i uruchom go w emulatorze.
### 2.	Przejrzyj nowy projekt i zapoznaj się z jego elementami
#### Projekt „AirMonitor”:
- App.xaml – plik z zasobami globalnymi na poziomie aplikacji
-	App.xaml.cs – punkt wejściowy aplikacji Xamarin.Forms, ustawiamy mu stronę startową, możemy też zareagować na zdarzenia cyklu życia aplikacji
- MainPage.xaml – Przykładowa główna strona aplikacji (plik definiowania wyglądu)
- MainPage.xaml.cs - Przykładowa główna strona aplikacji (plik z logiką strony)
#### Projekt „AirMonitor.Android”:
- Properties/AndroidManifest.xml – podstawowy plik konfiguracyjny aplikacji Android, dostępny również w formie graficznej z poziomu właściwości projektu
- Assets – folder przeznaczony do zasobów i mediów, np. pliki dźwiękowe, czy tekstowe.
-	Resources – folder, w którym umieszczamy większość zasobów aplikacji, jak ikony, teksty, style, wygląd stron, itd.
-	MainActivity.cs – Aktywność, punkt wejściowy aplikacji Android
#### Projekt „AirMonitor.iOS”:
-	Asset Catalogs – miejsce, gdzie dodajemy zasoby aplikacji, jak np. ikony
-	Resources – folder na zasoby, które nie pasują do Asset Catalog, jak launch screen, czcionki, czy pliki dźwiękowe lub konfiguracyjne
-	Resources/LaunchSreen.storyboard – launch screen/splash screen aplikacji, pierwszy ekran, który użytkownik widzi, po kliknięciu w ikonę aplikacji
-	AppDelegate.cs – klasa przetwarzająca zdarzenia systemowe
- Entitlements.plist – plik, w którym definiujemy dodatkowe usługi i funkcjonalności aplikacji, np. korzystanie z iCloud, powiadomień push, HomeKit
-	Info.plist – plik z ustawieniami aplikacji, np. wersja, nazwa
-	Main.cs – punkt wejściowy aplikacji iOS
### 3.	Zapoznaj się z narzędziami kontroli wersji w Visual Studio.
##### Dodaj projekt do kontroli wersji (git):
- File -> Add to Source Control
##### Dostosuj opcje gita:
- W oknie Team Explorer wybierz Settings -> Repository Settings i wprowadź swoje dane (imię i email), które będą powiązane z commitami.
##### Pierwszy commit:
- Zrób pierwszą zmianę w kodzie (np. Zmień tekst w MainPage.xml)
- W Team Explorer wybierz Changes i przejrzyj zmiany.
-	Zmiany mogą być w dwóch stanach przed commitem: unstaged i staged. Zmiany w stanie unstaged nie zostaną zacommitowane, musimy więc przenieść je to stanu staged. Zrobimy to plusem na prawo od napisu Changes lub w menu PPM.
- Każdy commit musi mieć wiadomość. Wpisujemy wiadomość w polu na górze.
- Klikamy Commit Staged.
##### Pamiętajmy, żeby robić commity regularnie, np. po każdej większej zmianie, czy skoczonej funkcjonalności (lub jeśli jest ona duża to również w trakcie).
##### Pushowanie zmian:
- Commity są u nas lokalnie na komputerze. Musimy wypushować zmiany na serwer, żeby inni mogli je pobierać.
- Załóż konto na GitHubie: https://github.com
- Stwórz tam repozytorium (publiczne)
- Skopiuj adres repozytorium w formacie: https://github.com/[nazwa_uzytkownika]/[nazwa_repozytorium].git)
-	W Visual Studio w Team Explorer -> Settings -> Repository Settings -> Remotes dodaj adres z nazwą “origin” (bez cudzysłowów)
-	W Team Explorer wybierz Sync i w sekcji Outgoing commits kliknij Push
-	Będziesz musiał podać login i hasło do GitHuba. Po tym kroku twoje commity będą dostępne z portalu.
##### Projekt z zajęć i własny powinny być na bieżąco aktualizowane na GitHubie.
### 4.	Stworzenie strony szczegółów z podstawowymi kontrolkami
##### Wygląd strony jak na zrzucie poniżej
##### Użyte kontrolki: ContentPage, ScrollView, StackLayout, Grid, Frame, Label, Span, Image, BoxView, Slider
##### Podpowiedzi:
- Przetestuj aplikację na urządzeniu z mały ekranem/rozdzielczością. Czy zawartość można przewinąć tak, żeby zobaczyć to co nie mieści się na ekranie?
- Całość ułożona jest od góry do dołu w liniach z odstępami. Który layout ma takie zachowanie?
- Jeden z layoutów ma właściwość do zaokrąglenia rogów - możesz go użyć do widoku z zielonym kółkiem.
- Label może wyświetlać sforamtowany tekst (np. część pogrubiona lub z innym rozmiarem czcionki). Użyj tej właściwości zamiast tworzyć kilka Labeli obok siebie.
- W Sliderze dla ciśnienia będziesz musiał ustawić wartość minimalną np. na 900 i maksymalną np. na 1100. Czy kolejność tych właściwości ma znaczenie?
-	Widoki dla PM 2,5 oraz PM 10 mają równą szerokość i pionową linię między nimi. Jakiego layoutu użyjesz? Musisz zdefiniować 3 kolumny.
-	Ikonka “?” po prawej stronie to przycisk - niech po naciśnięciu wyświetla popup z przykładowym wyjaśnieniem czym jest CAQI. Możesz tu użyć wbudowanej metody DisplayAlert.
-	Podwidoki dla PM 2,5, PM 10 i kolejnych wyglądają tak samo - mają tytuł i pewną zawartość - stwórz dla nich nową kontrolkę (w oddzielnym pliku) i zaembedu w widoku głównym. W kontrolce użyj BindableProperty w dwóch właściwościach - jedna do zbindowania tytułu, druga do zbindowania dowolnej zawartości (możesz to zostawić na koniec).

### Efekt końcowy: 
<img src="https://github.com/matteozajac/wsei-xamarin/blob/lab1/lab1_screen.png" width="250">

## Przydatne materiały: 
- Kontrolki (strony, layouty, widoki): https://docs.microsoft.com/pl-pl/xamarin/xamarin-forms/user-interface/controls/ 
- Formatowanie tekstu w Label: https://docs.microsoft.com/pl-pl/xamarin/xamarin-forms/user-interface/text/label#formatted-text 
- Własne kontrolki: https://docs.microsoft.com/pl-pl/xamarin/xamarin-forms/user-interface/layouts/contentview 
- Podstawy XAML: https://docs.microsoft.com/pl-pl/xamarin/xamarin-forms/xaml/xaml-basics/

## Dodatkowe materiały: 
- Cykl życia aplikacji Xamarin.Forms: https://docs.microsoft.com/pl-pl/xamarin/xamarin-forms/app-fundamentals/app-lifecycle 
- Android Resources: https://docs.microsoft.com/pl-pl/xamarin/android/app-fundamentals/resources-in-android/?tabs=windows 
- Android Manifest w Xamarinie: https://docs.microsoft.com/pl-pl/xamarin/android/platform/android-manifest

## Instalacja Xamarina
- Instrukcja instalacji: https://docs.microsoft.com/pl-pl/xamarin/get-started/installation/windows
- Jeśli mamy już zainstalowane Android Studio, to Visual Studio najprawdopodobniej zainstaluje SDK Androida w innym miejscu, a więc emulatory z Android Studio nie będą widoczne w Visualu - można taki emulator włączyć z linii komend lub z Android Studio i wtedy będzie dostępny z Visuala
- Dodawanie nowych emulatorów Androida: https://docs.microsoft.com/pl-pl/xamarin/android/get-started/installation/android-emulator/device-manager?tabs=windows&pivots=windows
- Przyspieszenie sprzętowe dla emulatorów (możesz to sprawdzić, jeśli emulator działa bardzo wolno): https://docs.microsoft.com/pl-pl/xamarin/android/get-started/installation/android-emulator/hardware-acceleration?pivots=windows
- Popularne problemy z emulatorami: https://docs.microsoft.com/pl-pl/xamarin/android/get-started/installation/android-emulator/troubleshooting?pivots=windows
- Odpalanie aplikacji Androida na urządzeniu: https://docs.microsoft.com/pl-pl/xamarin/android/get-started/installation/set-up-device-for-development
