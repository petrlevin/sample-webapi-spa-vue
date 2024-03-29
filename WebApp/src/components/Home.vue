<template>
    <div>
        <div class="buttons">
            <dx-button :width="120"
                       text="Edit"
                       type="normal"
                       styling-mode="contained"
                       @click="startEdit"
                       :disabled="modified" />
            <dx-button :width="120"
                       text="Insert"
                       type="normal"
                       styling-mode="contained"
                       @click="startInsert"
                       :disabled="modified" />
            <dx-button :width="120"
                       text="Delete"
                       type="normal"
                       styling-mode="contained"
                       @click="deleteUser"
                       :disabled="modified||progress" />

        </div>
        <dx-data-grid :data-source="usersStore"
                      :show-borders="true"
                      :focused-row-enabled="true"
                      :focused-row-key.sync="current"
                      :auto-navigate-to-focused-row="true"
                      :disabled="modified">
            <dx-column data-field="Id"
                       data-type="number" />
            <dx-column data-field="UserName"
                       caption="User name"
                       data-type="string" />
            <dx-column data-field="DepartmentId"
                       caption="Department">
                <dx-lookup :data-source="departments"
                           value-expr="Id"
                           display-expr="Title" />
            </dx-column>
            <dx-paging :page-size="10" />
        </dx-data-grid>


        <div>
            <div class="dx-fieldset">
                <div class="dx-field">
                    <div class="dx-field-label">User name</div>
                    <div class="dx-field-value">
                        <dx-text-box :hover-state-enabled="false"
                                     :value.sync="userData.UserName"
                                     :disabled="!modified" />
                    </div>
                </div>
                <div class="dx-field">
                    <div class="dx-field-label">Department</div>
                    <div class="dx-field-value">
                        <dx-select-box :data-source="departments"
                                       :value.sync="userData.DepartmentId"
                                       display-expr="Title"
                                       value-expr="Id"
                                       :disabled="!modified" />
                    </div>
                </div>
            </div>
            <div class="buttons">
                <dx-button :width="120"
                           :text="action"
                           type="normal"
                           styling-mode="contained"
                           @click="modify"
                           :disabled="!modified||progress" />
                <dx-button :width="120"
                           text="Cancel"
                           type="normal"
                           styling-mode="contained"
                           @click="cancel"
                           :disabled="!modified||progress" />

            </div>
        </div>
    </div>

</template>

<script>
    import {DxDataGrid, DxLookup,DxPager, DxPaging ,DxColumn } from 'devextreme-vue/data-grid';
    import {  DxSelectBox,  DxButton, DxTextBox } from 'devextreme-vue';
    import { DxForm, DxItem } from 'devextreme-vue/form';
    
    import ArrayStore from 'devextreme/data/array_store';
    import State from './state.js';
    import webApi from '../webapi.config.js';
    import axios from 'axios';


    export default {
        name: 'app',
        components: {
            DxDataGrid,
            DxLookup,
            DxSelectBox,
            DxForm,
            DxTextBox,
            DxItem,
            DxButton,
            DxPager,
            DxPaging,
            DxColumn
        },
        data() {
            return {
                state: State.init,
                users: [],
                departments: [],
                current: 0,
                error: '',
                progress:false
            };
        },
        created() {

            axios.get(webApi.users)
                .then(response => { this.users = response.data; })
                .then(_ => axios.get(webApi.departments))
                .then(response => this.departments = response.data)
                .then(_=>this.current = this.users.length>0?this.users[0].Id:0)
                .catch(error => console.log(this.error = error))
                .finally(_=>this.state=State.browsing)
        },
        computed: {
            usersStore() {
                let data = (this.state == State.init) ? [] : this.users;
                return new ArrayStore({
                    key: 'Id',
                    data: data
                });
            },
            userData() {
                 return this.state != State.inserting ? Object.assign({}, this.currentUser()) : { UserName: 'New User', DepartmentId: this.departments[0].Id };
            },
            modified() {
                 return this.state != State.browsing;
            },
            action() {
                 return this.state != State.inserting ? 'Update' : 'Insert';
            }
        },
        methods: {
            cancel() {
                this.state = State.browsing;
            },
            modify() {
                this.progress = true;
                axios[this.state.action](webApi.users, this.userData)
                    .then(response => this[this.state.callback](response))
                    .then(_ => this.state = State.browsing)
                    .catch(error => console.log(this.error = error))
                    .finally(this.progress = false);
            },
            onInsert(response) {
                console.log(response);
                this.userData.Id = response.data;
                this.usersStore.insert(this.userData);       
            },
            onUpdate() {
                Object.assign(this.currentUser(), this.userData);
            },
            startInsert() {
                this.state = State.inserting;
            },
            startEdit() {
                this.state = State.editing;
            },
            deleteUser() {
                this.progress = true;
                let userId = this.current;
                axios.delete(webApi.users+'/'+userId)
                    .then(_ => this.usersStore.remove(userId))
                    .catch(error => console.log(this.error = error))
                    .finally(this.progress = false);
               
            },
            currentUser() {
                return this.users.find(e => e.Id == this.current);
            }

        }
    }
</script>

<style scoped>
    .buttons {
        margin-top: 20px;
        margin-bottom: 10px;
    }

    .buttons > div {
        width: 300px;
        margin-right: 10px;
    }
 
</style>