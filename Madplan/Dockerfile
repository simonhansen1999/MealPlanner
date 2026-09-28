# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy everything
COPY . .

# Build argument for solution file
ARG SOLUTION=Madplan.sln

# Restore dependencies
RUN dotnet restore $SOLUTION

# Build and publish
RUN dotnet publish $SOLUTION -c Release -o /app/out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# Install curl for healthchecks if needed
RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*

# Copy published app
COPY --from=build /app/out ./

# Make the app listen on all interfaces
ENV DOTNET_URLS=http://+:80

# Expose container ports
EXPOSE 80
EXPOSE 443

# Default entrypoint
ENTRYPOINT ["dotnet", "Madplan.dll"]
