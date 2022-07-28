#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5501
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["StaffScheduler/StaffScheduler.csproj", "StaffScheduler/"]
RUN dotnet restore "StaffScheduler/StaffScheduler.csproj"
COPY . .
WORKDIR "/src/StaffScheduler"
RUN dotnet build "StaffScheduler.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StaffScheduler.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://*:80
ENTRYPOINT ["dotnet", "StaffScheduler.dll"]