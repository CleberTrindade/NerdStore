#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/services/NS.Pedido.API/NS.Pedido.API.csproj", "src/services/NS.Pedido.API/"]
RUN dotnet restore "src/services/NS.Pedido.API/NS.Pedido.API.csproj"
COPY . .
WORKDIR "/src/src/services/NS.Pedido.API"
RUN dotnet build "NS.Pedido.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NS.Pedido.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NS.Pedido.API.dll"]