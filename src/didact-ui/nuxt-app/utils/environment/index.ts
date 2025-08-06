/**
 * Determines if the single page app is currently running within the Nuxt dev server or not.
 * @returns 
 */
const isDev = () => {
    return import.meta.dev;
}

export { isDev }