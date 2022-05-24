<template>
  <div class="container">
    <div>
      <table class="table table-dark table-striped">
        <thead>
          <tr>
            <th scope="col">#</th>
            <th scope="col">Şirket Adı</th>
            <th scope="col">Temsilci Adı</th>
            <th scope="col">Telefon</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="item in supplierData">
            <td>{{ item.id }}</td>
            <td>{{ item.companyName }}</td>
            <td>{{ item.contactName }}</td>
            <td>{{ item.phone }}</td>
          </tr>
        </tbody>
      </table>
    </div>
    <div>
      <button @click="previous" class="btn btn-primary me-2" v-if="canDecrease">
        Previous
      </button>
      <button @click="next" class="btn btn-primary">Next</button>
    </div>
  </div>
</template>

<script>
export default {
  name: "Supplier",
  data() {
    return {
      supplierData: null,
      page: 1,
      count: 10,
    };
  },
  mounted() {
    this.loadSupplier();
  },
  methods: {
    loadSupplier() {
      axios
        .get(
          `https://localhost:7273/api/Supplier/list?count=${this.count}&page=${this.page}`
        )
        .then((response) => {
          this.supplierData = response.data.data;
        });
    },
    next() {
      this.page++;
      this.loadSupplier();
    },
    previous() {
      this.page--;
      this.loadSupplier();
    },
  },
  computed: {
    canDecrease() {
      return this.page > 1;
    },
  },
};
</script>
