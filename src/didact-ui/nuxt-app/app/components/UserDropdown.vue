<template>
    <DropdownMenu>
        <DropdownMenuTrigger as-child>
            <SidebarMenuButton
                size="lg"
                class="data-[state=open]:bg-sidebar-accent data-[state=open]:text-sidebar-accent-foreground cursor-pointer"
            >
                <Avatar class="h-8 w-8 rounded-lg" alt="user">
                <img src="/user-icon.png" alt="user-icon" width="32" height="32" class="rounded-full p-1 bg-neutral-700" />
                </Avatar>
                <!-- <ChevronsUpDown class="ml-auto size-4" /> -->
            </SidebarMenuButton>
        </DropdownMenuTrigger>
        <DropdownMenuContent
            class="w-[--reka-dropdown-menu-trigger-width] min-w-56 rounded-lg"
            side="bottom"
            align="end"
            :side-offset="4"
        >
            <DropdownMenuLabel class="p-0 font-normal">
                <div class="flex items-center gap-2 px-1 py-1.5 text-left text-sm">
                <Avatar class="h-8 w-8 rounded-lg">
                    <AvatarFallback class="rounded-lg">
                    CN
                    </AvatarFallback>
                </Avatar>
                <div class="grid flex-1 text-left text-sm leading-tight">
                </div>
                </div>
            </DropdownMenuLabel>
            <DropdownMenuSeparator />
            <DropdownMenuGroup>
                <DropdownMenuItem>
                <Sparkles />
                Upgrade to Pro
                </DropdownMenuItem>
            </DropdownMenuGroup>
            <DropdownMenuSeparator />
            <DropdownMenuGroup>
                <DropdownMenuItem>
                <BadgeCheck />
                Account
                </DropdownMenuItem>
                <DropdownMenuItem>
                <CreditCard />
                Billing
                </DropdownMenuItem>
                <DropdownMenuItem>
                <Bell />
                Notifications
                </DropdownMenuItem>
            </DropdownMenuGroup>
            <DropdownMenuSeparator />
            <DropdownMenuItem>
                <LogOut />
                Log out
            </DropdownMenuItem>
        </DropdownMenuContent>
    </DropdownMenu>
</template>

<script setup lang="ts">
import { ChevronsUpDown, LogOut } from 'lucide-vue-next';
</script>