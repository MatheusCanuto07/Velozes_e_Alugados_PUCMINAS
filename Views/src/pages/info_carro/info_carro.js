document.addEventListener('DOMContentLoaded', function () {
    lerCarro();
});

function lerCarro() {
    const params = new URLSearchParams(window.location.search);
    const idCarro = params.get('placa');

    fetch(`https://localhost:7090/api/Carro/${idCarro}`, {
        method: 'GET'
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok ' + response.statusText);
            }
            return response.json();
        })
        .then(carro => {
            preencherDetalhes(carro);
        })
        .catch(error => console.error('Erro ao buscar dados do carro:', error));
}

function preencherDetalhes(carro) {
    console.log('Preenchendo detalhes do carro:', carro);
    const nomeCarro = document.getElementById('marca-modelo');
    const disponibilidadeCarro = document.getElementById('disponibilidade');
    const precoDiaria = document.getElementById('preco-diaria');
    const kmCarro = document.getElementById('km');
    const anoCarro = document.getElementById('ano');
    const corCarro = document.getElementById('cor');
    const precoKm = document.getElementById('preco-kkm');
    const imagemCarro = document.getElementById('imagem-carro');

    nomeCarro.textContent = `${carro.modelo} / ${carro.marca}`;
    disponibilidadeCarro.textContent = carro.disponibilidade == 1 ? 'Veículo Disponível' : 'Veículo Indisponível';
    precoDiaria.textContent = `Preço Diária: R$ ${carro.precoDiaria}`;
    kmCarro.textContent = `Quilometragem: ${carro.km} km`;
    anoCarro.textContent = `Ano: ${carro.ano}`;
    corCarro.textContent = `Cor: ${carro.cor}`;
    precoKm.textContent = `Preço por Km: R$ ${carro.precoKm}`;
    imagemCarro.src = carro.endereco_imagem;
}
