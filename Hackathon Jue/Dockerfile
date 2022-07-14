#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Hackathon Jue/Hackathon Jue.csproj", "Hackathon Jue/"]
RUN dotnet restore "Hackathon Jue/Hackathon Jue.csproj"
COPY . .
WORKDIR "/src/Hackathon Jue"
RUN dotnet build "Hackathon Jue.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hackathon Jue.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hackathon Jue.dll"]