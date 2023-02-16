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
mutation {
  registerAthlete(nome: "Adriano", sobrenome: "Kerber", nascimento: "1992-08-31T17:30:15+05:30", estiloPreferencial: Guard, apelido: "Adri", posicoes: [{ nome: "Armlock" }, { nome: "Armlock Fantasma", descricao: "Quando o adversário está de quatro apoios e você puxa a lapela dele por baixo do braço e se joga só segurando na lapela o braço irá se abrir para que você possa pegá-lo ao cair no chão." }])
  {
    nome
    sobrenome
    posicoes {
      id
      nome
      descricao
    }
  },
  registerPosition(posicao: { nome: "Chave de pé reta", descricao: "Uma chave aplicada no pé que puxa ele..."})
    {
      id
      nome
      descricao
    }
}

#### Example: you can encapsulate the query inside the query object
query {
  jiujiteiros {
    id
    nome
    sobrenome
    apelido
    estiloPreferencial
  }
  posicoes {
    id,
    nome,
    descricao
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

### Find position by id:
# query {
#   posicoes(id: 1) {
#     id
#     nome
#     descricao
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

- [X] Add position entity and relate with athlete to display the positions most used by the athlete
- [X] Add InputTypes - specific models to input data througth mutations
- [X] Finish Position service and all logic related to Positions
- [X] Fix architectural layers of project adding mappers and proper domain encapsulation
- [X] Registration of Jiujiteiro must not use ID on GraphQL Mutation but service should accept ID registration
- [ ] How to update data? - Maybe use the ID as an input parameter to update data on mutation or create a specific mutation to update data
- [ ] Fix RESTful API to have the same behaviour of the GraphQL API bringing full data of Positions for each Athlete instead of the simple IDs. Think about how to divide on the Repositories the queries for GraphQL and RESTful
- [ ] Add database (MongoDB) to repository IAthleteRepository and remove fake data
- [ ] Create integration tests for GraphQL responses
- [ ] Use Mongo2Go on integration tests to check repositories
- [ ] Create Professor model and bind with athlete to display athlete teachers