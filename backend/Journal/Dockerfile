#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Journal.csproj", "Journal/"]
RUN dotnet restore "Journal/Journal.csproj"
COPY . .
WORKDIR "/src/Journal"

RUN dotnet restore "Journal.csproj"
COPY . .
WORKDIR "/src/Journal"
RUN dotnet build "Journal.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Journal.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Journal.dll"]

CMD ASPNETCORE_URLS=http://*:$PORT dotnet Journal.dll





