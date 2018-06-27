using Werter.ProjetoCassandra.Shared.Entities;

namespace Werter.ProjetoCassandra.Domain.StoreContext.Entities
{
    public class Produto : EntityBase
    {
        public Produto(string titulo, string descricao, decimal preco)
        {
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Preco = preco;
        }

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }

        public override string ToString()
        {
            return Titulo;
        }


    }
}
