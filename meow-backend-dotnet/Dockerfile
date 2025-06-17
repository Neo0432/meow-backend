# Используем официальный образ .NET SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Устанавливаем рабочую директорию внутри контейнера
WORKDIR /app

# Копируем .csproj и восстанавливаем зависимости
COPY meow-backend-dotnet.csproj ./
RUN dotnet restore

# Копируем остальные файлы проекта
COPY . ./

# Собираем приложение в Release-режиме
RUN dotnet publish -c Release -o out

# Используем официальный runtime-образ для запуска
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

# Устанавливаем рабочую директорию внутри контейнера
WORKDIR /app

# Копируем собранное приложение из предыдущего stage
COPY --from=build /app/out ./

# Указываем порт, на котором будет слушать ASP.NET (на всякий случай)
EXPOSE 5062

# Устанавливаем пакет для EF
#RUN dotnet tool install --global dotnet-ef
#ENV PATH="$PATH:/root/.dotnet/tools"

# Запускаем миграции
#RUN dotnet ef database update

# Запускаем приложение
ENTRYPOINT ["dotnet", "meow-backend-dotnet.dll"]
