<script setup lang="ts">
import TodoPage from "./components/TodoPage.vue";
// import SplitPanes from "./components/SplitPanes.vue";
</script>

<template>
  <Suspense>
    <TodoPage />
  </Suspense>
  <!-- <SplitPanes /> -->
</template>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
</style>
