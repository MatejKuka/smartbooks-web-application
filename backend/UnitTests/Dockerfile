FROM mcr.microsoft.com/dotnet/sdk:7.0

WORKDIR /app
#COPY *.csproj ./
COPY ["./UnitTests", "UnitTests/"]
COPY ["./Application", "Application/"]
COPY ["./Domain", "Domain/"]
#RUN dotnet restore "./UnitTests/UnitTests.csproj"

ENTRYPOINT ["dotnet", "test", "./UnitTests"]