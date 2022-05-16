<script setup>
import { ref } from 'vue';

const typedTask = ref('');
const taskList = ref([]);
function addTask() {
    if (typedTask.value === '')
        return;
    taskList.value.push(typedTask.value);
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
        <ul class="list-group list-group-flush" v-if="taskList.length > 0">
            <li v-for="taskItem of taskList" :key="taskItem" class="list-group-item fs-4">
                {{ taskItem }}
            </li>
        </ul>
    </div>
</template>

<style scoped>
li {
    text-align: start;
}
</style>