<template>
  <div>
    Sayfanın Mevcut Değeri <span> {{ number }}</span>
  </div>
  <button @click="increase" class="btn btn-primary me-2">Artır</button>
  <button @click="decrease" class="btn btn-primary" v-if="canDecrease">
    Azalt
  </button>
</template>

<script>
export default {
  name: "Number",
  props: {
    value: {
      type: Number,
    },
  },
  mounted() {
    this.number = this.value ?? 0;
  },
  data() {
    return {
      number: 0,
    };
  },
  methods: {
    increase() {
      this.number++;
    },
    decrease() {
      this.number--;
    },
  },
  computed: {
    canDecrease() {
      return this.number ?? 0;
    },
  },
};
</script>
