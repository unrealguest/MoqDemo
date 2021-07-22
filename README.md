## Introduction

This is a simple example that shows the basics of mocking using the Moq framework.
Feel free to fork the project and use it as a playground to develop your own ideas and tests using NHibernate and Moq!

## What's contained in this project

The project reads the _Books.json_ file and loads the records contained within into a small self-contained sqlite database.
The models, mappings and the database accesses are built using NHibernate / FluentNHibernate. Feel free to check those parts as well as they could be useful for you in the future projects.

## How to run the project
This project is a .Net Core 3.1 project so you can either import it into Visual Studio / Visual Studio Code and run it as you would normally, or you can use the terminal as well. You will of course need the .Net Core 3.1 runtime on the machine you are trying to run the project. (https://dotnet.microsoft.com/download/dotnet/3.1)

1. Navigate into the _MoqDemo_ project folder and use the command `dotnet run` to run the application. This will create the sqlite database, fill it with the data provided by the _Books.json_ file and write the books and authors into the console output.

2. Then, you can run the unit tests either from the root folder or from the _MoqDemoTest_ folder using the `dotnet test` command. This will run the unit tests and print the result into the console output.

## Want more?
If you want to read more about the possibilities of Moq and / or NHibernate, see the following links:

- Moq4 Quickstart guide: https://github.com/Moq/moq4/wiki/Quickstart
- NHibernate tutorial: https://nhibernate.info/doc/tutorials/first-nh-app/your-first-nhibernate-based-application.html
- NHibernate reference: https://nhibernate.info/doc/nhibernate-reference/index.html
