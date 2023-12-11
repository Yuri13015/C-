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


On peut utiliser un "?" pour dire que la valeur peut etre NUL.

API : Une API (Application Programming Interface) est un ensemble de règles, de protocoles et de définitions qui permettent à différents logiciels de communiquer et d'interagir entre eux. Elle définit les méthodes, les structures de données et les formats d'échange de données utilisés par les applications pour interagir de manière programmée.

Une API peut être considérée comme un contrat entre différentes parties. Elle spécifie comment les différentes composantes d'un logiciel doivent interagir les unes avec les autres, les opérations qu'elles peuvent effectuer et les données qu'elles peuvent échanger. Elle fournit une interface claire et normalisée qui permet aux développeurs d'utiliser les fonctionnalités d'un logiciel ou d'un service sans avoir à connaître les détails internes de son implémentation.

Les API peuvent être utilisées de différentes manières. Par exemple, une API peut être utilisée pour accéder à des fonctionnalités d'un système d'exploitation, d'une bibliothèque de code, d'un service en ligne ou d'une plateforme de développement. Les développeurs peuvent intégrer des API dans leurs propres applications pour tirer parti des fonctionnalités fournies par d'autres systèmes et services, ce qui facilite la création d'applications interconnectées et modulaires.

Les API sont souvent fournies sous forme de bibliothèques de code, de kits de développement logiciel (SDK) ou d'interfaces web. Elles peuvent utiliser différents protocoles de communication, tels que HTTP, REST, SOAP, GraphQL, etc., et peuvent prendre en charge différents formats de données, tels que JSON, XML, CSV, etc.

Schéma API :
+------------------------+                      +----------------------+
|                        |                      |                      |
|   Application Client   |                      |    Application API    |
|                        |                      |                      |
+------------------------+                      +----------------------+
            |                                               |
            |               Requêtes HTTP                    |
            +----------------------------------------------->
            |                                               |
            |               Réponses HTTP                    |
            <-----------------------------------------------+
            |                                               |



Schéma api react : 

+---------------------+         +------------------+         +------------------+
|                     |         |                  |         |                  |
|    Application      |         |      API         |         |    Database      |
|    Client (React)   | <-----> |    .NET Server   | <-----> |                  |
|                     |   HTTP  |                  |   CRUD  |                  |
+---------------------+  Reqs/  +------------------+   Ops   +------------------+
                         Resps


                         
Pour créer une application API créer un classe c# 
Une propertie mets a disposition des accesseurs (getters et setters)
