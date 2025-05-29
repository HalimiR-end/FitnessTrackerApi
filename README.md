Fitness Tracker API - Backend (.NET 8)
Kjo është pjesa e backend-it për projektin Fitness Tracker, ndërtuar me .NET 8 dhe duke ndjekur principet e Clean Architecture. Projekti ofron funksione të ndryshme për menaxhimin e përdoruesve, ushtrimeve dhe planifikimeve të stërvitjes (workouts), dhe përmbush kërkesat për një projekt në lëndën Testimi i Softuerit.

Struktura e Projektit
FitnessTrackerApi.API – Pjesa e jashtme që përmban controller-at, konfigurimet dhe startup-in e aplikacionit.

FitnessTrackerApi.Application – Layer-i i logjikës së biznesit me interface, DTO dhe handler për MediatR.

FitnessTrackerApi.Domain – Modelet dhe entitetet kryesore të sistemit.

FitnessTrackerApi.Infrastructure – Aksesimi në databazë, implementimet e interface-ve, JWT, logger.

(Opsionalisht: FitnessTrackerApi.Tests për testime).

Teknologjitë e Përdorura
.NET 8

Entity Framework Core

MediatR

AutoMapper

JWT Authentication

MySQL

Swagger

Clean Architecture

Udhëzime për Startim Lokal
Klono projektin ose kopjoje në kompjuterin tënd.

Konfiguro appsettings.json me lidhjen e databazës:

json
Copy
Edit
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;database=fitnessdb;user=root;password=FJALËKALIMI_YT;"
}
Apliko migrimet (vetëm herën e parë):

pgsql
Copy
Edit
dotnet ef database update
Run aplikacionin:

arduino
Copy
Edit
dotnet run --project FitnessTrackerApi.API
Hap Swagger në browser:

bash
Copy
Edit
https://localhost:{PORTI}/swagger
Funksionalitetet Kryesore
Regjistrimi dhe hyrja e përdoruesve

Krijimi, leximi, përditësimi dhe fshirja e ushtrimeve

Menaxhimi i planifikimeve të workout-it

Regjistrimi i aktiviteteve ditore

Profil i personalizuar për përdoruesin

JWT për autentifikim dhe autorizim

Testimi
Testime të bazuara në Selenium (për UI)

Unit testime të mundshme për API

Swagger për testim interaktiv të endpoint-eve

Dokumentacioni i API-së
Swagger gjenerohet automatikisht kur aplikacioni startohet.

Adresa tipike:

bash
Copy
Edit
https://localhost:{port}/swagger
