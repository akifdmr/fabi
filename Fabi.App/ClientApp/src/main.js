import { createApp } from 'vue'
import router from './router'
import App from './App.vue'

import './css/style.css'

const baseUrl =
    import.meta.env.BASE_URL;

if (
    import.meta.hot) {
    import.meta.hot.dispose(() => router.dispose())
}

const app = createApp(App)
app.use(router)
app.mount('#app')