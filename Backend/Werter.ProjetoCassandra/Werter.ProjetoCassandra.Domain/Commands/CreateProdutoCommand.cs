using Flunt.Notifications;
using System;
using Werter.ProjetoCassandra.Shared.Contracts;

namespace Werter.ProjetoCassandra.Domain.Commands
{
    public sealed class CreateProdutoCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public bool EValido()
        {
            return Valid;
        }
    }
}
