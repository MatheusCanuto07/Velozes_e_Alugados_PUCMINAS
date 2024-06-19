document.addEventListener("DOMContentLoaded", function () {
    // Carregar dados do usuário ao carregar a página
    var dadosRecuperados = JSON.parse(sessionStorage.getItem('dadosUsuario'));
    var usuario = JSON.parse(dadosRecuperados);
    console.log(usuario);
    
    fetch(`https://localhost:7090/api/pessoa/${usuario.pessoaCpf}`, {
        method: 'GET'
    })
        .then(response => response.json())
        .then(data => {
            console.log("Todo objeto data: ", data);
            
            let dataNascimento = data.data_NASCIMENTO;
            if (dataNascimento) {
                const date = new Date(dataNascimento);
                const formattedDate = `${String(date.getDate()).padStart(2, '0')}/${String(date.getMonth() + 1).padStart(2, '0')}/${date.getFullYear()}`;
                document.getElementById('data_NASCIMENTO').value = formattedDate;
            }

            document.getElementById('cpf').value = data.cpf;
            document.getElementById('nomE_PESSOA').value = data.nomE_PESSOA;
            //document.getElementById('cnH_PESSOA').value = data.cnH_PESSOA;
            document.getElementById('ceP_PESSOA').value = data.ceP_PESSOA;
            document.getElementById('logradouro').value = data.logradouro;
            document.getElementById('numero').value = data.numero;
            //document.getElementById('complemento').value = data.complemento;
            //document.getElementById('bairro').value = data.bairro;
            document.getElementById('cidade').value = data.cidade;
            document.getElementById('uf').value = data.uf;
            document.getElementById('sexo').value = data.sexo;
            document.getElementById('email').value = usuario.email;
            //document.getElementById('tipo').value = data.tipo;
            
            //document.getElementById('senha').value = data.senha;
        })
        .catch(error => console.error('Erro ao carregar os dados:', error));

    // Enviar dados do usuário ao clicar em enviar
    /*document.getElementById('userForm').addEventListener('submit', function (event) {
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
    document.getElementById('cep').addEventListener('blur', function () {
        const cep = this.value.replace(/\D/g, '');
        if (cep.length !== 8) return;

        const xhr = new XMLHttpRequest();
        xhr.open('GET', `https://viacep.com.br/ws/${cep}/json/`);
        xhr.onload = function () {
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
    birthdateInput.addEventListener('input', function (event) {
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

    genderInput.addEventListener('click', function () {
        optionsList.classList.toggle('active');
    });

    options.forEach(option => {
        option.addEventListener('click', function () {
            genderInput.value = this.dataset.value;
            optionsList.classList.remove('active');
        });
    });*/
});
