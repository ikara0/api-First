<template>
  <div>
    <ul class="nav nav-pills mb-3 mt-2" role="tablist">
      <li class="nav-item" role="presentation">
        <button
          class="nav-link"
          id="pills-profile-tab"
          data-bs-toggle="pill"
          data-bs-target="#suppliers"
          type="button"
          role="tab"
        >
          Supplier
        </button>
      </li>
      <li class="nav-item" role="presentation">
        <button
          class="nav-link"
          id="pills-contact-tab"
          data-bs-toggle="pill"
          data-bs-target="#customers"
          type="button"
          role="tab"
        >
          Customer
        </button>
      </li>
    </ul>
    <div class="tab-content" id="pills-tabContent">
      <div
        class="tab-pane fade show active"
        id="suppliers"
        role="tabpanel"
        aria-labelledby="pills-home-tab"
        tabindex="0"
      >
        <Supplier />
      </div>
      <div
        class="tab-pane fade"
        id="customers"
        role="tabpanel"
        aria-labelledby="pills-profile-tab"
        tabindex="0"
      >
        <Customer />
      </div>
    </div>
  </div>
</template>

<script>
import Number from "./components/Number.vue";
import Customer from "./components/Customer.vue";
import Supplier from "./components/Supplier.vue";

export default {
  components: {
    Number,
    Customer,
    Supplier,
  },
};
</script>
