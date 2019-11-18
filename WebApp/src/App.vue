<template>
    <div id="app">
        <form v-on:submit.prevent>
            <Home msg="Hello world!" :users="users" :departments="dapartments" />

            <button v-on:click="adduser">Add</button>
            <button v-on:click="changeuser">Change</button>
        </form>
    </div>
</template>

<script>
    import Home from './components/Home.vue';

    export default {
        name: 'app',
        components: {
            Home
        },
        data() {
            return  {
                webapi: {
                    users:'',
                    departments:'',
                },
                users: [],
                departments: []
            };
        },
        created() {
            this.users = [{ Id: 1, UserName: "Sedoff", DepartmentId: 1 }, { Id: 2, UserName: "Petroff", DepartmentId: 1 }, { Id: 3, UserName: "Smith", DepartmentId: 2}];
            this.departments = [{ Id: 1, Title: "Russian" }, { Id: 2, Title: "Commom" }];
        },
        computed: {
            dapartmentsMap() {
                var result = {};
                this.departments.forEach(el => {
                    result[el.Id] = el.Tittle; 
                });
                return result;
            }
        },
         methods: {
            adduser: function () {
                this.users.push({ Id: 4, UserName: "Kozloff", DepartmentId: 1 })
               
             },
             changeuser: function () {
                 this.users[0].UserName = this.users[0].UserName + '7';
                 this.users[1] = { Id: 2, UserName: "Sokoloff", DepartmentId: 1 };
             },
         }
  
 
     }
    
</script>

<style>
</style>

