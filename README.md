# User Management System

WPF (.NET 10) desktop app to register, view, search, edit and delete users.

- Register users (name, phone, email, location) with validation and duplicate-email check
- Registered users list with search, stats (total / today / locations) and registration date
- Click a row or pick from the dropdown to edit or delete a user
- Users are saved to `%LocalAppData%\UserManagementSystem\users.json`

Run: `dotnet run` (output exe: `UserManagementSystem.exe`)
