#ISITECH B3 RPI D- .NET

#Prérequis

avoir installé .NET core 8.0 ou sup
``bash
dotnet --version pour voir la version installer

dotnet --list-sdks //liste des SDK installés

##COURS

.NET est un framework de dev cross plateforme conçu par microsoft :

apperçu des tech .NET

Image ici

Avec .NET passer a la version lts suivantes en version paires car maintenu plus longtemps.

la diff entre .NET et .NET Core est que .NET est open source et cross platform, tandis que .NET framework est proprietaire et fonctionne qur sur windows.

la portabilité de .NET Core est possible car il depend pas de windows, mais de coreCLR uneversion clr qui est cross-platform.

les librairies NuGet : .NET Core utilise les librairies NuGet qui sont des librairies opensources tandis que .NET Framework utilise les librairies proprietaires de microsoft.
Cependant toutes les libraires .NET framework ne sont pas encore portees sur .NET Core.

.Net libraires installer avec la version 8.0
environnement sécuriser plus controller que npm avec microsoft

## Le pattern MVC 

.NET utilise le pattern MVC  pour developper des applications web:

-separation des couches logiques, metier et présentation
-Razor pages permet de crer des pages web
-du model binding et de la validation de model

création d'un projet : dotnet new console --use-program-main -o  consoleProject 

dotnet new installe un nouveau projet
dotnet restore restaure les packages
dotnet build compile le projet
dotnet run execute le projet

installer les paquets de 2 manières 
