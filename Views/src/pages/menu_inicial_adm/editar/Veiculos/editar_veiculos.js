document.addEventListener('DOMContentLoaded', function () {
  const inputs = document.querySelectorAll('input, textarea, select');
  inputs.forEach(input => {
    input.disabled = true;
  });
  carregaDados();
})

function carregaDados(){
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
            <th scope="row">
              <input type="text" value="${carro.placa}">
            </th>
            <td><input type="text" value="${carro.modelo}"></td>
            <td><input type="text" value="${carro.marca}"></td>
            <td><input type="text" value="${carro.cor}"></td>
            <td><input type="text" value="${carro.ano}"></td>
            <td><input type="text" value="${carro.km}"></td>
            <td><input type="text" value="${carro.disponibilidade}"></td>
            <td><input type="text" value="${carro.precoKm}"></td>
            <td><input type="text" value="${carro.precoDiaria}"></td>
            <td><input type="text" value="${carro.observacoes}"></td>
            <td><button class="btn btn-warning" onclick="editaCarro('${carro.placa}')">Editar</button></td>
            <td><button class="btn btn-danger" onclick="deletaCarro('${carro.placa}')">Apagar</button></td>
          </tr>
          `;
        });
        var body_table_carros = document.getElementById("body_table_carros");
        body_table_carros.innerHTML = str;

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
}

function deletaCarro(placa) {
  console.log("Delete teste")

  fetch(`https://localhost:7090/api/Carro/${placa}`, {
    method: 'DELETE',
    headers: {
      'Content-Type': 'application/json'
    }
  })
    .then(response => {
      if (!response.ok) {
        throw new Error(`Erro ao tentar excluir o carro: ${response.status} - ${response.statusText}`);
      }
      console.log('Carro excluído com sucesso.');
      carregaDados();
    })
    .catch(error => {
      console.error('Erro ao tentar excluir o carro:', error);
      // Trate o erro conforme necessário
    });

}