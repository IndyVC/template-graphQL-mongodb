# Clovis-API will be the gateway and can be run in a seperate Docker container. 
Steps to run the docker container (Docker has to be installed on your machine):
- **docker pull indyvc/clovis-api** (no tag needed, default is latest)
- **docker run -d -p 3000:80 indyvc/clovis-api**
-> Go to localhost:3000 and everything should be working. Current route of the API you can test is the default project of .NET, so you should be able to surf to: localhost:3000/weatherforecast and see some JSON data. 
