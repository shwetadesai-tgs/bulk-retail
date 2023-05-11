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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IOrderRepositories orderRepositories,IMapper mapper,IUnitOfWork unitOfWork)
        {
            _orderRepositories = orderRepositories;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Orders>> GetAllOrders(int userId)
        {
            try
            {
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
    }
}
