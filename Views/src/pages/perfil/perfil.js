//Automatização do CEP
document.getElementById('cep').addEventListener('blur', function() {
    const cep = this.value.replace(/\D/g, '');
    if (cep.length !== 8) return;

    const xhr = new XMLHttpRequest();
    xhr.open('GET', `https://viacep.com.br/ws/${cep}/json/`);
    xhr.onload = function() {
        const data = JSON.parse(xhr.responseText);
        if (!data.erro) {
            document.getElementById('state').value = data.uf;
            document.getElementById('city').value = data.localidade;
            document.getElementById('neighborhood').value = data.bairro;
            document.getElementById('street').value = data.logradouro; // Adiciona a rua
        }
    };
    xhr.send();
});

//Validação da data de nascimento
const birthdateInput = document.getElementById('birthdate');

birthdateInput.addEventListener('input', function(event) {
    let value = event.target.value;

    value = value.replace(/\D/g, '');

    if (value.length > 2) {
        value = value.substring(0, 2) + '/' + value.substring(2);
    }
    if (value.length > 5) {
        value = value.substring(0, 5) + '/' + value.substring(5, 9);
    }

    event.target.value = value;
});


//Validação do Gênero
const genderInput = document.getElementById('gender');
const optionsList = document.querySelector('.options');
const options = document.querySelectorAll('.option');

genderInput.addEventListener('click', function() {
    optionsList.classList.toggle('active');
});

options.forEach(option => {
    option.addEventListener('click', function() {
        genderInput.value = this.dataset.value;
        optionsList.classList.remove('active');
    });
});
