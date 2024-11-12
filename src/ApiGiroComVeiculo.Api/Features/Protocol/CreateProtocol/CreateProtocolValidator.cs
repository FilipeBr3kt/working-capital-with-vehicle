using ApiGiroComVeiculo.Api.Common.Utils;
using FluentValidation;

namespace ApiGiroComVeiculo.Api.Features.Protocol.CreateProtocol;

public class CreateProtocolValidator : AbstractValidator<CreateProtocolCommand>
{
    public CreateProtocolValidator()
    {
        RuleFor(p => p.SessionId)
            .GreaterThan(0).WithMessage("sessionId is required.");

        RuleFor(p => p.TermId)
            .GreaterThan(0).WithMessage("termId is required.");

        RuleFor(p => p.IndicationId)
            .GreaterThan(0).WithMessage("indicationId is required.");

        RuleFor(p => p.ReasonId)
            .GreaterThan(0).WithMessage("reasonId is required.");

        RuleFor(p => p.PartnerId)
            .GreaterThan(0).WithMessage("partnerId is required.");

        RuleFor(p => p.StoreId)
            .GreaterThan(0).WithMessage("storeId is required.");

        RuleFor(p => p.ChannelId)
            .GreaterThan(0).WithMessage("channelId is required.");

        RuleFor(p => p.ReasonDescription)
            .NotEmpty().WithMessage("reasonDescription is required.")
            .MinimumLength(2).WithMessage("The name must be have 2 caracters.");

        RuleFor(p => p.CustomerCNPJ)
            .NotEmpty().WithMessage("customerCNPJ is required.")
            .Must(Validators.IsValidCNPJ).WithMessage("Invalid CNPJ.");

        RuleFor(p => p.CustomerName)
            .NotEmpty().WithMessage("customerName is required.")
            .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚãõçñÇÑ]+\s+[a-zA-ZáéíóúÁÉÍÓÚãõçñÇÑ]+(\s[a-zA-ZáéíóúÁÉÍÓÚãõçñÇÑ]+)*$")
            .WithMessage("The field must have just letters, with name and lastname.");

        RuleFor(p => p.CustomerFantasyName)
            .NotEmpty().WithMessage("customerFantasyName is required.")
            .MinimumLength(2).WithMessage("The name must be have 2 caracters.");

        RuleFor(p => p.CustomerInvoiceAmount)
            .NotEmpty().WithMessage("customerInvoiceAmount is required.")
            .GreaterThanOrEqualTo(2 * 1000).WithMessage("The CustomerInvoiceAmount must be greater than or equal to R$ 2.000,00");

        RuleFor(p => p.CustomerBusinessSizeStatus)
            .GreaterThan(0).WithMessage("customerBusinessSizeStatus is required.");

        RuleFor(p => p.PartnerName)
            .NotEmpty().WithMessage("partnerName is required.")
            .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚãõçñÇÑ]+\s+[a-zA-ZáéíóúÁÉÍÓÚãõçñÇÑ]+(\s[a-zA-ZáéíóúÁÉÍÓÚãõçñÇÑ]+)*$")
            .WithMessage("The field must have just letters, with name and lastname.");

        RuleFor(p => p.PartnerCPF)
            .NotEmpty().WithMessage("partnerCPF is required.")
            .Must(Validators.IsValidCPF).WithMessage("Invalid CPF.");

        RuleFor(p => p.ContactName)
            .NotEmpty().WithMessage("contactName is required.")
            .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚãõçñÇÑ]+\s+[a-zA-ZáéíóúÁÉÍÓÚãõçñÇÑ]+(\s[a-zA-ZáéíóúÁÉÍÓÚãõçñÇÑ]+)*$")
            .WithMessage("The field must have just letters, with name and lastname.");

        RuleFor(p => p.ContactEmail)
            .NotEmpty().WithMessage("contactEmail is required.")
            .EmailAddress().WithMessage("Email invalid.");

        RuleFor(p => p.ContactPhoneDdd)
            .NotEmpty().WithMessage("contactPhoneDdd is required.")
            .Must(Validators.IsValidDDD).WithMessage("Invalid DDD.");

        RuleFor(p => p.ContactPhoneNumber)
            .NotEmpty().WithMessage("contactPhoneNumber is required.")
            .Must(Validators.IsValidPhoneNumber).WithMessage("Invalid number.");

        RuleFor(p => p.VehiclePlate)
            .NotEmpty().WithMessage("vehiclePlate is required.")
            .Must(Validators.IsValidPlate).WithMessage("Invalid plate.");

        RuleFor(p => p.VehicleModelYear)
            .GreaterThan(0).WithMessage("vehicleModelYear is required.");

        RuleFor(p => p.VehicleManufactureYear)
            .GreaterThan(0).WithMessage("vehicleManufactureYear is required.");

        RuleFor(p => p.VehicleMarketValue)
            .GreaterThan(0).WithMessage("vehicleMarketValue is required.");

        RuleFor(p => p.VehicleBrand)
            .NotEmpty().WithMessage("vehicleBrand is required.");

        RuleFor(p => p.VehicleModel)
            .NotEmpty().WithMessage("vehicleModel is required.");

        RuleFor(p => p.VehicleTypeId)
            .GreaterThan(0).WithMessage("vehicleTypeId is required.");

        RuleFor(p => p.IsVehicleInCustomerName)
            .NotEmpty().WithMessage("isVehicleInCustomerName is required.");

        RuleFor(p => p.IsVehicleFullyPaid)
            .NotEmpty().WithMessage("isVehicleFullyPaid is required.");

        RuleFor(p => p.RequestedAmount)
            .NotEmpty().WithMessage("requestedAmount is required.")
            .GreaterThanOrEqualTo(30 * 1000).WithMessage("The RequestedAmount must be greater than or equal to R$ 30.000,00")
            .LessThanOrEqualTo(150 * 1000).WithMessage("The RequestedAmount must be less than or equal to R$ 150.000,00");

        RuleFor(p => p.TermDuration)
            .GreaterThan(0).WithMessage("termDuration is required");

        RuleFor(p => p.IsAcceptanceId)
            .GreaterThan(0).WithMessage("isAcceptanceId is required");

        RuleFor(p => p.IsAcceptanceTermId)
            .GreaterThan(0).WithMessage("isAcceptanceTermId is required");

        RuleFor(p => p.AcceptanceDate)
            .NotEmpty().WithMessage("acceptanceDate is required.");

        RuleFor(p => p.TermStartDate)
            .NotEmpty().WithMessage("termStartDate is required.");

        RuleFor(p => p.RegistrationStartDate)
            .NotEmpty().WithMessage("registrationStartDate is required.");

        RuleFor(p => p.RegistrationEndDate)
            .NotEmpty().WithMessage("registrationEndDate is required.");

        RuleFor(p => p.IpAddress)
            .NotEmpty().WithMessage("ipAddress is required.");
    }
}
