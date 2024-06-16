console.log("pimba")

document.addEventListener('DOMContentLoaded', function () {
  var url = "https://localhost:7090/api/Carro";

  fetch(url)
    .then(response => response.text()
      .then(data => ({ status: response.status, body: data })))
    .then(result => {
      var str = "";

      if (result.status === 200) {
        console.log(result.body);
        var carros = JSON.parse(result.body);
        carros.forEach(carro => {
          console.log(carro);
          str += `
            <tr>
              <th scope="row">${carro.placa}</th>
              <td>${carro.modelo}</td>
              <td>${carro.marca}</td>
              <td>${carro.cor}</td>
              <td>${carro.ano}</td>
              <td>${carro.km}</td>
              <td>${carro.disponibilidade}</td>
              <td>${carro.precoKm}</td>
              <td>${carro.precoDiaria}</td>
              <td>${carro.observacoes}</td>
              
            </tr>
          `;
        });
        var body_table_carros = document.getElementById("body_table_carros");
        //body_table_carros.innerHTML = str;

        // Seleciona todos os elementos input na página
        const inputs = document.querySelectorAll('input');

        // Itera sobre todos os inputs e os desabilita
        inputs.forEach(input => {
          input.disabled = true;
        });

      } else {
        alert("Ocorreu um erro, contate a equipe de suporte");
      }
    })
    .catch(error => {
      console.error("Erro ao fazer a requisição:", error);
    });

})