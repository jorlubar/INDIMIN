FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Core.Api/Core.Api.csproj", "src/Core.Api/"]
RUN dotnet restore "src/Core.Api/Core.Api.csproj"
COPY . .
WORKDIR "/src/src/Core.Api"
RUN dotnet build "Core.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Core.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Core.Api.dll"]