using System;
using System.Collections.Generic;

namespace ApiGiroComVeiculo.Api.Entities;

/// <summary>
/// Capital Giro - Veiculo
/// </summary>
public partial class T2208
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Id
    /// </summary>
    public int? FkT2302 { get; set; }

    /// <summary>
    /// Faturamento
    /// </summary>
    public decimal? VlFaturamento { get; set; }

    /// <summary>
    /// Juros
    /// </summary>
    public decimal? PcJuros { get; set; }

    /// <summary>
    /// Cedente
    /// </summary>
    public bool? BlCedente { get; set; }

    /// <summary>
    /// Emitido
    /// </summary>
    public bool? BlConEmissao { get; set; }

    /// <summary>
    /// Assinado
    /// </summary>
    public bool? BlConAssinatura { get; set; }

    /// <summary>
    /// Data Emissao
    /// </summary>
    public DateOnly? DtConEmissao { get; set; }

    /// <summary>
    /// Data Assinatura
    /// </summary>
    public DateOnly? DtConAssinatura { get; set; }

    /// <summary>
    /// Nome Socio
    /// </summary>
    public string? SocNome { get; set; }

    /// <summary>
    /// CPF Socio
    /// </summary>
    public string? SocInsFederal { get; set; }

    /// <summary>
    /// Porte Empresa
    /// </summary>
    public byte? DmPorte { get; set; }

    /// <summary>
    /// Val.Prestacao
    /// </summary>
    public decimal? VlPrestacao { get; set; }

    /// <summary>
    /// Val.Prestacao
    /// </summary>
    public decimal? VlPrestacaoLib { get; set; }

    /// <summary>
    /// Val.TAC
    /// </summary>
    public decimal? VlTac { get; set; }

    /// <summary>
    /// Val.TAC
    /// </summary>
    public decimal? VlTacLib { get; set; }

    /// <summary>
    /// Coeficiente
    /// </summary>
    public decimal? PcCoeficiente { get; set; }

    /// <summary>
    /// Coeficiente Lib
    /// </summary>
    public decimal? PcCoeficienteLib { get; set; }

    /// <summary>
    /// Data Pri.Vencto
    /// </summary>
    public DateOnly? DtPriVencto { get; set; }

    /// <summary>
    /// Data Pri.Vencto Lib
    /// </summary>
    public DateOnly? DtPriVenctoLib { get; set; }

    /// <summary>
    /// Dia Carencia
    /// </summary>
    public short? QtDiaCarencia { get; set; }

    /// <summary>
    /// Dia Carencia Lib
    /// </summary>
    public short? QtDiaCarenciaLib { get; set; }

    /// <summary>
    /// Prazo
    /// </summary>
    public short? QtMesPrazo { get; set; }

    /// <summary>
    /// Prazo Lib
    /// </summary>
    public short? QtMesPrazoLib { get; set; }

    /// <summary>
    /// Placa
    /// </summary>
    public string? VeiPlaca { get; set; }

    /// <summary>
    /// Ano Modelo
    /// </summary>
    public short? VeiAnoModelo { get; set; }

    /// <summary>
    /// Ano Fabric
    /// </summary>
    public short? VeiAnoFabric { get; set; }

    /// <summary>
    /// Vei.Marca
    /// </summary>
    public string? VeiMarca { get; set; }

    /// <summary>
    /// Vei.Modelo
    /// </summary>
    public string? VeiModelo { get; set; }

    /// <summary>
    /// Vei.Quitado
    /// </summary>
    public bool? BlFinQuitado { get; set; }

    /// <summary>
    /// Val.Vei.Estimado
    /// </summary>
    public decimal? VlVeiEstimado { get; set; }

    /// <summary>
    /// Val.Vei.Avaliado
    /// </summary>
    public decimal? VlVeiAvaliado { get; set; }

    /// <summary>
    /// Val.Vei.FIP
    /// </summary>
    public decimal? VlVeiFip { get; set; }

    /// <summary>
    /// Dia Vencto
    /// </summary>
    public byte? DiaVencto1 { get; set; }

    /// <summary>
    /// Dia Vencto
    /// </summary>
    public byte? DiaVencto2 { get; set; }

    /// <summary>
    /// Tipo
    /// </summary>
    public byte? DmVeiTipo { get; set; }

    /// <summary>
    /// Em Seu Nome
    /// </summary>
    public bool? BlVeiNome { get; set; }

    /// <summary>
    /// Rating
    /// </summary>
    public byte? DmRating { get; set; }

    /// <summary>
    /// Data Insert
    /// </summary>
    public DateTime? DhInsert { get; set; }

    /// <summary>
    /// Data Update
    /// </summary>
    public DateTime? DhUpdate { get; set; }

    /// <summary>
    /// Editavel
    /// </summary>
    public byte? Ex0001 { get; set; }

    /// <summary>
    /// Sessao
    /// </summary>
    public int? Ex0002 { get; set; }
}
