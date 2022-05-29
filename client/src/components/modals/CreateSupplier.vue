<template>
  <div
    class="modal fade"
    id="exampleModal"
    tabindex="-1"
    aria-labelledby="exampleModalLabel"
    aria-hidden="true"
  >
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">
            Tedarikçi Ekleme Paneli
          </h5>
          <button
            type="button"
            class="btn-close"
            data-bs-dismiss="modal"
            aria-label="Close"
          ></button>
        </div>
        <div class="modal-body">
          <div v-if="hasError" class="alert alert-warning m-1">
            Veriler doğrulanamadı...
          </div>
          <form class="mt-3">
            <div class="mb-3">
              <input
                type="text"
                class="form-control"
                id="companyName"
                placeholder="Company Name"
                name="companyName"
                v-model="companyName"
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
                v-model="contactName"
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
                v-model="phone"
                required
              />
            </div>
            <div class="mb-3">
              <input
                type="text"
                id="adress"
                class="form-control"
                placeholder="Address"
                name="address"
                v-model="address"
                required
              />
            </div>
            <div class="mb-3">
              <input
                type="text"
                id="region"
                class="form-control"
                placeholder="Region"
                name="region"
                v-model="region"
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
                v-model="city"
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
                v-model="country"
                required
              />
            </div>
            <div class="modal-footer">
              <button
                type="button"
                class="btn btn-secondary"
                data-bs-dismiss="modal"
              >
                Close
              </button>
              <button @click="save" type="submit" class="btn btn-info">
                <span class="fa-solid fa-save"></span> Kaydet
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import axios from "axios";
export default {
  emits: ["success"],
  name: "CreateSupplier",
  data() {
    return {
      instance: null,
      companyName: null,
      contactName: null,
      country: null,
      city: null,
      phone: null,
      address: null,
      region: null,
      hasError: false,
    };
  },
  mounted() {
    this.instance = new bootstrap.Modal(
      document.getElementById("exampleModal")
    );
  },
  methods: {
    open() {
      this.hasError = false;
      this.instance.show();
    },
    save() {
      this.hasError = false;
      let newSupplier = {
        companyName: this.companyName,
        contactName: this.contactName,
        city: this.city,
        country: this.country,
        phone: this.phone,
        address: this.address,
        region: this.region,
      };
      axios
        .post(`https://localhost:7273/api/Supplier/add`, newSupplier)
        .then((data) => {
          if (data.data) {
            this.instance.hide();
            this.$emit("success");
          }
        })
        .catch(() => {
          this.hasError = true;
        });
    },
  },
};
</script>
<style scoped></style>
