import { createRouter, createWebHistory } from 'vue-router';
import { coreServices } from './services';
import Dashboard from './pages/main/Dashboard.vue';
import Login from './pages/main/Login.vue';
import { isAuthenticated } from '../core/services/tokenService'

const routes = [{
        path: '/',
        name: 'Dashboard',
        component: Dashboard,
        meta: { requiresAuth: true },
    },
    {
        path: '/login',
        name: 'Login',
        component: Login,
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
    scrollBehavior() {
        return { left: 0, top: 0 };
    }
});

router.beforeEach(async(to) => {
    if (!isAuthenticated() && !to.path.includes('/auth/')) {
        // redirect the user to the login page
        return { path: '/login' }
    }
});

export default router;