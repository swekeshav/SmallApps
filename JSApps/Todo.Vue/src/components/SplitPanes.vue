<script setup>
import { Splitpanes, Pane } from "splitpanes";
import "splitpanes/dist/splitpanes.css";
</script>
<template>
  <splitpanes class="default-theme" style="height: 100vh">
    <pane min-size="20" max-size="70">
      <!-- <img src="../assets/images/mountains.jpg" alt="Mountains" /> -->
      1
    </pane>
    <pane min-size="20" max-size="70">
      <!-- <img src="../assets/images/mountains.jpg" alt="Mountains" /> -->
      2
    </pane>
  </splitpanes>
</template>
<style>
.splitpanes__pane {
  background-image: url("../assets/images/mountains.jpg");
}
</style>
