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
📦 HortiFrutiApiStore
├── API
│   ├── Controllers
│   ├── Configurations
│   └── Program.cs
│
├── Services
│   ├── DTOs
│   ├── Services
│   └── Regras de Negócio
│
├── Domain
│   ├── BaseEntity
│   ├── Entities
│   ├── ValueObjects
│   ├── Abstractions
│   └── Exceptions
│
├── Infrastructure
│   ├── Context
│   ├── Mappings
│   └── Repositories
│
└── Tests
