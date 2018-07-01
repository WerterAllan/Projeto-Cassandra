
using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Werter.ProjetoCassandra.Domain.Contracts;

namespace Werter.ProjetoCassandra.Api.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        protected BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public new IActionResult Response(object Result, IEnumerable<Notification> Notifications)
        {
            if (!Notifications.Any())
                return BadRequest(new { success = false, errors = Notifications });

            try
            {
                _unitOfWork.Commit();
                return Ok(new { success = true, data = Result });
            }
            catch (Exception erro)
            {
                return TratarErro(erro);
            }


        }

        public IActionResult TratarErro(Exception erro)
        {
            // adicionar aqui um serviço que loga os erros            

            var notificacaoDeErro = new Notification[] { new Notification("BadRequest", erro.Message) };
            var retornoParaOCliente = new { success = false, errors = notificacaoDeErro };
            return BadRequest(retornoParaOCliente);
        }
    }

}