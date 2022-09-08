
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /ProjetRedLineAG

# Copy csproj and restore as distinct layers
COPY . .
RUN dotnet restore ProjetRedLineAG

# Copy everything else and build
COPY . .
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /ProjetRedLineAG
COPY --from=build-env /app/out .

# Run the app on container startup
# Use your project name for the second parameter
# e.g. MyProject.dll
ENTRYPOINT [ "dotnet", "ProjetRedLineAG.dll" ]
