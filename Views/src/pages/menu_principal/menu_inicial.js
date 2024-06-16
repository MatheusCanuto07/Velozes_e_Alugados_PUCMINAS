document.addEventListener('DOMContentLoaded', function () {
    fetch('https://localhost:7090/api/Carro', {
        method: 'GET'
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok ' + response.statusText);
            }
            return response.json();
        })
        .then(data => {
            const carrosContainer = document.getElementById('carros-container');
            carrosContainer.innerHTML = ''; // Clear previous content if any
            console.log("teste_Higor_Matheus")
            data.forEach(carro => {
                const carCard = document.createElement('div');
                carCard.className = 'card';
                carCard.innerHTML = `
                    <img src="${carro.endereco_imagem}" alt="${carro.endereco_imagem}">
                    <div class="card-content">
                        <h3>${carro.marca}</h3>
                        <h3>${carro.modelo}</h3>
                        <p>${carro.cor}</p>
                        <button><a href="../info_carro/info_carro.html?placa=${carro.placa}">Ver mais</a></button>
                    </div>
                `;
                console.log(carCard);
                carrosContainer.appendChild(carCard);
            });
        })
        .catch(error => {
            console.error('Error fetching data:', error);
        });
});
