<template>
  <Popover v-model:open="open">
    <PopoverTrigger as-child>
      <Button
        variant="outline"
        role="combobox"
        :aria-expanded="open"
        class="w-[200px] justify-between"
      >
        {{
          value
            ? environments.find(environment => environment.id === value)?.name
            : 'Select environment...'
        }}
        <ChevronsUpDownIcon class="ml-2 h-4 w-4 shrink-0 opacity-50" />
      </Button>
    </PopoverTrigger>
    <PopoverContent class="w-[200px] p-0">
      <Command>
        <CommandInput placeholder="Search environment..." />
        <CommandList>
          <CommandEmpty>No environment found.</CommandEmpty>
          <CommandGroup>
            <CommandItem
              v-for="environment in environments"
              :key="environment.id"
              :value="environment.id"
              @select="() => {
                value = value === environment.id ? 0 : environment.id
                open = false
              }"
            >
              <CheckIcon
                :class="cn(
                  'mr-2 h-4 w-4',
                  value === environment.id ? 'opacity-100' : 'opacity-0',
                )"
              />
              {{ environment.name }}
            </CommandItem>
          </CommandGroup>
        </CommandList>
      </Command>
    </PopoverContent>
  </Popover>
</template>

<script setup lang="ts">
import { CheckIcon, ChevronsUpDownIcon } from 'lucide-vue-next'
import { cn } from '@/lib/utils'
const { getEnvironments } = useEnvironments()

const environments = await getEnvironments();

const open = ref(false)
const value = ref(0)
</script>