<template>
  <div class="container">
    <div class="row">
      <div class="col-5">
        <form>
          <div class="mb-3">
            <input
              type="text"
              class="form-control"
              id="companyName"
              placeholder="Company Name"
              name="companyName"
              required
            />
          </div>
          <div class="mb-3">
            <input
              type="text"
              id="contactName"
              class="form-control"
              placeholder="Contact Name"
              name="contactName"
              required
            />
          </div>
          <div class="mb-3">
            <input
              type="text"
              id="phone"
              class="form-control"
              placeholder="Phone"
              name="phone"
              required
            />
          </div>
          <div class="mb-3">
            <input
              type="text"
              id="city"
              class="form-control"
              placeholder="City"
              name="city"
              required
            />
          </div>
          <div class="mb-3">
            <input
              type="text"
              id="country"
              class="form-control"
              placeholder="Country"
              name="country"
              required
            />
          </div>
          <button type="submit" class="btn btn-primary" @click="save">
            Submit
          </button>
        </form>
      </div>
      <div class="col-7">
        <select v-model="selected">
          <option
            v-for="count in counts"
            v-bind:value="{ id: count.id, text: count.value }"
          >
            {{ count.value }}
          </option>
        </select>
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
        <div>
          <button
            @click="previous"
            class="btn btn-primary me-2"
            v-if="canDecrease"
          >
            Previous
          </button>
          <button @click="next" class="btn btn-primary">Next</button>
        </div>
      </div>
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
      counts: [
        { id: 10, value: 10 },
        { id: 15, value: 15 },
        { id: 20, value: 20 },
      ],
      selected: "",
    };
  },
  mounted() {
    this.loadSupplier();
  },
  methods: {
    loadSupplier() {
      axios
        .get(
          `https://localhost:7273/api/Supplier/list?count=${this.selected.id}&page=${this.page}`
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
    save() {
      let newSupplier = {
        companyName: $("#companyName").val(),
        contactName: $("#contactName").val(),
        city: $("#city").val(),
        country: $("#country").val(),
        phone: $("#phone").val(),
      };

      fetch(`https://localhost:7273/api/Supplier/add`, {
        method: "POST",
        body: JSON.stringify(newSupplier),
      })
        .then((res) => res.json())
        .then((data) => console.log(data));
    },
  },
  computed: {
    canDecrease() {
      return this.page > 1;
    },
  },
};
</script>
