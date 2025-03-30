# ukg-technical-assignment-
UKG BE ASSIGNMENT - HCM

# How to run the project
1. Configure MsSQL DB
```
docker run \
  -e "ACCEPT_EULA=Y" \
  -e "MSSQL_SA_PASSWORD=Password123" \
  -p 1433:1433 \
  --name UKG.HCM \
  -d mcr.microsoft.com/mssql/server:2022-latest
```