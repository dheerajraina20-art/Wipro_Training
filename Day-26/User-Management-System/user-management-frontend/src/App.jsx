import axios from "axios";
import { useEffect, useState } from "react";
import UserForm from "./UserForm";
import UserList from "./UserList";

function App() {
  const [users, setUsers] = useState([]);

  const fetchUsers = async () => {
    const res = await axios.get("http://localhost:5000/users");
    setUsers(res.data);
  };

  useEffect(() => {
    fetchUsers();
  }, []);

  return (
    <div style={{ padding: "20px" }}>
      <h1>User Management System</h1>
      <UserForm fetchUsers={fetchUsers} />
      <UserList users={users} />
    </div>
  );
}

export default App;
