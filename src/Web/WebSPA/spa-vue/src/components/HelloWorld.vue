<template>
  <div class="hello">
    <h1>{{ name }}</h1>
    {{ message }}
  </div>
</template>

<script>
export default {
  name: "HelloWorld",
  data () {
    return {
      name: null,
      message: null
    }
  },
  mounted () {
    this.$http
      .get('/api/greeting/random')
      .then(response => (this.name = response.data.name, this.message = response.data.message))
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

</style>
