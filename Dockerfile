FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["LoanSystemManagment.sln", "./"]

COPY ["LoanSystemManagment/LoanSystemManagment.csproj", "LoanSystemManagment/"]
COPY ["Core/Domain/Domain.csproj", "Core/Domain/"]
COPY ["Core/Services/Services.csproj", "Core/Services/"]
COPY ["Services.Abstraction/Services.Abstraction.csproj", "Services.Abstraction/"]
COPY ["Infrastructure/Persistence/Persistence.csproj", "Infrastructure/Persistence/"]
COPY ["Infrastructure/Presentation/Presentation.csproj", "Infrastructure/Presentation/"]
COPY ["Shared/Shared.csproj", "Shared/"]

RUN dotnet restore

COPY . .

WORKDIR "/src/LoanSystemManagment"
RUN dotnet build "LoanSystemManagment.csproj" -c Release -o /app/build
RUN dotnet publish "LoanSystemManagment.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
EXPOSE 443
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000

ENTRYPOINT ["dotnet", "LoanSystemManagment.dll"] 