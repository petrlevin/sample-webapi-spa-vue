<!--<template>
    <div class="home">
        <h1>{{ msg }}</h1>
        <p>Welcome to your new single-page application, built with <a href="https://vuejs.org" target="_blank">Vue.js</a>.</p>
        <table>
            <thead>

            </thead>
            <tbody>
                <tr v-for="user in users" v-key="user.Id">
                    <td>
                        {{user.Id}}
                    </td>
                    <td>
                        {{user.UserName}}
                    </td>
                    <td>
                        {{departments[user.DepartmentId]}}
                    </td>
                </tr>

            </tbody>

        </table>
    </div>
</template> -->

<template>
    <dx-data-grid :data-source="users"
                  :columns="columns"
                  :show-borders="true">
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
</template>
<script>
    import {
  DxDataGrid,
  DxColumn,
  DxEditing,
  DxFilterRow,
  DxHeaderFilter,
  DxGroupPanel,
  DxGrouping,
  DxScrolling,
  DxSummary,
  DxLookup,
  DxTotalItem,
  DxGroupItem,
  DxMasterDetail,
  DxStringLengthRule,
  DxRequiredRule,
  DxRangeRule,
  DxValueFormat
} from 'devextreme-vue/data-grid';

    export default {
       components: {
    DxDataGrid,
    DxColumn,
    DxEditing,
    DxFilterRow,
    DxHeaderFilter,
    DxGroupPanel,
    DxGrouping,
    DxScrolling,
    DxSummary,
    DxLookup,
    DxTotalItem,
    DxGroupItem,
    DxMasterDetail,
    DxStringLengthRule,
    DxRangeRule,
    DxRequiredRule,
    DxValueFormat,
    MasterDetailGrid
  },
        name: 'Home',
        props: {
                msg: String,
                users: Array,
                departments: Array
        },
        data() {
                    return {
                    columns: ['Id', 'UserName', 'Department']
                };
  }
    }

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>

