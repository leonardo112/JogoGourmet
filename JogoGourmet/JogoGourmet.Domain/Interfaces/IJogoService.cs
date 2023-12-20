﻿namespace JogoGourmet.Domain.Interfaces
{
    public interface IJogoService
    {
        void ExibirPenseEmUmPrato();

        bool IsPratoPensadoCaracterizadoPor(string caracteristica);

        bool IsPratoPensadoIgual(string prato);

        string ReceberNovoPrato();

        string ReceberDiferencialEntrePratos(string pratoNovo, string pratoDeComparacao);

        void ExibirAcerto();
    }
}
