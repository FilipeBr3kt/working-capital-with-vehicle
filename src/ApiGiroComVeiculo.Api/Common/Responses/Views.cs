namespace ApiGiroComVeiculo.Api.Common.Responses;

public class GetProtocolResponseView
{
    public int Id { get; set; }
    public string NrProtocol { get; set; } = null!;
    public DateTime DateRegister { get; set; }
    public string Document { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int PhoneDdd { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public int RequestedValue { get; set; }
    public string Plate { get; set; } = null!;
    public int Type { get; set; }
    public int Status { get; set; }
    public int Situation { get; set; }
}
