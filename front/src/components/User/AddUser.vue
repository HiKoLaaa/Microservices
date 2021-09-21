<template>
  <User v-bind:is-editing="false"></User>
</template>

<script>
import User from "@/components/User/User";
export default {
  name: "AddUser",
  components: {User}
}
</script>