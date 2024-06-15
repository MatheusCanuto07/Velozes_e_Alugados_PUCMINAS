var btnEntra = document.getElementById("btn-entra");

var emailVazio = document.getElementById("emailVazio");
var emailLongo = document.getElementById("emailLongo");
var emailValido = document.getElementById("emailValido");

var senhaVazia = document.getElementById("senhaVazia");
var senhaTamanho = document.getElementById("senhaTamanho");

var podeEnviar = true;

var email = document.getElementById("email");
console.log(email);
var senha = document.getElementById("senha");
console.log(senha);

email.addEventListener('input', function(event) {
  var valorAtual = event.target.value;
  console.log('Valor atual:', valorAtual);

  emailVazio.classList.add('d-none');

  var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

  if (!emailRegex.test(valorAtual)) {
    emailValido.className = '';
    emailValido.classList.add('text-danger');
    podeEnviar = false;
  } else{
    podeEnviar = true;
    emailValido.className = '';
    emailValido.classList.add('d-none');
  }

  var minLength = 5;
  var maxLength = 254;
  
  if (valorAtual.length < minLength || valorAtual.length > maxLength) {
    podeEnviar = false;
    emailLongo.className = '';
    emailLongo.classList.add('text-danger');
  } else{
    podeEnviar = true;
    emailLongo.className = '';
    emailLongo.classList.add('d-none');
  }

});

senha.addEventListener('input', function(event) {
  var valorAtual = event.target.value;
  console.log('Valor atual:', valorAtual);

  senhaVazia.classList.add('d-none');

  console.log(senha.length);
  if(valorAtual.length < 8){
    podeEnviar = false;
    senhaTamanho.className = '';
    senhaTamanho.classList.add('text-danger');
  } else{
    podeEnviar = true;
    senhaTamanho.className = '';
    senhaTamanho.classList.add('d-none');
  }
})

btnEntra.addEventListener("click", function () {

  if (email.value === "") {
    podeEnviar = false;
    emailVazio.className = '';
    emailVazio.classList.add('text-danger');
  }

  if (senha.value === ""){
    podeEnviar = false;
    senhaVazia.className = '';
    senhaVazia.classList.add('text-danger');
  }

  console.log(podeEnviar);

  var url = `https://localhost:7090/login/validarLogin/${email}/${senha}`;

  // fetch(url)
  //   .then(response => response.text().then(data => ({ status: response.status, body: data })))
  //   .then(result => {
  //     if (result.status === 200) {
  //       window.location.href = "../menu_principal/menu_inicial.html";
  //     } else {
  //       alert("Email ou senha está errado pai");
  //     }
  //   })
  //   .catch(error => {
  //     console.error("Erro ao fazer a requisição:", error);
  //   });

});