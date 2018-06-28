using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Werter.ProjetoCassandra.Domain.Repositories;

namespace Werter.ProjetoCassandra.Testes.Handlers
{
    [TestClass]
    public class PedidoHandlerTestes : TesteBase
    {
        private IPedidoRepository _pedidoRepository;
        


        [TestInitialize]
        public void SetUp()
        {
            _pedidoRepository = Substitute.For<IPedidoRepository>();            
        }

        
    }
}
