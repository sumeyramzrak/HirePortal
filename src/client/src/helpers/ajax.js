import axios from "axios";
import store from "../store";
export default {
  install: (app) => {
    const instance = axios.create({
      baseURL: "https://hireportalapi20220715213835.azurewebsites.net",
    });

    const addHeader = () => {
      let config = {
        headers: {},
      };
      const token = store.state.session.token;
      if (token) {
        config.headers["Authorization"] = "Bearer " + token;
      }
      return config;
    };

    const ajax = {
      get: function (url) {
        return instance.get(url, addHeader());
      },
      post: function (url, data) {
        return instance.post(url, data, addHeader());
      },
      delete: function (url) {
        return instance.delete(url, addHeader());
      },
      put: function (url,data) {
        return instance.put(url,data, addHeader());
      },
    };
    app.config.globalProperties.$ajax = ajax;
  },
};
