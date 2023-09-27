using AutoMapper;
using G_Pigmy.App.LookUp.Customer.Response;
using GLib.Common;
using dm = G_Pigmy.App.Models;


namespace G_Pigmy.App.LookUp.Profiles
{
    public class GetCustomerProfile : Profile
    {
        public GetCustomerProfile()
        {
            CreateMap<GetCustomerResponse, dm.Customer>().ReverseMap();
        }
    }
}
