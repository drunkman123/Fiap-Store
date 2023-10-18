# Fiap-Store
 Tech Challenge 1 FIAP 2NETT

## Startup instructions
- put sql server connection string in application settings on field "DB_FIAP_STORE"
- execute the sql script located on "dump sql/dbo.sql"
- execute dotnet run --urls "https://localhost:8080" --project fiap-store
- open https://localhost:8080/swagger/index.html on browser
- use the endpoint "/api/Login/Authenticate" to get a JWT

## Default user
- cpf: 11111111111
- password: test