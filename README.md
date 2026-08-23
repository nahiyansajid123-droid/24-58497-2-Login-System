# Login and Register — draft for Rihan's review

> **Before publishing:** Please rewrite the short sections below in your own voice. They are factual prompts based on the project, not a final personal statement. The technical details and run instructions should remain accurate.

## What this application does — rewrite in my own words

This Windows Forms project has Login, Registration, and Dashboard screens. A person can create an account, log in with an existing account, and log out from the dashboard to return to Login.

**My own explanation:** Add two or three sentences here about what I learned from moving the project from Microsoft Access to SQL Server.

## How to run

1. Open `database.sql` with SQL Server Management Studio and execute it.
2. Open `Login and Register.sln` in Visual Studio.
3. Check `Login and Register/App.config`. The default server is `(localdb)\\MSSQLLocalDB`.
4. If your server has a different name, change only the `Data Source` part of `connString`.
5. Build and run the project.
6. Test with username `admin` and password `admin123`.

## Changes I need to explain in my own words

- `frmLogin.cs` and `frmRegister.cs` now use SQL Server through `System.Data.SqlClient` instead of Microsoft Access/OleDb.
- `App.config` stores one connection string and both forms read it through `ConfigurationManager`.
- `database.sql` creates `db_users`, `tbl_users`, and the `admin` test account.
- Login and registration use `@username` and `@password` parameters. Explain that this keeps user input separate from SQL commands and helps prevent SQL injection.
- `frmDashboard.cs` confirms logout and returns to Login, while `Program.cs` starts on Login.

## Personal review before submission

- [ ] Rewrite the two personal sections above in my own voice.
- [ ] Confirm the LocalDB `Data Source` matches my computer.
- [ ] Run the app and add only screenshots I actually captured, if required.
- [ ] Verify the GitHub repository contains this README, `database.sql`, `App.config`, and source code but not `.vs`, `bin`, or `obj`.
