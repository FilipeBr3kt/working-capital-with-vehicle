using System;
using System.Collections.Generic;

namespace ApiGiroComVeiculo.Api.Entities;

public partial class VwApiT2208P1
{
    public int? Id { get; set; }

    public byte? DmTipo { get; set; }

    public string? NrProtocolo { get; set; }

    public string? NrSimulacao { get; set; }

    public string? InsFederal { get; set; }

    public int? CdQprof { get; set; }

    public string? Nome { get; set; }

    public string? NmFantasia { get; set; }

    public byte? DmPessoa { get; set; }

    public int? FkT1201 { get; set; }

    public int? FkT1101 { get; set; }

    public int? FkT1009 { get; set; }

    public int? FkT1010 { get; set; }

    public int? FkT1204 { get; set; }

    public int? FkT2106 { get; set; }

    public int? FkT2301 { get; set; }

    public int? FkT23012 { get; set; }

    public int? FkP1005 { get; set; }

    public int? FkC1001 { get; set; }

    public int? FkC1101 { get; set; }

    public int? FkT1017 { get; set; }

    public int? FkT1212 { get; set; }

    public int? FkT2310 { get; set; }

    public int? FkT2004 { get; set; }

    public int? NrScore { get; set; }

    public DateTime? DhRegistro { get; set; }

    public string? NmContato { get; set; }

    public short? FonDdd { get; set; }

    public string? FonNum { get; set; }

    public short? FonDdd2 { get; set; }

    public string? FonNum2 { get; set; }

    public string? Email { get; set; }

    public string? Email2 { get; set; }

    public string? EndCep { get; set; }

    public string? EndLogradouro { get; set; }

    public string? EndNumero { get; set; }

    public string? EndComplemento { get; set; }

    public string? EndBairro { get; set; }

    public decimal? VlSolicitado { get; set; }

    public decimal? VlLiberado { get; set; }

    public decimal? VlPagamento { get; set; }

    public DateOnly? DtPagamento { get; set; }

    public decimal? SimValor { get; set; }

    public short? SimPrazo { get; set; }

    public decimal? SimTaxa { get; set; }

    public decimal? SimTxAno { get; set; }

    public decimal? SimParcela { get; set; }

    public DateOnly? SimDtEmissao { get; set; }

    public DateOnly? SimPriVencto { get; set; }

    public string? DsContato { get; set; }

    public string? Senha { get; set; }

    public string? NmBanco { get; set; }

    public string? NrBanco { get; set; }

    public string? NrAgencia { get; set; }

    public string? NrConta { get; set; }

    public string? NrContaDv { get; set; }

    public string? DsMotivo { get; set; }

    public string? DsDados { get; set; }

    public string? DsMotEmprestimo { get; set; }

    public string? DsStaParceiro { get; set; }

    public DateOnly? DhStaParceiro { get; set; }

    public string? Par01 { get; set; }

    public string? Par02 { get; set; }

    public bool? BlNovo { get; set; }

    public bool? BlAceite { get; set; }

    public bool? BlTermo { get; set; }

    public DateTime? DhAceite { get; set; }

    public DateTime? DhIniTermo { get; set; }

    public DateTime? DhTerTermo { get; set; }

    public DateTime? DhIniCad { get; set; }

    public DateTime? DhTerCad { get; set; }

    public string? NrIp { get; set; }

    public byte? DmSituacao { get; set; }

    public byte? DmStatus { get; set; }

    public byte? DmTemp { get; set; }

    public DateTime? DhInsert { get; set; }

    public DateTime? DhUpdate { get; set; }

    public bool? Ex0001 { get; set; }

    public int? Ex0002 { get; set; }

    public string? InsFederalFmt { get; set; }

    public DateOnly? DtRegistro { get; set; }

    public TimeOnly? HrRegistro { get; set; }

    public string? Perfil { get; set; }

    public string? NmLocalidade { get; set; }

    public string? SgUf { get; set; }

    public string? NmProduto { get; set; }

    public string? NmMotivo { get; set; }

    public string? NmTerCondic { get; set; }

    public string? DsTerCondic { get; set; }

    public string? NmParceiro { get; set; }

    public string? LinkBase { get; set; }

    public string? NmCanal { get; set; }

    public string? NmForContato { get; set; }

    public string? NmMotEmprestimo { get; set; }

    public string? NmIndicacao { get; set; }

    public decimal? VlFaturamento { get; set; }

    public decimal? PcJuros { get; set; }

    public bool? BlCedente { get; set; }

    public bool? BlConEmissao { get; set; }

    public bool? BlConAssinatura { get; set; }

    public DateOnly? DtConEmissao { get; set; }

    public DateOnly? DtConAssinatura { get; set; }

    public string? SocNome { get; set; }

    public string? SocInsFederal { get; set; }

    public byte? DmPorte { get; set; }

    public decimal? VlPrestacao { get; set; }

    public decimal? VlPrestacaoLib { get; set; }

    public decimal? VlTac { get; set; }

    public decimal? VlTacLib { get; set; }

    public decimal? PcCoeficiente { get; set; }

    public decimal? PcCoeficienteLib { get; set; }

    public DateOnly? DtPriVencto { get; set; }

    public DateOnly? DtPriVenctoLib { get; set; }

    public short? QtDiaCarencia { get; set; }

    public short? QtDiaCarenciaLib { get; set; }

    public short? QtMesPrazo { get; set; }

    public short? QtMesPrazoLib { get; set; }

    public string? VeiPlaca { get; set; }

    public short? VeiAnoModelo { get; set; }

    public short? VeiAnoFabric { get; set; }

    public string? VeiMarca { get; set; }

    public string? VeiModelo { get; set; }

    public bool? BlFinQuitado { get; set; }

    public decimal? VlVeiEstimado { get; set; }

    public decimal? VlVeiAvaliado { get; set; }

    public decimal? VlVeiFip { get; set; }

    public byte? DiaVencto1 { get; set; }

    public byte? DiaVencto2 { get; set; }

    public byte? DmVeiTipo { get; set; }

    public bool? BlVeiNome { get; set; }
}
