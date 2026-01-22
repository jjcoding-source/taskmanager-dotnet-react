import React, { useState } from "react";
import { createTask } from "../api/taskApi";

const TaskForm = ({ onTaskCreated }) => {
  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await createTask({ title, description });
      onTaskCreated(response.data);
      setTitle("");
      setDescription("");
    } catch (err) {
      console.error(err); 
      
    // Safe way to access error message
    if (err.response) {
      // Server returned a response (like 400 Bad Request)
      alert("Validation Error: " + JSON.stringify(err.response.data));
    } else if (err.request) {
      // Request was made but no response (Network Error)
      alert("Network Error: Could not reach the backend");
    } else {
      // Something else
      alert("Error: " + err.message);
    }
  }
};

  return (
    <form onSubmit={handleSubmit}>
      <input
        type="text"
        placeholder="Title"
        value={title}
        onChange={(e) => setTitle(e.target.value)}
      />
      <input
        type="text"
        placeholder="Description"
        value={description}
        onChange={(e) => setDescription(e.target.value)}
      />
      <button type="submit">Add Task</button>
    </form>
  );
};

export default TaskForm;
