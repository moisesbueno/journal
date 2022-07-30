<template>
  <!-- Page Content -->

  <div>
    <div class="buttoncls">
      <router-link :to="{ name: 'home' }">
        <button type="button" class="btn btn-primary">Voltar</button>
      </router-link>
    </div>

    <div class="container">
      <!-- Portfolio Item Heading -->
      <h1 class="my-4">{{ journal.name }}</h1>

      <!-- Portfolio Item Row -->
      <div class="row">
        <div class="col-md-6">
          <div class="img">
            <img class="img-fluid" :src="journal.image" alt="" />
          </div>
        </div>

        <div class="col-md-4">
          <h3 class="my-3">Informações</h3>

          <p><b>Nome:</b> {{ journal.name }}</p>
          <p><b>Issn:</b> {{ journal.issn }}</p>
          <p><b>Qualis:</b> {{ journal.description }}</p>
          <p><b>Apc:</b> {{ journal.apc }}</p>
          <b
            >Url:<a :href="journal.url" target="_blank">{{
              journal.name
            }}</a></b
          >
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import Journal from "../services/journals";
export default {
  data() {
    return {
      journal: {
        id: this.$route.params.id,
        name: "",
        issn: "",
        url: "",
        description: "",
        apc: null,
        image: "",
      },
    };
  },
  mounted() {
    if (this.journal.id) {
      Journal.get(this.journal.id).then((res) => {
        let data = res.data;
        this.journal.name = data.name;
        this.journal.description = data.description;
        this.journal.url = data.url;
        this.journal.issn = data.issn;
        this.journal.url = data.url;
        this.journal.image = data.image;
        this.journal.apc = data.apc;
      });
    }
  },
};
</script>
<style scoped>
.buttoncls {
  float: right;
  margin-right: 10%;
}
</style>

