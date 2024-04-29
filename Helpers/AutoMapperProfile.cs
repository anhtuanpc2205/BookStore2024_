using AutoMapper;
using BookStore2024.Data;
using BookStore2024.ViewModels;

namespace BookStore2024.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<RegisterVM, TblUser>();
        }
    }
}
