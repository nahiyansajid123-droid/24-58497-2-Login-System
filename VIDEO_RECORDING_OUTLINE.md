# 2–4 minute recording outline

Use your own voice and wording. This is a factual sequence for the required demonstration.

1. In SQL Server Management Studio, run `SELECT * FROM tbl_users;` and show the table before creating a new user.
2. In the application, open Registration and create a new username that is not already in the table.
3. Log in with that new username and password, then show the Dashboard.
4. Click Logout, choose Yes, and show that Login appears again.
5. Return to SQL Server Management Studio, run `SELECT * FROM tbl_users;`, and show the new user row.

Explain aloud:

- `frmLogin.cs` and `frmRegister.cs` changed from Microsoft Access/OleDb to SQL Server/SqlClient.
- `App.config` contains the connection string so it is not repeated in every form.
- The code uses `@username` and `@password` parameters to keep input out of the SQL text and reduce SQL injection risk.
