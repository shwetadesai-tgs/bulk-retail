using AutoMapper;
using Order.Core.ObjectModel;
using Order.Core.RequestResponseModel;

namespace Order.API.AutoMapper
{
    public class AutoProfile:Profile
    {
        public AutoProfile() 
        {
            CreateMap<OrderRequestModel, Orders>();
            CreateMap<CartRequestModel, ShoppingCart>();
        }
    }
}
