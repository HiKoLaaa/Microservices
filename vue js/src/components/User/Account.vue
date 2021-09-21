<template>
  <div class="row justify-content-center m-3">
    <div class="col-6 bg-light">
      <b-form @submit="onSubmit">
        <b-form-group id="input-group-1" label="Your Name:" label-for="input-1">
          <b-form-input
              id="input-1"
              v-model="account.name"
              placeholder="Enter name"
              required
          ></b-form-input>
        </b-form-group>
        <b-form-group
            id="input-group-2"
            label="Email address:"
            label-for="input-2"
        >
          <b-form-input
              id="input-2"
              v-model="account.email"
              type="email"
              placeholder="Enter email"
              required
          ></b-form-input>
        </b-form-group>
        <b-button type="submit" class="m-1" variant="primary">Save</b-button>
      </b-form>
    </div>
  </div>
</template>

<script>
import {editAccount, saveAccount} from "@/requests/users";

export default {
  name: "Account",
  methods: {
    async onSubmit(event) {
      event.preventDefault();

      if (!this.account.accountId) {
        parent.account.accountId = await saveAccount({ name: this.account.name, email: this.account.email });
      }
      else {
        await editAccount({ id: this.account.accountId, name: this.account.name, email: this.account.email });
      }

      await this.$router.push("/users");
    },
  },
  data() {
    return {
      isSaved: false
    }
  },
  props: {
    account: {
      type: Object,
      required: true
    }
  }
}
</script>