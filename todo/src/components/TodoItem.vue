<script setup>
    import { defineProps, ref } from 'vue';

    const props = defineProps({
        taskItem: Object
    })

    const completed = ref(props.taskItem.completed);
</script>

<template>
    <div class="form-check">
        <input class="form-check-input" type="checkbox" v-model="completed" id="taskItem.id">
        <label class="form-check-label" for="taskItem.id">
            {{ props.taskItem.title }}
        </label>
    </div>
</template>