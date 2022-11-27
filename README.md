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
    id
    nome
    sobrenome
    apelido
  }
}


######################
### Mutation example:
# mutation {
#  registerAthlete(id: 8 nome: "Adriano")
#  {
#    nome
#    sobrenome
#  }
# }

#### Optional: when you query you can put the query in the beginning of the scope
query {
  jiujiteiros {
    nome
    sobrenome
  }
}

### Find athlete by id:
# query {
#   jiujiteiros(id: 1) {
#     id
#     nome
#     sobrenome
#     apelido
#   }
# }
```

Or acess via any RestClient or direcly via cURL
```cURL
curl --location --request POST 'https://localhost:7193/graphql' \
--header 'Content-Type: application/json' \
--data-raw '{"query":"{\r\n    jiujiteiros {\r\n        nome,\r\n        sobrenome\r\n    }\r\n}","variables":{}}'
```

> Note: the port of the URL examples might change
> Address for regular RESTful WebAPI => https://localhost:7193/swagger/index.html

## Run tests
In order to run the test just use: `dotnet test`

## Roadmap
The next steps of this project are:

- [ ] Create teacher model and bind with athlete to display athlete teachers
- [ ] Add database (MongoDB) to repository IAthleteRepository and remove fake data
- [ ] Create integration tests for GraphQL responses
- [ ] Use Mongo2Go on integration tests to check repositories