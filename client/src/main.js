import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import vueFloatLabel from "vue-float-label";

const app = createApp(App);
app.use(router);
app.use(vueFloatLabel);
app.mount("#app");
