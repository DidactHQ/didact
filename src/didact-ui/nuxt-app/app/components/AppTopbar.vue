<template>
    <div class="bg-neutral-900 py-4 pr-4 flex flex-row items-center">
        <SidebarTrigger class="mx-2" />
        <Separator orientation="vertical" />
        <h1 class="ml-4 text-center font-semibold">{{ title }}</h1>
        <!-- Wrap in div to space apart -->
        <div class="ml-auto">
            <UserDropdown />
        </div>
    </div>
</template>

<script setup lang="ts">
const route = useRoute();
const title = computed(() => {
    return route.name;
})
</script>