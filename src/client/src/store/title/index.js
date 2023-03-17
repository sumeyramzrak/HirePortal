export default {
  namespaced: true,
  state: () => ({
    title: "Karşılama Ekranı",
  }),
  mutations: {
    set(state, value) {
      state.title = value;
    },
  },
};
