using Order.Core.IRepositories;
using Order.Core.IServices;
using Order.Core.ObjectModel;
using Order.Core.RequestResponseModel;
using AutoMapper;
using static Order.Core.Constants.Enums;

namespace Order.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepositories _orderRepositories;
        private readonly IOrderDetailServices _orderDetailServices;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IOrderRepositories orderRepositories,IOrderDetailServices orderDetailServices,IMapper mapper,IUnitOfWork unitOfWork)
        {
            _orderRepositories = orderRepositories;
            _orderDetailServices = orderDetailServices;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Orders>> GetAllOrders(int userId)
        {
            try
            {   
                //var orders = _orderRepositories.Find(x => x.OrderId == userId).ToList();
                //var orderDetails = _orderDetailServices.GetAllOrders(userId).Result;

                //var result = (from obj in orders
                //              //join orderDes in orderDetails on obj.OrderId equals orderDes.OrderId
                //              select new Orders()
                //              {
                //                  OrderId = obj.OrderId,
                //                  CustomerId = obj.CustomerId,
                //                  Discount = obj.Discount,
                //                  IsDeleted = obj.IsDeleted,
                //                  OrderNumber = obj.OrderNumber,
                //                  OrderPriceExGST=obj.OrderPriceExGST,
                //                  OrderStatus = obj.OrderStatus,
                //                  OrderPriceIncGST  =obj.OrderPriceIncGST,
                //                  PaymentModeId = obj.PaymentModeId,
                //                  PaymentTransId = obj.PaymentTransId,
                //                  OrderDetails = orderDetails.Where(x=>x.OrderId == userId).ToList(),
                //              }).ToList();

                var result = _orderRepositories.Find(x => x.OrderId == userId).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                throw;
            }
        }
        public Orders GetOrder(int orderId)
        {
            try
            {
                return _orderRepositories.Find(x => x.OrderId == orderId).First();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ResultMessage Update(OrderRequestModel orderRequestModel)
        {
            ResultMessage resultMessage = ResultMessage.Succeess;

            var orders = _orderRepositories.Find(x=>x.OrderNumber == orderRequestModel.OrderNumber).FirstOrDefault();
            
            if(orders == null)
            {
                resultMessage = ResultMessage.RecorNotFound;
                
                return resultMessage;
            }

            var orderObj = _mapper.Map(orderRequestModel, orders);

            _orderRepositories.Update(orderObj);

            return resultMessage;
        }

        public ResultMessage Add(OrderRequestModel orderRequestModel)
        {
            try
            {
                Orders orders = new();

                var orderObj = _mapper.Map(orderRequestModel, orders);

                _orderRepositories.Create(orderObj);
                _unitOfWork.Commit();
                return ResultMessage.Succeess;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ResultMessage Delete(int orderId)
        {
            ResultMessage resultMessage = ResultMessage.Succeess;

            var orders = _orderRepositories.Find(x => x.OrderId == orderId).FirstOrDefault();

            if (orders == null)
            {
                resultMessage = ResultMessage.RecorNotFound;

                return resultMessage;
            }

            _orderRepositories.Delete(orders);

            return resultMessage;
        }
    }
}
