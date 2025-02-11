using Ecommorce.Application.ILogger;
using Ecommorce.Application.Repository;
using Ecommorce.Model.ProductModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommorce.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {

        private readonly IRepositoryManager _repository;
        private readonly ILoggerManger _logger;

        public OrdersController(IRepositoryManager repository, ILoggerManger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("customer-orders /grid")]
        public IEnumerable<string> GetProductGrid()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet("customer-orders/{id}")]
        public string GetOrderById(int id)
        {
            return "value";
        }

        [HttpPost("customer-orders/product ")]
        public void OrderByProduct([FromBody] OrderDTO value)
        {





        }
        

     [HttpPost("customer-orders/{id}/cancel ")]
        public void CancelOrder([FromBody] OrderDTO value)
        {

            //orderId Int
            // CancelReason String



        }


        [HttpGet("customer-orders/{id}/complete ")]
        public string CompleteOrder(int id)
        {
            return "value";
        }

        

        [HttpPost("customer-orders/cart ")]
        public void OrderByCart([FromBody] OrderDTO value)
        {

            //userAddressId int
            //OrderNote strin



        }


        [HttpPost("customer-orders/{id}/pay ")]
        public void PayOrder(int id)
        {
            //OrderId Int


        }


        [HttpPost("mp/pay/notify/{no} ")]
        public void OrderPayNotify(int id)
        {
            //OrderNo string


        }

        [HttpPut("customer-orders/{id}")]
        public void EditOrder(int id, [FromBody] OrderDTO value)
        {

            //Id Int
            //userAddressId Int
            //OrderNote string
            //Items OrderItem[]

        }



        [HttpPost("merchant-orders/{id}/shipment ")]
        public void Shipment([FromBody] OrderDTO value)
        {

        //            orderId Int
        //TrackingNumber String




        }
        [HttpPost("merchant-orders/{id}/hangup ")]
        public void HangUpOrder([FromBody] OrderDTO value)
        {

            //orderId Int
            //Reason String




        }



        [HttpPut("merchant-orders/{id}/complete")]
        public void EditOrderm(int id, [FromBody] OrderDTO value)
        {

            //Id Int
            //userAddressId Int
            //OrderNote string
            //Items OrderItem[]

        }


  



        [HttpDelete("merchant-orders/{id}/hangup")]
        public void DeleteOrder(int id)
        {

            //orderId Int
            //Reason String

        }
    }





    public class OrderDTO
    {

        //userAddressId Int
        //productId int
        //quantity int
        //OrderNote String

    }
}
