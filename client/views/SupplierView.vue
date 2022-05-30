<template>
  <div>
    <Transition>
      <div v-if="isSuccess" class="alert alert-success mt-3">
        İşlem Başarılı :)
      </div>
    </Transition>
    <Transition>
      <div v-if="isFailed" class="alert alert-danger mt-3">
        İşlem Başarısız :(
      </div>
    </Transition>
    <button @click="add" class="btn btn-outline-info m-1">
      <i class="fa-solid fa-user-plus"></i> Add New
    </button>
    <div
      v-if="loading"
      style="min-height: 500px !important"
      class="d-flex justify-content-center align-items-center"
    >
      <div class="spinner-grow text-primary" role="status"></div>
    </div>
    <div v-else class="table-responsive">
      <table class="table table-dark table-striped mt-3">
        <thead>
          <tr>
            <th scope="col">#</th>
            <th scope="col">Şirket Adı</th>
            <th scope="col">Temsilci Adı</th>
            <th scope="col">Adres</th>
            <th scope="col">Telefon</th>
            <th></th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="item in supplierData" :key="item.id">
            <td>{{ item.id }}</td>
            <td>{{ item.companyName }}</td>
            <td>{{ item.contactName }}</td>
            <td>{{ item.address }}</td>
            <td>{{ item.phone }}</td>
            <td>
              <a
                @click="deleteSupplier(item.id)"
                class="btn btn-sm btn-outline-danger"
                ><i class="bi bi-trash"></i
              ></a>
            </td>
            <td>
              <a
                @click="updateSupplier(item.id)"
                class="btn btn-sm btn-outline-warning"
                ><i class="bi bi-pen"></i
              ></a>
            </td>
          </tr>
        </tbody>
      </table>
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
  </div>
  <div>
    <DeleteConfirm ref="deleteModal" @yes="deleteOk" />
    <CreateSupplier ref="createModal" @success="save" />
    <UpdateSupplier ref="updateModal" />
  </div>
  <div></div>
</template>

<script>
import axios from "axios";
import CreateSupplier from "../src/components/modals/CreateSupplier.vue";
import DeleteConfirm from "../views/confirm/DeleteConfirm.vue";
import UpdateSupplier from "../src/components/modals/UpdateSupplier.vue";
export default {
  name: "Supplier",
  data() {
    return {
      page: 1,
      count: 10,
      supplierData: [],
      totalCount: 0,
      isSuccess: false,
      isFailed: false,
      loading: false,
      selectedId: null,
    };
  },
  mounted() {
    this.loadSupplier();
  },
  components: {
    CreateSupplier,
    DeleteConfirm,
    UpdateSupplier,
  },
  methods: {
    loadSupplier() {
      this.loading = true;
      setTimeout(() => {
        axios
          .get(
            `https://localhost:7273/api/Supplier/list?count=${this.count}&page=${this.page}`
          )
          .then((response) => {
            this.supplierData = response.data.data;
            this.totalCount = response.data.totalCount;
          })
          .finally(() => {
            this.loading = false;
          });
      }, 1000);
    },
    add() {
      this.$refs.createModal.open();
    },
    deleteSupplier(id) {
      this.selectedId = id;
      this.$refs.deleteModal.open();
    },
    deleteOk() {
      axios
        .delete(`https://localhost:7273/api/Supplier/delete/${this.selectedId}`)
        .then((response) => {
          if (response) {
            this.isSuccess = true;
            this.loadSupplier();
          }
        })
        .catch((error) => {
          if (error) {
            this.isFailed = true;
          }
        })
        .finally(() => {
          setTimeout(() => {
            this.isSuccess = false;
            this.isFailed = false;
          }, 4000);
        });
    },
    updateSupplier(id) {
      this.selectedId = id;
      this.$refs.updateModal.open(this.selectedId);
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
      this.isSuccess = true;
      this.loadSupplier();
      setTimeout(() => {
        this.isSuccess = false;
      }, 3000);
    },
  },
};
</script>
<style scoped>
.v-enter-active,
.v-leave-active {
  transition: opacity 0.5s ease;
}

.v-enter-from,
.v-leave-to {
  opacity: 0;
}
</style>
