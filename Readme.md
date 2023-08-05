# Docker Workshop

.NET Web application to receive request and write body to console.

Nginx to be the reverse proxy.

Ngrok in local to receive public webhook request.

## Build .NET Web App image
```
cd mybot
docker build . -t mybot:1.0
```

## Run Nginx and .NET Web App from Docker-compose
```
docker-compose up -d
```

## Open Ngrok
```
sudo choco install ngrok # if not installed
ngrok authtoken <your-token> # Get token from ngrok web
ngrok http 172.30.98.250:80 # use ifconfig and check eth0 to get the IP address if Docker host in WSL
```

## Test and Check
```
curl -X POST -H "Content-Type: application/json" -d '{"mykey":"myvalue"}' https://b26d-182-234-95-82.ngrok-free.app
docker logs <your-dotnet-container-name>
```