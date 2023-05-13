using Order.Core.IRepositories;
using Order.Core.IServices;
using Order.Core.ObjectModel;
using Order.Core.RequestResponseModel;
using AutoMapper;
using static Order.Core.Constants.Enums;
using Product.API.Migrations;

namespace Order.Infrastructure.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CartService(
            ICartRepository cartRepository, 
            IOrderDetailServices orderDetailServices, 
            IMapper mapper, 
            IUnitOfWork unitOfWork)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ShoppingCart>> GetAllItems(int userId)
        {
            try
            {
                var result = _cartRepository.Find(x => x.UserId == userId).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                throw;
            }
        }
       
        public ResultMessage Update(CartRequestModel cartRequestModel)
        {
            ResultMessage resultMessage = ResultMessage.Succeess;

            var items = _cartRepository.Find(x => x.Id == cartRequestModel.Id).FirstOrDefault();

            if (items == null)
            {
                resultMessage = ResultMessage.RecorNotFound;

                return resultMessage;
            }

            var itemObj = _mapper.Map(cartRequestModel, items);

            _cartRepository.Update(itemObj);

            return resultMessage;
        }

        public ResultMessage Add(CartRequestModel cartRequestModel)
        {
            try
            {
                ShoppingCart shoppingCarts = new();

                var Obj = _mapper.Map(cartRequestModel, shoppingCarts);

                _cartRepository.Create(Obj);
                _unitOfWork.Commit();
                return ResultMessage.Succeess;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ResultMessage Delete(int productId, int userId)
        {
            ResultMessage resultMessage = ResultMessage.Succeess;

            var item = _cartRepository.Find(x => x.UserId == userId && x.ProductId == productId).FirstOrDefault();

            if (item == null)
            {
                resultMessage = ResultMessage.RecorNotFound;

                return resultMessage;
            }

            _cartRepository.Delete(item.Id);

            return resultMessage;
        }
    }
}
