$(document).ready(function () {

  function updateCounts() {
    let total = $("#taskList li").length;
    let completed = $("#taskList li.completed").length;
    $("#totalCount").text("Total: " + total);
    $("#completedCount").text("Completed: " + completed);
    $("#pendingCount").text("Pending: " + (total - completed));
    localStorage.setItem("tasks", $("#taskList").html());
  }

  function addTask() {
    let text = $("#taskInput").val().trim();
    let date = $("#dueDate").val();
    let priority = $("#priority").val();

    if (text === "") return;

    let task = $(`
      <li class="priority-${priority}">
        <span>${text} (Due: ${date || "No date"})</span>
        <div>
          <button class="complete">✔</button>
          <button class="delete">✖</button>
        </div>
      </li>
    `).hide().fadeIn();

    $("#taskList").append(task);
    $("#taskInput").val("");
    updateCounts();
  }

  $("#addTask").click(addTask);
  $("#taskInput").keypress(function(e){
    if (e.which === 13) addTask();
  });

  $("#taskList").on("click", ".complete", function () {
    $(this).closest("li").toggleClass("completed").slideToggle(100).slideToggle(100);
    updateCounts();
  });

  $("#taskList").on("click", ".delete", function () {
    $(this).closest("li").fadeOut(function () {
      $(this).remove();
      updateCounts();
    });
  });

  $("#all").click(() => $("#taskList li").show());
  $("#completed").click(() => {
    $("#taskList li").hide();
    $("#taskList li.completed").show();
  });
  $("#pending").click(() => {
    $("#taskList li").hide();
    $("#taskList li:not(.completed)").show();
  });

  // Load saved tasks
  $("#taskList").html(localStorage.getItem("tasks"));
  updateCounts();
});
