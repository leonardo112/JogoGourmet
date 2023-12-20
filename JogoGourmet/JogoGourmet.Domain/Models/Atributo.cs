namespace JogoGourmet.Domain.Models
{
    public class Atributo
    {
        public string Descricao { get; }
        public Prato PratoAssociado { get; }

        private readonly ICollection<Atributo> _AtributoSecudario;
        public IReadOnlyCollection<Atributo> AtributoSecudario => _AtributoSecudario.ToList();

        public Atributo(string descricao, Prato pratoAssociado)
        {
            Descricao = descricao;
            PratoAssociado = pratoAssociado;

            _AtributoSecudario = new List<Atributo>();
        }

        public void NovaSubCaracteristica(string descricao, Prato pratoAssociado)
        {
            _AtributoSecudario.Add(new Atributo(descricao, pratoAssociado));
        }

    }
}
