# Budget-Tracker-Blazor

https://benvenuteo.github.io/budget-tracker-frontend/ -----> (link powinno działać do 10.01.2026)

BudgetTracker to aplikacja typu SPA (Single Page Application) do zarządzania budżetem domowym, zbudowana w oparciu o **.NET 8**, **Blazor WebAssembly** oraz **Clean Architecture**.

Projekt powstał w celu demonstracji wzorców projektowych, separacji warstw aplikacji oraz integracji .NET z ekosystemem przeglądarki.

##  Główne Funkcjonalności

* **Interaktywny Dashboard:** Wizualizacja przychodów i wydatków za pomocą wykresów (Chart.js) oraz kart KPI.
* **Zarządzanie Transakcjami:** Pełny CRUD z paginacją po stronie klienta, filtrowaniem i sortowaniem.
* **Kategorie:** System dynamicznego tworzenia kategorii z "Live Preview" (podglądem na żywo) i wyborem kolorów HEX.
* **Bezpieczeństwo:** Rejestracja i logowanie użytkowników oparte o JWT (JSON Web Tokens) i ASP.NET Core Identity.
* **Responsywność:** Nowoczesny UI

## Technologia i Architektura

Projekt został zrealizowany z zachowaniem zasad **Clean Architecture**, co zapewnia luźne powiązania i łatwość testowania.

### Backend (.NET 8 Web API):
* **Wzorce:** Repository Pattern, Unit of Work, Dependency Injection.
* **Baza danych:** SQLite z podejściem **Code First** i konfiguracją przez **Fluent API**.
* **Obsługa błędów:** Global Exception Middleware (spójne formatowanie błędów API).
* **Logowanie:** Serilog (zapis logów do plików z podziałem na dni i poziom błędów).
* **Mapowanie:** AutoMapper do konwersji między Encjami a DTO.
* **Bezpieczeństwo:** JWT Bearer Authentication.

### Frontend (Blazor WebAssembly):
* **JS Interop:** Ręcznie napisana warstwa komunikacji z JavaScript (bez gotowych wrapperów) do obsługi Chart.js i okien dialogowych.
* **State Management:** Własna implementacja `CustomAuthStateProvider` do obsługi stanu uwierzytelnienia.
* **Komunikacja:** `HttpClient` z wykorzystaniem **HttpInterceptor** do automatycznego dołączania tokenów Bearer.
* **Walidacja:** Współdzielone reguły walidacji (Data Annotations) dla frontu i backendu.
* **Komponenty:** Reużywalne komponenty UI (Spinner, Karty, Tabele).

## Wykorzystane Biblioteki

* **Backend:** `EF Core`, `Serilog`, `AutoMapper`, `Identity`, `Swashbuckle (Swagger)`.
* **Frontend:** `Blazored.LocalStorage`, `Blazored.Toast`, `Chart.js` (via Interop).
