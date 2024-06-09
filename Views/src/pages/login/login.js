// Seleciona o elemento com o id "btn-entra"
var btnEntra = document.getElementById("btn-entra");

// Adiciona um event listener para o evento de clique
btnEntra.addEventListener("click", function () {
  // Código a ser executado quando o botão for clicado

  // Supondo que você tenha os valores de email e senha
  var email = document.getElementById("email").value;
  console.log(email);

  var senha = document.getElementById("senha").value;
  console.log(senha);

  // URL da API com email e senha como parte do caminho
  var url = `https://localhost:7090/login/validarLogin/${email}/${senha}`;

  //Faz a requisição à API
  fetch(url)
    .then(response => response.text().then(data => ({ status: response.status, body: data })))
    .then(result => {
      // Verifica o código de status da resposta
      if (result.status === 200) {
        // Login aceito, redireciona o usuário para a página desejada
        window.location.href = "../menu_principal/menu_inicial.html"; // Substitua pelo URL desejado
      } else {
        // Exibe a mensagem de erro
        alert("Email ou senha está errado pai");
      }
    })
    .catch(error => {
      console.error("Erro ao fazer a requisição:", error);
    });

});