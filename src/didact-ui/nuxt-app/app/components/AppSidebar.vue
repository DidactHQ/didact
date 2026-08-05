<template>
  <Sidebar collapsible="icon">

    <SidebarHeader class="flex flex-col pt-2 justify-items-center">
        <NuxtLink to="/" class="py-4 flex flex-row items-center">
          <img src="/didact-logo.png" width="31" height="31" class="mr-2" />
          <span class="text-2xl font-semibold" v-show="open">Didact</span>
        </NuxtLink>
    </SidebarHeader>

    <SidebarContent>
      <SidebarGroup v-show="open" class="mt-2">
        <EnvironmentCombobox />
      </SidebarGroup>
      <SidebarGroup>
        <!-- <SidebarGroupLabel>Application</SidebarGroupLabel> -->
        <SidebarGroupContent>
          <SidebarMenu>
            <SidebarMenuItem v-for="item in items" :key="item.title">
              <SidebarMenuButton as-child :is-active="isActiveRoute(item.path)">
                <NuxtLink :to="item.path">
                  <img :src="'/' + item.iconFilename" width="17" height="17" />
                  <span>{{ item.title }}</span>
                </NuxtLink>
              </SidebarMenuButton>
            </SidebarMenuItem>
          </SidebarMenu>
        </SidebarGroupContent>
      </SidebarGroup>
    </SidebarContent>

    <SidebarFooter>
        <SidebarMenu>
            <SidebarMenuItem>
              <SidebarMenuButton as-child>
                <NuxtLink to="https://console.didact.dev" target="_blank">
                  <!-- <component :is="item.icon" /> -->
                  <img src="/external-icon.png" width="17" height="17" />
                  <span>Console</span>
                </NuxtLink>
              </SidebarMenuButton>
            </SidebarMenuItem>

            <!-- <SidebarMenuItem>
              <SidebarMenuButton as-child>
                <NuxtLink to="/api">
                  <component :is="item.icon" />
                  <img src="/api-icon.png" width="17" height="17" />
                  <span>API Doc</span>
                </NuxtLink>
              </SidebarMenuButton>
            </SidebarMenuItem> -->

            <SidebarMenuItem>
              <SidebarMenuButton as-child>
                <NuxtLink to="/help">
                  <!-- <component :is="item.icon" /> -->
                  <img src="/help-icon.png" width="17" height="17" />
                  <span>Help</span>
                </NuxtLink>
              </SidebarMenuButton>
            </SidebarMenuItem>

            <SidebarMenuItem>
              <SidebarMenuButton as-child>
                <NuxtLink to="/settings">
                  <!-- <component :is="item.icon" /> -->
                  <img src="/settings-icon.png" width="17" height="17" />
                  <span>Settings</span>
                </NuxtLink>
              </SidebarMenuButton>
            </SidebarMenuItem>
          </SidebarMenu>
    </SidebarFooter>
  </Sidebar>
</template>

<script setup lang="ts">
import { useSidebar } from './ui/sidebar';
const { open } = useSidebar();
const { items } = useSidebarData();
const route = useRoute();

const isActiveRoute = (path: string) => {
  if (path === '/')
    return route.path === '/';
  
  return route.path.includes(path);
}
</script>