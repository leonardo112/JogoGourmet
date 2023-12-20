using JogoGourmet.App.Interfaces;
using JogoGourmet.App.Models;

namespace JogoGourmet.App
{
    public class Iniciar
    {
        private readonly IJogoService _jogoService;

        public Iniciar(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        public void IniciarJogo()
        {
            var raiz = new Atributo(string.Empty, new Prato(Messages.BoloDeChocolate));
            raiz.NovoAtributo(Messages.Massa, new Prato(Messages.Lasanha));

            while (true)
            {
                _jogoService.ExibirPenseEmUmPrato();
                ChecarAtributo(raiz);
            }
        }

        private void ChecarAtributo(Atributo caracteristica)
        {
            if (IsPratoDeUmSubAtributo(caracteristica))
                return;

            if (IsPratoAssociado(caracteristica))
            {
                _jogoService.ExibirAcerto();
                return;
            }

            AddNovoPratoComSubAtributo(caracteristica);
        }

        /// <summary>
        /// Verifica se o prato pensado pelo usuário foi encontrado em alguma das subcaracterísticas daquela característica
        /// </summary>
        private bool IsPratoDeUmSubAtributo(Atributo caracteristica)
        {
            foreach (var sub in caracteristica.AtributoSecudario)
            {
                if (_jogoService.IsPratoPensadoCaracterizadoPor(sub.Descricao))
                {
                    ChecarAtributo(sub);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Verifica se o prato pensado pelo usuário é o prato que está associado àquela característica.
        /// </summary>
        private bool IsPratoAssociado(Atributo caracteristica)
        {
            return _jogoService.IsPratoPensadoIgual(caracteristica.PratoAssociado.Nome);
        }

        /// <summary>
        /// Recebe um novo prato associado a uma subcaracterística
        /// </summary>
        private void AddNovoPratoComSubAtributo(Atributo caracteristicaPai)
        {
            var novoPrato = new Prato(_jogoService.ReceberNovoPrato());

            string descricaoSub =
                _jogoService.ReceberDiferencaEntrePratos(novoPrato.Nome, caracteristicaPai.PratoAssociado.Nome);

            caracteristicaPai.NovoAtributo(descricaoSub, novoPrato);
        }
    }
}
