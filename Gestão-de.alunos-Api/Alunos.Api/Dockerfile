FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /Alunos.Api

# Copy csproj and restore as distinct layers
COPY Alunos.Application/Alunos.Application.csproj Alunos.Application/
COPY Alunos.Domain/Alunos.Domain.csproj alunos.Domain/

RUN dotnet --info
RUN dotnet restore "Alunos.Api/Alunos.Api.csproj"

# Copy everything else and build
COPY . .

# Publish
WORKDIR "/src/Alunos.Api"
RUN dotnet publish "Alunos.Api.csproj" -c Release -o /app

FROM runtime AS publish
WORKDIR /app
EXPOSE 80

COPY --from=build /app .
ENTRYPOINT ["dotnet", "Alunos.Api.dll"]

CMD dotnet Alunos.Api.dll --urls "http://*:$PORT"