using AutoMapper;
using db = G_Pigmy.App.DbModels;
using G_Pigmy.App.Models;

namespace G_Pigmy.App.DataControl.Profiles
{
    internal class AgentProfile : Profile
    {
        public AgentProfile()
        {
            CreateMap<db.Agent, Agent>().ReverseMap();
        }
    }
}
