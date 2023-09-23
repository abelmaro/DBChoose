# DBChoose

DBChoose is a .NET Core 7 project that allows you to switch between different database engines using an environment variable. It leverages Entity Framework Core for seamless database interaction.

## Features

* Supports both SQL Server and PostgreSQL as backend database engines.
* Utilizes Docker and Docker Compose for easy setup and deployment.
* Flexibly switch between database engines using environment variables.

## Prerequisites

* [.NET Core 7 SDK](https://dotnet.microsoft.com/es-es/download/dotnet/7.0)

* [Docker](https://www.docker.com/get-started/)

## Getting Started
1. Clone the repository to your local machine.

```
git clone https://github.com/your-username/DBChoose.git
```

2. Navigate to the project directory.

```
cd DBChoose
```

3. Update the DATABASE_PROVIDER environment variable inside docker-compose.yml. You can choose between "sql" or "postgresql"

```
...
    environment:
        DATABASE_PROVIDER: "sql"
...

```

4. Start the project using Docker Compose.
```
docker compose up
```

This will spin up instances of SQL Server, the project API, and PostgreSQL.



Happy coding!

