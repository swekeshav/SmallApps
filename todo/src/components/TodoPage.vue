<script setup>
import { ref, computed, onMounted, watch } from "vue";
import TodoItem from "./TodoItem.vue";

const typedTask = ref("");
let todos = ref([]);

// onMounted (async () => {
//   taskSet.value = await fetch("https://dummyjson.com/todos.value?limit=10")
//     .then((response) => response.json())
//     .then((data) => data.todos.value);
// });

onMounted(() => {
  todos.value = JSON.parse(localStorage.getItem("todos")) || [];
});

const displayState = ref("total");

const addTask = () => {
  if (typedTask.value === "") return;
  todos.value.unshift({
    id: newId(),
    todo: typedTask.value,
    completed: false,
    userId: 1,
  });
  typedTask.value = "";
};

const newId = () => {
  if (todos.value.length === 0) return 1;
  return Math.max(...todos.value.map((m) => m.id)) + 1;
};

watch(
  todos,
  (newVal) => {
    localStorage.setItem("todos", JSON.stringify(newVal));
  },
  { deep: true }
);

const filteredTodos = computed(() => {
  if (displayState.value === "active") {
    return todos.value.filter((a) => a.completed == false);
  } else if (displayState.value === "completed") {
    return todos.value.filter((a) => a.completed == true);
  }
  return todos.value;
});

const handleCompletedEvent = function (taskItem, completionState) {
  todos.value.find((a) => a.id === taskItem.value.id).completed =
    completionState.value;
};

const handleDeletedEvent = (id) => {
  todos.value = todos.value.filter((todo) => {
    return todo.id != id;
  });
};
</script>

<template>
  <h1 class="mb-5">Happy Todos!</h1>
  <div class="row">
    <div class="col-lg-2 d-lg-block d-none">
      <h3 class="text-start mx-5 my-1">Filters</h3>
      <div class="card m-3 mb-4">
        <h4 class="text-start mx-4 mt-4">Status</h4>
        <div class="mx-4 my-2" role="group">
          <div class="form-check text-start my-1">
            <input
              class="form-check-input fs-5"
              type="radio"
              name="btnDisplay"
              value="all"
              id="btnAll"
              v-model="displayState"
              checked
            />
            <label class="form-check-label fs-5" for="btnAll"> All </label>
          </div>
          <div class="form-check text-start my-1">
            <input
              class="form-check-input fs-5"
              type="radio"
              name="btnDisplay"
              value="active"
              id="btnActive"
              v-model="displayState"
            />
            <label class="form-check-label fs-5" for="btnActive">
              Active
            </label>
          </div>
          <div class="form-check text-start my-1">
            <input
              class="form-check-input fs-5"
              type="radio"
              name="btnDisplay"
              value="completed"
              id="btnCompleted"
              v-model="displayState"
            />
            <label class="form-check-label fs-5" for="btnCompleted">
              Completed
            </label>
          </div>
        </div>
      </div>
    </div>
    <div class="offset-lg-1 col-lg-6">
      <div class="input-group input-group-lg mb-3">
        <input
          type="text"
          class="form-control"
          placeholder="Enter a Task"
          v-model="typedTask"
          id="txtNewTask"
          @keyup.enter="addTask()"
        />
        <button class="btn btn-primary ms-3" @click="addTask()">
          Add Todo
        </button>
      </div>
      <TransitionGroup
        class="list-group list-group-flush my-5"
        v-if="filteredTodos.length > 0"
        name="list"
        tag="ul"
      >
        <li
          v-for="taskItem in filteredTodos"
          :key="taskItem.id"
          class="list-group-item fs-5"
        >
          <TodoItem
            :taskItem="taskItem"
            v-on:emitCompleted="handleCompletedEvent"
            v-on:emitDeleted="handleDeletedEvent"
          />
        </li>
      </TransitionGroup>
    </div>
  </div>
</template>

<style scoped>
li {
  text-align: start;
}
.list-move, /* apply transition to moving elements */
.list-enter-active,
.list-leave-active {
  transition: all 0.5s ease;
}

.list-enter-from,
.list-leave-to {
  opacity: 0;
  transform: translateX(30px);
}

/* ensure leaving items are taken out of layout flow so that moving
   animations can be calculated correctly. */
/* .list-leave-active {
  position: absolute;
} */
</style>
