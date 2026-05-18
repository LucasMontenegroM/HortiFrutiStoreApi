# HortiFrutiStore API

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat&logo=dotnet)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-REST_API-blue?style=flat&logo=microsoft)
![EF Core](https://img.shields.io/badge/EF_Core-SQL_Server-CC2927?style=flat&logo=microsoftsqlserver)
![Swagger](https://img.shields.io/badge/Swagger-OpenAPI-85EA2D?style=flat&logo=swagger&logoColor=black)

API desenvolvida em **ASP.NET Core (.NET 10)** para gerenciamento de uma loja de hortifruti, permitindo o controle e manipulacao de produtos com regras de negocio aplicadas na camada de dominio.

> Projeto de estudos com aplicacao pratica de **DDD**, **EF Core** e boas praticas de desenvolvimento de APIs REST.

---

## Tecnologias Utilizadas

| Tecnologia | Uso |
|---|---|
| ASP.NET Core (.NET 10) | Framework principal da API |
| Entity Framework Core | ORM e acesso ao banco de dados |
| SQL Server | Banco de dados relacional |
| FluentValidation | Validacao de entidades do dominio |
| Swagger / OpenAPI | Documentacao interativa dos endpoints |

---

## Arquitetura

O projeto segue os principios de **Domain-Driven Design (DDD)** com separacao em 4 camadas:

| Camada | Responsabilidade |
|--------|-----------------|
| `Api` | Receber requisicoes HTTP, roteamento e tratamento de erros |
| `Application` | Orquestrar casos de uso e DTOs |
| `Domain` | Regras de negocio, entidades, value objects e interfaces |
| `Infrastructure` | Persistencia de dados com EF Core + SQL Server |

> A camada **Domain** nao possui dependencia de nenhuma biblioteca de infraestrutura, respeitando o **Dependency Inversion Principle**.

---

## Estrutura de Pastas

```
HortiFrutiStore/
|
+-- src/
|   |
|   +-- HortiFrutiStore.Api/                        # Camada de apresentacao (entrada HTTP)
|   |   +-- Controllers/
|   |   |   \-- ProdutoController.cs                # Endpoints REST de Produto
|   |   +-- Middleware/
|   |   |   \-- ExceptionHandler.cs                 # Tratamento global de excecoes (IExceptionHandler)
|   |   \-- Program.cs                              # Configuracao da aplicacao e DI
|   |
|   +-- HortiFrutiStore.Application/                # Camada de aplicacao (casos de uso)
|   |   +-- DTOs/
|   |   |   \-- ProductDto.cs                       # Objeto de transferencia de dados (ProdutoDto)
|   |   \-- Services/
|   |       +-- Interfaces/
|   |       |   \-- IProdutoService.cs              # Contrato do servico de Produto
|   |       \-- ProdutoService.cs                   # Implementacao dos casos de uso de Produto
|   |
|   +-- HortiFrutiStore.Domain/                     # Camada de dominio (regras de negocio)
|   |   +-- Abstracoes/
|   |   |   \-- Entity.cs                           # Classe base com Id (Guid)
|   |   +-- Entities/
|   |   |   \-- Produto.cs                          # Entidade Produto + ProdutoValidator (FluentValidation)
|   |   +-- Exceptions/
|   |   |   +-- AppException.cs                     # Excecao de aplicacao
|   |   |   +-- DomainException.cs                  # Excecao de dominio
|   |   |   \-- NotFoundException.cs                # Excecao de recurso nao encontrado (HTTP 404)
|   |   +-- Interfaces/
|   |   |   +-- IProdutoRepository.cs               # Contrato do repositorio especifico de Produto
|   |   |   +-- IRepository.cs                      # Repositorio generico (Expression<Func<T, bool>>)
|   |   |   \-- IUnitOfWork.cs                      # Contrato de Unit of Work (CommitAsync)
|   |   \-- ObjetosDeValor/
|   |       \-- Preco.cs                            # Value Object: ValorBase, Desconto, ValorFinal
|   |
|   \-- HortiFrutiStore.Infrastructure/             # Camada de infraestrutura (acesso a dados)
|       +-- Contexts/
|       |   \-- StoreContext.cs                     # DbContext do Entity Framework Core (SQL Server)
|       +-- Repositories/
|       |   \-- ProdutoRepository.cs                # Implementacao do IProdutoRepository
|       \-- DependencyInjection/
|           \-- InfrastructureExtensions.cs         # Extension method: AdicionarInfrastrutura()
|
\-- Tests/
```

---

## Endpoints

Base URL: `/produto`

| Metodo | Rota | Descricao | Status |
|--------|------|-----------|--------|
| `GET` | `/produto/{id}` | Busca um produto por Id | `200 OK` |
| `GET` | `/produto/buscartodos?numPagina=0&numExibidos=25` | Lista produtos com paginacao | `200 OK` |
| `POST` | `/produto/criar` | Cria um novo produto | `201 Created` |
| `PATCH` | `/produto/nome/{id}` | Altera o nome do produto | `204 No Content` |
| `PATCH` | `/produto/preco/{id}` | Altera o preco base do produto | `204 No Content` |
| `PATCH` | `/produto/desconto/{id}` | Altera o desconto do produto | `204 No Content` |
| `DELETE` | `/produto/excluir/{id}` | Remove um produto | `200 OK` |

---

## Como Executar

### Pre-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local ou remoto)

### Configuracao

**1.** Clone o repositorio:

```
git clone https://github.com/LucasMontenegroM/HortiFrutiStoreApi.git
cd HortiFrutiStoreApi
```

**2.** Configure a connection string em `src/HortiFrutiStore.Api/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=HortiFrutiStore;Trusted_Connection=True;"
  }
}
```

**3.** Aplique as migrations:

```
dotnet ef database update --project src/HortiFrutiStore.Infrastructure --startup-project src/HortiFrutiStore.Api
```

**4.** Execute a aplicacao:

```
dotnet run --project src/HortiFrutiStore.Api
```

**5.** Acesse a documentacao Swagger:

```
https://localhost:{porta}/swagger
```
