# مرحله Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# کپی کردن فایل پروژه و بازیابی dependencies
COPY ["GhazaSystem.Front.csproj", "./"]
RUN dotnet restore "GhazaSystem.Front.csproj"

# کپی کردن تمام فایل‌ها
COPY . .

# Build کردن پروژه
RUN dotnet build "GhazaSystem.Front.csproj" -c Release -o /app/build

# مرحله Publish
FROM build AS publish
RUN dotnet publish "GhazaSystem.Front.csproj" -c Release -o /app/publish /p:UseAppHost=false

# مرحله Final - استفاده از NGINX
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

# حذف فایل‌های پیش‌فرض NGINX
RUN rm -rf ./*

# کپی کردن فایل‌های منتشر شده Blazor
COPY --from=publish /app/publish/wwwroot .

# کپی کردن فایل پیکربندی NGINX
#COPY nginx.conf /etc/nginx/nginx.conf

EXPOSE 80
EXPOSE 443