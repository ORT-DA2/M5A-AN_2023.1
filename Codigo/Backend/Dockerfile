FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic AS base
RUN apt-get update
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build
ENV PUBLISH_NAME "homework"
ENV SOLUCTION "Homeworks.WebApi"
ENV MAIN_PROJECT "Homeworks.WebApi.csproj"
WORKDIR /src
COPY ./ $PUBLISH_NAME
WORKDIR /src/$PUBLISH_NAME/$SOLUCTION

FROM build AS restore
RUN dotnet restore

FROM restore AS publish
RUN dotnet publish $MAIN_PROJECT -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Homeworks.WebApi.dll"]