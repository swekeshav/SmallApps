<template>
  <Suspense>
    <TodoPage />
  </Suspense>
</template>

<script>
import TodoPage from './components/TodoPage.vue'

export default {
  name: 'App',
  components: {
    TodoPage
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
