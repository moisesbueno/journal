<template>
  <div>
    <h1>Buscar revista</h1>

    <div class="searchArea">
      <div class="input-group input-group-sm mb-2">
        <input
          type="text"
          class="form-control"
          aria-label="Default"
          aria-describedby="inputGroup-sizing-default"
          v-model="search"
          placeholder="Digite aqui"
          @keyup="searchJournals()"
        />

        <select class="form-select" >
          <option v-for="s in searchBy" :key="s.value" value="s.value">{{ s.description }}</option>
        </select>

        <!-- <div class="input-group-append">
          <button
            class="btn btn-primary"
            type="button"
            @click="searchJournals()"
          >
            Pesquisar
          </button>
        </div> -->
      </div>
    </div>

    <div class="x">
      <div class="container">
        <div class="row">
          <div
            class="col-sm-4 py-2"
            v-for="journal of journals"
            :key="journal.id"
          >
            <div class="card h-100 border-primary">
              <div class="card-body">
                <h5 class="card-title">{{ journal.name }}</h5>
                <p class="card-text">Qualis {{ journal.description }}</p>

                <router-link
                  :to="{ name: 'detalhes', params: { id: journal.id } }"
                >
                  <button class="btn btn-outline-secondary">Detalhes</button>
                </router-link>
              </div>
            </div>
          </div>
        </div>
      </div>

      <v-pagination
        :pagination="pagination"
        @navigate="navigate"
      ></v-pagination>
    </div>
  </div>
</template>
<script>
import Journal from "../services/journals";
import Pagination from "./Pagination.vue";
let timeout = null;
export default {
  components: {
    "v-pagination": Pagination,
  },
  methods: {
    navigate(page) {
      this.listJournals(page - 1, this.search);
    },

    listJournals(page, search) {
      Journal.list(12, page, search).then((res) => {
        this.journals = res.data.items;
        this.handlePagination(res);
      });
    },
    searchJournals() {
      clearTimeout(timeout);

      timeout = setTimeout(() => {
        this.listJournals(undefined, this.search);
      }, 800);
    },

    handlePagination(res) {
      this.pagination = {
        pageNumber: res.data.pageNumber,
        pageSize: res.data.pageSize,
        total: res.data.total,
        totalPages: res.data.totalPages,
      };
    },
  },
  data() {
    return {
      journals: [],
      search: "",
      pagination: {},
      searchBy: [],
    };
  },

  mounted() {
    this.listJournals();

    let search = [
      { value: "", description: "" },
      { value: "issn", description: "Issn" },
      { value: "name", description: "Nome" },
      { value: "1", description: "A1" },
      { value: "2", description: "A2" },
      { value: "3", description: "A3" },
      { value: "4", description: "A4" },
      { value: "5", description: "B1" },
      { value: "6", description: "B2" },
      { value: "7", description: "B3" },
      { value: "8", description: "B4" },
      { value: "9", description: "C" },
      { value: "10", description: "ESTRATO" },
      { value: "11", description: "NP" },
    ];
    this.searchBy = search;
  },
};
</script>
<style>
.searchArea {
  width: 50%;
  display: block;
  margin-right: auto;
  margin-left: auto;
}
.div-card {
  display: inline-block;
}
.x {
  width: 50%;
  margin-right: auto;
  margin-left: auto;
  height: 100%;
}
.my-flex-card > div > div.card {
  height: calc(100% - 15px);
  margin-bottom: 15px;
}
</style>