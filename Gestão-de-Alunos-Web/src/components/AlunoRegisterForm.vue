<template>
  <div class="container">
    <!-- "showModal" passa a ser true -->
    <button v-on:click="showModal = !showModal" class="btn btn-lg btn-outline-primary float-right">Cadastrar Aluno</button>
    
    <!-- Adiciona/remove a classe "show" -->
    <div v-bind:class="modalClass" class="modal-container">
      <div class="user-modal">
        <h3 class="text-primary">Cadastro de Aluno</h3>
        <form>
          <div class="form-group">
            <label for="name">Nome</label>
            <input required value="" type="text" id="nameRegister" class="form-control"/>
          </div>
    
          <div class="form-group">
            <label for="email">Email</label>
            <input required value="" type="email" id="emailRegister" class="form-control"/>
          </div>
          
          <div class="form-group">
            <label for="ra">RA</label>
            <input required value="" type="number" id="raRegister" class="form-control"/>
          </div>

          <div class="form-group">
            <label for="cpf">CPF</label>
            <input required value="" type="text" id="cpfRegister" class="form-control" the-mask v-mask="['###.###.###-##']"/>
          </div>
          
          <!-- ao clicar, "showModal" passa a ser false -->
          <button v-on:click.prevent="showModal = !showModal" class="btn btn-secondary mr-1">Fechar</button>
          <button v-on:click="criarNovoAluno()" type="submit" class="btn btn-primary">Salvar</button> 
        </form>
      </div>
    </div>

    <div v-bind:class="showModelAtencao" class="modal-container">
      <div class="user-modal">
        <h3 class="text-primary">Atenção!</h3>
          <form>
          <h4 class="modal-atencao">{{users}}</h4>
          <!-- ao clicar, "showModal" passa a ser false -->
          <button v-on:click.prevent="showModelAtencao = !showModelAtencao" class="btn btn-secondary mr-1">Fechar</button>
        </form>
      </div>
    </div>

  </div>
</template>

<script>
import {mask} from 'vue-the-mask'

export default { 
  name: 'AlunoRegisterForm',
  directives: {mask},
  data() {
    return {
      users: [],
      showModal: false,
      showModelAtencao: false,
    };
  },
  methods: {
    // Requisição POST para criar um novo aluno
    
    async criarNovoAluno() {
      await fetch('https://localhost:7224/api/alunos/cadastrar', {
        method: 'POST',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify({
          nome: document.getElementById('nameRegister').value,
          email: document.getElementById('emailRegister').value,
          ra: document.getElementById('raRegister').value,
          cpf: document.getElementById('cpfRegister').value
        }),
      })
      .then((response) => response.json())
      .then((data) => {
        this.users = data;
        console.log(data);
        console.log('caiu aqui');
      })
      .catch((err) => {
        console.error(err);
      });
    },
  },
  // Função para colocar ou tirar a classe "show" no Modal
  computed: {
    modalClass() {
      return this.showModal ? 'show' : '';
    },
    modelClassAtencao() {
     return this.showModelAtencao ? 'show' : '';
    }
  },
};
</script>

<style>
.modal-container {
  position: fixed;
  background-color: rgba(0, 0, 0, 0.3);
  top: 0;
  left: 0;
  height: 100vh;
  width: 100vw;

  display: flex;
  align-items: center;
  justify-content: center;
  
  opacity: 0;
  pointer-events: none;
  transition: opacity 0.3s ease-in-out;
}

.modal-container.show {
  opacity: 1;
  pointer-events: auto;
}

.user-modal {
  color: #535353;
  background-color: #fff;
  background-image: url("../assets/background.jpg");
  width: 450px;
  padding: 40px 50px;
  max-width: 100%;
  border-radius: 10px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.3);
}

.user-modal h1 {
  margin: 0;
}

.user-modal p {
  opacity: 0.9;
}
</style>
