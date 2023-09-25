#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TerosOpenBanking.Application/TerosOpenBanking.Application.csproj", "TerosOpenBanking.Application/"]
COPY ["TerosOpenBanking.Domain/TerosOpenBanking.Domain.csproj", "TerosOpenBanking.Domain/"]
COPY ["TerosOpenBanking.Infra/TerosOpenBanking.Infra.csproj", "TerosOpenBanking.Infra/"]
RUN dotnet restore "TerosOpenBanking.Application/TerosOpenBanking.Application.csproj"
COPY . .
WORKDIR "/src/TerosOpenBanking.Application"
RUN dotnet build "TerosOpenBanking.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TerosOpenBanking.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TerosOpenBanking.Application.dll"]
