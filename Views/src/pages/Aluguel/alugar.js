document.addEventListener('DOMContentLoaded', function () {
    lerPessoa();

    const finalizarButton = document.querySelector('.entrar');
    finalizarButton.addEventListener('click', function (event) {
        event.preventDefault(); // Evita o comportamento padrão do botão de enviar um formulário
        alugarCarro();
    });
});

function lerPessoa() {
    var dadosRecuperados = JSON.parse(sessionStorage.getItem('dadosUsuario'));
    var usuario = JSON.parse(dadosRecuperados);
    console.log(usuario);

    fetch(`https://localhost:7090/api/pessoa/${usuario.pessoaCpf}`, {
        method: 'GET'
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok ' + response.statusText);
            }
            return response.json();
        })
        .then(pessoa => {
            preencherDetalhes(pessoa);
        })
        .catch(error => console.error('Erro ao buscar dados do carro:', error));
}

function preencherDetalhes(pessoa) {
    console.log('Preenchendo detalhes da pessoa:', pessoa);
    const nomePessoa = document.getElementById('nome');
    const placaCarro = document.getElementById('placa');
    const params = new URLSearchParams(window.location.search);
    const idplacaCarro = params.get('placa');

    // Definindo o valor dos elementos input
    nomePessoa.value = pessoa.nomE_PESSOA;
    placaCarro.value = idplacaCarro;
}

function alugarCarro() {
    const nomePessoa = document.getElementById('nome').value;
    const placaCarro = document.getElementById('placa').value;
    const dataInicio = document.querySelector('input[name="dataInicio"]').value;
    const dataFim = document.querySelector('input[name="dataFim"]').value;
    const valorTotal = document.querySelector('input[name="valorTotal"]').value;
    const infoLocacao = document.querySelector('input[name="infoLocacao"]').value;
    
    var dadosRecuperados = JSON.parse(sessionStorage.getItem('dadosUsuario'));
    var usuario = JSON.parse(dadosRecuperados);
    console.log(usuario);

    const cpfCliente = usuario.pessoaCpf;
    console.log('CPF do cliente:', cpfCliente);
    const locacao = {
        
        cliente_pessoa_cpf: cpfCliente,
        carro_placa: placaCarro,
        dataInicio: new Date(dataInicio).toISOString(),
        dataFim: new Date(dataFim).toISOString(),
        valorTotal: parseFloat(valorTotal),
        kmInicial: 0,
        kmFinal: 0,
        infoLocacao: infoLocacao
    };
    console.log(locacao);

    fetch('https://localhost:7090/Alugar', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(locacao)
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok ' + response.statusText);
        }
        return response.json();
    })
    .then(data => {
        console.log('Locação realizada com sucesso:', data);
        // Redirecionar ou exibir mensagem de sucesso
    })
    .catch(error => console.error('Erro ao realizar a locação:', error));
}
