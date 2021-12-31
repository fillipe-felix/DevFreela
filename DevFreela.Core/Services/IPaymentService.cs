using System.Threading.Tasks;
using DevFreela.Core.DTOs;

namespace DevFreela.Core.Services
{
    public interface IPaymentService
    {
        void ProcessPayment(PaymentInfoDto paymentInfoDto);
    }
}