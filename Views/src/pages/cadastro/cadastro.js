//Automatização do CEP
document.getElementById('cep').addEventListener('blur', function() {
    const cep = this.value.replace(/\D/g, '');
    if (cep.length !== 8) return;

    const xhr = new XMLHttpRequest();
    xhr.open('GET', `https://viacep.com.br/ws/${cep}/json/`);
    xhr.onload = function() {
        const data = JSON.parse(xhr.responseText);
        if (!data.erro) {
            document.getElementById('state').value = data.uf;
            document.getElementById('city').value = data.localidade;
            document.getElementById('neighborhood').value = data.bairro;
            document.getElementById('street').value = data.logradouro; // Adiciona a rua
        }
    };
    xhr.send();
});

//Validação da data de nascimento
const birthdateInput = document.getElementById('birthdate');

birthdateInput.addEventListener('input', function(event) {
    let value = event.target.value;

    value = value.replace(/\D/g, '');

    if (value.length > 2) {
        value = value.substring(0, 2) + '/' + value.substring(2);
    }
    if (value.length > 5) {
        value = value.substring(0, 5) + '/' + value.substring(5, 9);
    }

    event.target.value = value;
});


//Validação do Gênero
const genderInput = document.getElementById('gender');
const optionsList = document.querySelector('.options');
const options = document.querySelectorAll('.option');

genderInput.addEventListener('click', function() {
    optionsList.classList.toggle('active');
});

options.forEach(option => {
    option.addEventListener('click', function() {
        genderInput.value = this.dataset.value;
        optionsList.classList.remove('active');
    });
});

//Captura dados do formulário
function capturaDados() {
    var nome = document.getElementById('firstname').value;
    var numero = document.getElementById('number').value;
    var email = document.getElementById('email').value;
    var nascimento = document.getElementById('birthdate').value;
    var cpf = document.getElementById('cpf').value;
    var genero = document.getElementById('gender').value;
    var cep = document.getElementById('cep').value;
    var bairro = document.getElementById('neighborhood').value;
    var estado = document.getElementById('state').value;
    var rua = document.getElementById('street').value;
    var cidade = document.getElementById('city').value;
    var numCasa = document.getElementById('houseNumber').value;
    var senha = document.getElementById('password').value;
  
    var isValid = true;
  
    if (nome === '') {
      isValid = false;
      alert('Por favor, informe seu nome.');
    }
  
    if (numero === '') {
      isValid = false;
      alert('Por favor, informe seu número.');
    }
  
    if (email === '') {
      isValid = false;
      alert('Por favor, informe seu e-mail.');
    }
  
    if (nascimento === '') {
      isValid = false;
      alert('Por favor, informe sua data de nascimento.');
    }
  
    if (cpf === '') {
      isValid = false;
      alert('Por favor, informe seu CPF.');
    }
  
    if (genero === '') {
      isValid = false;
      alert('Por favor, informe seu gênero.');
    }
  
    if (cep === '') {
      isValid = false;
      alert('Por favor, informe seu CEP.');
    }
  
    if (bairro === '') {
      isValid = false;
      alert('Por favor, informe seu bairro.');
    }
  
    if (estado === '') {
      isValid = false;
      alert('Por favor, informe seu estado.');
    }
  
    if (rua === '') {
      isValid = false;
      alert('Por favor, informe sua rua.');
    }
  
    if (cidade === '') {
      isValid = false;
      alert('Por favor, informe sua cidade.');
    }
  
    if (numCasa === '') {
      isValid = false;
      alert('Por favor, informe o número da sua casa.');
    }
  
    if (senha === '') {
      isValid = false;
      alert('Por favor, informe sua senha.');
    }
  
    if (isValid) {
      alert('Formulário validado com sucesso!');
  
      enviaDados(nome, numero, email, nascimento, cpf, genero, cep, bairro, estado, rua, cidade, numCasa, senha);
    }
  }
  
  function enviaDados(nome, numero, email, nascimento, cpf, genero, cep, bairro, estado, rua, cidade, numCasa, senha) {
    var url = "https://localhost:7090/api/Usuario";
  
    var formData = {
      nome: nome,
      numero: numero,
      email: email,
      nascimento: nascimento,
      cpf: cpf,
      genero: genero,
      cep: cep,
      bairro: bairro,
      estado: estado,
      rua: rua,
      cidade: cidade,
      numCasa: numCasa,
      senha: senha
    };
  
    var usuarioConvertido = JSON.stringify(formData);
  
    fetch(url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: usuarioConvertido
    })
      .then(response => {
        if (!response.ok) {
          throw new Error('Ocorreu um erro ao enviar o formulário.');
        }
        return response.json();
      })
      .then(data => {
        console.log('Resposta do servidor:', data);
        alert('Formulário enviado com sucesso!');
      })
      .catch(error => {
        console.error('Erro ao enviar formulário:', error);
        alert('Ocorreu um erro ao enviar o formulário. Por favor, tente novamente.');
      });
  }
  

  //Colocando usuario no banco
const express = require('express');
const mysql = require('mysql');
const bodyParser = require('body-parser');
const app = express();

app.use(bodyParser.json());

const connection = mysql.createConnection({
    host: '127.0.0.1',
    user: 'root',
    database: 'Cadastro'
});

connection.connect(error => {
    if (error) throw error;
    console.log('Conectado ao banco de dados.');
});

app.post('/api/Usuario', (req, res) => {
    const user = req.body;

    const query = 'INSERT INTO Usuario (nome, numero, email, nascimento, cpf, genero, cep, bairro, estado, rua, cidade, numCasa, senha) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)';
    const values = [user.nome, user.numero, user.email, user.nascimento, user.cpf, user.genero, user.cep, user.bairro, user.estado, user.rua, user.cidade, user.numCasa, user.senha];

    connection.query(query, values, (error, results) => {
        if (error) {
            console.error('Erro ao inserir dados:', error);
            res.status(500).send('Erro ao inserir dados');
        } else {
            res.status(200).send('Dados inseridos com sucesso');
        }
    });
});

app.listen(7090, () => {
    console.log('Servidor rodando na porta 7090');
});
