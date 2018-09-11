using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Eron.Business.Core.Services.Financial.Base.Bank;
using Eron.Business.Core.Services.Financial.Base.Invoice;
using Eron.Business.Core.Services.Financial.Base.Invoice.Dto;
using Eron.Core.AppEnums;
using Eron.Core.ManagementSettings;
using Eron.Presentation.WebApplication.WebApi.Infrastructure;
using Microsoft.AspNet.Identity;

namespace Eron.Presentation.WebApplication.WebApi.Api.Financial.Base
{
    [Authorize]
    [RoutePrefix("api/invoice")]
    public class InvoiceController : BaseApiController
    {
        private readonly IInvoiceAppService _invoiceAppService;
        private readonly IBankAppService _bankAppService;

        public InvoiceController(
            IInvoiceAppService invoiceAppService,
            IBankAppService bankAppService)
        {
            _invoiceAppService = invoiceAppService;
            _bankAppService = bankAppService;
        }

        public async Task<IHttpActionResult> Get()
        {
            var userId = User.Identity.GetUserId();
            var result = await _invoiceAppService.GetUserInvoices(userId);
            return Ok(result);
        }

        [Route("number/{invoiceNumber}")]
        public async Task<IHttpActionResult> Get(string invoiceNumber)
        {
            var result = await _invoiceAppService.GetUserInvoice(invoiceNumber);
            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [Route("management/number/{invoiceNumber}")]
        public async Task<IHttpActionResult> GetByNumber(string invoiceNumber)
        {
            var result = await _invoiceAppService.GetInvoiceByNumber(invoiceNumber);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("AllProductInvoices")]
        public async Task<IHttpActionResult> AllProductInvoices(InvoiceListRequestDto input)
        {
            var result = await _invoiceAppService.GetAllProductInvoicesAsPagedList(input);
            return Ok(result);
        }

        [HttpPost]
        [Route("AllInvoices")]
        [Authorize(Roles = "admin")]
        public async Task<IHttpActionResult> AllInvoices(InvoiceListRequestDto input)
        {
            var result = await _invoiceAppService.GetAllInvoicesAsPagedList(input);
            return Ok(result);
        }

        [HttpPost]
        [Route("ChangeStateOfInvoiceList")]
        public async Task<IHttpActionResult> ChangeStateOfInvoiceList(InvoiceChangeStatusDto input)
        {
            var userId = User.Identity.GetUserId();
            var result = await _invoiceAppService.ChangeStateOfInvoiceList(input, userId);
            return Ok(result);
        }

        [HttpPost]
        [Route("ByCart")]
        public async Task<IHttpActionResult> CreateByCart()
        {
            var result = await _invoiceAppService.CreateInvoiceByCart();
            return Ok(result);
        }

        [HttpPost]
        [Route("ByOrders")]
        public async Task<IHttpActionResult> CreateByOrders([FromBody]List<string> orderNumbers)
        {
            var result = await _invoiceAppService.CreateInvoiceByOrders(orderNumbers);
            return Ok(result);
        }

        [HttpGet]
        [Route("CreateReferenceNumber/{invoiceNumber}")]
        public async Task<IHttpActionResult> CreateReferenceNumber(string invoiceNumber)
        {
            //create new transaction - set it to unpaid, set refId and send to bank
            var userId = User.Identity.GetUserId();
            var invoice = (await _invoiceAppService.GetInvoiceByNumber(invoiceNumber));

            var invoiceVerified = invoice.VerifyInvoice();

            BankNameType bankNameType = ApplicationSettings.DefaultBankName;
            //if (bankName.IsPopulated())
            //    Enum.TryParse(bankName, out bankNameType);

            if (invoiceVerified)
            {
                var refId = await _bankAppService.CreateReference(bankNameType, userId, invoice.Id);
                return Ok(refId);
            }
            return BadRequest("فاکتور انتخابی قابل پرداخت نیست");
        }

        [HttpPost]
        [Route("Payment/CallBack")]
        public async Task<IHttpActionResult> Callback(string invoiceNumber)
        {
            //get the bank result and send it to 
            return Ok();
        }

        [HttpDelete]
        [Route("{invoiceNumber}")]
        [Authorize(Roles = "admin")]
        public IHttpActionResult Delete(string invoiceNumber)
        {
            throw new NotImplementedException();
        }
    }
}