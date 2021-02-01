<template>
  <div class="home">
    <table class="table">
      <thead class="thead-dark">
        <tr>
          <th scope="col">Site #</th>
          <th scope="col">Site Name</th>
          <th scope="col">Cause</th>
          <th scope="col">Solved?</th>
        </tr>
      </thead>
      <tbody></tbody>
    </table>
  </div>
</template>

<script>
import SiteDownRow from "../components/SiteDownRow.vue";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getSiteDowns");
  },
  computed: {
    sitedowns() {
      return this.$store.state.sitedowns;
    },
  },
  components: {
    SiteDownRow,
  },
};
</script>
