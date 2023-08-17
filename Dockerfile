#imagen base en cual basaremos nuestra imagen
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build 
#creación del directorio de trabajo
WORKDIR /app
#exponer el puerto 80
EXPOSE 80
#copiar csproj y restaurar la app 
COPY ./*.csproj ./
RUN dotnet restore
#copiamos los archivos y compilados o construidos de la app 
COPY . .
RUN dotnet publish -c Release -o publish 
#construir el contenedor
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/publish .
#Indicar el archivo dll compilado nombre de proyecto
ENTRYPOINT [ "dotnet","WebServicesEnrollment.dll" ]


