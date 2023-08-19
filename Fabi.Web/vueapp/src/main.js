// main.js
import { createApp } from 'vue';
import App from './App.vue';
import "./registerServiceWorker";
import router from "./router/index";
import store from "./store/index";
const app = createApp(App);
app.use(router);
app.use(store);
//setupStore();
app.mount('#app');