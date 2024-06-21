//Automatização do CEP
document.getElementById('cep').addEventListener('blur', function () {
  const cep = this.value.replace(/\D/g, '');
  if (cep.length !== 8) return;

  const xhr = new XMLHttpRequest();
  xhr.open('GET', `https://viacep.com.br/ws/${cep}/json/`);
  xhr.onload = function () {
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

  enviaDados(nome, numero, email, nascimento, cpf, genero, cep, bairro, estado, rua, cidade, numCasa, senha);

  // if (nome === '') {
  //   isValid = false;
  //   alert('Por favor, informe seu nome.');
  // }

  // if (numero === '') {
  //   isValid = false;
  //   alert('Por favor, informe seu número.');
  // }

  // if (email === '') {
  //   isValid = false;
  //   alert('Por favor, informe seu e-mail.');
  // }

  // if (nascimento === '') {
  //   isValid = false;
  //   alert('Por favor, informe sua data de nascimento.');
  // }

  // if (cpf === '') {
  //   isValid = false;
  //   alert('Por favor, informe seu CPF.');
  // }

  // if (genero === '') {
  //   isValid = false;
  //   alert('Por favor, informe seu gênero.');
  // }

  // if (cep === '') {
  //   isValid = false;
  //   alert('Por favor, informe seu CEP.');
  // }

  // if (bairro === '') {
  //   isValid = false;
  //   alert('Por favor, informe seu bairro.');
  // }

  // if (estado === '') {
  //   isValid = false;
  //   alert('Por favor, informe seu estado.');
  // }

  // if (rua === '') {
  //   isValid = false;
  //   alert('Por favor, informe sua rua.');
  // }

  // if (cidade === '') {
  //   isValid = false;
  //   alert('Por favor, informe sua cidade.');
  // }

  // if (numCasa === '') {
  //   isValid = false;
  //   alert('Por favor, informe o número da sua casa.');
  // }

  // if (senha === '') {
  //   isValid = false;
  //   alert('Por favor, informe sua senha.');
  // }
}

function enviaDados(nome, numero, email, nascimento, cpf, genero, cep, bairro, estado, rua, cidade, numCasa, senha) {
  var url = "https://localhost:7090/api/Pessoa";

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
  console.log(formData);
  var usuarioConvertido = JSON.stringify(formData);
  console.log(usuarioConvertido);
  // fetch(url, {
  //   method: 'POST',
  //   headers: {
  //     'Content-Type': 'application/json'
  //   },
  //   body: usuarioConvertido
  // })
  //   .then(response => {
  //     if (!response.ok) {
  //       throw new Error('Ocorreu um erro ao enviar o formulário.');
  //     }
  //     return response.json();
  //   })
  //   .then(data => {
  //     console.log('Resposta do servidor:', data);
  //     alert('Formulário enviado com sucesso!');
  //   })
  //   .catch(error => {
  //     console.error('Erro ao enviar formulário:', error);
  //     alert('Ocorreu um erro ao enviar o formulário. Por favor, tente novamente.');
  //   });
}


