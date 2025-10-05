FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app


COPY . ./

RUN dotnet restore FCG.Api/FCG.Api.csproj

RUN dotnet add FCG.Api package Microsoft.IdentityModel.Protocols --version 8.0.16
RUN dotnet add FCG.Api package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.16

RUN dotnet publish FCG.Api/FCG.Api.csproj -c Release -o /app/out
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out ./



# Install the agent
RUN apt-get update && apt-get install -y wget ca-certificates gnupg \
&& echo 'deb http://apt.newrelic.com/debian/ newrelic non-free' | tee /etc/apt/sources.list.d/newrelic.list \
&& wget https://download.newrelic.com/548C16BF.gpg \
&& apt-key add 548C16BF.gpg \
&& apt-get update \
&& apt-get install -y 'newrelic-dotnet-agent' \
&& rm -rf /var/lib/apt/lists/*

# Enable the agent
ENV CORECLR_ENABLE_PROFILING=1 \
CORECLR_PROFILER={36032161-FFC0-4B61-B559-F6C5D41BAE5A} \
CORECLR_NEWRELIC_HOME=/usr/local/newrelic-dotnet-agent \
CORECLR_PROFILER_PATH=/usr/local/newrelic-dotnet-agent/libNewRelicProfiler.so \
NEW_RELIC_LICENSE_KEY=2c0b1adf9fe24ec87d9d7755e57a46e9FFFFNRAL \
NEW_RELIC_APP_NAME="dotnet-newrelic"




ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "FCG.Api.dll"]