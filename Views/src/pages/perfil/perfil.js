document.addEventListener("DOMContentLoaded", function() {
    // Carregar dados do usuário ao carregar a página
    fetch('/api/user')
        .then(response => response.json())
        .then(data => {
            document.getElementById('name').value = data.name;
            document.getElementById('email').value = data.email;
            document.getElementById('age').value = data.age;
            document.getElementById('cep').value = data.cep;
            document.getElementById('street').value = data.street;
            document.getElementById('neighborhood').value = data.neighborhood;
            document.getElementById('city').value = data.city;
            document.getElementById('state').value = data.state;
            document.getElementById('birthdate').value = data.birthdate;
            document.getElementById('gender').value = data.gender;
        })
        .catch(error => console.error('Erro ao carregar os dados:', error));

    // Enviar dados do usuário ao clicar em enviar
    document.getElementById('userForm').addEventListener('submit', function(event) {
        event.preventDefault();
        
        const userData = {
            name: document.getElementById('name').value,
            email: document.getElementById('email').value,
            age: document.getElementById('age').value,
            cep: document.getElementById('cep').value,
            street: document.getElementById('street').value,
            neighborhood: document.getElementById('neighborhood').value,
            city: document.getElementById('city').value,
            state: document.getElementById('state').value,
            birthdate: document.getElementById('birthdate').value,
            gender: document.getElementById('gender').value
        };
        
        fetch('/api/user', {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userData)
        })
        .then(response => response.json())
        .then(data => {
            alert('Dados atualizados com sucesso!');
        })
        .catch(error => console.error('Erro ao atualizar os dados:', error));
    });

    // Automatização do CEP
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
                document.getElementById('street').value = data.logradouro;
            }
        };
        xhr.send();
    });

    // Validação da data de nascimento
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

    // Validação do Gênero
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
});
