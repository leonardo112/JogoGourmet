using JogoGourmet.App.Interfaces;

namespace JogoGourmet.App.Services
{
    public class JogoService : IJogoService
    {
        public void ExibirPenseEmUmPrato()
        {
            Console.WriteLine();
            Console.WriteLine(Messages.PenseEmUmPrato);
            Console.WriteLine();
        }

        public bool IsPratoPensadoIgual(string prato)
        {
            return LerBool(string.Format(Messages.PratoQuePensou, prato));
        }

        public bool IsPratoPensadoCaracterizadoPor(string caracteristica)
        {
            return LerBool(string.Format(Messages.PratoQuePensou, caracteristica));
        }

        public string ReceberNovoPrato()
        {
            return LerString(Messages.PerguntaQualPratoPensou);
        }

        public string ReceberDiferencaEntrePratos(string pratoNovo, string pratoDeComparacao)
        {
            return LerString(string.Format(Messages.PerguntaDiferencialEntre2Pratos, pratoNovo, pratoDeComparacao));
        }

        public void ExibirAcerto()
        {
            Console.WriteLine(Messages.Vitoria);
        }

        private static bool LerBool(string textoParaExibir)
        {
            Console.Write(textoParaExibir);

            bool? resposta = null;
            while (resposta == null)
            {
                string? respostaStr = Console.ReadLine()?.Trim().ToUpperInvariant();

                switch (respostaStr)
                {
                    case "S":
                        resposta = true;
                        break;

                    case "N":
                        resposta = false;
                        break;

                    default:
                        Console.WriteLine(Messages.RespostaBoolInvalida);
                        break;
                }
            }

            return resposta.Value;
        }

        private static string LerString(string textoParaExibir)
        {
            Console.Write(textoParaExibir);

            string? resposta = null;
            while (string.IsNullOrWhiteSpace(resposta))
            {
                resposta = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(resposta))
                    Console.WriteLine(Messages.RespostaStringInvalida);
            }

            return resposta;
        }
    }
}
