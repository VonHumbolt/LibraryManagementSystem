# Library Management System
C# Backend Project For Managing Library System

## Summary
  &nbsp;&nbsp;&nbsp;&nbsp;  Library Project provides managing books that is in library and library users. Only librarian can lend books to users and add new books.
When the librarian lends book to users, system automatically sends an email to the user's email. User can see all books which borrowed. In Addition, the user can only extend 
return date of books once. The return dates of books are given automatically by the system as 20 days. Each user can only borrow 5 books at a time. All saved users and books are stored in database(mssql).

## Technologies
**C# - Asp.Net - Mssql - EntityFramework - Autofac - FluentValidation - MailKit**

## Layers

### Business
All required codes for managing database operations by communicating with data access layer. In Addition, this layer consist of validation rules.

### Data Access
Crud operations is written in this layer. All operations which is related to database such as borrow book, delete book are done using the codes in this layer.

### Core
It is the layer where project independent codes such as File helper, Cross Cutting Concernes, AOP, MailKitManager are written.

### Web Api
Opens the project to the internet. All api requests (get, post methods) are in this layer. Using this layer you can communicate with different technologies(react, angular).

## Contact
Email -> kaankaplan@icloud.com
