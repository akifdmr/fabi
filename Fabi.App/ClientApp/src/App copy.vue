<template>
  <router-view />
</template>

<script>
import { createRouter, createWebHistory } from 'vue-router'
import { routesArr } from './router'
import './charts/ChartjsConfig';

const baseUrl =import.meta.env.BASE_URL;

const router = createWebHistory({
    history: routerHistory,
    basename: baseUrl,
    routesArr
});
if (import.meta.hot) {
  import.meta.hot.dispose(() => router.dispose())
}

export default function App() {
  return <RouterProvider router={router} fallbackElement={<Fallback />} />
}

export function Fallback() {
  return <p>Performing initial data load</p>
}
</script>

