<template>
  <div class="container">
    <h3 class="mt-2 mb-3 float-left text-primary">Alunos</h3>
    <!-- Tabela de Alunos -->
    <table class="table table-striped">
      <thead>
        <tr>
          <th scope="col">Registro Acadêmico</th>
          <th scope="col">Nome</th>
          <th scope="col">E-mail</th>
          <th scope="col">CPF</th>
        </tr>
      </thead>
      <tbody>
        
        <tr v-for="(aluno) in alunos" :key="aluno.id" class="m-5">
          <td>{{ aluno.ra }}</td>
          <td>{{ aluno.nome }}</td>
          <td>{{ aluno.email }}</td>
          <td>{{ aluno.cpf }}</td>
          <td>
            <form>
              <button v-on:click.prevent="emitShowModal(aluno)" class="btn btn-sm btn-info mr-1">Editar</button>
              <button v-on:click.prevent="modelClassAtencao(aluno)" class="btn btn-sm btn-danger">Deletar</button>
            </form>
          </td>
        </tr>

        <!-- Fim "v-for" -->
      </tbody>
    </table>

    <div v-bind:class="showModelAtencao" class="modal-container">
      <div class="user-modal">
        <h3 class="text-primary">Atenção!</h3>
          <form>
            <h4 class="modal-atencao">Tem Certeza?</h4>
            <!-- ao clicar, "showModal" passa a ser false -->
            <button v-on:click.prevent="showModelAtencao = !showModelAtencao" class="btn btn-secondary mr-1">Cancelar</button>
            <button v-on:click="deletarAluno(aluno3.id)" type="submit" class="btn btn-primary">Deletar</button> 
          </form>
      </div>
    </div> 

  </div>

</template>

<script>
import { EventBus } from '../main.js';

export default {
  name: 'AlunosTabela',
  data() {
    return {
      alunos: [],
      showModal: false,
      showModelAtencao: "",
      aluno3: [],
    }
  },
  // Ao criar o componente, é feito uma requisição GET para a API do backend
   async created() {
     setInterval(() => {
       fetch('https://localhost:7224/api/alunos', {
         method: "GET",
       })
       .then((response) => response.json())
       .then(data => {
         this.alunos = data
       })
     }, 200)
  },
  methods: {
    // Requisição DELETE para excluir o aluno por id
    async deletarAluno(id) {
      await fetch('https://localhost:7224/api/alunos/deletar', {
        method: 'DELETE',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify({
         id: id
        }),
      })
      .then((response) => response.json())
      .then((data) => {
        this.alunos = data;
        console.log(data);
        console.log('caiu aqui');
      })
      .catch((err) => {
        console.error(err);
      });
    },
    // Metodo usa o 'EventBus' para poder emitir dados de forma global
    // --> Emite dados de "aluno" e "showModal"
    emitShowModal(aluno) {
      this.aluno = aluno;
      EventBus.$emit('click', this.showModal, this.aluno);
      
      console.log(this.aluno);
      console.log('UsersTable:', this.showModal);
    },
    modelClassAtencao(aluno) {
      this.aluno3 = aluno;
      this.showModelAtencao = 'show';
    }
  },

};
</script>

<style scoped>
th {
  padding-left: 1.2rem;
}
td {
  padding-left: 1.2rem;
}

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
