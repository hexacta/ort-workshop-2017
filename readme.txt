Abrir la consola de powershell

#dotnet new --install Microsoft.AspNetCore.SpaTemplates::*
#dotnet new
#dotnet new webapi -o OrtWorkshopBackend
#cd OrtWorkshopBackend
#rm -r wwwroot
#dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 2.0.0
#code .

Abrir el archivo OrtWorkshopBackend.csproj y borrar lo siguiente:

  <ItemGroup>
    <Folder Include="wwwroot\" />
  </ItemGroup>

Borrar:

Archivo: Controllers\ValuesController.cs

Crear los siguientes directorios y archivos:

Dir: Data
Dir: Data\Entities
Dir: Service
Dir: Service\Implement
Dir: Service\Contract


Archivo: Data\OrtWorkshopContext.cs
Archivo: Data\Entities\Movie.cs
Archivo: Data\Entities\Genre.cs
Archivo: Service.Contract\IGenreService.cs
Archivo: Service.Contract\IMovieService.cs
Archivo: Service.Implement\GenreService.cs
Archivo: Service.Implement\MovieService.cs


