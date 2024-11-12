namespace ApiGiroComVeiculo.Api.Common.Responses;

public class ValidateProtocolProcedureResponse
{
    public int Id { get; set; }
    public string? NrProtocolo { get; set; }
    public string? Nome { get; set; }
    public bool BlAtendimento { get; set; }
    public int UltDias { get; set; }
    public byte DmStatus { get; set; }
    public byte DmSituacao { get; set; }
    public bool Result { get; set; }
    public string? Msg { get; set; }
}

public class InsertProtocolProcedureResponse
{
    public int IdProtocolo { get; set; }
    public string? NrProtocolo { get; set; }
    public string? Senha { get; set; }
    public bool Result { get; set; }
    public string? Msg { get; set; }
}