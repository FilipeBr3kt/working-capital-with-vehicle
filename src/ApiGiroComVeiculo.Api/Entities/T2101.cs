using System;
using System.Collections.Generic;

namespace ApiGiroComVeiculo.Api.Entities;

/// <summary>
/// Protocolo
/// </summary>
public partial class T2101
{
    /// <summary>
    /// Protocolo
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Tipo
    /// </summary>
    public byte? DmTipo { get; set; }

    /// <summary>
    /// Num.Protocolo
    /// </summary>
    public string? NrProtocolo { get; set; }

    /// <summary>
    /// Num.Simulação
    /// </summary>
    public string? NrSimulacao { get; set; }

    /// <summary>
    /// CNPJ
    /// </summary>
    public string? InsFederal { get; set; }

    public int? CdQprof { get; set; }

    /// <summary>
    /// Nome
    /// </summary>
    public string? Nome { get; set; }

    /// <summary>
    /// Nome Fantasia
    /// </summary>
    public string? NmFantasia { get; set; }

    /// <summary>
    /// Pessoa
    /// </summary>
    public byte? DmPessoa { get; set; }

    /// <summary>
    /// Produto
    /// </summary>
    public int? FkT1201 { get; set; }

    /// <summary>
    /// Pessoa
    /// </summary>
    public int? FkT1101 { get; set; }

    /// <summary>
    /// Canal Divulgação
    /// </summary>
    public int? FkT1009 { get; set; }

    /// <summary>
    /// Forma Contato
    /// </summary>
    public int? FkT1010 { get; set; }

    /// <summary>
    /// Termo Condição
    /// </summary>
    public int? FkT1204 { get; set; }

    /// <summary>
    /// Motivo
    /// </summary>
    public int? FkT2106 { get; set; }

    /// <summary>
    /// Parceiro
    /// </summary>
    public int? FkT2301 { get; set; }

    public int? FkT23012 { get; set; }

    /// <summary>
    /// Localidade
    /// </summary>
    public int? FkP1005 { get; set; }

    /// <summary>
    /// Sistema
    /// </summary>
    public int? FkC1001 { get; set; }

    /// <summary>
    /// Usuário
    /// </summary>
    public int? FkC1101 { get; set; }

    public int? FkT1017 { get; set; }

    public int? FkT1212 { get; set; }

    public int? FkT2310 { get; set; }

    public int? FkT2004 { get; set; }

    public int? NrScore { get; set; }

    /// <summary>
    /// Data Registro
    /// </summary>
    public DateTime? DhRegistro { get; set; }

    /// <summary>
    /// Nome Contato
    /// </summary>
    public string? NmContato { get; set; }

    /// <summary>
    /// DDD
    /// </summary>
    public short? FonDdd { get; set; }

    /// <summary>
    /// Fone
    /// </summary>
    public string? FonNum { get; set; }

    /// <summary>
    /// DDD
    /// </summary>
    public short? FonDdd2 { get; set; }

    /// <summary>
    /// Fone
    /// </summary>
    public string? FonNum2 { get; set; }

    /// <summary>
    /// E-mail
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// E-mail
    /// </summary>
    public string? Email2 { get; set; }

    /// <summary>
    /// CEP
    /// </summary>
    public string? EndCep { get; set; }

    /// <summary>
    /// Logradouro
    /// </summary>
    public string? EndLogradouro { get; set; }

    /// <summary>
    /// Número
    /// </summary>
    public string? EndNumero { get; set; }

    /// <summary>
    /// Complemento
    /// </summary>
    public string? EndComplemento { get; set; }

    /// <summary>
    /// Bairro
    /// </summary>
    public string? EndBairro { get; set; }

    /// <summary>
    /// Val.Solicitado
    /// </summary>
    public decimal? VlSolicitado { get; set; }

    /// <summary>
    /// Val.Liberado
    /// </summary>
    public decimal? VlLiberado { get; set; }

    public decimal? VlPagamento { get; set; }

    /// <summary>
    /// Data Pagamento
    /// </summary>
    public DateOnly? DtPagamento { get; set; }

    public decimal? SimValor { get; set; }

    public short? SimPrazo { get; set; }

    public decimal? SimTaxa { get; set; }

    public decimal? SimTxAno { get; set; }

    public decimal? SimParcela { get; set; }

    public DateOnly? SimDtEmissao { get; set; }

    public DateOnly? SimPriVencto { get; set; }

    public string? DsContato { get; set; }

    /// <summary>
    /// Senha
    /// </summary>
    public string? Senha { get; set; }

    /// <summary>
    /// Banco
    /// </summary>
    public string? NmBanco { get; set; }

    public string? NrBanco { get; set; }

    /// <summary>
    /// Num.Agência
    /// </summary>
    public string? NrAgencia { get; set; }

    /// <summary>
    /// Num.Conta
    /// </summary>
    public string? NrConta { get; set; }

    /// <summary>
    /// DV
    /// </summary>
    public string? NrContaDv { get; set; }

    /// <summary>
    /// Motivo
    /// </summary>
    public string? DsMotivo { get; set; }

    /// <summary>
    /// Dados
    /// </summary>
    public string? DsDados { get; set; }

    public string? DsMotEmprestimo { get; set; }

    public string? DsStaParceiro { get; set; }

    public DateOnly? DhStaParceiro { get; set; }

    public string? Par01 { get; set; }

    public string? Par02 { get; set; }

    /// <summary>
    /// Novo
    /// </summary>
    public bool? BlNovo { get; set; }

    /// <summary>
    /// Aceite
    /// </summary>
    public bool? BlAceite { get; set; }

    /// <summary>
    /// Termo Condição
    /// </summary>
    public bool? BlTermo { get; set; }

    /// <summary>
    /// Data Aceite
    /// </summary>
    public DateTime? DhAceite { get; set; }

    /// <summary>
    /// Data Início
    /// </summary>
    public DateTime? DhIniTermo { get; set; }

    /// <summary>
    /// Dat.Término
    /// </summary>
    public DateTime? DhTerTermo { get; set; }

    /// <summary>
    /// Data Início
    /// </summary>
    public DateTime? DhIniCad { get; set; }

    /// <summary>
    /// Dat.Término
    /// </summary>
    public DateTime? DhTerCad { get; set; }

    public string? NrIp { get; set; }

    /// <summary>
    /// Situacao
    /// </summary>
    public byte? DmSituacao { get; set; }

    /// <summary>
    /// Status
    /// </summary>
    public byte DmStatus { get; set; }

    public byte? DmTemp { get; set; }

    /// <summary>
    /// Data Insert
    /// </summary>
    public DateTime? DhInsert { get; set; }

    /// <summary>
    /// Data Update
    /// </summary>
    public DateTime? DhUpdate { get; set; }

    /// <summary>
    /// Editável
    /// </summary>
    public bool? Ex0001 { get; set; }

    /// <summary>
    /// Sessão
    /// </summary>
    public int? Ex0002 { get; set; }
}
