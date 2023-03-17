<template>
	<div class="login-body">
		<div class="login-panel"></div>
		<div class="login-content">
			<img src="layout/images/logo-black.png" alt="babylon-layout"/>
			<h1><span>SIGN IN</span> TO BABYLON</h1>
			<p>Welcome, please use the form to sign-in.</p>
			<div class="login-input-wrapper">
				<InputText
              placeholder="Username"
              type="username"
              class="form-control"
              v-model="username"/>
				<i class="pi pi-user"></i>
			</div>
			<div class="login-input-wrapper">
            <InputText
            placeholder="Password"
            type="password"
            class="form-control"
            v-model="password"/>
				<i class="pi pi-lock"></i>
			</div>
			<Button label="Sign In" @click="login"/>
		</div>
	</div>
</template>
<script>
	export default {
	name: "Login",
  data: () => {
    return {
      username: null,
      password: null,
      isFailed: false,
    };
  },
  methods: {
    login() {
      this.isFailed = false;
      const d = {
        username: this.username,
        password: this.password,
      };
      this.$ajax.post("api/authentication/login", d).then((response) => {
        if (response.data) {
          this.$store.commit("session/setToken", response.data.token);
          this.$store.commit(
            "session/setDisplayName",
            response.data.displayName
          );
          this.$router.push("/app");
        } else {
          this.isFailed = true;
        }
      });
    },
  },
	}
</script>

<style scoped>

</style>