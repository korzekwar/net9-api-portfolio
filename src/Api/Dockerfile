# Estágio de Build - imagem com o SDK completo para compilar
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /source

# Copia e restaura dependências primeiro para aproveitar o cache do Docker
COPY *.sln .
COPY src/Api/*.csproj ./src/Api/
COPY src/Core/*.csproj ./src/Core/
COPY src/Infrastructure/*.csproj ./src/Infrastructure/
RUN dotnet restore

# Copia o resto do código e publica a versão final
COPY . .
WORKDIR /source/src/Api
RUN dotnet publish -c Release -o /app --no-restore

# Estágio Final - imagem menor, só com o necessário para rodar
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app .
# Ponto de entrada: comando que executa quando o contêiner inicia
ENTRYPOINT ["dotnet", "Api.dll"]