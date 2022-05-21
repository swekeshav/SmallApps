<script setup>
import { reactive, ref } from 'vue';
import TodoItem from './TodoItem.vue';

const typedTask = ref('');
var taskList = await fetch('https://jsonplaceholder.typicode.com/todos')
    .then((response) => response.json());
var lastId = Math.max.apply(Math, taskList.map(function (task) { return task.id }));
const taskSet = reactive(taskList);

function addTask() {
    if (typedTask.value === '')
        return;
    taskSet.unshift({ userId: 1, id: ++lastId, title: typedTask.value, completed: false });
    typedTask.value = '';
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
        <ul class="list-group list-group-flush" v-if="taskSet.length > 0">
            <li v-for="taskItem in taskSet" :key="taskItem.id" class="list-group-item fs-4">
                <TodoItem :taskItem="taskItem" />
            </li>
        </ul>
    </div>
</template>

<style scoped>
li {
    text-align: start;
}
</style>