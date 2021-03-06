﻿using Bogus;
using Bogus.Extensions.Brazil;
using Flunt.Notifications;
using System;
using System.Linq;
using Werter.ProjetoCassandra.Domain.StoreContext.Entities;
using Werter.ProjetoCassandra.Domain.StoreContext.FluentBuilder;
using Werter.ProjetoCassandra.Testes.Helpers;

namespace Werter.ProjetoCassandra.Testes
{
    public abstract class TesteBase
    {
        private Random _gerador = new Random();
        public Faker Fake { get; }
        public TesteBase()
        {
            Fake = new Faker("pt_BR");
        }

        public int GerarValor(int inicial, int final) => _gerador.Next(inicial, final);

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

        public Cliente GerarClienteFake()
        {
            var cliente = new ClienteBuilder()                
                .Nome(Fake.Person.FirstName, Fake.Person.LastName)
                .Email(Fake.Person.Email)
                .Documento(Fake.Person.Cpf())
                .Build();

            return cliente;

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

        public static void Log(string info)
        {
            Console.WriteLine(info);
        }
    }
}
