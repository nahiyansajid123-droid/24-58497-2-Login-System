# README personal-review checklist

Use this checklist before publishing `README.md`:

- Replace the two marked draft sections with your own explanation of the app and the SQL Server conversion.
- Keep the factual run steps: execute `database.sql`, verify `App.config`, and test `admin` / `admin123`.
- Mention the actual edited files: `frmLogin.cs`, `frmRegister.cs`, `frmDashboard.cs`, `Program.cs`, `App.config`, and `database.sql`.
- Explain why the project changed from OleDb/Microsoft Access to SqlClient/SQL Server.
- Explain why the connection string is stored once in `App.config`.
- Explain why `@username` and `@password` are parameters and how they help prevent SQL injection.
- Do not claim screenshots, GitHub publishing, video recording, or tests that you did not actually complete.
