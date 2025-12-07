# SmartBalance 💰

Welcome to **SmartBalance**, a modern financial tracking application designed to help users manage their expenses and maintain a balanced budget. 
This project is built using **Blazor WebAssembly (WASM)** for the client-side and a custom **ASP.NET Core API** for backend functionality.

The app is actively in development, featuring secure user authentication, a responsive UI, and a dashboard with chart visualizations. Future updates will introduce advanced expense tracking, financial insights, and more!

---

## 🚀 Project Overview

SmartBalance aims to empower users with tools to manage their finances effectively. Key goals include:

- ✅ **Secure User Authentication** – Register and log in with JWT-based authentication.
- ✅ **Intuitive Expense Tracking** – A calendar-based interface for logging expenses (with a scheduler already implemented).
- ✅ **Personalized Dashboards** – Financial summaries and interactive charts (already includes a monthly balance overview).
- ✅ **Modern UI/UX** – Responsive design with Radzen components for a seamless experience.

This README provides an overview of the project, its technologies, architecture, current features, and future plans.

---

## 🛠 Technologies Used

### Client-Side (Blazor WebAssembly)
- 🟣 **Blazor WebAssembly** – Framework for building interactive web apps with C# and .NET.
- 🎨 **Radzen** – Modern UI component library for responsive layouts, forms, charts, spinners, and icons.
- 💾 **Blazored.LocalStorage** – Secure storage of authentication tokens.
- 🔐 **JWT Authentication** – Custom authentication state provider for managing user sessions.

### Server-Side (API)
- ⚙ **ASP.NET Core** – Powers the backend API for authentication and expense management.
- 🗄 **Entity Framework Core** – Handles database interactions with Neon Postgres.
- 🔑 **JWT** – Secure token-based authentication for API access.

### Development Tools
- 💻 **Visual Studio** – Primary IDE for coding and debugging.
- 🔄 **Git** – Version control for tracking changes.
- 🔧 **.NET 9** – Runtime and SDK for building the app and API.

### ☁ Database & Hosting
- 🛢 **Neon** – Serverless PostgreSQL database for storing user data and expenses.
- 🚀 **Render** – Free-tier cloud hosting platform for deploying the API.
- 🌍 **Cloudflare Pages** – Hosts the Blazor WASM frontend, offering:
  - Global CDN for fast performance.
  - Automatic SSL for secure connections.
  - Custom domain support at zero cost.

---

## 🏗 Architecture

SmartBalance follows an **N-layer architecture** to ensure modularity, scalability, and maintainability:

1. **Presentation Layer** (`SmartBalanceApplication`)
   - Built with Blazor WASM and Radzen UI.
   - Handles user interactions (login, registration, home page, dashboard).
   - Communicates with the API via HTTP requests.

2. **Business Logic Layer (BLL)** (`SmartBalance.Api`)
   - Manages authentication and expense tracking logic.
   - Interacts with the Data Access Layer (DAL) through interfaces.

3. **Data Access Layer (DAL)** (`SmartBalance.Api`)
   - Uses Entity Framework Core to interact with Neon Postgres for data storage and retrieval.

---

## 🔥 Features

### ✅ Current Features
- **🔐 User Authentication**
  - Secure login and registration with JWT.
  - Real-time form validation with feedback.
  - Loading spinners during API calls.
  - Toast notifications for user actions (e.g., successful registration).
  - Auto-redirect to login after successful registration.
  - **Demo Login**: Use `UserDemo` / `UserDemo2025` for testing (see [Live Demo](#-live-demo)).

- **🏡 Home Page**
  - Personalized welcome message with the logged-in username.
  - Scheduler component for viewing and managing expenses by date.

- **📊 Dashboard**
  - Monthly balance overview with interactive charts.
  - Visualizes positive and negative balances.
  - Displays all 12 months in chronological order.

- **🎨 UI/UX**
  - Modern design with smooth gradients and responsive layouts.
  - Radzen components for forms, buttons, charts, and more.

---

## 🌍 Live Demo

Try SmartBalance now!

- **Frontend (Blazor WebAssembly)** – 🔗 [SmartBalance.pages.dev](https://smartbalance.pages.dev)
- **Backend API (ASP.NET Core)** – 🔗 [SmartBalance API on Render](https://smartbalanceapi.onrender.com/swagger/index.html)

### Demo Credentials
For quick testing, use the following credentials:
- **Username**: `UserDemo`
- **Password**: `UserDemo2025`

> **Note**: The API is hosted on Render's free tier, which may cause delays in API requests due to cold starts when the server is idle. Please allow a few seconds for responses.
 
