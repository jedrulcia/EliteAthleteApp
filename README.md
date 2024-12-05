
# 🏋️‍♂️ EliteAthleteApp

**EliteAthleteApp** is a comprehensive tool for managing training plans, designed for coaches and their athletes. Currently, the app is a web application and will soon be extended to mobile devices. 

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
- Creating (Private/Public)  
- Editing  
- Deleting  
- Adding custom photos and videos (handled by Google Drive Storage)  

### 🗓️ **Training Modules**
- Creating (Creating a training module for a specific time frame generates a single training plan for every day during that period)  
- Editing (Adjusting the time frame)  
- Deleting  

### 📋 **Training Plans**
- Managing Exercises (Adding/editing exercises in a training plan)  
- Copying training plan content to other training plans  
- Completing a training plan + sending a report  
- Tracking the training plan completion status  
- Exporting training plans to PDF  

### 🧑‍💻 **User Panel**
**One-Repetition-Max, Body Measurements, Body Analysis, Medical Tests**:  
- Creating  
- Editing  
- Deleting  
- Tracking progress (charts powered by Chart.js)  

### 💬 **Chat**
- Real-time communication between coach and athlete (powered by SignalR)  

### 👨‍💼 **Admin Panel**
- Sending single or global emails via SendGrid  
- Deleting users  
- Banning/Unbanning users  
- Setting exercises as public upon request  

---

## 📦 **Preview**
![homepage](https://github.com/user-attachments/assets/a0b2cda1-126a-44c2-9054-bab49e387305)
![exercises](https://github.com/user-attachments/assets/47e08368-ad98-4561-88aa-389ff33b7ca2)
![trainingplans](https://github.com/user-attachments/assets/f339df39-9a24-4b01-add4-4b57e90c28aa)
![manageexercise](https://github.com/user-attachments/assets/de9ff558-e6dd-4b6c-9d41-9d70557e1164)
![userpanel](https://github.com/user-attachments/assets/20c7500e-7e00-4a7e-93a7-bd82f9eecba7)
![chat](https://github.com/user-attachments/assets/ed2eecfb-032e-42d5-947e-4c8b5e09734b)

---

## 💡 How to Run the Project Locally?

1. Clone the repository:  
   ```bash
   git clone https://github.com/your-username/EliteAthleteApp.git
   ```
2. Set up essential services (Backblaze Storage, SendGrid, Google Drive, MSSQL database)
3. Create appsettings.json file inside of the main folder
4. Add this structure to appsettings.json and fill the fields in square brackets:
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
5. Run database migrations using Entity Framework:  
   ```bash
   dotnet ef database update
   ```
6. Start the application:  
   ```bash
   dotnet run
   ```

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).
