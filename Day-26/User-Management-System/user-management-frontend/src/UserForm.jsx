import axios from "axios";
import { useState } from "react";

function UserForm({ fetchUsers }) {
  const [name, setName] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!name) return;

    await axios.post("http://localhost:5000/users", { name });

    setName("");
    fetchUsers();
  };

  return (
    <form onSubmit={handleSubmit} style={{ marginBottom: "20px" }}>
      <input
        type="text"
        placeholder="Enter user name"
        value={name}
        onChange={(e) => setName(e.target.value)}
      />
      <button type="submit">Add User</button>
    </form>
  );
}

export default UserForm;
