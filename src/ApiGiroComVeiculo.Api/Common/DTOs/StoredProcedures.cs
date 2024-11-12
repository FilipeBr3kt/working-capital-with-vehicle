namespace ApiGiroComVeiculo.Api.Common.DTOs;

public record VerifyUserInformationDTO(string Cnpj, string Plate);

public record InsertProtocolDTO(
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
);

