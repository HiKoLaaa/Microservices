import Vue from 'vue'
import VueRouter from 'vue-router'
import App from './App.vue'
import UserList from "@/components/UserList";
import {BootstrapVue, IconsPlugin} from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import EditUser from "@/components/User/EditUser";
import AddUser from "@/components/User/AddUser";

Vue.config.productionTip = false
Vue.use(VueRouter);
Vue.use(BootstrapVue);
Vue.use(IconsPlugin);

const routes = [
    {path: '/users', component: UserList},
    {path: '/users/new', component: AddUser},
    {path: '/users/:id', component: EditUser}
];

export const router = new VueRouter({
    routes
});

new Vue({
    render: h => h(App),
    router
}).$mount('#app')
