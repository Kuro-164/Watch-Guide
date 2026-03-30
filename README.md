# 🎬 WatchGuide

WatchGuide is a **full-stack desktop application** built using **C# WinForms** and a **.NET Web API backend**.
It helps users discover movies and TV shows, view detailed information, and get personalized recommendations based on their preferences.

---

## 🚀 Features

* 🔥 Trending movies & TV shows
* 🎯 Personalized recommendations (based on genres & languages)
* 🔍 Smart search with similar content suggestions
* 📄 Detailed show page (poster, rating, genres, description, cast)
* 📺 OTT platform availability with **FREE / RENT / SUB** badges
* ⚙️ User preference saving & loading

---

## 🏗️ Architecture

This project follows a **client-server architecture**:

* 🖥️ **Frontend:** WinForms (.NET 8)
* 🌐 **Backend:** ASP.NET Core Web API
* 📡 **External APIs:** TMDB & Watchmode
* 🗄️ **Database:** PostgreSQL (Supabase)

---

## 🛠️ Tech Stack

### Frontend

* C# WinForms
* .NET 8

### Backend

* ASP.NET Core Web API
* DTO-based architecture

### Database

* PostgreSQL (Supabase)

---

## ⚙️ Setup & Run

### 🔹 1. Clone the repository

```bash
git clone https://github.com/Kuro-164/Watch-Guide.git
```

---

### 🔹 2. Configure Backend

* Open `WatchGuideAPI`
* Add your API keys (TMDB & Watchmode) in:

```
appsettings.json
```

* Configure your PostgreSQL (Supabase) connection string

---

### 🔹 3. Run Backend

```bash
dotnet run
```

---

### 🔹 4. Run Frontend

* Open solution in Visual Studio
* Set **WinFormsApp1** as Startup Project
* Run the application

---

## ⚠️ Important Notes

* Backend must be running before starting the app
* Requires internet connection for API data
* Ensure correct Base URL (`localhost`) is configured

---

## 📌 Highlights

* Clean DTO-based API design
* Separation of frontend & backend
* Real-world API integration
* Desktop-optimized UI

---

## 📜 License

This project is intended for **educational and portfolio use**.
