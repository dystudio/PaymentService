using System;
using System.Threading.Tasks;
using EasyAbp.PaymentService.Refunds.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.PaymentService.Refunds
{
    [RemoteService(Name = "PaymentService")]
    [Route("/api/paymentService/refund")]
    public class RefundController : PaymentServiceController, IRefundAppService
    {
        private readonly IRefundAppService _service;

        public RefundController(IRefundAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<RefundDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<RefundDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return _service.GetListAsync(input);
        }
    }
}