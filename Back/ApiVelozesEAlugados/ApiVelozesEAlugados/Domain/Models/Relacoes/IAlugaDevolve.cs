<<<<<<< HEAD
﻿using ApiVelozesEAlugados.Application.ViewModel;
using CarroName;
=======
﻿using CarroName;
>>>>>>> developer

namespace ApiVelozesEAlugados.Domain.Models.Relacoes
{
    public interface IAlugaDevolve
    {
<<<<<<< HEAD
        void add(AlugaDevolveViewModel alugadevolve);
        List<AlugaDevolve> Get();

        Carro GetByCod(int codlocacao);


        void Update(int codlocacao, AlugaDevolveViewModel alugadevolve);
=======
        List<AlugaDevolve> Get();
>>>>>>> developer
    }
}
