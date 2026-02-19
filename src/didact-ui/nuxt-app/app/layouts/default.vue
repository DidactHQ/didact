<template>
  <SidebarProvider>
    <AppSidebar />
    <div class="flex flex-col w-full">
      <AppTopbar />
      <PageContainer>
        <slot />
      </PageContainer>
    </div>
  </SidebarProvider>
</template>