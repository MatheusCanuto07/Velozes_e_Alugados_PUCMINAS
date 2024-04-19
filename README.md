# TIAPC-PUCMINAS

`Sistemas de informação`

`Trabalho Interdisciplinar: Aplicações para Processos de Negócios`

`3° semestre`

Aqui vai ter um resumo muito bom algum dia

## Integrantes

* Bárbara Xavier Soares de Barros
* Felipe Fernandes de Bellis Ruas
* Higor Antonio da Silva
* Matheus Henrique Marques Canuto
* Rafael Romagnoli Conforte Cesario
* Pedro Arley Paes Maia

## Orientador (a)

* Luciana Mara Freitas Diniz

## Pré-requisitos

Antes de começar, certifique-se de ter as seguintes ferramentas instaladas em sua máquina:

-

## Passos para Inicializar o Projeto

#### 1. Clone o repositório

Abra um terminal e clone o repositório do seu projeto:

```bash
git clone .....
```

#### 2. Configuração do Projeto ASP.NET Core

- Abra o terminal na pasta do projeto da API.

```bash
cd [seucaminho]/...
```

- Instale as dependências do NuGet e configure a string de conexão:

```bash
dotnet restore
```

- No aquivo ConnectionContext.cs dentro da pasta Infraestrutura, modifique a string de conexão com base na sua conexão MySql

```bash
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
      string stringConexao = "Server=...;Port=...;Database=...;User Id=...;Password=...;";
  
      optionsBuilder.UseMySql(connectionString: stringConexao, serverVersion: ServerVersion.AutoDetect(stringConexao));
  } 
```

- No banco de dados rode o SQL abaixo para a criação do banco e tabela:

```bash
Código SQL
```

- Inicie a API:

```bash
dotnet run
```

A API estará acessível em `https://localhost:7281`.

#### 3. Configuração do Projeto React

- Abra outro terminal e vá para a pasta do projeto React:

```bash
cd [seucaminho]/to-do-list
```

- Instale as dependências do npm:

```bash
npm install
```

#### 4. Inicie o Projeto React

- Inicie o aplicativo React:

```bash
npm start
```

O aplicativo React estará acessível em `http://localhost:3000`.
