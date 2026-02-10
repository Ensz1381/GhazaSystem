# GhazaSystem.blazor/Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# کپی کردن فایل‌های پروژه
COPY ["../GhazaSystem.UI/GhazaSystem.UI.csproj", "GhazaSystem.UI/"]


COPY ["../GhazaSystem.Common/GhazaSystem.Common.csproj", "GhazaSystem.Common/"]

RUN dotnet restore "GhazaSystem.UI/GhazaSystem.UI.csproj"

COPY GhazaSystem.UI/ GhazaSystem.UI/
COPY GhazaSystem.Common/ GhazaSystem.Common/
COPY GhazaSystem.UI/wwwroot/* ../wwwroot

# بیلد پروژه اصلی
WORKDIR /src/GhazaSystem.UI
RUN dotnet publish -c Release -o /app/publish

# مرحله نهایی
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "GhazaSystem.UI.dll"]