FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["src/SPD.Api.Authentication/SPD.Api.Authentication.csproj", "src/SPD.Api.Authentication/"]
RUN dotnet restore "src/SPD.Api.Authentication/SPD.Api.Authentication.csproj"
COPY . .
WORKDIR "/src/src/SPD.Api.Authentication"
RUN dotnet build "SPD.Api.Authentication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SPD.Api.Authentication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SPD.Api.Authentication.dll"]
