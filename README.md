# Introduction

Open Source Content Management System ( ERON )

- [Introduction](#introduction)
- [Application Layers](#application-layers)
    - [Application Presentation Layer](#application-presentation-layer)

<!-- [![Build status](https://ci.appveyor.com/api/projects/status/9ebmnxlnfgp54mld?svg=true)](https://ci.appveyor.com/project/MRebati/eron) -->

Eron is an open source and easy to use Content Management System that powers from Asp.net Frameworks and initiates good Software Architecture.
it might still have some problems but we're trying to resolve all issues.

It's base architecture provides two types of presentation layer applications. which are:

1. Administration Panel (which I call ControlPanel)
2. Website (which is the public view of the application)

Solution base architecture is a complex composite of various standard architectures and I tried to use the best practices for implementation of them.

# Application Layers

Solutions Folders are:

- Application Presentation Layer
  - 1. WebApi Application to provide all required APIs for the presentation layer.
  - 2. WebSite Application is used for public use and is MVC based so we can use Search Engine Crawlers on them.
- Business Logic Layer
    - 1. Interface of services which is class service. __not WCF or SOAP service__.
    - 2. Implementation of services
- Data Access Layer
    - 1. Interface of repositories and units of work and infrastructure contracts.
    - 2. Implementation of repositories and units of work and infrastructure classes.
- Core Application Layer
    - 1. Core Application Project contains the main entities and types, enums and appSettings and also some infrastructure for all project.
- Shared Kernel Layer
    - 1. Shared Kernel Project contains the value objects and helpers to be used all over the application
    - 2. Shared Kernel Dependency Resolver which containes modules and connections between contracts and implementations.

## Application Presentation Layer



Eron Solution also has some repositories [here in the organization page of itself](https://github.com/EronSolutions)

Find me here: [Eron Website](http://eron.ir). or here: [Rebati.net](http://rebati.net)
