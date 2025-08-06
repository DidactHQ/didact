// https://nuxt.com/docs/api/configuration/nuxt-config

import tailwindcss from "@tailwindcss/vite";
import Aura from '@primeuix/themes/aura';

export default defineNuxtConfig({
  compatibilityDate: '2024-11-01',
  devtools: { enabled: true },
  vite: {
    plugins: [
      tailwindcss(),
    ],
  },
  css: ['~/assets/css/main.css'],
  modules: [
    '@primevue/nuxt-module'
  ],
  primevue: {
    options: {
        theme: {
            preset: Aura
        }
    },
    components: {
      include: '*',
      // Need to temporarily exclude PrimeVue form components because of npm install bug.
      // See https://github.com/primefaces/primevue/issues/7434.
      // Also need to exclude Editor and Chart because of weird build issues.
      // See https://github.com/primefaces/primevue-nuxt-module/issues/16#issuecomment-1794482993.
      exclude: ['Form', 'FormField', 'Editor', 'Chart']
    }
  },
  ssr: false,
  nitro: {
    output: {
      publicDir: '../dotnet-app/DidactUi/wwwroot'
    }
  }
})
