<template>
    <div id="app">
       
            <Home />
       
    </div>
</template>

<script>
    import Home from './components/Home.vue';
 
    export default {
        name: 'app',
        components: {
            Home
        }
     }
    
</script>

<style>
    #app {
    margin-left: 120px;
    margin-right: 320px;
    padding: 20px;
    max-width: 550px;
    min-width: 300px;
}
 


</style>

