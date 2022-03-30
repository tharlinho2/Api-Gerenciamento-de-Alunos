<template>
  <div id="app">
    <Header />
    <AlunoRegisterForm />
    <AlunoEditForm />
    <AlunosTabela />
  </div>
</template>

<script>
import Header from './components/Header.vue';
import AlunoRegisterForm from './components/AlunoRegisterForm.vue';
import AlunoEditForm from './components/AlunoEditForm.vue';
import AlunosTabela from './components/AlunosTabela.vue';


export default {
  name: 'App',
  components: {
    Header,
    AlunoRegisterForm,
    AlunosTabela,
    AlunoEditForm
  }
}
</script>

<style>
#app {
  margin-top: 40px;
}
</style>
