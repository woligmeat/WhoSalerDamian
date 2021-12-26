FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WhoSalerDamian/WhoSalerDamian.csproj", "WhoSalerDamian/"]
RUN dotnet restore "WhoSalerDamian/WhoSalerDamian.csproj"
COPY . .
WORKDIR "/src/WhoSalerDamian"
RUN dotnet build "WhoSalerDamian.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WhoSalerDamian.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WhoSalerDamian.dll"]
