FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MovieLibraryWeb/MovieLibraryWeb.csproj", "MovieLibraryWeb/"]
COPY ["MovieLibrary.DataAccess/MovieLibrary.DataAccess.csproj", "MovieLibrary.DataAccess/"]
COPY ["MovieLibrary.Models/MovieLibrary.Models.csproj", "MovieLibrary.Models/"]
COPY ["Services/MovieLibrary.Services.csproj", "Services/"]
RUN dotnet restore "MovieLibraryWeb/MovieLibraryWeb.csproj"
COPY . .
WORKDIR "/src/MovieLibraryWeb"
RUN dotnet build "MovieLibraryWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MovieLibraryWeb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieLibraryWeb.dll"]
