#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/NeedleWork.API/NeedleWork.API.csproj", "src/NeedleWork.API/"]
COPY ["src/NeedleWork.Infrastructure/NeedleWork.Infrastructure.csproj", "src/NeedleWork.Infrastructure/"]
COPY ["src/NeedleWork.Core/NeedleWork.Core.csproj", "src/NeedleWork.Core/"]
COPY ["src/NeedleWork.Application/NeedleWork.Application.csproj", "src/NeedleWork.Application/"]
RUN dotnet restore "src/NeedleWork.API/NeedleWork.API.csproj"
COPY . .
WORKDIR "/src/src/NeedleWork.API"
RUN dotnet build "NeedleWork.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NeedleWork.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NeedleWork.API.dll"]