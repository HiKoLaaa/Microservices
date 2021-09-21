<template>
  <div>
    <div class="row">
      <Account v-bind:account="getAccount"/>
    </div>
    <div class="row">
      <Profile v-bind:profile="getProfile"/>
    </div>
  </div>
</template>

<script>
import Account from "@/components/User/Account";
import Profile from "@/components/User/Profile";
import {getUser} from "@/requests/users";

export default {
  name: "User",
  async mounted() {
    if (this.isEditing === true) {
      const path = this.$route.path.split('/')[2];
      this.user = await getUser(path)
    }

    this.account = {
      accountId: this.user.account_id,
      name: this.user.name,
      email: this.user.email
    };

    this.profile = {
      accountId: this.user.account_id,
      isNew: this.user.first_name && this.user.last_name && this.user.department_title,
      firstName: this.user.first_name,
      lastName: this.user.last_name,
      departmentTitle: this.user.department_title
    }
  },
  computed: {
    getAccount() {
      return this.account;
    },
    getProfile() {
      return this.profile;
    }
  },
  data() {
    return {
      account: {},
      profile: {},
      user: {}
    }
  },
  components: {
    Account,
    Profile
  },
  props: {
    isEditing: {
      type: Boolean,
      required: true,
    }
  }
}
</script>