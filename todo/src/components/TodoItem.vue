<script setup>
import { defineProps, defineEmits, ref, watch } from 'vue';

const props = defineProps({
    taskItem: Object
})

const emits = defineEmits(['emitCompleted', 'emitDeleted'])

const item = ref(props.taskItem);
const completed = ref(props.taskItem.completed);

watch(completed, () => {
    emits('emitCompleted', item, completed)
})

</script>

<template>
    <Transition>
        <div class="form-check d-flex">
            <input class="form-check-input" type="checkbox" v-model="completed" id="taskItem.id">
            <label class="form-check-label ms-3" for="taskItem.id">
                {{ props.taskItem.todo }}
            </label>
            <button class="ms-auto btn btn-danger" @click="$emit('emitDeleted', taskItem.id)">Delete</button>
        </div>
    </Transition>
</template>

<style scoped>
/* we will explain what these classes do next! */
.v-enter-active,
.v-leave-active {
    transition: opacity 0.5s ease;
}

.v-enter-from,
.v-leave-to {
    opacity: 0;
}
</style>