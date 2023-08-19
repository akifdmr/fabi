<!--<template>
  <router-view />
</template>

<script>
import './charts/ChartjsConfig';
</script>-->

<template>
    <Login v-if="$route.path.includes('/auth/') " />
    <Error v-else-if="$route.path === '/error'" />
    <Access v-else-if="$route.path === '/access'" />
    <NotFound v-else-if="$route.path === '/notfound'" />
    <Landing v-else-if="$route.path === '/landing'" />
    <ContactUs v-else-if="$route.path === '/contactus'" />
    <Dashboard v-else="$route.path == '/dashboard'" />
    <!--<router-view />-->
    <!--<App :topbarTheme="topbarTheme" :layoutMode="layoutMode" :menuTheme="menuTheme" @menu-theme="onMenuTheme" @topbar-theme="onTopbarThemeChange" @layout-mode-change="onLayoutChange" v-else />-->
</template>

<script>
    import Error from './pages/Error';
    import Access from './pages/Access';
    import Login from '.pages/Login';
    import NotFound from './pages/NotFound';
    import Landing from './pages/Landing';
    import ContactUs from './pages/ContactUs';
    import Dashboard from './pages/main/Dashboard'
    export default {
        data() {
            return {
                theme: 'blue',
                layoutMode: 'light',
                topbarTheme: 'blue',
                menuTheme: 'light',
            }
        },
        methods: {
            onLayoutChange(layout) {
                this.layoutMode = layout;
                this.$appState.layoutMode = layout;
                this.menuTheme = layout;

                const logo = document.getElementById('logo');
                logo.src = 'layout/images/logo-light.svg';

                if (layout === 'dark') {
                    this.topbarTheme = 'dark';
                }
                else {
                    this.topbarTheme = 'blue';
                }
            },
            onTopbarThemeChange(theme) {
                this.topbarTheme = theme.name;

                const themeName = theme.name;
                const logo = document.getElementById('logo');

                if (themeName == 'white' || themeName == 'yellow' || themeName == 'amber' || themeName == 'orange' || themeName == 'lime') {
                    logo.src = 'layout/images/logo-dark.svg';
                }
                else {
                    logo.src = 'layout/images/logo-light.svg';
                }
            },
            onMenuTheme(menuTheme) {
                this.menuTheme = menuTheme.name;
            }
        },
        components: {
            "Error": Error,
            "Access": Access,
            "Login": Login,
            "NotFound": NotFound,
            "Landing": Landing,
            "ContactUs": ContactUs,
            "Dashboard": Dashboard
        }
    }
</script>

<style scoped>
</style>