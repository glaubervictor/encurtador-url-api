
# EncurtadorUrl.Api

Exemplo de aplicação para encurtar URLs


## Variáveis de Ambiente

Para rodar esse projeto, você vai precisar configurar as seguintes variáveis de ambiente no seu appsettings.json

`ConnectionString`

### Migrações

`EF`

Este projeto utiliza Entity Framework, após o banco de dados configurado utilize o seguinte comando em seu `Package Manager Console` com o projeto `EncurtadorUrl.Api.Data` escolhido em seu Visual Studio:

```bash
Update-Database -Context ApplicationDbContext -StartupProject EncurtadorUrl.Api
```

### Docker 

Rode o docker para gerar a imagem do projeto em ambiente de testes, certifique que sua string de conexão com o banco de dados esteja correta.
## Stack utilizada

**Back-end:**, .NET 6 WebAPI, FluentValidation, Entity Framework e MediatR.

