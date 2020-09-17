#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Walmart.Api.Product/Walmart.Api.Product.csproj", "Walmart.Api.Product/"]
RUN dotnet restore "Walmart.Api.Product/Walmart.Api.Product.csproj"
COPY . .
WORKDIR "/src/Walmart.Api.Product"
RUN dotnet build "Walmart.Api.Product.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Walmart.Api.Product.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Walmart.Api.Product.dll"]
