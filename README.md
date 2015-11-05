# EFFoo

This project demonstrates techniques for using EF Migrations.

Poorly named but, EFFoo is the consumer and EFFoo2 is a Library project which has the Entities, DataContext, and is where Repository and other data access logic would live.


* Batch script in EFFoo project which creates a LocalDb database
* Batch script in EFFoo project which generates Migrations
* Extension methods in EFFoo2 project which add Data Migrations to Migrations
* Extension methods in EFFoo project which ensure Migrations have been run and that additional environment data has been added
