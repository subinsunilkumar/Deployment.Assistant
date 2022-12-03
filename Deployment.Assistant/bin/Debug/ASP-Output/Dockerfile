#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY . .
ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000
RUN groupadd --gid 1000 LaunchBEServiceUser && useradd --uid 1000 --gid 1000 --home-dir /usr/share/LaunchBEServiceUser --no-create-home LaunchBEServiceUser
USER LaunchBEServiceUser
ENTRYPOINT ["dotnet", "IDS.Services.BE.LaunchPage.dll"]
