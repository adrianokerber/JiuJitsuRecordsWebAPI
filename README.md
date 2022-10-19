# JiuJitsuRecordsWebAPI
A CRUD GraphQL WebAPI on .NET about jiu-jitsu athletes (A.K.A.: jiujiteiros).
> PS: This API is for study purposes only ;)

To build and run the API just run
```powershell
dotnet run --project .\src\JiuJitsuRecords.WebAPI\JiuJitsuRecords.WebAPI.csproj
```

## Usage

To debug the WebAPI you can use the Altair UI through the following URL:
```
https://localhost:7193/ui/altair
```
.. And run the following queries:
```
{
  jiujiteiros {
    nome
    sobrenome
  }
}


######################
### Mutation example:
# mutation
# {
#   registerAthlete(nome: "Atleta Fake")
#   {
#       id
#       message
#   }
# }

#### Query option 2:
query {
  jiujiteiros {
    nome
    sobrenome
  }
}
```

Or acess via any RestClient or direcly via cURL
```cURL
curl --location --request POST 'https://localhost:7193/graphql' \
--header 'Content-Type: application/json' \
--data-raw '{"query":"{\r\n    jiujiteiros {\r\n        nome,\r\n        sobrenome\r\n    }\r\n}","variables":{}}'
```

> Note: the port of the URL examples might change