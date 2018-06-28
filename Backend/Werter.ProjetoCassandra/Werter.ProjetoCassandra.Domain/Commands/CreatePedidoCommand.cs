using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using Werter.ProjetoCassandra.Domain.StoreContext.ValueObject;
using Werter.ProjetoCassandra.Shared.Contracts;

namespace Werter.ProjetoCassandra.Domain.Commands
{
    public sealed class CreatePedidoCommand : Notifiable, ICommand
    {

        public string NomeCliente { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataPedido { get; set; }
        public List<CreatePedidoItemCommand> CreatePedidoItensCommands { get; set; }
        


        public bool EValido()
        {
            AddNotifications(new Contract()
              .HasMinLen(NomeCliente, 3, "NomeCliente", "O nome deve ter mais de 3 caracteres")                            
              .HasMaxLen(NomeCliente, 50, "NomeCliente", "O nome não pode ter mais de 50 caracteres")
              .IsEmail(Email, "Email", "Email inválido")
              .IsTrue(Documento.CpfValido(Cpf), "Cpf", "CPF inválido")
              );

            return Valid;
        }
    }
}
