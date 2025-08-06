<template>
  <div>
    <NuxtRouteAnnouncer />
    <NuxtWelcome />
    <!-- <div class="m-16">
      <Button label="Verify" />
      <Card style="width: 25rem; overflow: hidden">
    <template #header>
    </template>
    <template #title>Advanced Card</template>
    <template #subtitle>Card subtitle</template>
    <template #content>
        <p class="m-0">
            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore sed consequuntur error repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis, culpa ratione quam perferendis esse, cupiditate neque
            quas!
        </p>
    </template>
    <template #footer>
        <div class="flex gap-4 mt-1">
            <Button label="Cancel" severity="secondary" outlined class="w-full" />
            <Button label="Save" class="w-full" />
        </div>
    </template>
</Card>
    </div> -->
  </div>
</template>

<script setup lang="ts">
import { getEnvironmentVariables } from './utils/environment-variables';

const environmentVariables = await getEnvironmentVariables();
console.log('The dummy env variable is: ', environmentVariables.didactEngineBaseUrl);
</script>