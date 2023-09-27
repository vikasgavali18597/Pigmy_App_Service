using AutoMapper;
using Db = G_Pigmy.App.DbModels;
using G_Pigmy.App.Models;

namespace G_Pigmy.App.DataControl.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Db.Customer, Customer>().ReverseMap();
        }
    }
}
