using ApiGiroComVeiculo.Api.Common.Responses;
using MediatR;

namespace ApiGiroComVeiculo.Api.Features.Protocol.CreateProtocol;

public record CreateProtocolCommand(
    // Proposal
    int? SessionId,
    int? TermId,
    int? IndicationId,
    int? ReasonId,
    int? PartnerId,
    int? StoreId,
    int? ChannelId,
    string ReasonDescription,

    // Customer
    string CustomerCNPJ,
    string CustomerName,
    string CustomerFantasyName,
    int CustomerInvoiceAmount,
    int CustomerBusinessSizeStatus,

    // Partner
    string PartnerName,
    string PartnerCPF,

    // Contact
    string ContactName,
    string ContactEmail,
    int ContactPhoneDdd,
    string ContactPhoneNumber,

    // Vehicle
    string VehiclePlate,
    int VehicleModelYear,
    int VehicleManufactureYear,
    int VehicleMarketValue,
    string VehicleBrand,
    string VehicleModel,
    int VehicleTypeId,
    int IsVehicleInCustomerName,
    int IsVehicleFullyPaid,

    // Operation
    int RequestedAmount,
    int TermDuration,
    int IsAcceptanceId,
    int IsAcceptanceTermId,
    DateTime AcceptanceDate,
    DateTime TermStartDate,
    DateTime TermEndDate,
    DateTime RegistrationStartDate,
    DateTime RegistrationEndDate,
    string IpAddress
) : IRequest<InsertProtocolProcedureResponse>;
