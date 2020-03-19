FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
ARG PROJECT
WORKDIR /src
COPY ${PROJECT}/${PROJECT}.csproj ./
RUN dotnet restore ${PROJECT}.csproj
COPY . .
WORKDIR "/src/."
RUN dotnet build ${PROJECT}/${PROJECT}.csproj -c Release -o /app/build

FROM build AS publish
ARG PROJECT
RUN dotnet publish ${PROJECT}/${PROJECT}.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
ARG PROJECT
ENV PROJECT_NAME=${PROJECT}
COPY --from=publish /app/publish .
ENTRYPOINT dotnet ${PROJECT_NAME}.dll
