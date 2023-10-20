# MovieTickets
## This app is designed for purchasing movie tickets online.
## Main page
![mainpage](https://github.com/IlyaBokovv/MovieTickets/assets/138998700/9628650a-fde8-4ec6-a6bd-5076d346a3e5)
## Actors page
![actorspage](https://github.com/IlyaBokovv/MovieTickets/assets/138998700/5d3c3211-fa3b-4711-a30f-4a0098310dc5)

# Usage
## Direct way
### First step: 
```
git clone https://github.com/IlyaBokovv/MovieTickets.git
```
### Second step:
```
Change ConnectionString in `appsettings.json` and 
```
### Third step:
```
dotnet run --project MovieTickets
```
## via Docker
### First step: 
```
git clone https://github.com/IlyaBokovv/MovieTickets.git
```
### Second step:
```
Create a .env file in the project's root directory and add the line: DB_PASSWORD={YourStrongPassword$}
```
Note: The password should meet the requirements for an MS SQL Server password.
### Third step:
```
docker compose up -d
```

