<template>
  <div class="row justify-content-center m-3">
    <div class="col-6 bg-light">
      <b-form @submit="onSubmit">
        <b-form-group id="input-group-1" label="Your first name:" label-for="input-1">
          <b-form-input
              id="input-1"
              v-model="profile.firstName"
              placeholder="Enter first name"
              required
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-2" label="Your last name:" label-for="input-2">
          <b-form-input
              id="input-2"
              v-model="profile.lastName"
              placeholder="Enter last name"
              required
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-3" label="Department:" label-for="input-3">
          <b-form-select
              class="w-100 h3"
              id="input-3"
              v-model="profile.departmentTitle"
              :options="this.departments.map(department => department.title)"
              required
          ></b-form-select>
        </b-form-group>

        <b-button type="submit" class="m-1" variant="primary">Save</b-button>
      </b-form>
    </div>
  </div>
</template>

<script>
import {editProfile, getDepartments, saveProfile} from "@/requests/users";

export default {
  name: "Profile",
  methods: {
    async onSubmit(event) {
      if (!this.profile.accountId) {
        throw "Can not add profile without explicitly adding account."
      }

      event.preventDefault();

      const departmentId = this.departments.find(department => department.title === this.profile.departmentTitle).id;
      const profileDto = {
        account_id: this.profile.accountId,
        first_name: this.profile.firstName,
        last_name: this.profile.lastName,
        department_id: departmentId
      };

      if (!this.profile.isNew) {
        await saveProfile(profileDto)
      } else {
        await editProfile(profileDto);
      }

      await this.$router.push("/users");
    },
  },
  data() {
    return {
      isSaved: false,
      departments: []
    }
  },
  async mounted() {
    this.departments = await getDepartments();
  },
  props: {
    profile: {
      type: Object,
      required: true
    }
  }
}
</script>