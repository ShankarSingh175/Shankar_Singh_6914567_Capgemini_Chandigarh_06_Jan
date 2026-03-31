using AutoMapper;
using SecureAccountDetails.DTOs;
using SecureAccountDetails.Models;

namespace SecureAccountDetails.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Accounts, AccountDetailsDto>()
            .ForMember(dest => dest.MaskedAccountNumber, opt => opt.MapFrom(src =>
                src.AccountNumber != null
                    ? (src.AccountNumber.Length > 4
                        ? new string('X', Math.Min(6, src.AccountNumber.Length - 4)) + src.AccountNumber.Substring(src.AccountNumber.Length - 4)
                        : new string('X', src.AccountNumber.Length))
                    : "XXXX"))
            .ForMember(dest => dest.Balance, opt => opt.Ignore());
    }
}