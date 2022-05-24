<script setup>
import { reactive, ref, computed } from 'vue';
import TodoItem from './TodoItem.vue';

const typedTask = ref('');
var taskList = await fetch('https://jsonplaceholder.typicode.com/todos')
    .then((response) => response.json());

taskList.forEach((task, idx) => {
    if (idx % 3 === 0) {
        task.priority = "low";
    } else if (idx % 3 === 1) {
        task.priority = "medium";
    } else {
        task.priority = "high";
    }
})

var lastId = Math.max.apply(Math, taskList.map(function (task) { return task.id }));
const taskSet = reactive(taskList);

const displayState = ref('total');
const priorityState = ref('all');

function addTask() {
    if (typedTask.value === '')
        return;
    taskSet.unshift({ userId: 1, id: ++lastId, title: typedTask.value, completed: false });
    typedTask.value = '';
}

const filteredTodos = computed(() => {
    if (displayState.value === "active") {
        return taskSet.filter(a => a.completed == false && (priorityState.value === "all" || a.priority === priorityState.value))
    } else if (displayState.value === "completed") {
        return taskSet.filter(a => a.completed == true && (priorityState.value === "all" || a.priority === priorityState.value))
    }
    return taskSet.filter(a => (priorityState.value === "all" || a.priority === priorityState.value));
})

const totalCount = computed(() => {
    return taskSet.length;
})

const activeCount = computed(() => {
    return taskSet.filter(a => a.completed == false).length;
})

const completedCount = computed(() => {
    return taskSet.filter(a => a.completed == true).length;
})

const allCount = computed(() => {
    return taskSet.filter(a => (displayState.value === "total" || a.completed === (displayState.value === "active" ? false : true))).length;
})

const lowCount = computed(() => {
    return taskSet.filter(a => (displayState.value === "total" || a.completed === (displayState.value === "active" ? false : true))
        && a.priority === "low").length;
})

const mediumCount = computed(() => {
    return taskSet.filter(a => (displayState.value === "total" || a.completed === (displayState.value === "active" ? false : true))
        && a.priority === "medium").length;
})

const highCount = computed(() => {
    return taskSet.filter(a => (displayState.value === "total" || a.completed === (displayState.value === "active" ? false : true))
        && a.priority === "high").length;
})

const emitCompletedEvent = function(taskItem, completionState){
    taskSet.find(a => a.id === taskItem.value.id).completed = completionState.value;
}

</script>

<template>
    <h1 class="mb-5">Happy Todos!</h1>
    <div class="container">
        <div class="input-group input-group-lg mb-3">
            <input type="text" class="form-control" placeholder="Enter a Task" v-model="typedTask"
                @keyup.enter="addTask()">
            <button class="btn btn-primary ms-3" @click="addTask()">+</button>
        </div>
        <div class="btn-group btn-group-lg d-flex my-4" role="group">
            <input type="radio" class="btn-check" value="total" name="btnDisplay" id="btnTotal" v-model="displayState"
                checked>
            <label class="btn btn-outline-primary" for="btnTotal">Total ({{ totalCount }})</label>

            <input type="radio" class="btn-check" value="active" name="btnDisplay" id="btnActive"
                v-model="displayState">
            <label class="btn btn-outline-primary" for="btnActive">Active ({{ activeCount }})</label>

            <input type="radio" class="btn-check" value="completed" name="btnDisplay" id="btnCompleted"
                v-model="displayState">
            <label class="btn btn-outline-primary" for="btnCompleted">Completed ({{ completedCount }})</label>
        </div>
        <div class="btn-group btn-group-lg d-flex my-4" role="group">
            <input type="radio" class="btn-check" value="all" name="btnPriority" id="btnAll" v-model="priorityState"
                checked>
            <label class="btn btn-outline-info" for="btnAll">All ({{ allCount }})</label>

            <input type="radio" class="btn-check" value="low" name="btnPriority" id="btnLow" v-model="priorityState">
            <label class="btn btn-outline-secondary" for="btnLow">Low ({{ lowCount }})</label>

            <input type="radio" class="btn-check" value="medium" name="btnPriority" id="btnMedium"
                v-model="priorityState">
            <label class="btn btn-outline-success" for="btnMedium">Medium ({{ mediumCount }})</label>

            <input type="radio" class="btn-check" value="high" name="btnPriority" id="btnHigh" v-model="priorityState">
            <label class="btn btn-outline-danger" for="btnHigh">High ({{ highCount }})</label>
        </div>
        <ul class="list-group list-group-flush" v-if="filteredTodos.length > 0">
            <li v-for="taskItem in filteredTodos" :key="taskItem.id" class="list-group-item fs-4">
                <TodoItem :taskItem="taskItem" @emitCompleted="emitCompletedEvent"/>
            </li>
        </ul>
    </div>
</template>

<style scoped>
li {
    text-align: start;
}
</style>