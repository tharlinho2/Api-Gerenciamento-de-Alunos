<template>
  <div class="container">
    <!-- Adiciona/remove a classe "show" -->
    <div v-bind:class="modalClass" class="modal-container">
      <div class="user-modal">
        <h3 class="text-info">Editar Aluno</h3>
        <form>
          <div class="form-group">
            <label for="">Nome</label>
            <input v-bind:value="aluno.nome" required type="text" id="nameEdit" class="form-control"/>
          </div>

          <div class="form-group">
            <label for="">Email</label>
            <input v-bind:value="aluno.email" required type="email" id="emailEdit" class="form-control"/>
          </div>

          <div class="form-group">
            <label for="">RA</label>
            <input v-bind:value="aluno.ra" required type="email" disabled class="form-control"/>
          </div>

          <div class="form-group">
            <label for="">CPF</label>
            <input v-bind:value="aluno.cpf" required type="email" disabled class="form-control"/>
          </div>
          
          <!-- ao clicar, "showModal" passa a ser false -->
          <button v-on:click.prevent="showModal = !showModal" class="btn btn-secondary mr-1">Fechar</button>
          <button v-on:click="AtualizarAluno(aluno.id)" type="submit" class="btn btn-primary">Salvar</button> 
        </form>
      </div>
    </div>

  </div>
</template>

<script>
import { EventBus } from '../main.js';

export default {
  name: 'AlunoEditForm',
  data() {
    return {
      alunos: [],
      aluno: '',
      showModal: false
    }
  },
  methods: {
    // Requisição PUT para atualizar informações do aluno
    async AtualizarAluno(id) {
      await fetch(`https://localhost:7224/api/alunos/atualizar`, {
        method: 'PUT',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify({ 
          nome: document.getElementById('nameEdit').value,
          email: document.getElementById('emailEdit').value,
          id: id
        }),
      })
      .then((response) => response.json())
      .then((data) => {
        this.alunos = data;
        console.log('caiu aqui');
      })
      .catch((err) => {
        console.error(err);
      });
    }
  },
  // Ao criar o componente, recebemos os dados emitidos do 'EventBus' aqui nesse componente
  created() {
    // evento de click
    EventBus.$on('click', (modal, aluno) => {
      this.showModal = !modal;
      this.aluno = aluno;
      console.log('showModal', this.showModal);
      console.log('modal', modal)
    })
  },
  // Função para colocar ou tirar a classe "show" no Modal
  computed: {
    modalClass() {
      return this.showModal ? 'show' : '';
    }
  }
  
};
</script>

<style>

</style>
