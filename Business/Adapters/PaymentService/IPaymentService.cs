using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Adapters.PaymentService
{
    public interface IPaymentService
    {
        void SetForm();
        void SetBuyer();
        void SetShipping();
        void SetBilling();
        void SetItems();
        object PaymentForm();
        object CallbackForm(string token);

    }
}
