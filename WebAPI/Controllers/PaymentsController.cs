using Business.Adapters.PaymentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("payment")]
        public IActionResult Payment()
        {
            _paymentService.SetForm();
            _paymentService.SetBuyer();
            _paymentService.SetShipping();
            _paymentService.SetBilling();
            _paymentService.SetItems();
            var paymentForm = _paymentService.PaymentForm();
            return Ok(paymentForm);
        }

        [HttpGet("callback")]
        public IActionResult Callback(string token)
        {
            var checkoutForm = _paymentService.CallbackForm(token);
            return Ok(checkoutForm);
        }
    }
}
