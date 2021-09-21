<template>
  <div class="action-buttons">
    <button class="btn btn-outline-primary m-1" @click="editUser">
      <i class="fa fa-edit"></i>
    </button>
    <button class="btn btn-outline-dark m-1" @click="deleteUser">
      <i class="fa fa-trash"></i>
    </button>
  </div>
</template>
<script>
import "font-awesome/css/font-awesome.min.css"
import {deleteUser} from "@/requests/users";
import {router} from "@/main";

export default {
  name: "ActionButtons",
  methods: {
    editUser() {
      router.push({path: `users/${this.data.account_id}`});
    },
    async deleteUser() {
      await deleteUser(this.data.account_id);
    }
  },
  props: {
    data: {
      type: Object,
      required: true
    },
  },
};
</script>