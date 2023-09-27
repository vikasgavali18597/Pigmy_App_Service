using AutoMapper;
using db = G_Pigmy.App.DbModels;
using G_Pigmy.App.Models;
namespace G_Pigmy.App.DataControl.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<db.Transaction, Transaction>().ReverseMap();
        }
    }
}
