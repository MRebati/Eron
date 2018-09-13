
**Eron Solutions - Content Management System**

## Table Of Contents:

- [Introduction](#introduction)
- [Application Layers](#application-layers)
    - [Application Presentation Layer](#application-presentation-layer)
    - [Business Logic Layer](#business-logic-layer)
    - [Data Access Layer](#data-access-layer)
    - [Core Application Layer](#core-application-layer)
    - [Sharek Kernel Layer](#sharek-kernel-layer)

# Introduction

Open Source Content Management System ( ERON )

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
  - WebApi Application
  - Website Application
  - Angular Application
- Business Logic Layer
    - Contracts
    - Implementations
- Data Access Layer
    - Contracts
    - Implementations with EF
- Core Application Layer
    - Core Application Entities
- Shared Kernel Layer
    - Shared Kernel with helpers and useful infrastructures
    - Dependency Resolver



## Application Presentation Layer
1. WebApi Application provides all required APIs for the presentation layer.
2. WebSite Application is used for public use and is MVC based so we can use Search Engine Crawlers on them.
3. Angular Application is more of a control Panel application for management and administrative usage.

## Business Logic Layer

1. Contracts contains Interface of services which is class service. __not WCF or SOAP service__.
2. Implementations has the netframework6 classes implementing the contracts of each and every service.    

## Data Access Layer
Well using the right pattern for DAL points to the repositories and unit of work patterns.
This layer contains these two projects for now:
1. Contracts which contains the interfaces and infrastructure for generic and base classes of the required design patterns
2. Implementations which contains the implementation to all the repositories and units of work and the framework infrastructures.

## Core Application Layer
Core layer contains the base entities, enums, some internal helpers and system settings

## Sharek Kernel Layer
Shared kernel has 2 projects now.
these are: 
1. Shared Kernel Project contains the value objects and helpers to be used all over the application.
2. Shared Kernel Dependency Resolver which containes modules and connections between contracts and implementations.

Eron Solution also has some repositories [here in the organization page of itself](https://github.com/EronSolutions)

Find me here: [Eron Website](http://eron.ir). or here: [Rebati.net](http://rebati.net)
