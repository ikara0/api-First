<template>
  <div id="tblCustomer" class="container">
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
          <tr v-for="item in customerData">
            <td>{{ item.id }}</td>
            <td>{{ item.companyName }}</td>
            <td>{{ item.contactName }}</td>
            <td>{{ item.phone }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="container">
    <button @click="previous" class="btn btn-primary me-2" v-if="canDecrease">
      Previous
    </button>
    <button @click="next" class="btn btn-primary">Next</button>
  </div>
</template>

<script>
export default {
  name: "Customer",
  data() {
    return {
      customerData: null,
      page: 1,
      count: 10,
    };
  },
  mounted() {
    this.loadCustomer();
  },
  methods: {
    loadCustomer() {
      axios
        .get(
          `https://localhost:7273/api/customer/customer-list?count=${this.count}&page=${this.page}`
        )
        .then((response) => {
          this.customerData = response.data.data;
        });
    },
    next() {
      this.page++;
      this.loadCustomer();
    },
    previous() {
      this.page--;
      this.loadCustomer();
    },
  },
  computed: {
    canDecrease() {
      return this.page > 1;
    },
  },
};
</script>
