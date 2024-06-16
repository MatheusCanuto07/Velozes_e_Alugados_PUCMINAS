function capturarValores() {

  var placa = document.getElementById('placa').value;
  var modelo = document.getElementById('modelo').value;
  var marca = document.getElementById('marca').value;
  var cor = document.getElementById('cor').value;
  var ano = parseInt(document.getElementById('ano').value);
  var km = parseInt(document.getElementById('km').value);
  var disponibilidade = parseInt(document.getElementById('disponibilidade').value);
  var precoKm = parseInt(document.getElementById('precoKm').value);
  var precoDiaria = parseInt(document.getElementById('precoDiaria').value);
  var observacoes = document.getElementById('observacoes').value;

  var isValid = true;

  if (placa === '') {
    isValid = false;
    alert('Por favor, informe a placa do veículo.');
  }

  if (modelo === '') {
    isValid = false;
    alert('Por favor, informe o modelo do veículo.');
  }

  if (marca === '') {
    isValid = false;
    alert('Por favor, informe a marca do veículo.');
  }

  if (cor === '') {
    isValid = false;
    alert('Por favor, informe a cor do veículo.');
  }

  if (isNaN(ano) || ano <= 0) {
    isValid = false;
    alert('Por favor, informe um ano válido.');
  }

  if (isNaN(km) || km < 0) {
    isValid = false;
    alert('Por favor, informe uma quilometragem válida.');
  }

  if (isNaN(disponibilidade) || disponibilidade < 0) {
    isValid = false;
    alert('Por favor, informe uma disponibilidade válida.');
  }

  if (isNaN(precoKm) || precoKm < 0) {
    isValid = false;
    alert('Por favor, informe um preço por quilômetro válido.');
  }

  if (isNaN(precoDiaria) || precoDiaria < 0) {
    isValid = false;
    alert('Por favor, informe um preço por diária válido.');
  }

  // Exibir feedback para observações se estiver vazio
  if (observacoes === '') {
    alert('Por favor, informe observações sobre o veículo.');
  }

  // Se o formulário for válido, você pode enviar os dados
  if (isValid) {
    // Aqui você pode fazer o que quiser com os dados válidos, como enviar para um backend
    alert('Formulário validado com sucesso!');

    // Exemplo: Envio para um backend (requer implementação backend)
    enviaDados(placa, modelo, marca, cor, ano, km, disponibilidade, precoKm, precoDiaria, observacoes);
  }

}

function enviaDados(placa, modelo, marca, cor, ano, km, disponibilidade, precoKm, precoDiaria, observacoes) {
  // Fazendo a requisição fetch
  var url = "https://localhost:7090/api/Carro";

  var formData = {
    placa: placa,
    modelo: modelo,
    marca: marca,
    cor: cor,
    ano: ano,
    km: km,
    disponibilidade: disponibilidade,
    precoKm: precoKm,
    precoDiaria: precoDiaria,
    observacoes: observacoes
  };

  carroConvertido = JSON.stringify(formData);

  fetch(url, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: carroConvertido
  })
    .then(response => {
      if (!response.ok) {
        throw new Error('Ocorreu um erro ao enviar o formulário.');
      }
      console.log(response.json());
    })
    .then(data => {
      console.log('Resposta do servidor:', data);
      alert('Formulário enviado com sucesso!');
      // Aqui você pode realizar alguma ação após o envio bem sucedido
    })
    .catch(error => {
      console.error('Erro ao enviar formulário:', error);
      alert('Ocorreu um erro ao enviar o formulário. Por favor, tente novamente.');
    });
}
