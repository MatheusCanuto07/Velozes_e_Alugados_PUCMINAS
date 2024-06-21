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
        carrosContainer.innerHTML = ''; // Limpar conteúdo anterior
        data.forEach(carro => {
            const carCard = document.createElement('div');
            carCard.className = 'card';
            carCard.innerHTML = `
                <img src="${carro.endereco_imagem}" alt="Imagem do carro">
                <div class="card-content">
                    <p class="marca">${carro.marca}</p>
                    <p class="modelo">${carro.modelo}</p>
                    <p class="ano">${carro.ano}</p>
                    <button><a href="../info_carro/info_carro.html?placa=${carro.placa}">Ver mais</a></button>
                </div>
            `;
            carrosContainer.appendChild(carCard);
        });

        // Inicialização da filtragem após a criação dos cards
        initCardFiltering();
    })
    .catch(error => {
        console.error('Error fetching data:', error);
    });

    function initCardFiltering() {
        const anoInput = document.getElementById("ano");
        const modeloInput = document.getElementById("modelo");
        const marcaInput = document.getElementById("marca");
        const cardsContainer = document.querySelector(".cards-container");

        const noResultsMessage = document.createElement("p");
        noResultsMessage.textContent = "Nenhum veículo disponível nos critérios informados";
        noResultsMessage.style.display = "none";
        noResultsMessage.style.color = "#ffffff";
        cardsContainer.appendChild(noResultsMessage);

        function filterCards() {
            const cards = document.querySelectorAll(".card"); // Movido para dentro da função de filtragem
            const anoFilter = anoInput.value.toLowerCase();
            const modeloFilter = modeloInput.value.toLowerCase();
            const marcaFilter = marcaInput.value.toLowerCase();
            let hasResults = false;

            cards.forEach(card => {
                const ano = card.querySelector(".ano").textContent.toLowerCase();
                const modelo = card.querySelector(".modelo").textContent.toLowerCase();
                const marca = card.querySelector(".marca").textContent.toLowerCase();

                const anoMatches = ano.includes(anoFilter);
                const modeloMatches = modelo.includes(modeloFilter);
                const marcaMatches = marca.includes(marcaFilter);

                if (anoMatches && modeloMatches && marcaMatches) {
                    card.style.display = "";
                    hasResults = true;
                } else {
                    card.style.display = "none";
                }
            });

            noResultsMessage.style.display = hasResults ? "none" : "block";
        }

        anoInput.addEventListener("input", filterCards);
        modeloInput.addEventListener("input", filterCards);
        marcaInput.addEventListener("input", filterCards);
        document.getElementById("pesquisar").addEventListener("click", filterCards);
    }
});