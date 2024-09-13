<template>
  <div v-if="showError" class="error-message">
    <p>{{ message }}</p>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import type { PropType } from 'vue'; // Use 'import type' para importar tipos

export default defineComponent({
  name: 'ErrorToggle',
  props: {
    showError: {
      type: Boolean as PropType<boolean>,
      required: true,
    },
    message: {
      type: String as PropType<string>,
      required: true,
      default: 'Invalid input! Please enter a valid value.',
    },
  },
});
</script>

<style scoped>
.error-message {
  margin-top: 20px;
  padding: 10px;
  background-color: #ffcccc; /* Red background for error */
  color: #b20000; /* Dark red text for contrast */
  border-radius: 5px;
  text-align: center;
  font-weight: bold;
  font-size: 1.2rem;
}
</style>
