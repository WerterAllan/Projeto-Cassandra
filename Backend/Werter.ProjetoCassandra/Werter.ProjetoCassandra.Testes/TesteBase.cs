using Bogus;
using Bogus.Extensions.Brazil;
using Flunt.Notifications;
using System;
using System.Linq;
using Werter.ProjetoCassandra.Domain.StoreContext.Entities;
using Werter.ProjetoCassandra.Domain.StoreContext.FluentBuilder;

namespace Werter.ProjetoCassandra.Testes
{
    public abstract class TesteBase
    {
        public Faker Fake { get; }
        public TesteBase()
        {
            Fake = new Faker("pt_BR");
        }

        public PedidoBuilder MontarPedidoBasico()
        {
            return new PedidoBuilder()
                .Nome(Fake.Person.FirstName, Fake.Person.LastName)
                .Documento(Fake.Person.Cpf())
                .Email(Fake.Person.Email);                
        }

        public Produto UmProduto()
        {
            return new Produto(Fake.Commerce.ProductName(), Fake.Commerce.ProductAdjective(), Fake.Random.Decimal(10, 5000));
        }

        public Pedido MontarUmPedidoSimples()
        {
            return MontarPedidoBasico()
                            .AdicionarProduto(UmProduto(), 5)
                            .Build();
        }


        public string ExtrairAsNotificacoes<T>(T objetoNotificavel) where T : Notifiable
        {

            var descriptions = objetoNotificavel.Notifications
                .Select(x => $"Property: {x.Property} Message: {x.Message}")
                .ToList();

            var texto = string.Join("\n", descriptions);

            if (descriptions.Count > 0)
                Console.WriteLine(texto);

            return texto;
        }
    }
}
