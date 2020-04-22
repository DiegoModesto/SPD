FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/SPD.Api.Categories/SPD.Api.Categories.csproj", "src/SPD.Api.Categories/"]
RUN dotnet restore "src/SPD.Api.Categories/SPD.Api.Categories.csproj"
COPY . .
WORKDIR "/src/src/SPD.Api.Categories"
RUN dotnet build "SPD.Api.Categories.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SPD.Api.Categories.csproj" -c Release -o /app/publish

FROM base AS final
ENV ASPNETCORE_URLS="http://+:5010"
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SPD.Api.Categories.dll"]