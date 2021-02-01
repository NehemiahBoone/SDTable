<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col-12">
        <h2>
          SiteDowns<i
            class="fas fa-plus text-success px-1"
            @click="sdToggle = !sdToggle"
          ></i>
        </h2>
        <form @submit.prevent="postSD" class="form-inline m-1" v-if="sdToggle">
          <div class="form-group px-1">
            <input
              type="text"
              name="Site#"
              id="Site#"
              class="form-control"
              placeholder="Site #..."
              aria-describedby="helpId"
              v-model="newSD.siteNum"
            />
          </div>
          <div class="form-group px-1">
            <input
              type="text"
              name="SiteName"
              id="SiteName"
              class="form-control"
              placeholder="Site Name..."
              aria-describedby="helpId"
              v-model="newSD.siteName"
            />
          </div>
          <div class="form-group px-1">
            <input
              type="text"
              name="Cause"
              id="Cause"
              class="form-control"
              placeholder="Cause..."
              aria-describedby="helpId"
              v-model="newSD.cause"
            />
          </div>
          <label class="pl-1" for="solved">Solved?</label>
          <div class="form-group px-1">
            <input
              type="checkbox"
              name="solved"
              id="solved"
              class="form-control"
              aria-describedby="helpId"
              v-model="newSD.solved"
            />
          </div>
          <button class="btn btn-success" type="submit">Post SiteDown</button>
        </form>
      </div>
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
  data() {
    return {
      sdToggle: false,
      newSD: {},
    };
  },
  methods: {
    postSD() {
      this.$store.dispatch("postSD", this.newSD);
      this.newSD = {};
    },
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
