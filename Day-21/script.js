//STEP 2: Access DOM Objects (Create references to DOM elements)
//STEP 3: Event Data (JavaScript Object)
//STEP 4: Display Events Dynamically (Add Elements)
//STEP 5: Handle Event Selection (Modify Content)
//STEP 6: Register for Event (Modify DOM Content)
//STEP 7: Unregister from Event (Remove / Modify)
//STEP 8: Add New Event Dynamically (Create + Append)
//STEP 9: Prevent Errors (Client-Side Validation)

// Event list and details section
const eventList = document.getElementById("eventList");
const eventTitle = document.getElementById("eventTitle");
const eventDesc = document.getElementById("eventDesc");
const countSpan = document.getElementById("count");

// Buttons
const registerBtn = document.getElementById("registerBtn");
const unregisterBtn = document.getElementById("unregisterBtn");
const addEventBtn = document.getElementById("addEventBtn");

//event data
const events = [
  { id: 1, name: "Music Night", description: "Enjoy live band performances.", participants: 5 },
  { id: 2, name: "Art Workshop", description: "Learn painting from experts.", participants: 3 },
  { id: 3, name: "Tech Talk", description: "Discussion on latest tech trends.", participants: 7 }
];

let selectedEvent = null; // Keeps track of which event user clicks

//display events dynamically
function displayEvents() {
  eventList.innerHTML = ""; // Clear old list before reloading

  events.forEach(event => {
    const li = document.createElement("li");
    li.textContent = event.name;
    li.style.cursor = "pointer";

    // When event is clicked
    li.addEventListener("click", () => selectEvent(event, li));

    eventList.appendChild(li);
  });
}

displayEvents(); // Call when page loads

// Handle event selection
function selectEvent(event, element) {
  selectedEvent = event;

  // Remove highlight from others
  document.querySelectorAll("#eventList li").forEach(li => li.classList.remove("selected"));

  element.classList.add("selected");

  // Show details
  eventTitle.textContent = event.name;
  eventDesc.textContent = event.description;
  countSpan.textContent = event.participants;
}

// Register for event
registerBtn.addEventListener("click", () => {
  if (!selectedEvent) {
    alert("Please select an event first!");
    return;
  }

  selectedEvent.participants++;
  countSpan.textContent = selectedEvent.participants;
});

// Unregister from event
unregisterBtn.addEventListener("click", () => {
  if (!selectedEvent) {
    alert("Please select an event first!");
    return;
  }

  if (selectedEvent.participants > 0) {
    selectedEvent.participants--;
    countSpan.textContent = selectedEvent.participants;
  } else {
    alert("No participants to remove!");
  }
});

// Add new event dynamically
addEventBtn.addEventListener("click", () => {
  const name = prompt("Enter event name:");
  const desc = prompt("Enter event description:");

  if (!name || !desc) {
    alert("Event name and description cannot be empty!");
    return;
  }

  const newEvent = {
    id: events.length + 1,
    name: name,
    description: desc,
    participants: 0
  };

  events.push(newEvent);
  displayEvents(); // Refresh list
});
