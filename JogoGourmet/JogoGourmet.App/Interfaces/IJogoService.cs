namespace JogoGourmet.App.Interfaces
{
    public interface IJogoService
    {
        void ExibirPenseEmUmPrato();

        bool IsPratoPensadoCaracterizadoPor(string caracteristica);

        bool IsPratoPensadoIgual(string prato);

        string ReceberNovoPrato();

        string ReceberDiferencaEntrePratos(string pratoNovo, string pratoDeComparacao);

        void ExibirAcerto();
    }
}
