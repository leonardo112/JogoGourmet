using JogoGourmet.App.Services;

namespace JogoGourmet.App
{
    public class Program
    {
        public static void Main()
        {
            var jogo = new Iniciar(new JogoService());
            jogo.IniciarJogo();
        }
    }
}
