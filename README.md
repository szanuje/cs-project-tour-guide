# Tour Guide Project
## Description
Aplikacja wyświetla użytkownikowi destynacje turystyczne np. Karaiby, Hawaje itp. Nasz tour guide pozwala przejrzeć interesujące destynacje w poszukiwaniu ciekawych miejsc. Nastepnie miejsca mogą byc dodane przez użytkownika do zakładki 'My Trips". Jednocześnie użytkownik może przejrzeć hotele znajdujące się w poblizu interesujących go miejsc. Widok hoteli znajduje się w zakładce 'Hotels'.

Aplikacja umożliwia także rejestrację i logowanie użytkownika. Pozwala to użytkownikowi zapisać wybrane miejsca podróży, bez utraty planu po wyłączeniu aplikacji.

## Tools

Aplikację stworzono przy pomocy Visual Studio 2022 oraz:
- Frameworków:
    - Microsoft.NETCore.App (6.0.1)
    - Microsoft.WindowsDesktop.App.WPF (6.0.0)
- Pakietów:
    - Microsoft.EntityFrameworkCore (6.0.1)
    - Microsoft.EntityFrameworkCore.InMemory (6.0.1)
    - Microsoft.EntityFrameworkCore.Sqlite (6.0.1)
    - Microsoft.EntityFrameworkCore.Tools (6.0.1)
    - Microsoft.EntityFrameworkCore.Design (6.0.1)

## How To Run
- Visual Studio:
    - uruchomić solucję TourGuide.UI
- Release:
    - uruchomić plik wykonawczy `\TourGuide\TourGuide.UI\bin\Release\net6.0-windows\TourGuide.UI.exe`

## How to Use
Użytkowanie aplikacji wymaga poprawnego zalogowania. Nowe konto można stworzyć klikając w niebieski tekst "Create a new profile" na ekranie logowania.
W ramach testu, udostępnione jest również konto admina:

- Username: admin
- Password: admin

Pozwala ono na przeglądniecie destynacji, posiada uprawnienia do dodawania oraz usuwania nowych destynacji, miejsc i hoteli. Przykładowy scenariusz:
- Logujemy się na konto admin
- Klikamy w przycisk "Manage" w prawym górnym rogu, obok wyświetlonego imienia i nazwiska usera
- Dodajemy destynacje w panelu po prawej
- Wybieramy destynacje i przechodzimy do miejsc przyciskiem "Places"
- Wybieramy miejsce i usuwamy je z destynacji przyciskiem "Remove place"

## Documentation
W ramach dokumentacji opisano wszystkie używane metody oraz parametry w postaci znaczników XML w kodzie źródłowym programu.

Pełna dokumentacja dostępna jest również w formacie HTML, po lokalnym uruchomieniu pliku:
[https://github.com/szanuje/cs-project-tour-guide/blob/master/TourGuide/Help/index.html](https://github.com/szanuje/cs-project-tour-guide/blob/master/TourGuide/Help/index.html)

![docs_preview](./images/docs_preview.png)

## Authors
- Konrad Ulman
- Paweł Jelonek
- Maksymilian Pleśniak

## Database
![login](./images/db.png)

## Screenshots
![login](./images/login.png)
![register](./images/register.png)
