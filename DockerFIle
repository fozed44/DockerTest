#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["GetSomeThing/GetSomeThing.csproj", "GetSomeThing/"]
RUN dotnet restore "GetSomeThing/GetSomeThing.csproj"
COPY . .
WORKDIR "/src/GetSomeThing"
RUN dotnet build "GetSomeThing.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GetSomeThing.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GetSomeThing.dll"]