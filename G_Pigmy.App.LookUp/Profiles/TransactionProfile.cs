using AutoMapper;
using G_Pigmy.App.DbModels;
using G_Pigmy.App.LookUp.Transaction.Response;
using dm = G_Pigmy.App.Models;

namespace G_Pigmy.App.LookUp.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
                CreateMap<dm.Transaction, TransactionResponse>().ReverseMap();
        }
    }
}
