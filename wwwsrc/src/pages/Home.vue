<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col-12"></div>
    </div>
    <div class="row">
      <div class="col-12">
        <table class="table">
          <thead class="thead-dark">
            <tr>
              <th scope="col">Site #</th>
              <th scope="col">Site Name</th>
              <th scope="col">Cause</th>
              <th scope="col">Solved?</th>
            </tr>
          </thead>
          <tbody>
            <site-down-row
              v-for="sitedown in sitedowns"
              :key="sitedown.id"
              :sdProp="sitedown"
            />
          </tbody>
        </table>
      </div>
    </div>
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
