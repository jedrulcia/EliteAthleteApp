
# 🏋️‍♂️ EliteAthleteApp

**EliteAthleteApp** is a comprehensive tool for managing training plans, designed for coaches and their athletes. Currently, the app is a web application and will soon be extended to mobile devices. 

.NET MAUI application repo - [EliteAthleteAppMobile](https://github.com/jedrulcia/EliteAthleteAppMobile) 📱
Backend for application repo - [EliteAthleteAppShared](https://github.com/jedrulcia/EliteAthleteAppShared) 🖥️

## 📦 **Preview**
![homepage](https://github.com/user-attachments/assets/a0b2cda1-126a-44c2-9054-bab49e387305)

---

## 🚀 Technologies

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black)
![HTML5](https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white)
![CSS3](https://img.shields.io/badge/CSS3-1572B6?style=for-the-badge&logo=css3&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)
![.NET MAUI](https://img.shields.io/badge/.NET%20MAUI-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![XAML](https://img.shields.io/badge/XAML-0C54C2?style=for-the-badge&logo=.net&logoColor=white)
![MSSQL](https://img.shields.io/badge/MSSQL-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Backblaze](https://img.shields.io/badge/Backblaze%20Storage-2D3E50?style=for-the-badge&logo=backblaze&logoColor=white)
![Google Drive](https://img.shields.io/badge/Google%20Drive-4285F4?style=for-the-badge&logo=googledrive&logoColor=white)
![SignalR](https://img.shields.io/badge/SignalR-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![SendGrid](https://img.shields.io/badge/SendGrid-008CE7?style=for-the-badge&logo=sendgrid&logoColor=white)

---

## 📋 Features

### 🏋️‍♂️ **Exercises**
![exercises](https://github.com/user-attachments/assets/47e08368-ad98-4561-88aa-389ff33b7ca2)
- Creating (Private/Public)  
- Editing  
- Deleting  
- Adding custom photos and videos (handled by Google Drive Storage)  


### 🗓️ **Training Modules**
![trainingplans](https://github.com/user-attachments/assets/f339df39-9a24-4b01-add4-4b57e90c28aa)
- Creating (Creating a training module for a specific time frame generates a single training plan for every day during that period)  
- Editing (Adjusting the time frame)  
- Deleting  

### 📋 **Training Plans**
![manageexercise](https://github.com/user-attachments/assets/de9ff558-e6dd-4b6c-9d41-9d70557e1164)
- Managing Exercises (Adding/editing exercises in a training plan)  
- Copying training plan content to other training plans  
- Completing a training plan + sending a report  
- Tracking the training plan completion status  
- Exporting training plans to PDF  

### 🧑‍💻 **User Panel**
![userpanel](https://github.com/user-attachments/assets/20c7500e-7e00-4a7e-93a7-bd82f9eecba7)
**One-Repetition-Max, Body Measurements, Body Analysis, Medical Tests**:  
- Creating  
- Editing  
- Deleting  
- Tracking progress (charts powered by Chart.js)  

### 💬 **Chat**
![chat](https://github.com/user-attachments/assets/ed2eecfb-032e-42d5-947e-4c8b5e09734b)
- Real-time communication between coach and athlete (powered by SignalR)  

### 👨‍💼 **Admin Panel**
- Sending single or global emails via SendGrid  
- Deleting users  
- Banning/Unbanning users  
- Setting exercises as public upon request  

---

## 💡 How to Run the Project Locally?

1. Clone the repository:  
   ```bash
   git clone https://github.com/your-username/EliteAthleteApp.git
   ```
2. Clone the backend repository:
   ```bash
   https://github.com/jedrulcia/EliteAthleteAppShared.git
   ```
3. Clone the mobile app repository:
   ```bash
   https://github.com/jedrulcia/EliteAthleteAppMobile.git
   ```
4. Create appsettings.json file inside of the main folder
5. Add this structure to appsettings.json and fill the fields in square brackets:
   ```json
   {
     "ConnectionStrings": {
    "DatabaseConnectionString": "Server=[YOUR SERVER NAME];Database=[YOUR DATABASE NAME];Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False",
    "SendGridConnectionString": "[SEND GRID ID]"
     },
     "GoogleFolders": {
       "userimage": "[GOOGLE DRIVE FOLDER ID]",
       "exerciseimage": "[GOOGLE DRIVE FOLDER ID]",
       "exercisevideo": "[GOOGLE DRIVE FOLDER ID]",
       "medicaltestimage": "[GOOGLE DRIVE FOLDER ID]",
       "bodyanalysisimage": "[GOOGLE DRIVE FOLDER ID]"
     },
     "Email": "[YOUR EMAIL FOR EMAIL SENDER]",
     "Backblaze": {
       "keyId": "[YOUR BACKBLAZE KEYID]",
       "applicationKey": "[YOUR BACKBLAZE APPLICATION KEY]",
       "bucketId": "[YOUR BACKBLAZE BUCKET ID]"
     },
       "AllowedHosts": "*"
     }
   ```
6. Set up essential services (Backblaze Storage, SendGrid, Google Drive, MSSQL database)
7. Run database migrations using Entity Framework:  
   ```bash
   dotnet ef database update
   ```
8. Start the application:  
   ```bash
   dotnet run
   ```

---

## ⚖️ Privacy and Copyright Policy

All content, code, and materials in this repository are the intellectual property of the author and are protected by copyright laws. Unauthorized reproduction, distribution, or use of the content without explicit permission is prohibited.

By using this application, you agree that:

1. You will not use the application or its components for illegal purposes. 
2. The author retains all rights to the application and its source code. 
3. The application or its components will not be used for commercial purposes without the explicit knowledge and consent of the author.
4. No sensitive personal data is collected, stored, or shared by this application. However, you are responsible for ensuring compliance with applicable data protection laws when using it.

For inquiries about usage, licensing, or permissions, please contact the repository owner.