<script setup>
import AppSideBar from "./components/AppSideBar.vue"
</script>

<template>
  <div class="row">
    <div class="col-2">
        <AppSideBar />
    </div>
    <div class="col-10">
      <div class="container" style="margin-left:2rem !important">
        <RouterView />
      </div>
    </div>
  </div>
</template>
<style>
</style>

