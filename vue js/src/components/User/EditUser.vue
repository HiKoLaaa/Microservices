<template>
  <User v-bind:is-editing="true"></User>
</template>

<script>
import User from "@/components/User/User";
export default {
  name: "EditUser",
  components: {
    User
  }
}
</script>