# Fiap-Store
 Tech Challenge 1 FIAP 2NETT

#Integrantes do Grupo 34

-Edmundo Junior RM351083
-Felipe Andreoli  RM350666
-Denis Nigra RM350670
-Jeziel Moura RM351088


## Startup instructions
- put sql server connection string in application settings on field "DB_FIAP_STORE"
- execute the sql script located on "dump sql/dbo.sql"
- execute dotnet run --urls "https://localhost:8080" --project fiap-store
- open https://localhost:8080/swagger/index.html on browser
- use the endpoint "/api/Login/Authenticate" to get a JWT

## Admin user
- cpf: 11111111111
- password: test

## Client user
- cpf: 22222222222
- password: test


