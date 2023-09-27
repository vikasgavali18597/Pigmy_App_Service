using AutoMapper;
using G_Pigmy.App.Mutation.Transaction.Command;
using dm = G_Pigmy.App.Models;

namespace G_Pigmy.App.Mutation.Profiles.TransactionsProfiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<TransactionCommand, dm.Transaction>().ReverseMap();
        }
    }
}
