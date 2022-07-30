<template>
  <nav aria-label="Page navigation example">
    <ul class="pagination justify-content-center">
      <li class="page-item" :class="{ disabled: pagination.pageNumber == 0 }">
        <a
          class="page-link"
          href="#"
          @click="navigate($event, pagination.pageNumber)"
          >Anterior</a
        >
      </li>

      <li
        class="page-item"
        v-for="(page, index) of totalPages"
        :key="index"
        :class="{ active: page == pagination.pageNumber + 1 }"
      >
        <span class="page-link" v-if="page == '...'">{{ page }}</span>
        <a
          class="page-link"
          v-if="page != '...'"
          @click="navigate($event, page)"
          >{{ page }}</a
        >
      </li>

      <li
        class="page-item"
        :class="{
          disabled: pagination.pageNumber + 1 == pagination.totalPages,
        }"
      >
        <a
          class="page-link"
          href="#"
          @click="navigate($event, pagination.pageNumber + 2)"
          >Próxima</a
        >
      </li>
    </ul>
  </nav>
</template>
<script>
export default {
  props: ["pagination"],

  data() {
    return {
      totalPages: 0,
    };
  },
  methods: {
    navigate(ev, page) {
      ev.preventDefault();
      this.$emit("navigate", page);
    },

    generatePagesArray: function (
      currentPage,
      collectionLength,
      rowsPerPage,
      paginationRange
    ) {
      var pages = [];
      var totalPages = Math.ceil(collectionLength / rowsPerPage);
      var halfWay = Math.ceil(paginationRange / 2);
      var position;

      if (currentPage <= halfWay) {
        position = "start";
      } else if (totalPages - halfWay < currentPage) {
        position = "end";
      } else {
        position = "middle";
      }

      var ellipsesNeeded = paginationRange < totalPages;
      var i = 1;
      while (i <= totalPages && i <= paginationRange) {
        var pageNumber = this.calculatePageNumber(
          i,
          currentPage,
          paginationRange,
          totalPages
        );
        var openingEllipsesNeeded =
          i === 2 && (position === "middle" || position === "end");
        var closingEllipsesNeeded =
          i === paginationRange - 1 &&
          (position === "middle" || position === "start");
        if (
          ellipsesNeeded &&
          (openingEllipsesNeeded || closingEllipsesNeeded)
        ) {
          pages.push("...");
        } else {
          pages.push(pageNumber);
        }
        i++;
      }
      return pages;
    },
    calculatePageNumber: function (
      i,
      currentPage,
      paginationRange,
      totalPages
    ) {
      var halfWay = Math.ceil(paginationRange / 2);
      if (i === paginationRange) {
        return totalPages;
      } else if (i === 1) {
        return i;
      } else if (paginationRange < totalPages) {
        if (totalPages - halfWay < currentPage) {
          return totalPages - paginationRange + i;
        } else if (halfWay < currentPage) {
          return currentPage - halfWay + i;
        } else {
          return i;
        }
      } else {
        return i;
      }
    },
  },
  watch: {
    pagination() {
      let s = this.pagination;
      this.totalPages = this.generatePagesArray(s.pageNumber, s.total, s.pageSize, 12);
    },
  },
};
</script>
<style>
</style>