using AutoMapper;
using Megasave.Domain.DTOs;
using Megasave.Domain.Entities;

namespace Megasave.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Supplies, SupplierDto>().ReverseMap();
            CreateMap<Supplies, CreateSupplierDto>().ReverseMap();
            CreateMap<Categories, CategoryDto>().ReverseMap();
            CreateMap<Transactions, TransactionDto>().ReverseMap();
            CreateMap<Batches, CreateBatchDto>().ReverseMap();
            CreateMap<Batches, BatchDto>().ReverseMap();
            CreateMap<Branches, CreateBranchDto>().ReverseMap();
            CreateMap<Branches, BranchDto>().ReverseMap();
            CreateMap<Transactions, CreateTransactionDto>().ReverseMap();
            CreateMap<Transactions, TransactionDto>().ReverseMap();
            CreateMap<Files, CreateFileDto>().ReverseMap();
            CreateMap<Files, FileDto>().ReverseMap();
            CreateMap<Departments, DepartmentDto>().ReverseMap();
            CreateMap<Departments, CreateDepartmentDto>().ReverseMap();
            CreateMap<Banks, BankDto>().ReverseMap();
            CreateMap<Banks, CreateBankDto>().ReverseMap();
            CreateMap<BatchesHistory, BatchHistoryDto>().ReverseMap();
        }
    }
}