# Образ (Os) + платформа .NET 
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app

EXPOSE 80
ENV ASPNETCORE_URLS http://+:80
ENV ASPNETCORE_ENVIRONMENT Development

# Этап сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Копируем все проекты
COPY ["SocNet1/SocNet1.csproj", "SocNet1/"]
COPY ["BusinessLogic/BusinessLogic.csproj", "BusinessLogic/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]

# Восстанавливаем зависимости
RUN dotnet restore "SocNet1/SocNet1.csproj"

# Копируем все файлы проекта
COPY . .

# Собираем проект
RUN dotnet build "SocNet1/SocNet1.csproj" -c Release -o /app/build

# Этап публикации
FROM build AS publish
RUN dotnet publish "SocNet1/SocNet1.csproj" -c Release -o /app/publish

# Финальный образ
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Запуск приложения
ENTRYPOINT ["dotnet", "SocNet1.dll"]