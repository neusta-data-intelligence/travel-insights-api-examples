# Travel Insights C# Api Client Example

## Prerequisites
- Docker
- Travel Insights API credentials
- Travel Insights API URL

## Usage
In this folder copy the `dotenv-template` to `.env` and fill the blanks.

In the solution folder run
```sh
$ docker build -f TiApiDemo/Dockerfile -t ti-csharp-api-client-demo . 
```
Then run the built image with
```sh
$ docker run --rm --env-file TiApiDemo/.env ti-csharp-api-client-demo
```