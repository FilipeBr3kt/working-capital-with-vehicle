namespace ApiGiroComVeiculo.Api.Features.Protocol.GetProtocol;

public class Color
{
    public string Light { get; set; } = null!;
    public string Dark { get; set; } = null!;
}
public class Protocol
{
    public int Id { get; set; }
    public string NumberProtocol { get; set; } = null!;
    public string DateRegister { get; set; } = null!;
    public string DateRegisterF { get; set; } = null!;
    public string DocumentF { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int PhoneDdd { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public int RequestedValue { get; set; }
    public string RequestedValueF { get; set; } = null!;
    public string Plate { get; set; } = null!;
    public int Type { get; set; }
    public string Status { get; set; } = null!;
    public int CodeSituation { get; set; }
    public string Situation { get; set; } = null!;
    public Color ColorSituation { get; set; } = null!;
    public string DescriptionSituation { get; set; } = null!;
}

public class GetProtocolResponse
{
    public Protocol CurrentProtocol { get; set; } = null!;
    public List<Protocol> HistoryProtocol { get; set; } = null!;
}
