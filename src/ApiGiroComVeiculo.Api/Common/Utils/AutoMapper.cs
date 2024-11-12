using ApiGiroComVeiculo.Api.Common.DTOs;
using ApiGiroComVeiculo.Api.Features.Auth.Login;
using ApiGiroComVeiculo.Api.Features.Protocol.CreateProtocol;
using AutoMapper;

namespace ApiGiroComVeiculo.Api.Common.Utils;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProtocolCommand, InsertProtocolDTO>();
        CreateMap<LoginCommand, VerifyUserInformationDTO>();
    }
}
