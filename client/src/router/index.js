import { createRouter, createWebHistory } from "vue-router";
import HomeView from "../../views/HomeView.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  linkActiveClass: "active",
  routes: [
    {
      path: "/",
      name: "home",
      component: HomeView,
    },
    // {
    //   path: "/product",
    //   name: "product",
    //   component: () => import("../../views/"),
    // },
    {
      path: "/supplier",
      name: "supplier",
      component: () => import("../../views/SupplierView.vue"),
    },
    // {
    //   path: "/employee",
    //   name: "employee",
    //   component: () => import("../../views/EmployeeView.vue"),
    // },
    {
      path: "/customer",
      name: "customer",
      component: () => import("../../views/CustomerView.vue"),
    },
  ],
});

export default router;
