# Dokumentacja Techniczna - Wypożyczalnia Samochodów w ASP.NET

## Spis Treści
1. [Wprowadzenie](#wprowadzenie)
2. [Technologie](#technologie)
3. [Wymagania](#wymagania)
4. [Konfiguracja Projektu](#konfiguracja-projektu)
5. [Uruchomienie](#uruchomienie)
6. [Struktura Katalogów](#struktura-katalogów)
7. [Opis Plików](#opis-plików)
8. [Endpointy API](#endpointy-api)
9. [Modele Danych](#modele-danych)
10. [Widoki](#widoki)
11. [Uprawnienia](#uprawnienia)

## Wprowadzenie

Projekt "Wypożyczalnia Samochodów" to aplikacja webowa stworzona przy użyciu technologii ASP.NET, umożliwiająca użytkownikom wynajem samochodów online. Aplikacja oferuje funkcjonalności takie jak przeglądanie dostępnych samochodów, składanie formularzy wynajmu oraz zarządzanie wypożyczeniami.

## Technologie

Projekt wykorzystuje następujące technologie:
- ASP.NET Core
- Entity Framework Core
- SQL Server LocalDB
- Bootstrap (do stylizacji widoków)
- Identity (do zarządzania użytkownikami i autoryzacją)

## Wymagania

Przed rozpoczęciem pracy z projektem upewnij się, że masz zainstalowane:
- .NET SDK 8.0
- SQL Server LocalDB

## Konfiguracja Projektu

### Baza Danych

Sprawdź, czy SQL Server LocalDB jest zainstalowany:
```bash
sqllocaldb info
```
Jeśli LocalDB nie jest zainstalowany, pobierz i zainstaluj go z witryny Microsoft SQL Server Express. Podczas instalacji upewnij się, że opcja LocalDB jest zaznaczona.

### Aktualizacja Connection String

Jeżeli jest to konieczne, zaktualizuj Connection String w pliku `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=NazwaBazyDanych;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

## Uruchomienie

Aby uruchomić projekt, wykonaj następujące kroki w terminalu:
```bash
cd path/to/your/project
dotnet restore
dotnet build
dotnet ef database update
dotnet run
```

## Struktura Katalogów

Projekt posiada następującą strukturę katalogów:
- `Controllers` - Zawiera kontrolery MVC.
- `Models` - Zawiera modele danych.
- `Views` - Zawiera widoki Razor.
- `Data` - Zawiera kontekst bazy danych i migracje.
- `wwwroot` - Zawiera pliki statyczne (CSS, JS, obrazy).

## Opis Plików

### Kontrolery

- `HomeController` - Główne strony aplikacji (index, privacy, about, contact).
- `CarsController` - Zarządzanie samochodami.
- `RentalFormsController` - Zarządzanie formularzami wynajmu.

### Modele

- `Car` - Model reprezentujący samochód.
- `RentalForm` - Model reprezentujący formularz wynajmu.
- `ErrorViewModel` - Model błędu.

### Widoki

- `Home/Index` - Strona główna aplikacji, gdzie użytkownicy mogą zobaczyć podstawowe informacje i rozpocząć przeglądanie oferty wynajmu samochodów.
- `Home/About` - Strona informacyjna o firmie, zawierająca szczegóły na temat misji, wizji oraz partnerów biznesowych.
- `Home/Contact` - Strona kontaktowa zawierająca dane kontaktowe firmy oraz formularz umożliwiający użytkownikom wysłanie wiadomości.
- `Home/Privacy` - Strona z polityką prywatności, informująca użytkowników o sposobach zbierania i przetwarzania danych osobowych.
- `Cars/Index` - Widok listy dostępnych samochodów.
- `RentalForms/Index` - Widok listy formularzy wynajmu.
- `RentalForms/Details` - Widok szczegółów formularza wynajmu.
- `RentalForms/Edit` - Widok edycji formularza wynajmu.

## Endpointy API

### Home

- `GET /` - Strona główna.
- `GET /Privacy` - Polityka prywatności.
- `GET /About` - Strona "O nas".
- `GET /Contact` - Strona kontaktowa.

### Cars

- `GET /Cars` - Lista dostępnych samochodów.

### RentalForms

- `GET /RentalForms` - Lista wszystkich formularzy wynajmu (dostępne tylko dla admina).
- `GET /RentalForms/Details/{id}` - Szczegóły formularza wynajmu.
- `POST /RentalForms/SubmitForm` - Wysłanie formularza wynajmu.
- `POST /RentalForms/Delete/{id}` - Usunięcie formularza wynajmu (dostępne tylko dla admina).
- `GET /RentalForms/Edit/{id}` - Formularz edycji wynajmu (dostępne tylko dla admina).
- `POST /RentalForms/Edit` - Zapisanie zmian w formularzu wynajmu (dostępne tylko dla admina).

## Modele Danych

### Car

| Nazwa       | Typ         | Opis                       |
|-------------|-------------|----------------------------|
| Id          | int         | Unikalny identyfikator     |
| Name        | string      | Nazwa samochodu            |
| ImageUrl    | string      | URL obrazka samochodu      |
| PricePerDay | decimal     | Cena za dzień wynajmu      |

### RentalForm

| Nazwa        | Typ         | Opis                       |
|--------------|-------------|----------------------------|
| Id           | int         | Unikalny identyfikator     |
| Name         | string      | Imię i nazwisko wynajmującego |
| Email        | string      | Adres email wynajmującego  |
| Phone        | string      | Numer telefonu wynajmującego |
| PickupDate   | DateTime    | Data odbioru               |
| LeavingDate  | DateTime    | Data zwrotu                |
| Consent      | bool        | Zgoda na warunki wynajmu   |
| CarId        | int         | Id samochodu               |
| UserId       | string      | Id użytkownika             |

## Widoki

### Cars/Index

- Wyświetla listę dostępnych samochodów.
- Przyciski do wynajmu samochodu.

### RentalForms/Index

- Wyświetla listę wszystkich formularzy wynajmu (dostępne tylko dla admina).
- Przyciski do edycji i usunięcia formularza.

### RentalForms/Details

- Formularz wynajmu samochodu.
- Wyświetla szczegóły wybranego samochodu.

### RentalForms/Edit

- Formularz edycji wynajmu (dostępne tylko dla admina).
- Możliwość edycji danych wynajmu.

## Uprawnienia

- Dostęp do listy formularzy wynajmu oraz możliwość edycji i usunięcia formularzy mają tylko użytkownicy z rolą admina.
- Formularze wynajmu mogą być wypełniane tylko przez zalogowanych użytkowników.

### Tworzenie Użytkownika Admina

Aby uzyskać dostęp do widoków wypożyczeń oraz innych widoków administracyjnych, należy utworzyć użytkownika admin@admin.pl:

1. Utwórz nowego użytkownika z adresem email `admin@admin.pl`.
2. Przypisz rolę admina do tego użytkownika.

Przykładowo, możesz to zrobić za pomocą narzędzi migracyjnych lub interfejsu użytkownika, jeśli taki jest dostępny w projekcie.

Przykładowe widoki dostępne dla admina:
- Lista formularzy wynajmu (`/RentalForms`)
- Szczegóły formularza wynajmu (`/RentalForms/Details/{id}`)
- Edycja formularza wynajmu (`/RentalForms/Edit/{id}`)
- Usunięcie formularza wynajmu (`/RentalForms/Delete/{id}`)
