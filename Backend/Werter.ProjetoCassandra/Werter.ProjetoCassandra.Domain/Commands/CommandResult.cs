using System;
using System.Collections.Generic;
using System.Text;
using Werter.ProjetoCassandra.Shared.Handlers;

namespace Werter.ProjetoCassandra.Domain.Commands
{
    public sealed class CommandResult : ICommandResult
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }

        public dynamic Data { get; set; }

        public CommandResult() { }
        public CommandResult(bool sucesso, string mensagem, dynamic data = null)
        {
            this.Sucesso = sucesso;
            this.Mensagem = mensagem;
            this.Data = data;
        }
    }
}
