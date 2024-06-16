document.addEventListener('DOMContentLoaded', function() {
  var dadosRecuperados = JSON.parse(sessionStorage.getItem('dadosUsuario'));
  var usuario = JSON.parse(dadosRecuperados);

  tipo = "Funcionario";

  var menu_adm = document.getElementById("menu_adm");
  console.log(usuario.email);

  str = `
    <h3 id="title-bem-vindo">Bem-vindo Adm ${usuario.email}</h3>
      <div class="text-center mb-5">
        <a href="../menu_inicial_cliente/menu_inicial_cliente.html">
          <img class="img-fluid" id="logo-img" src="../../assets/imgs/Mini Logo.png" alt="Logo da empresa, um Z junto com um a e uma estrada que atravesa as duas letras">
        </a>
        
        <div class="d-flex flex-column align-items-center">
          <button class="btn-editar"><a href="cadastrar_veiculo/cadastrar.html"><p>Cadastrar veículos</p></a></button>
          <button class="btn-editar"><a href="editar/Veiculos/editar_veiculos.html"><p>Editar veículos</p></a></button>
        </div>
        <button class="btn-visao-geral"><a href="../menu_principal/menu_inicial.html"><p>Home</p></a></button>
      </div>
      `
  if(usuario.tipo == "Funcionario"){
    var menu_adm = document.getElementById("menu_adm");
    menu_adm.innerHTML = str; 
  }
});

