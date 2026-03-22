# MyApi — Containerized REST API

A REST API built with ASP.NET Core C#, containerized with Docker, 
and deployed to the cloud with automatic CI/CD.

## Live API
https://myapi-production-c5b6.up.railway.app/products

## Tech Stack
- ASP.NET Core (.NET 8) — REST API
- Docker — Containerization
- GitHub Actions — CI/CD pipeline
- Railway — Cloud deployment

## Endpoints
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /products | Get all products |
| GET | /products/{id} | Get a single product |
| POST | /products | Add a new product |
| DELETE | /products/{id} | Delete a product |
| GET | /health | Health check |

## Run Locally
git clone https://github.com/ranayasserx/MyApi.git
cd MyApi/MyApi
dotnet run

## Run with Docker
docker build -t myapi .
docker run -p 8080:80 myapi