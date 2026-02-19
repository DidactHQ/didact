<template>
    <div class="bg-neutral-900 py-4 flex flex-row">
        <SidebarTrigger class="mx-2" />
        <Separator orientation="vertical" class="" />
        <h1 class="ml-4 text-center font-semibold">{{ pathTitle }}</h1>
            <!-- <Avatar class="place-self-end">
      <AvatarImage src="https://github.com/shadcn.png" alt="@shadcn" />
      <AvatarFallback>CN</AvatarFallback>
    </Avatar> -->
    </div>
</template>

<script setup lang="ts">
const route = useRoute();

const pathTitle = computed(() => {
    if (route.meta.label)
        return route.meta.label;
    
    return !route.name
        ? null
        : route.name?.toString().charAt(0).toUpperCase() + route.name?.toString().slice(1);
})
</script>