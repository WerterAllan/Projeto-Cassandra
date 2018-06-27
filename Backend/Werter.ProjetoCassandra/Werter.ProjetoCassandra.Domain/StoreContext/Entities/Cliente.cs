using System;
using System.Collections.Generic;
using System.Text;
using Werter.ProjetoCassandra.Domain.StoreContext.ValueObject;

namespace Werter.ProjetoCassandra.Domain.StoreContext.Entities
{
    public class Cliente : EntityBase
    {
        public Cliente(Nome nome, Email email, Documento documento)
        {
            this.Nome = nome;
            this.Email = email;
            this.Documento = documento;
        }

        public Nome Nome { get; }
        public Email Email { get; }
        public Documento Documento { get; set; }

    }
}
