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
            environments.find(environment => environment.id === selectedEnvironment.id)?.name
            ? environments.find(environment => environment.id === selectedEnvironment.id)?.name
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
              @select="selectEnvironment(environment)"
            >
              <CheckIcon
                :class="cn(
                  'mr-2 h-4 w-4',
                  selectedEnvironment.id === environment.id ? 'opacity-100' : 'opacity-0',
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
const { getEnvironments, selectedEnvironment } = useEnvironments()

const open = ref(false)
const environments = await getEnvironments();

const selectEnvironment = (environment: Environment) => {
  selectedEnvironment.value = environment;
  open.value = false;
}
</script>