<template>
  <main class="bg-white">

    <div class="relative flex">

      <!-- Content -->
      <div class="w-full md:w-1/2">
        <div class="flex flex-col h-full min-h-screen after:flex-1">

          <div class="flex-1">
            <div class="flex items-center justify-between h-16 px-4 sm:px-6 lg:px-8">
              <!-- Logo -->
              <router-link class="block" to="/">
                <svg width="32" height="32" viewBox="0 0 32 32">
                  <defs>
                    <linearGradient x1="28.538%" y1="20.229%" x2="100%" y2="108.156%" id="logo-a">
                      <stop stop-color="#A5B4FC" stop-opacity="0" offset="0%" />
                      <stop stop-color="#A5B4FC" offset="100%" />
                    </linearGradient>
                    <linearGradient x1="88.638%" y1="29.267%" x2="22.42%" y2="100%" id="logo-b">
                      <stop stop-color="#38BDF8" stop-opacity="0" offset="0%" />
                      <stop stop-color="#38BDF8" offset="100%" />
                    </linearGradient>
                  </defs>
                  <rect fill="#6366F1" width="32" height="32" rx="16" />
                  <path d="M18.277.16C26.035 1.267 32 7.938 32 16c0 8.837-7.163 16-16 16a15.937 15.937 0 01-10.426-3.863L18.277.161z" fill="#4F46E5" />
                  <path d="M7.404 2.503l18.339 26.19A15.93 15.93 0 0116 32C7.163 32 0 24.837 0 16 0 10.327 2.952 5.344 7.404 2.503z" fill="url(#logo-a)" />
                  <path d="M2.223 24.14L29.777 7.86A15.926 15.926 0 0132 16c0 8.837-7.163 16-16 16-5.864 0-10.991-3.154-13.777-7.86z" fill="url(#logo-b)" />
                </svg>
              </router-link>
            </div>
          </div>          

          <div class="max-w-sm px-4 py-8 mx-auto">
            <h1 class="mb-6 text-3xl font-bold text-slate-800">MyFabi Operasyon Merkezi</h1>
            <!-- Form -->
            <form @submit="$event" >
              <div class="space-y-4">
                <div>
                  <label class="block mb-1 text-sm font-medium" for="email">Email Address</label>
                  <input type="text" v-model="username" placeholder="Kullanıcı adı" class="w-full form-input"/>
                </div>
                <div>
                  <label class="block mb-1 text-sm font-medium" for="password">Password</label>
                  <input id="password" class="w-full form-input" type="password" v-model="password" placeholder="Şifre" autoComplete="on" />
                </div>
              </div>
              <div class="flex items-center justify-between mt-6">
                <button type="submit" @click="login">Giriş</button>

                <router-link class="ml-3 text-white bg-indigo-500 btn hover:bg-indigo-600" to="/">Sign In</router-link>
              </div>
            </form>
            <!-- Footer -->
          </div>

        </div>
      </div>

      <!-- Image -->
      <div class="absolute top-0 bottom-0 right-0 hidden md:block md:w-1/2" aria-hidden="true">
        <img class="object-cover object-center w-full h-full" src="../../../public/logo.png" width="760" height="1024" alt="Authentication" />
        <img class="absolute left-0 hidden ml-8 -translate-x-1/2 top-1/4 lg:block" src="../../images/auth-decoration.png" width="218" height="224" alt="Authentication decoration" />
      </div>

    </div>

  </main>
</template>
<script>
export default  {
  data() {
    return {
      username: '',
      password: ''
    }
  },
  methods: {
    login() {
      // kullanıcı adı ve şifreyi kontrol ediyoruz
      if (this.username === 'admin' && this.password === '123') {
        // eğer kullanıcı adı ve şifre doğruysa, kullanıcının oturum açtığını belirten bir anahtar-değer çifti localStorage'a ekliyoruz
        localStorage.setItem('isLoggedIn', true)

        // kullanıcıyı ana sayfaya yönlendiriyoruz
        this.$router.push({ name: 'Dashboard' })
      } else {
        // kullanıcı adı veya şifre yanlışsa hata mesajı gösteriyoruz
        alert('Kullanıcı adı veya şifre yanlış!')
      }
    }
  }
}
</script>