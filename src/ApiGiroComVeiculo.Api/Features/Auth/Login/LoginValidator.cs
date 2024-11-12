using ApiGiroComVeiculo.Api.Common.Utils;
using FluentValidation;

namespace ApiGiroComVeiculo.Api.Features.Auth.Login;

public class LoginValidator : AbstractValidator<LoginCommand>
{
    public LoginValidator()
    {
        RuleFor(p => p.Cnpj)
            .NotEmpty().WithMessage("cnpj is required.")
            .Must(Validators.IsValidCNPJ).WithMessage("Invalid CNPJ.");

        RuleFor(p => p.Plate)
            .NotEmpty().WithMessage("plate is required.")
            .Must(Validators.IsValidPlate).WithMessage("Invalid plate");
    }
}
