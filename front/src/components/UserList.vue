<template>
  <div class="container">
    <button class="btn btn-outline-dark m-1" @click="addUser">
      Add new user
    </button>
    <DataTable v-bind="bindings"/>
  </div>
</template>

<script>
import DataTable from "@andresouzaabreu/vue-data-table";
import ActionButtons from "@/components/UserListActionButtons";
import "bootstrap/dist/css/bootstrap.min.css";
import "@andresouzaabreu/vue-data-table/dist/DataTable.css";
import {getUsers} from "@/requests/users";
import {router} from "@/main";

export default {
  name: "UserList",
  components: {
    DataTable
  },
  computed: {
    bindings() {
      return {
        columns: [
          {
            key: "name"
          },
          {
            key: "email"
          },
          {
            key: "first_name"
          },
          {
            key: "last_name"
          },
          {
            key: "department_title"
          },
          {
            title: "Actions",
            component: ActionButtons
          }
        ],
        data: this.users,
        showPagination: false,
        showDownloadButton: false,
        showEntriesInfo: false,
        showPerPage: false
      }
    }
  },
  async mounted() {
    this.users = await getUsers();
  },
  data() {
    return {
      users: [ ]
    };
  },
  methods: {
    addUser() {
      router.push({path: `users/new`});
    }
  }
}
</script>