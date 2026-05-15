#  HortiFrutiApiStore

API desenvolvida em **ASP.NET Core** para gerenciamento de uma loja de hortifruti, permitindo o controle e manipulação de produtos e regras de negócio da aplicação.

O projeto segue uma arquitetura em camadas, separando responsabilidades entre domínio, persistência, regras de negócio e exposição da API, facilitando manutenção, organização e escalabilidade do sistema.

---

## 🚀 Tecnologias Utilizadas

- **ASP.NET Core**
- **Entity Framework Core**
- **SQL Server**
- **Swagger / OpenAPI**
- **FluentValidation**
- **REST API**

---

## 📂 Arquitetura do Projeto

O projeto foi estruturado seguindo uma arquitetura em camadas, promovendo separação de responsabilidades e melhor organização do código.

### Estrutura de Pastas

```txt
HortiFrutiStore/
│
├── src/
│   │
│   ├── HortiFrutiStore.Api/                        # Camada de apresentação (entrada HTTP)
│   │   ├── Controllers/
│   │   │   └── ProdutoController.cs                # Endpoints REST de Produto
│   │   ├── Middleware/
│   │   │   └── ExceptionHandler.cs                 # Tratamento global de exceções (IExceptionHandler)
│   │   └── Program.cs                              # Configuração da aplicação e DI
│   │
│   ├── HortiFrutiStore.Application/                # Camada de aplicação (casos de uso)
│   │   ├── DTOs/
│   │   │   └── ProductDto.cs                       # Objeto de transferência de dados (ProdutoDto)
│   │   └── Services/
│   │       ├── Interfaces/
│   │       │   └── IProdutoService.cs              # Contrato do serviço de Produto
│   │       └── ProdutoService.cs                   # Implementação dos casos de uso de Produto
│   │
│   ├── HortiFrutiStore.Domain/                     # Camada de domínio (regras de negócio)
│   │   ├── Abstracoes/
│   │   │   └── Entity.cs                           # Classe base abstrata com Id (Guid)
│   │   ├── Entities/
│   │   │   └── Produto.cs                          # Entidade Produto + ProdutoValidator (FluentValidation)
│   │   ├── Exceptions/
│   │   │   ├── AppException.cs                     # Exceção de aplicação
│   │   │   ├── DomainException.cs                  # Exceção de domínio
│   │   │   └── NotFoundException.cs                # Exceção de recurso não encontrado
│   │   ├── Interfaces/
│   │   │   ├── IProdutoRepository.cs               # Contrato do repositório específico de Produto
│   │   │   ├── IRepository.cs                      # Repositório genérico (Expression<Func<T, bool>>)
│   │   │   └── IUnitOfWork.cs                      # Contrato de Unit of Work
│   │   └── ObjetosDeValor/
│   │       └── Preco.cs                            # Value Object: ValorBase, Desconto, ValorFinal
│   │
│   └── HortiFrutiStore.Infrastructure/             # Camada de infraestrutura (acesso a dados)
│       ├── Contexts/
│       │   └── StoreContext.cs                     # DbContext do Entity Framework Core (SQL Server)
│       ├── Repositories/
│       │   └── ProdutoRepository.cs                # Implementação do IProdutoRepository
│       └── [DependencyInjection/]
│           └── InfrastructureExtensions.cs         # Extension method: AdicionarInfrastrutura()
└── Tests
