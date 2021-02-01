import Vue from "vue";
import Vuex from "vuex";
import { api } from "../services/AxiosService.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    profile: {},
    sitedowns: []
  },
  mutations: {
    setProfile(state, profile) {
      state.profile = profile;
    },
    setSiteDowns(state, sitedowns) {
      state.sitedowns = sitedowns
    }
  },
  actions: {
    async getProfile({ commit }) {
      try {
        let res = await api.get("profiles");
        commit("setProfile", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async getSiteDowns({ commit, dispatch }) {
      try {
        let res = await api.get("sitedowns")
        console.log(res)
        commit("setSiteDowns", res.data)
      } catch (error) {
        console.error(error)
      }
    },
    async postSD({ commit, dispatch }, newSD) {
      try {
        let res = await api.post("sitedowns", newSD)
        console.log(res)
        dispatch("getSiteDowns")
      } catch (error) {
        console.error(error);
      }
    }
  },
});
