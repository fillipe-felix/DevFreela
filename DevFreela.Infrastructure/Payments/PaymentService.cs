using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DevFreela.Core.DTOs;
using DevFreela.Core.Services;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IMessageBusService _messageBusService;
        private const string QUEUE_NAME = "Payments";

        public PaymentService(IMessageBusService messageBusService)
        {
            _messageBusService = messageBusService;
        }

        public void ProcessPayment(PaymentInfoDto paymentInfoDto)
        {
            var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDto);

            var paymentInfoBytes = Encoding.UTF8.GetBytes(paymentInfoJson);
            
            _messageBusService.Publish(QUEUE_NAME, paymentInfoBytes);
        }
    }
}