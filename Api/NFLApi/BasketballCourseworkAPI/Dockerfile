#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BasketballCourseworkAPI/CourseworkApi.csproj", "BasketballCourseworkAPI/"]
COPY ["BasketballCourseworkBLL/Coursework.BLL.csproj", "BasketballCourseworkBLL/"]
COPY ["BasketballCourseworkDAL/Coursework.DAL.csproj", "BasketballCourseworkDAL/"]
COPY ["Entities/Entities.csproj", "Entities/"]
RUN dotnet restore "BasketballCourseworkAPI/CourseworkApi.csproj"
COPY . .
WORKDIR "/src/BasketballCourseworkAPI"
RUN dotnet build "CourseworkApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CourseworkApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourseworkApi.dll"]