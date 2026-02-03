const output = document.getElementById("output");

// Helper function to clear old data
function clearOutput() {
    output.innerHTML = "";
}

// 1️ Load Todos
function loadTodos() {
    clearOutput();

    fetch("https://jsonplaceholder.typicode.com/todos?_limit=10")
        .then(response => response.json())
        .then(data => {
            data.forEach(todo => {
                const div = document.createElement("div");
                div.className = "card";
                div.innerHTML = `
                    <strong>Todo:</strong> ${todo.title} <br>
                    <strong>Status:</strong> ${todo.completed ? "✅ Completed" : "❌ Not Completed"}
                `;
                output.appendChild(div);
            });
        });
}

// 2️ Load Comments
function loadComments() {
    clearOutput();

    fetch("https://jsonplaceholder.typicode.com/comments?_limit=10")
        .then(response => response.json())
        .then(data => {
            data.forEach(comment => {
                const div = document.createElement("div");
                div.className = "card";
                div.innerHTML = `
                    <strong>Name:</strong> ${comment.name} <br>
                    <strong>Email:</strong> ${comment.email} <br>
                    <strong>Comment:</strong> ${comment.body}
                `;
                output.appendChild(div);
            });
        });
}

// 3️ load Users
function loadUsers() {
    clearOutput();

    fetch("https://jsonplaceholder.typicode.com/users")
        .then(response => response.json())
        .then(data => {
            data.forEach(user => {
                const div = document.createElement("div");
                div.className = "card";
                div.innerHTML = `
                    <strong>Name:</strong> ${user.name} <br>
                    <strong>Username:</strong> ${user.username} <br>
                    <strong>Email:</strong> ${user.email} <br>
                    <strong>City:</strong> ${user.address.city}
                `;
                output.appendChild(div);
            });
        });
}
