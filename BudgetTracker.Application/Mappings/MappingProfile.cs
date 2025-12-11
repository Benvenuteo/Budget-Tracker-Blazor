using AutoMapper;
using BudgetTracker.Core.Domain;
using BudgetTracker.Shared.DTOs;

namespace BudgetTracker.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Transaction -> TransactionDto
            CreateMap<Transaction, TransactionDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : "Brak kategorii"))
                .ForMember(dest => dest.ColorHex, opt => opt.MapFrom(src => src.Category != null ? src.Category.ColorHex : "#000000"))
                .ReverseMap();

            // CreateTransactionDto -> Transaction
            CreateMap<CreateTransactionDto, Transaction>();

            // Category Mapping
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>();
        }
    }
}
