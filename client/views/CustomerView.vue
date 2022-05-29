<template>
  <div id="tblCustomer" class="container mt-3">
    <div>
      <table class="table table-dark table-striped">
        <thead>
          <tr>
            <th scope="col">#</th>
            <th scope="col">Şirket Adı</th>
            <th scope="col">Temsilci Adı</th>
            <th scope="col">Adres</th>
            <th scope="col">Telefon</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="item in customerData">
            <td>{{ item.id }}</td>
            <td>{{ item.companyName }}</td>
            <td>{{ item.contactName }}</td>
            <td>{{ item.address }}</td>
            <td>{{ item.phone }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="d-flex justify-content-center">
    <button
      @click="previous"
      class="btn btn-outline-info m-1"
      :disabled="page <= 1"
    >
      <i class="bi bi-arrow-left"></i>
    </button>
    <button
      @click="next"
      class="btn btn-outline-info m-1"
      :disabled="totalCount <= 0"
    >
      <i class="bi bi-arrow-right"></i>
    </button>
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
      totalCount: 0,
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
          this.totalCount = response.data.totalCount;
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
};
</script>
