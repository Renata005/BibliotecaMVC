# Relatório Técnico - LibraTech

## Introdução

Antes de continuar o desenvolvimento do sistema da LibraTech, foi realizada uma pesquisa sobre as principais tecnologias utilizadas no projeto. O objetivo é entender como essas ferramentas funcionam e identificar os motivos pelos quais elas foram escolhidas para o desenvolvimento da aplicação.

---

# Injeção de Dependência no ASP.NET Core

## O que é Injeção de Dependência?

A Injeção de Dependência (Dependency Injection - DI) é um recurso do ASP.NET Core que permite que objetos sejam fornecidos automaticamente para outras classes da aplicação.
No projeto da LibraTech, por exemplo, os Controllers precisam acessar o banco de dados através do Entity Framework. Em vez de criar uma instância manualmente do contexto, o próprio ASP.NET Core fornece essa dependência.
Essa abordagem torna o código mais organizado, facilita a manutenção e reduz o acoplamento entre as classes.

---

## Ciclos de vida dos serviços

### Transient

No ciclo de vida Transient, uma nova instância do serviço é criada toda vez que ele é solicitado.
É indicado para serviços simples e que não precisam compartilhar informações entre chamadas.

### Scoped

No ciclo Scoped, uma única instância é criada durante toda a requisição do usuário.
Esse é o ciclo normalmente utilizado pelo Entity Framework, pois cada requisição trabalha com seu próprio contexto de banco de dados.

### Singleton

No Singleton, apenas uma instância é criada e compartilhada por toda a aplicação.
Esse tipo é recomendado para serviços de configuração e cache.

### Por que o banco de dados não deve ser Singleton?

Se várias requisições utilizarem o mesmo contexto ao mesmo tempo, podem ocorrer problemas de concorrência, inconsistência dos dados e falhas de desempenho. Por esse motivo, o DbContext normalmente é registrado como Scoped.

---

# Entity Framework Core e ORM

## O que é uma ORM?

ORM (Object Relational Mapping) é uma tecnologia responsável por fazer a ligação entre as classes do sistema e as tabelas do banco de dados.
Com o Entity Framework Core, não é necessário escrever manualmente comandos SQL para criar tabelas ou realizar operações básicas de inserção, alteração e exclusão de registros.
Isso torna o desenvolvimento mais rápido e facilita a manutenção do projeto.

---

## O que é Code-First?

Code-First é uma abordagem em que o banco de dados é criado a partir das classes desenvolvidas em C#.
Primeiro são criadas as entidades da aplicação e, posteriormente, o Entity Framework é responsável por gerar as tabelas automaticamente.
Essa estratégia facilita a evolução do sistema, já que as alterações realizadas nas classes podem ser refletidas no banco através das migrations.

---

## Como funcionam as Migrations?

As migrations são responsáveis por registrar as alterações realizadas nas entidades do sistema.
Quando executamos:

```bash
dotnet ef migrations add InitialCreate
```

o Entity Framework gera arquivos contendo as mudanças necessárias para atualizar o banco.
Depois, ao executar:

```bash
dotnet ef database update
```

o EF Core verifica quais migrations já foram aplicadas anteriormente através da tabela `__EFMigrationsHistory`.

Dessa forma, somente as alterações ainda não executadas são aplicadas ao banco de dados, mantendo a estrutura sempre sincronizada com o código.

---

# SQLite

## Vantagens do SQLite

Durante o desenvolvimento da LibraTech, o SQLite apresenta diversas vantagens:
* Fácil configuração;
* Não necessita de servidor dedicado;
* Utiliza apenas um arquivo `.db`;
* Consome poucos recursos;
* É ideal para testes e projetos menores;
* Facilita o desenvolvimento e a distribuição da aplicação.

Por esses motivos, é bastante utilizado em ambientes de desenvolvimento e prototipação.

---

## Limitações do SQLite

Apesar das vantagens, o SQLite possui limitações quando a quantidade de usuários cresce.
Como todas as informações são armazenadas em um único arquivo, muitas operações de escrita simultâneas podem gerar gargalos e diminuir o desempenho da aplicação.
Em cenários com grande quantidade de acessos, podem ocorrer:
* Lentidão;
* Filas de escrita;
* Bloqueios temporários do banco;
* Redução do desempenho geral.

---

## Quando migrar para PostgreSQL ou SQL Server?

À medida que a aplicação cresce e o número de usuários aumenta, torna-se necessário utilizar bancos de dados mais robustos.
Soluções como PostgreSQL e SQL Server oferecem:
* Melhor desempenho;
* Maior capacidade de processamento;
* Melhor gerenciamento de concorrência;
* Maior escalabilidade;
* Recursos avançados de segurança e disponibilidade.

Por esse motivo, são mais indicados para aplicações em produção e sistemas que precisam atender um grande número de usuários simultaneamente.

---

# Conclusão

O ASP.NET Core, juntamente com o Entity Framework Core e o SQLite, fornece uma base sólida para o desenvolvimento da plataforma LibraTech. Recursos como Injeção de Dependência e Migrations tornam o código mais organizado e facilitam sua manutenção.
O SQLite atende muito bem durante as fases iniciais do projeto, porém, conforme a plataforma evoluir e o número de usuários aumentar, será necessário migrar para uma solução mais robusta, como PostgreSQL ou SQL Server, garantindo melhor desempenho e escalabilidade.

---

## Autor

Renata Santana Lopes

Curso de Sistemas de Informação

Projeto LibraTech
