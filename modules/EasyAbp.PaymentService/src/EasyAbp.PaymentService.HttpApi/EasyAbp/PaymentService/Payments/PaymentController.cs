using System;
using System.Threading.Tasks;
using EasyAbp.PaymentService.Payments.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.PaymentService.Payments
{
    [RemoteService(Name = "PaymentService")]
    [Route("/api/paymentService/payment")]
    public class PaymentController : PaymentServiceController, IPaymentAppService
    {
        private readonly IPaymentAppService _service;

        public PaymentController(IPaymentAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<PaymentDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<PaymentDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpGet]
        [Route("paymentMethod")]
        public Task<ListResultDto<PaymentMethodDto>> GetListPaymentMethod()
        {
            return _service.GetListPaymentMethod();
        }

        [HttpPost]
        [Route("pay")]
        public Task<PaymentDto> PayAsync(PayDto input)
        {
            return _service.PayAsync(input);
        }
    }
}