# Middleware Test Project: "Student Portal"

## 📌 Project Overview
You are required to build a **Student Portal Web Application** using ASP.NET Core middleware.  
This project will test your understanding of the middleware pipeline and the extension methods:
- `Use`
- `Run`
- `Map`
- `MapWhen`
- `UseWhen`

Your application should behave differently depending on the request **path**, **query string**, and **conditions**.  

---

## 📋 Requirements

### 1. Base Middleware
- [ ] Add a logging middleware using **`Use`** that:
  - Logs the HTTP method and request path to the console before the request is processed.
  - Logs `"Response sent"` after the request is processed.
- This middleware must **call `next()`** so the pipeline continues.

---

### 2. Home Route (Terminal Middleware)
- [ ] Implement a **`Run`** middleware at the root (`/`) that returns:

        Welcome to the Student Portal

- This middleware must **terminate the pipeline**.

---

### 3. Branching with `Map`
- [ ] Create a branch for `/students`:
  - Inside the branch, add a middleware (`Use`) that logs `"Inside Students branch"`.
  - Add a terminal **`Run`** that returns:

        Student Management Section

- [ ] Create another branch for `/teachers`:
  - Inside the branch, add a terminal **`Run`** that returns:

        Teacher Management Section

---

### 4. Conditional Branching with `MapWhen`
- [ ] Add a **`MapWhen`** middleware that:
  - If the query string contains `?admin=true`, branches to an admin section.
  - The admin section should respond with:

        Admin Dashboard

- [ ] If the query string does not contain `admin=true`, continue the normal pipeline.

---

### 5. Conditional Middleware with `UseWhen`
- [ ] Use **`UseWhen`** to add middleware only for requests where the path starts with `/api`.
  - In this condition, log `"API Request detected"`.
  - Still allow the request to continue to the rest of the pipeline.

---

### 6. Fallback Middleware
- [ ] Add a final **`Run`** middleware that handles all requests not already handled.
  - Respond with:

        Page Not Found

---

## ✅ Deliverables
- A working **ASP.NET Core project** (`Program.cs`) implementing all the above requirements.
- Students must not use MVC, minimal APIs, or controllers — only **middleware**.

---

## 🎯 Grading Rubric (Total: 100 points)

| Requirement                                | Points |
|--------------------------------------------|--------|
| Logging middleware with `Use` works        | 15     |
| Root `/` handled with `Run`                | 10     |
| `/students` branch works with `Map`        | 15     |
| `/teachers` branch works with `Map`        | 10     |
| `MapWhen` handles `?admin=true` correctly  | 15     |
| `UseWhen` logs only `/api` requests        | 15     |
| Fallback middleware (`Page Not Found`)     | 10     |
| Code cleanliness & comments                | 10     |
| **Total**                                  | **100**|

---

## 🚀 Example Test Cases

1. Request `GET /` → Response: `Welcome to the Student Portal`
2. Request `GET /students` → Logs `"Inside Students branch"`, Response: `Student Management Section`
3. Request `GET /teachers` → Response: `Teacher Management Section`
4. Request `GET /anything` → Response: `Page Not Found`
5. Request `GET /api/data` → Logs `"API Request detected"`, Response: `Page Not Found` (since no specific handler)
6. Request `GET /?admin=true` → Response: `Admin Dashboard`

---
