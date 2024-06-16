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
        var carros = JSON.parse(result.body);
        carros.forEach(carro => {
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
            <td><button class="btn btn-warning" id="${carro.placa}" class="${carro.placa}" onclick="editaCarro('${carro.placa}')">Editar</button></td>
            <td><button class="btn btn-danger" onclick="deletaCarro('${carro.placa}')">Apagar</button></td>
          </tr>
          `;
        });
        var body_table_carros = document.getElementById("body_table_carros");
        body_table_carros.innerHTML = str;

        // Seleciona todos os elementos input na página
        const Todosinputs = document.querySelectorAll('input');

        // Itera sobre todos os inputs e os desabilita
        Todosinputs.forEach(input => {
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
  // URL da API e placa do carro que você quer editar
  const url = `https://localhost:7090/api/Carro`;
  var botao = document.getElementById(placa);
  console.log(botao.innerHTML);

  var inputs = document.querySelectorAll('.' + placa);
  inputArray = [...inputs];

  if (botao.innerHTML == "Enviar") {
    var carro = {
      placa: inputArray[0].value,
      modelo: inputArray[1].value,
      marca: inputArray[2].value,
      cor: inputArray[3].value,
      ano: parseInt(inputArray[4].value),
      km: parseInt(inputArray[5].value),
      disponibilidade: parseInt(inputArray[6].value),
      precoKm: parseInt(inputArray[7].value),
      precoDiaria: parseInt(inputArray[8].value),
      observacoes: inputArray[9].value
    };

    carroConvertido = JSON.stringify(carro);
    console.log(carroConvertido);

    fetch(url, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: carroConvertido // Converte o objeto carro para JSON
    })
      .then(response => {
        
        if (!response.ok) {
          throw new Error(`Erro ao editar o carro: ${response.status} - ${response.statusText}`);
        }

        inputs.forEach(input => {
          input.disabled = true;
        });

        botao.className = '';
        botao.classList.add('btn', 'btn-warning');
        botao.innerHTML = "Editar";
        alert('Carro editado com sucesso.');
      })
      .catch(error => {
        console.error('Erro ao tentar editar o carro:', error);
        // Trate o erro conforme necessário
      });
  } else {
    botao.innerHTML = "Enviar";
    botao.className = '';
    botao.classList.add('btn', 'btn-success');

    inputs.forEach(input => {
      input.disabled = false;
    });
    
  }



}