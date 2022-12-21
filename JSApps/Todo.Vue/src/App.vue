<template>
  <!-- <Suspense>
    <TodoPage />
  </Suspense> -->
  <SplitPanes />
</template>

<script>
// import TodoPage from "./components/TodoPage.vue";
import SplitPanes from "./components/SplitPanes.vue";

export default {
  name: "App",
  components: {
    // TodoPage,
    SplitPanes,
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
</style>
