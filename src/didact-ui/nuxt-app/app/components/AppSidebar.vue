<template>
  <Sidebar collapsible="icon">

    <SidebarHeader class="pt-4">
        <NuxtLink to="/" class="flex flex-row items-center">
          <img src="/didact-logo.png" width="31" height="31" class="mr-2" />
          <span class="text-2xl font-semibold" v-if="open">Didact</span>
        </NuxtLink>
    </SidebarHeader>

    <SidebarContent>
      <SidebarGroup v-if="open" class="mt-2">
        <EnvironmentCombobox />
      </SidebarGroup>
      <SidebarGroup>
        <!-- <SidebarGroupLabel>Application</SidebarGroupLabel> -->
        <SidebarGroupContent>
          <SidebarMenu>
            <SidebarMenuItem v-for="item in items" :key="item.title">
              <SidebarMenuButton as-child>
                <NuxtLink :to="item.url">
                  <!-- <component :is="item.icon" /> -->
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

            <SidebarMenuItem>
              <SidebarMenuButton as-child>
                <NuxtLink to="/api">
                  <!-- <component :is="item.icon" /> -->
                  <img src="/api-icon.png" width="17" height="17" />
                  <span>API Doc</span>
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
import { Calendar, Home, Inbox, Search, Settings } from 'lucide-vue-next'
import { useSidebar } from './ui/sidebar';
const { open } = useSidebar();

// Menu items.
const items = [
  {
    title: 'Dashboard',
    url: '/',
    icon: Home,
    iconFilename: 'dashboard-icon.png'
  },
  {
    title: 'Flows',
    url: '/flows',
    icon: Inbox,
    iconFilename: 'flows-icon.png'
  },
  {
    title: 'Flowruns',
    url: '/flowruns',
    icon: Calendar,
    iconFilename: 'flow-runs-icon.png'
  },
  {
    title: 'Deployments',
    url: '/deployments',
    icon: Search,
    iconFilename: 'deployments-icon.png'
  },
  {
    title: 'Engines',
    url: '/engines',
    icon: Search,
    iconFilename: 'engines-icon.png'
  },
  {
    title: 'Variables',
    url: '/variables',
    icon: Search,
    iconFilename: 'variables-icon.png'
  },
  {
    title: 'Secrets',
    url: '/secrets',
    icon: Settings,
    iconFilename: 'secrets-icon.png'
  },
  {
    title: 'Alerts',
    url: '/alerts',
    icon: Settings,
    iconFilename: 'alerts-icon.png'
  }
]
</script>