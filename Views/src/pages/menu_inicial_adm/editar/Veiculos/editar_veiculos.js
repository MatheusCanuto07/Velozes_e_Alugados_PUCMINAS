document.addEventListener('DOMContentLoaded', function () {
  const inputs = document.querySelectorAll('input, textarea, select');
  inputs.forEach(input => {
    input.disabled = true;
  });
  carregaDados();
})

function carregaDados() {
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
              <input type="text" class="${carro.placa}" value="${carro.placa}">
            </th>
            <td><input type="text" class="${carro.placa}" value="${carro.modelo}"></td>
            <td><input type="text" class="${carro.placa}" value="${carro.marca}"></td>
            <td><input type="text" class="${carro.placa}" value="${carro.cor}"></td>
            <td><input type="text" class="${carro.placa}" value="${carro.ano}"></td>
            <td><input type="text" class="${carro.placa}" value="${carro.km}"></td>
            <td><input type="text" class="${carro.placa}" value="${carro.disponibilidade}"></td>
            <td><input type="text" class="${carro.placa}" value="${carro.precoKm}"></td>
            <td><input type="text" class="${carro.placa}" value="${carro.precoDiaria}"></td>
            <td><input type="text" class="${carro.placa}" value="${carro.observacoes}"></td>
            <td><button class="btn btn-warning" class="${carro.placa}" onclick="editaCarro('${carro.placa}')">Editar</button></td>
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

function editaCarro(placa) {
  const inputs = document.querySelectorAll('.' + placa);

  // Itera sobre os inputs selecionados
  inputs.forEach(input => {
    input.disabled = false;
  });

  const carro = {
    placa: 'ABC1234',
    modelo: 'Civic',
    marca: 'Honda',
    cor: 'Prata',
    ano: 2020,
    km: 10000,
    disponibilidade: 1,
    precoKm: 1.5,
    precoDiaria: 150,
    observacoes: 'Nenhuma'
  };

  // URL da API e placa do carro que você quer editar
  const url = `sua_url_da_api/carros/${carro.placa}`;

  // Requisição PUT
  fetch(url, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(carro) // Converte o objeto carro para JSON
  })
    .then(response => {
      if (!response.ok) {
        throw new Error(`Erro ao editar o carro: ${response.status} - ${response.statusText}`);
      }
      console.log('Carro editado com sucesso.');
      // Faça algo após a edição, se necessário
    })
    .catch(error => {
      console.error('Erro ao tentar editar o carro:', error);
      // Trate o erro conforme necessário
    });

}