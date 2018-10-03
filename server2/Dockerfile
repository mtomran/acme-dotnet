FROM microsoft/dotnet:2.1-sdk as build-env
WORKDIR /usr/src/app
COPY *.csproj ./
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o publish
FROM microsoft/dotnet:2.1-runtime
WORKDIR /app
COPY --from=build-env /usr/src/app/publish .
CMD ["dotnet", "dotnettest.dll"]