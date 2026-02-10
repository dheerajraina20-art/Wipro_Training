const express = require("express");
const cors = require("cors");

const app = express();
app.use(cors());
app.use(express.json());

let users = [
  { id: 1, name: "Alice" },
  { id: 2, name: "Bob" }
];

// GET all users
app.get("/users", (req, res) => {
  res.json(users);
});

// POST new user
app.post("/users", (req, res) => {
  const newUser = {
    id: users.length + 1,
    name: req.body.name
  };
  users.push(newUser);
  res.status(201).json(newUser);
});

app.listen(5000, () => {
  console.log("Server running on http://localhost:5000");
});

app.get("/", (req, res) => {
  res.send("User Management API is running");
});

/**
 * Project Explanation: User Management System using Node.js and React

In this project, we built a simple User Management System to understand how a React frontend communicates with a Node.js backend.

First, we set up a Node.js server using Express. The server was configured to run on port 5000 and provide REST API endpoints. We created a GET /users route to return a list of users and a POST /users route to add new users dynamically. We also enabled CORS and used express.json() middleware to handle data coming from the frontend.

Next, we created a React application using Vite. The React app acts as the frontend interface where users can see and add names. We used Axios to fetch user data from the backend and display it in the UI.

We implemented two main components:

UserList Component – Displays the list of users. This was later converted into a Class Component to understand how class components use this.props and the render() method.

UserForm Component – A Functional Component that contains an input field and button to add a new user. We used React state to manage form input and event handling to submit the form.

When a user enters a name and clicks Add User, a POST request is sent to the backend. The backend stores the new user, and the frontend refreshes the list using state updates. React’s Virtual DOM ensures that only the updated part of the UI re-renders, making the app efficient.

Outcome

By completing this project, we learned:

How to set up a Node.js + Express backend

How to create and connect a React frontend

How to use API calls (GET & POST)

The difference between Functional and Class Components

How props, state, and event handling work in React

How the Virtual DOM updates UI dynamically

This project demonstrates a basic full-stack application where frontend and backend work together seamlessly.
 */