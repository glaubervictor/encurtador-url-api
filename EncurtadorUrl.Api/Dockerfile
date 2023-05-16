#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EncurtadorUrl.Api/EncurtadorUrl.Api.csproj", "EncurtadorUrl.Api/"]
COPY ["EncurtadorUrl.Api.Data/EncurtadorUrl.Api.Data.csproj", "EncurtadorUrl.Api.Data/"]
COPY ["EncurtadorUrl.Api.Shared/EncurtadorUrl.Api.Shared.csproj", "EncurtadorUrl.Api.Shared/"]
RUN dotnet restore "EncurtadorUrl.Api/EncurtadorUrl.Api.csproj"
COPY . .
WORKDIR "/src/EncurtadorUrl.Api"
RUN dotnet build "EncurtadorUrl.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EncurtadorUrl.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EncurtadorUrl.Api.dll"]