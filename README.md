# Login and Register

## Project Description

This project is a Windows Forms application that allows users to register an account, log in, and access a dashboard. After logging in successfully, the user can log out and return to the login screen.

For this resubmission, I converted the original database system from Microsoft Access to SQL Server. Through this project, I learned how a C# Windows Forms application can connect to SQL Server and perform registration and login operations using SQL queries.

## What I Changed

The original project used Microsoft Access and OleDb. I changed the database connection so that the application now uses SQL Server through `System.Data.SqlClient`.

I updated `frmLogin.cs` and `frmRegister.cs` so that both forms communicate with the SQL Server database. I also added the database connection string to `App.config` and used `ConfigurationManager` to read the connection string. This keeps the database connection information in one place instead of writing the connection string separately in different forms.

I added `database.sql`, which creates the `db_users` database and the `tbl_users` table. It also includes an `admin` test account.

The login and registration queries use `@username` and `@password` parameters. These parameters keep user input separate from the SQL command itself, which helps prevent SQL injection attacks.

Passwords are stored as SHA-256 hashes instead of plain text. The application hashes a password before saving it and hashes the entered password before comparing it during login. Storing plain-text passwords is unsafe because anyone who obtains database access could directly read users' passwords.

I also updated the application flow so that the program starts from the Login form. The Logout button on the Dashboard asks for confirmation and returns the user to the Login form instead of exiting the entire application.

## Features

- User registration
- User login
- Empty-field validation
- Incorrect username or password handling
- SQL Server database connection
- Dashboard after successful login
- Logout confirmation
- Return to the Login screen after logout

## Technologies Used

- C#
- Windows Forms
- SQL Server
- SQL Server LocalDB
- System.Data.SqlClient
- Visual Studio

## Database Setup

1. Open `database.sql` using SQL Server Management Studio.
2. Execute the script.
3. The script creates the `db_users` database.
4. The script creates the `tbl_users` table.
5. The script also creates the test account:

   - Username: `admin`
   - Password: `admin123`

## Connection Configuration

The database connection string is stored in:

`Login and Register/App.config`

The default server configuration uses:

`(localdb)\MSSQLLocalDB`

If SQL Server is installed using a different server or instance name, only the `Data Source` part of the connection string should be changed.

## How to Run the Project

1. Run `database.sql` in SQL Server Management Studio.
2. Open `Login and Register.sln` in Visual Studio.
3. Check that the connection string in `App.config` matches the SQL Server instance on the computer.
4. Build the solution.
5. Run the application.
6. Register a new account or log in using an existing account.

## Testing

The following functionality was tested successfully:

- Registering a new user
- Rejecting invalid login credentials
- Logging in with valid credentials
- Opening the Dashboard after successful login
- Logging out from the Dashboard
- Returning to the Login screen after logout

## Repository

The repository contains the source code, solution files, `database.sql`, `App.config`, and this README. Generated Visual Studio files and folders such as `.vs`, `bin`, and `obj` should not be included in the final repository.
