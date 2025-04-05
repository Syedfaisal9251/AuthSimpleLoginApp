LoginMongoApp

A simple Windows Forms application built with C# and MongoDB for user login authentication.

# Features

1 Login with email and password
2 Email format validation
3 Strong password check
4 MongoDB integration using `MongoDB.Driver`
5 Status message for login success/failure

 Technologies Used

 C# (.NET Windows Forms)
 MongoDB
 MongoDB.Driver (NuGet Package)

 How to Run the Project

1 Prerequisites

 Visual Studio (Windows Forms app support)
 MongoDB (running locally on port 27017)
.NET Framework (4.7.2 or compatible)

2 Setup Instructions

1. Clone the Repository
   ```bash
   git clone https://github.com/yourusername/LoginMongoApp.git
Open the Project in Visual Studio

Install MongoDB Driver

Open NuGet Package Manager

Search and install: MongoDB.Driver

Start MongoDB

Ensure your local MongoDB server is running:

bash
Copy
Edit
mongod
Create Sample User in MongoDB

javascript
Copy
Edit
use AuthDB
db.Users.insertOne({
  email: "test@example.com",
  password: "StrongPass@123"
})
Run the Application

Press F5 or click Start in Visual Studio

Login

Enter email: test@example.com

Enter password: StrongPass@123

📄 File Structure
File	Purpose
Form1.cs	Main login logic & MongoDB queries
Program.cs	Entry point of the application
Form1.Designer.cs	UI layout for login form
