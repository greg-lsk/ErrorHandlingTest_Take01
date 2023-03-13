#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ApiServer/ApiServer.csproj", "ApiServer/"]
COPY ["Infrastructure/DesignTime/DataSeeder/DataSeeder.csproj", "Infrastructure/DesignTime/DataSeeder/"]
COPY ["Core/Application/Application.csproj", "Core/Application/"]
COPY ["Core/Domain/Domain.csproj", "Core/Domain/"]
COPY ["Core/Tools/Result/ErrorHandler.csproj", "Core/Tools/Result/"]
COPY ["Infrastructure/Persistence/Persistence.csproj", "Infrastructure/Persistence/"]
COPY ["Presentation/Api/Api.csproj", "Presentation/Api/"]
RUN dotnet restore "ApiServer/ApiServer.csproj"
COPY . .
WORKDIR "/src/ApiServer"
RUN dotnet build "ApiServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiServer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiServer.dll"]