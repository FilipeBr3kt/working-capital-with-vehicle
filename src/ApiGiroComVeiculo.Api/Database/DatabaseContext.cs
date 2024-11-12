using ApiGiroComVeiculo.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiGiroComVeiculo.Api.Database;

public partial class DatabaseContext : DbContext
{
    private readonly IConfiguration _config;

    public DatabaseContext(IConfiguration config)
    {
        _config = config;
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration config)
        : base(options)
    {
        _config = config;
    }

    public virtual DbSet<T1017> T1017s { get; set; }

    public virtual DbSet<T2101> T2101s { get; set; }

    public virtual DbSet<T2208> T2208s { get; set; }

    public virtual DbSet<VwApiT2208P1> VwApiT2208P1s { get; set; }

    public virtual DbSet<VwT1213B1> VwT1213B1s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_config.GetValue<string>("SecretsApi:ConnectionString"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<T1017>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("T1017");

            entity.HasIndex(e => e.Id, "IX_T1017_PK")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DhInsert)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("DH_INSERT");
            entity.Property(e => e.DhUpdate)
                .HasColumnType("datetime")
                .HasColumnName("DH_UPDATE");
            entity.Property(e => e.DmStatus)
                .HasDefaultValue((byte)1)
                .HasColumnName("DM_STATUS");
            entity.Property(e => e.Ex0001).HasColumnName("EX_0001");
            entity.Property(e => e.Ex0002).HasColumnName("EX_0002");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOME");
            entity.Property(e => e.NrSeq)
                .HasDefaultValue((short)1)
                .HasColumnName("NR_SEQ");
        });

        modelBuilder.Entity<T2101>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("T2101", tb => tb.HasComment("Protocolo"));

            entity.HasIndex(e => e.FkT2004, "IX_FK_T2004");

            entity.HasIndex(e => e.FkC1001, "IX_T2101_FK_C1001");

            entity.HasIndex(e => e.FkC1101, "IX_T2101_FK_C1101");

            entity.HasIndex(e => e.FkP1005, "IX_T2101_FK_P1005");

            entity.HasIndex(e => e.FkT1009, "IX_T2101_FK_T1009");

            entity.HasIndex(e => e.FkT1010, "IX_T2101_FK_T1010");

            entity.HasIndex(e => e.FkT1017, "IX_T2101_FK_T1017");

            entity.HasIndex(e => e.FkT1101, "IX_T2101_FK_T1101");

            entity.HasIndex(e => e.FkT1201, "IX_T2101_FK_T1201");

            entity.HasIndex(e => e.FkT1204, "IX_T2101_FK_T1204");

            entity.HasIndex(e => e.FkT1212, "IX_T2101_FK_T1212");

            entity.HasIndex(e => e.FkT2106, "IX_T2101_FK_T2106");

            entity.HasIndex(e => e.FkT2301, "IX_T2101_FK_T2301");

            entity.HasIndex(e => e.FkT23012, "IX_T2101_FK_T2301_2");

            entity.HasIndex(e => e.FkT2310, "IX_T2101_FK_T2310");

            entity.HasIndex(e => e.InsFederal, "IX_T2101_INS_FEDERAL");

            entity.HasIndex(e => e.NrProtocolo, "IX_T2101_NR_PROTOCOLO");

            entity.Property(e => e.Id)
                .HasComment("Protocolo")
                .HasColumnName("ID");
            entity.Property(e => e.BlAceite)
                .HasDefaultValue(false)
                .HasComment("Aceite")
                .HasColumnName("BL_ACEITE");
            entity.Property(e => e.BlNovo)
                .HasDefaultValue(false)
                .HasComment("Novo")
                .HasColumnName("BL_NOVO");
            entity.Property(e => e.BlTermo)
                .HasDefaultValue(false)
                .HasComment("Termo Condição")
                .HasColumnName("BL_TERMO");
            entity.Property(e => e.CdQprof).HasColumnName("CD_QPROF");
            entity.Property(e => e.DhAceite)
                .HasComment("Data Aceite")
                .HasColumnType("datetime")
                .HasColumnName("DH_ACEITE");
            entity.Property(e => e.DhIniCad)
                .HasComment("Data Início")
                .HasColumnType("datetime")
                .HasColumnName("DH_INI_CAD");
            entity.Property(e => e.DhIniTermo)
                .HasComment("Data Início")
                .HasColumnType("datetime")
                .HasColumnName("DH_INI_TERMO");
            entity.Property(e => e.DhInsert)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Data Insert")
                .HasColumnType("datetime")
                .HasColumnName("DH_INSERT");
            entity.Property(e => e.DhRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Data Registro")
                .HasColumnType("datetime")
                .HasColumnName("DH_REGISTRO");
            entity.Property(e => e.DhStaParceiro).HasColumnName("DH_STA_PARCEIRO");
            entity.Property(e => e.DhTerCad)
                .HasComment("Dat.Término")
                .HasColumnType("datetime")
                .HasColumnName("DH_TER_CAD");
            entity.Property(e => e.DhTerTermo)
                .HasComment("Dat.Término")
                .HasColumnType("datetime")
                .HasColumnName("DH_TER_TERMO");
            entity.Property(e => e.DhUpdate)
                .HasComment("Data Update")
                .HasColumnType("datetime")
                .HasColumnName("DH_UPDATE");
            entity.Property(e => e.DmPessoa)
                .HasComment("Pessoa")
                .HasColumnName("DM_PESSOA");
            entity.Property(e => e.DmSituacao)
                .HasComment("Situacao")
                .HasColumnName("DM_SITUACAO");
            entity.Property(e => e.DmStatus)
                .HasDefaultValue((byte)1)
                .HasComment("Status")
                .HasColumnName("DM_STATUS");
            entity.Property(e => e.DmTemp).HasColumnName("DM_TEMP");
            entity.Property(e => e.DmTipo)
                .HasDefaultValue((byte)1)
                .HasComment("Tipo")
                .HasColumnName("DM_TIPO");
            entity.Property(e => e.DsContato)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DS_CONTATO");
            entity.Property(e => e.DsDados)
                .IsUnicode(false)
                .HasComment("Dados")
                .HasColumnName("DS_DADOS");
            entity.Property(e => e.DsMotEmprestimo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DS_MOT_EMPRESTIMO");
            entity.Property(e => e.DsMotivo)
                .IsUnicode(false)
                .HasComment("Motivo")
                .HasColumnName("DS_MOTIVO");
            entity.Property(e => e.DsStaParceiro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DS_STA_PARCEIRO");
            entity.Property(e => e.DtPagamento)
                .HasComment("Data Pagamento")
                .HasColumnName("DT_PAGAMENTO");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("E-mail")
                .HasColumnName("EMAIL");
            entity.Property(e => e.Email2)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("E-mail")
                .HasColumnName("EMAIL_2");
            entity.Property(e => e.EndBairro)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Bairro")
                .HasColumnName("END_BAIRRO");
            entity.Property(e => e.EndCep)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("CEP")
                .HasColumnName("END_CEP");
            entity.Property(e => e.EndComplemento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Complemento")
                .HasColumnName("END_COMPLEMENTO");
            entity.Property(e => e.EndLogradouro)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Logradouro")
                .HasColumnName("END_LOGRADOURO");
            entity.Property(e => e.EndNumero)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("Número")
                .HasColumnName("END_NUMERO");
            entity.Property(e => e.Ex0001)
                .HasDefaultValue(true)
                .HasComment("Editável")
                .HasColumnName("EX_0001");
            entity.Property(e => e.Ex0002)
                .HasComment("Sessão")
                .HasColumnName("EX_0002");
            entity.Property(e => e.FkC1001)
                .HasComment("Sistema")
                .HasColumnName("FK_C1001");
            entity.Property(e => e.FkC1101)
                .HasComment("Usuário")
                .HasColumnName("FK_C1101");
            entity.Property(e => e.FkP1005)
                .HasComment("Localidade")
                .HasColumnName("FK_P1005");
            entity.Property(e => e.FkT1009)
                .HasComment("Canal Divulgação")
                .HasColumnName("FK_T1009");
            entity.Property(e => e.FkT1010)
                .HasComment("Forma Contato")
                .HasColumnName("FK_T1010");
            entity.Property(e => e.FkT1017).HasColumnName("FK_T1017");
            entity.Property(e => e.FkT1101)
                .HasComment("Pessoa")
                .HasColumnName("FK_T1101");
            entity.Property(e => e.FkT1201)
                .HasComment("Produto")
                .HasColumnName("FK_T1201");
            entity.Property(e => e.FkT1204)
                .HasComment("Termo Condição")
                .HasColumnName("FK_T1204");
            entity.Property(e => e.FkT1212).HasColumnName("FK_T1212");
            entity.Property(e => e.FkT2004).HasColumnName("FK_T2004");
            entity.Property(e => e.FkT2106)
                .HasComment("Motivo")
                .HasColumnName("FK_T2106");
            entity.Property(e => e.FkT2301)
                .HasComment("Parceiro")
                .HasColumnName("FK_T2301");
            entity.Property(e => e.FkT23012).HasColumnName("FK_T2301_2");
            entity.Property(e => e.FkT2310).HasColumnName("FK_T2310");
            entity.Property(e => e.FonDdd)
                .HasComment("DDD")
                .HasColumnName("FON_DDD");
            entity.Property(e => e.FonDdd2)
                .HasComment("DDD")
                .HasColumnName("FON_DDD_2");
            entity.Property(e => e.FonNum)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Fone")
                .HasColumnName("FON_NUM");
            entity.Property(e => e.FonNum2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Fone")
                .HasColumnName("FON_NUM_2");
            entity.Property(e => e.InsFederal)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("CNPJ")
                .HasColumnName("INS_FEDERAL");
            entity.Property(e => e.NmBanco)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Banco")
                .HasColumnName("NM_BANCO");
            entity.Property(e => e.NmContato)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Nome Contato")
                .HasColumnName("NM_CONTATO");
            entity.Property(e => e.NmFantasia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Nome Fantasia")
                .HasColumnName("NM_FANTASIA");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Nome")
                .HasColumnName("NOME");
            entity.Property(e => e.NrAgencia)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Num.Agência")
                .HasColumnName("NR_AGENCIA");
            entity.Property(e => e.NrBanco)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NR_BANCO");
            entity.Property(e => e.NrConta)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Num.Conta")
                .HasColumnName("NR_CONTA");
            entity.Property(e => e.NrContaDv)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasComment("DV")
                .HasColumnName("NR_CONTA_DV");
            entity.Property(e => e.NrIp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NR_IP");
            entity.Property(e => e.NrProtocolo)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasComment("Num.Protocolo")
                .HasColumnName("NR_PROTOCOLO");
            entity.Property(e => e.NrScore).HasColumnName("NR_SCORE");
            entity.Property(e => e.NrSimulacao)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasComment("Num.Simulação")
                .HasColumnName("NR_SIMULACAO");
            entity.Property(e => e.Par01)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PAR_01");
            entity.Property(e => e.Par02)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PAR_02");
            entity.Property(e => e.Senha)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Senha")
                .HasColumnName("SENHA");
            entity.Property(e => e.SimDtEmissao).HasColumnName("SIM_DT_EMISSAO");
            entity.Property(e => e.SimParcela)
                .HasColumnType("money")
                .HasColumnName("SIM_PARCELA");
            entity.Property(e => e.SimPrazo).HasColumnName("SIM_PRAZO");
            entity.Property(e => e.SimPriVencto).HasColumnName("SIM_PRI_VENCTO");
            entity.Property(e => e.SimTaxa)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SIM_TAXA");
            entity.Property(e => e.SimTxAno)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SIM_TX_ANO");
            entity.Property(e => e.SimValor)
                .HasColumnType("money")
                .HasColumnName("SIM_VALOR");
            entity.Property(e => e.VlLiberado)
                .HasComment("Val.Liberado")
                .HasColumnType("money")
                .HasColumnName("VL_LIBERADO");
            entity.Property(e => e.VlPagamento)
                .HasColumnType("money")
                .HasColumnName("VL_PAGAMENTO");
            entity.Property(e => e.VlSolicitado)
                .HasDefaultValue(0m)
                .HasComment("Val.Solicitado")
                .HasColumnType("money")
                .HasColumnName("VL_SOLICITADO");
        });

        modelBuilder.Entity<T2208>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("T2208", tb => tb.HasComment("Capital Giro - Veiculo"));

            entity.HasIndex(e => e.FkT2302, "IX_FK_T2302");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasComment("Id")
                .HasColumnName("ID");
            entity.Property(e => e.BlCedente)
                .HasDefaultValue(false)
                .HasComment("Cedente")
                .HasColumnName("BL_CEDENTE");
            entity.Property(e => e.BlConAssinatura)
                .HasDefaultValue(false)
                .HasComment("Assinado")
                .HasColumnName("BL_CON_ASSINATURA");
            entity.Property(e => e.BlConEmissao)
                .HasDefaultValue(false)
                .HasComment("Emitido")
                .HasColumnName("BL_CON_EMISSAO");
            entity.Property(e => e.BlFinQuitado)
                .HasComment("Vei.Quitado")
                .HasColumnName("BL_FIN_QUITADO");
            entity.Property(e => e.BlVeiNome)
                .HasComment("Em Seu Nome")
                .HasColumnName("BL_VEI_NOME");
            entity.Property(e => e.DhInsert)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Data Insert")
                .HasColumnType("datetime")
                .HasColumnName("DH_INSERT");
            entity.Property(e => e.DhUpdate)
                .HasComment("Data Update")
                .HasColumnType("datetime")
                .HasColumnName("DH_UPDATE");
            entity.Property(e => e.DiaVencto1)
                .HasDefaultValue((byte)0)
                .HasComment("Dia Vencto")
                .HasColumnName("DIA_VENCTO_1");
            entity.Property(e => e.DiaVencto2)
                .HasDefaultValue((byte)0)
                .HasComment("Dia Vencto")
                .HasColumnName("DIA_VENCTO_2");
            entity.Property(e => e.DmPorte)
                .HasDefaultValue((byte)0)
                .HasComment("Porte Empresa")
                .HasColumnName("DM_PORTE");
            entity.Property(e => e.DmRating)
                .HasComment("Rating")
                .HasColumnName("DM_RATING");
            entity.Property(e => e.DmVeiTipo)
                .HasDefaultValue((byte)1)
                .HasComment("Tipo")
                .HasColumnName("DM_VEI_TIPO");
            entity.Property(e => e.DtConAssinatura)
                .HasComment("Data Assinatura")
                .HasColumnName("DT_CON_ASSINATURA");
            entity.Property(e => e.DtConEmissao)
                .HasComment("Data Emissao")
                .HasColumnName("DT_CON_EMISSAO");
            entity.Property(e => e.DtPriVencto)
                .HasComment("Data Pri.Vencto")
                .HasColumnName("DT_PRI_VENCTO");
            entity.Property(e => e.DtPriVenctoLib)
                .HasComment("Data Pri.Vencto Lib")
                .HasColumnName("DT_PRI_VENCTO_LIB");
            entity.Property(e => e.Ex0001)
                .HasComment("Editavel")
                .HasColumnName("EX_0001");
            entity.Property(e => e.Ex0002)
                .HasComment("Sessao")
                .HasColumnName("EX_0002");
            entity.Property(e => e.FkT2302)
                .HasComment("Id")
                .HasColumnName("FK_T2302");
            entity.Property(e => e.PcCoeficiente)
                .HasComment("Coeficiente")
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("PC_COEFICIENTE");
            entity.Property(e => e.PcCoeficienteLib)
                .HasComment("Coeficiente Lib")
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("PC_COEFICIENTE_LIB");
            entity.Property(e => e.PcJuros)
                .HasDefaultValue(0m)
                .HasComment("Juros")
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("PC_JUROS");
            entity.Property(e => e.QtDiaCarencia)
                .HasComment("Dia Carencia")
                .HasColumnName("QT_DIA_CARENCIA");
            entity.Property(e => e.QtDiaCarenciaLib)
                .HasComment("Dia Carencia Lib")
                .HasColumnName("QT_DIA_CARENCIA_LIB");
            entity.Property(e => e.QtMesPrazo)
                .HasComment("Prazo")
                .HasColumnName("QT_MES_PRAZO");
            entity.Property(e => e.QtMesPrazoLib)
                .HasComment("Prazo Lib")
                .HasColumnName("QT_MES_PRAZO_LIB");
            entity.Property(e => e.SocInsFederal)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("CPF Socio")
                .HasColumnName("SOC_INS_FEDERAL");
            entity.Property(e => e.SocNome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Nome Socio")
                .HasColumnName("SOC_NOME");
            entity.Property(e => e.VeiAnoFabric)
                .HasComment("Ano Fabric")
                .HasColumnName("VEI_ANO_FABRIC");
            entity.Property(e => e.VeiAnoModelo)
                .HasComment("Ano Modelo")
                .HasColumnName("VEI_ANO_MODELO");
            entity.Property(e => e.VeiMarca)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Vei.Marca")
                .HasColumnName("VEI_MARCA");
            entity.Property(e => e.VeiModelo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Vei.Modelo")
                .HasColumnName("VEI_MODELO");
            entity.Property(e => e.VeiPlaca)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Placa")
                .HasColumnName("VEI_PLACA");
            entity.Property(e => e.VlFaturamento)
                .HasComment("Faturamento")
                .HasColumnType("money")
                .HasColumnName("VL_FATURAMENTO");
            entity.Property(e => e.VlPrestacao)
                .HasComment("Val.Prestacao")
                .HasColumnType("money")
                .HasColumnName("VL_PRESTACAO");
            entity.Property(e => e.VlPrestacaoLib)
                .HasComment("Val.Prestacao")
                .HasColumnType("money")
                .HasColumnName("VL_PRESTACAO_LIB");
            entity.Property(e => e.VlTac)
                .HasComment("Val.TAC")
                .HasColumnType("money")
                .HasColumnName("VL_TAC");
            entity.Property(e => e.VlTacLib)
                .HasComment("Val.TAC")
                .HasColumnType("money")
                .HasColumnName("VL_TAC_LIB");
            entity.Property(e => e.VlVeiAvaliado)
                .HasComment("Val.Vei.Avaliado")
                .HasColumnType("money")
                .HasColumnName("VL_VEI_AVALIADO");
            entity.Property(e => e.VlVeiEstimado)
                .HasComment("Val.Vei.Estimado")
                .HasColumnType("money")
                .HasColumnName("VL_VEI_ESTIMADO");
            entity.Property(e => e.VlVeiFip)
                .HasComment("Val.Vei.FIP")
                .HasColumnType("money")
                .HasColumnName("VL_VEI_FIP");
        });

        modelBuilder.Entity<VwApiT2208P1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_API_T2208_P1");

            entity.Property(e => e.BlAceite).HasColumnName("BL_ACEITE");
            entity.Property(e => e.BlCedente).HasColumnName("BL_CEDENTE");
            entity.Property(e => e.BlConAssinatura).HasColumnName("BL_CON_ASSINATURA");
            entity.Property(e => e.BlConEmissao).HasColumnName("BL_CON_EMISSAO");
            entity.Property(e => e.BlFinQuitado).HasColumnName("BL_FIN_QUITADO");
            entity.Property(e => e.BlNovo).HasColumnName("BL_NOVO");
            entity.Property(e => e.BlTermo).HasColumnName("BL_TERMO");
            entity.Property(e => e.BlVeiNome).HasColumnName("BL_VEI_NOME");
            entity.Property(e => e.CdQprof).HasColumnName("CD_QPROF");
            entity.Property(e => e.DhAceite)
                .HasColumnType("datetime")
                .HasColumnName("DH_ACEITE");
            entity.Property(e => e.DhIniCad)
                .HasColumnType("datetime")
                .HasColumnName("DH_INI_CAD");
            entity.Property(e => e.DhIniTermo)
                .HasColumnType("datetime")
                .HasColumnName("DH_INI_TERMO");
            entity.Property(e => e.DhInsert)
                .HasColumnType("datetime")
                .HasColumnName("DH_INSERT");
            entity.Property(e => e.DhRegistro)
                .HasColumnType("datetime")
                .HasColumnName("DH_REGISTRO");
            entity.Property(e => e.DhStaParceiro).HasColumnName("DH_STA_PARCEIRO");
            entity.Property(e => e.DhTerCad)
                .HasColumnType("datetime")
                .HasColumnName("DH_TER_CAD");
            entity.Property(e => e.DhTerTermo)
                .HasColumnType("datetime")
                .HasColumnName("DH_TER_TERMO");
            entity.Property(e => e.DhUpdate)
                .HasColumnType("datetime")
                .HasColumnName("DH_UPDATE");
            entity.Property(e => e.DiaVencto1).HasColumnName("DIA_VENCTO_1");
            entity.Property(e => e.DiaVencto2).HasColumnName("DIA_VENCTO_2");
            entity.Property(e => e.DmPessoa).HasColumnName("DM_PESSOA");
            entity.Property(e => e.DmPorte).HasColumnName("DM_PORTE");
            entity.Property(e => e.DmSituacao).HasColumnName("DM_SITUACAO");
            entity.Property(e => e.DmStatus).HasColumnName("DM_STATUS");
            entity.Property(e => e.DmTemp).HasColumnName("DM_TEMP");
            entity.Property(e => e.DmTipo).HasColumnName("DM_TIPO");
            entity.Property(e => e.DmVeiTipo).HasColumnName("DM_VEI_TIPO");
            entity.Property(e => e.DsContato)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DS_CONTATO");
            entity.Property(e => e.DsDados)
                .IsUnicode(false)
                .HasColumnName("DS_DADOS");
            entity.Property(e => e.DsMotEmprestimo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DS_MOT_EMPRESTIMO");
            entity.Property(e => e.DsMotivo)
                .IsUnicode(false)
                .HasColumnName("DS_MOTIVO");
            entity.Property(e => e.DsStaParceiro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DS_STA_PARCEIRO");
            entity.Property(e => e.DsTerCondic)
                .IsUnicode(false)
                .HasColumnName("DS_TER_CONDIC");
            entity.Property(e => e.DtConAssinatura).HasColumnName("DT_CON_ASSINATURA");
            entity.Property(e => e.DtConEmissao).HasColumnName("DT_CON_EMISSAO");
            entity.Property(e => e.DtPagamento).HasColumnName("DT_PAGAMENTO");
            entity.Property(e => e.DtPriVencto).HasColumnName("DT_PRI_VENCTO");
            entity.Property(e => e.DtPriVenctoLib).HasColumnName("DT_PRI_VENCTO_LIB");
            entity.Property(e => e.DtRegistro).HasColumnName("DT_REGISTRO");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Email2)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("EMAIL_2");
            entity.Property(e => e.EndBairro)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("END_BAIRRO");
            entity.Property(e => e.EndCep)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("END_CEP");
            entity.Property(e => e.EndComplemento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("END_COMPLEMENTO");
            entity.Property(e => e.EndLogradouro)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("END_LOGRADOURO");
            entity.Property(e => e.EndNumero)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("END_NUMERO");
            entity.Property(e => e.Ex0001).HasColumnName("EX_0001");
            entity.Property(e => e.Ex0002).HasColumnName("EX_0002");
            entity.Property(e => e.FkC1001).HasColumnName("FK_C1001");
            entity.Property(e => e.FkC1101).HasColumnName("FK_C1101");
            entity.Property(e => e.FkP1005).HasColumnName("FK_P1005");
            entity.Property(e => e.FkT1009).HasColumnName("FK_T1009");
            entity.Property(e => e.FkT1010).HasColumnName("FK_T1010");
            entity.Property(e => e.FkT1017).HasColumnName("FK_T1017");
            entity.Property(e => e.FkT1101).HasColumnName("FK_T1101");
            entity.Property(e => e.FkT1201).HasColumnName("FK_T1201");
            entity.Property(e => e.FkT1204).HasColumnName("FK_T1204");
            entity.Property(e => e.FkT1212).HasColumnName("FK_T1212");
            entity.Property(e => e.FkT2004).HasColumnName("FK_T2004");
            entity.Property(e => e.FkT2106).HasColumnName("FK_T2106");
            entity.Property(e => e.FkT2301).HasColumnName("FK_T2301");
            entity.Property(e => e.FkT23012).HasColumnName("FK_T2301_2");
            entity.Property(e => e.FkT2310).HasColumnName("FK_T2310");
            entity.Property(e => e.FonDdd).HasColumnName("FON_DDD");
            entity.Property(e => e.FonDdd2).HasColumnName("FON_DDD_2");
            entity.Property(e => e.FonNum)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FON_NUM");
            entity.Property(e => e.FonNum2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FON_NUM_2");
            entity.Property(e => e.HrRegistro).HasColumnName("HR_REGISTRO");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.InsFederal)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("INS_FEDERAL");
            entity.Property(e => e.InsFederalFmt)
                .IsUnicode(false)
                .HasColumnName("INS_FEDERAL_FMT");
            entity.Property(e => e.LinkBase)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("LINK_BASE");
            entity.Property(e => e.NmBanco)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NM_BANCO");
            entity.Property(e => e.NmCanal)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NM_CANAL");
            entity.Property(e => e.NmContato)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NM_CONTATO");
            entity.Property(e => e.NmFantasia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NM_FANTASIA");
            entity.Property(e => e.NmForContato)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NM_FOR_CONTATO");
            entity.Property(e => e.NmIndicacao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NM_INDICACAO");
            entity.Property(e => e.NmLocalidade)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NM_LOCALIDADE");
            entity.Property(e => e.NmMotEmprestimo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NM_MOT_EMPRESTIMO");
            entity.Property(e => e.NmMotivo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NM_MOTIVO");
            entity.Property(e => e.NmParceiro)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NM_PARCEIRO");
            entity.Property(e => e.NmProduto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NM_PRODUTO");
            entity.Property(e => e.NmTerCondic)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NM_TER_CONDIC");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOME");
            entity.Property(e => e.NrAgencia)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NR_AGENCIA");
            entity.Property(e => e.NrBanco)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NR_BANCO");
            entity.Property(e => e.NrConta)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NR_CONTA");
            entity.Property(e => e.NrContaDv)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("NR_CONTA_DV");
            entity.Property(e => e.NrIp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NR_IP");
            entity.Property(e => e.NrProtocolo)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NR_PROTOCOLO");
            entity.Property(e => e.NrScore).HasColumnName("NR_SCORE");
            entity.Property(e => e.NrSimulacao)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NR_SIMULACAO");
            entity.Property(e => e.Par01)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PAR_01");
            entity.Property(e => e.Par02)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PAR_02");
            entity.Property(e => e.PcCoeficiente)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("PC_COEFICIENTE");
            entity.Property(e => e.PcCoeficienteLib)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("PC_COEFICIENTE_LIB");
            entity.Property(e => e.PcJuros)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("PC_JUROS");
            entity.Property(e => e.Perfil)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("PERFIL");
            entity.Property(e => e.QtDiaCarencia).HasColumnName("QT_DIA_CARENCIA");
            entity.Property(e => e.QtDiaCarenciaLib).HasColumnName("QT_DIA_CARENCIA_LIB");
            entity.Property(e => e.QtMesPrazo).HasColumnName("QT_MES_PRAZO");
            entity.Property(e => e.QtMesPrazoLib).HasColumnName("QT_MES_PRAZO_LIB");
            entity.Property(e => e.Senha)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SENHA");
            entity.Property(e => e.SgUf)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("SG_UF");
            entity.Property(e => e.SimDtEmissao).HasColumnName("SIM_DT_EMISSAO");
            entity.Property(e => e.SimParcela)
                .HasColumnType("money")
                .HasColumnName("SIM_PARCELA");
            entity.Property(e => e.SimPrazo).HasColumnName("SIM_PRAZO");
            entity.Property(e => e.SimPriVencto).HasColumnName("SIM_PRI_VENCTO");
            entity.Property(e => e.SimTaxa)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SIM_TAXA");
            entity.Property(e => e.SimTxAno)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SIM_TX_ANO");
            entity.Property(e => e.SimValor)
                .HasColumnType("money")
                .HasColumnName("SIM_VALOR");
            entity.Property(e => e.SocInsFederal)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SOC_INS_FEDERAL");
            entity.Property(e => e.SocNome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SOC_NOME");
            entity.Property(e => e.VeiAnoFabric).HasColumnName("VEI_ANO_FABRIC");
            entity.Property(e => e.VeiAnoModelo).HasColumnName("VEI_ANO_MODELO");
            entity.Property(e => e.VeiMarca)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("VEI_MARCA");
            entity.Property(e => e.VeiModelo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("VEI_MODELO");
            entity.Property(e => e.VeiPlaca)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VEI_PLACA");
            entity.Property(e => e.VlFaturamento)
                .HasColumnType("money")
                .HasColumnName("VL_FATURAMENTO");
            entity.Property(e => e.VlLiberado)
                .HasColumnType("money")
                .HasColumnName("VL_LIBERADO");
            entity.Property(e => e.VlPagamento)
                .HasColumnType("money")
                .HasColumnName("VL_PAGAMENTO");
            entity.Property(e => e.VlPrestacao)
                .HasColumnType("money")
                .HasColumnName("VL_PRESTACAO");
            entity.Property(e => e.VlPrestacaoLib)
                .HasColumnType("money")
                .HasColumnName("VL_PRESTACAO_LIB");
            entity.Property(e => e.VlSolicitado)
                .HasColumnType("money")
                .HasColumnName("VL_SOLICITADO");
            entity.Property(e => e.VlTac)
                .HasColumnType("money")
                .HasColumnName("VL_TAC");
            entity.Property(e => e.VlTacLib)
                .HasColumnType("money")
                .HasColumnName("VL_TAC_LIB");
            entity.Property(e => e.VlVeiAvaliado)
                .HasColumnType("money")
                .HasColumnName("VL_VEI_AVALIADO");
            entity.Property(e => e.VlVeiEstimado)
                .HasColumnType("money")
                .HasColumnName("VL_VEI_ESTIMADO");
            entity.Property(e => e.VlVeiFip)
                .HasColumnType("money")
                .HasColumnName("VL_VEI_FIP");
        });

        modelBuilder.Entity<VwT1213B1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_T1213_B1");

            entity.Property(e => e.FkT1201).HasColumnName("FK_T1201");
            entity.Property(e => e.FkT1212).HasColumnName("FK_T1212");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NmMotivo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NM_MOTIVO");
            entity.Property(e => e.NmProduto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NM_PRODUTO");
            entity.Property(e => e.NrSeq).HasColumnName("NR_SEQ");
        });
        modelBuilder.HasSequence("SQ_C1201_P1");
        modelBuilder.HasSequence("SQ_C1201_P2");
        modelBuilder.HasSequence("SQ_T2101_P1");
        modelBuilder.HasSequence("SQ_T2101_P2");
        modelBuilder.HasSequence("SQ_T2405_P1");
        modelBuilder.HasSequence("SQ_T2405_P2").StartsAt(31L);
        modelBuilder.HasSequence("SQ_T2406_P1");
        modelBuilder.HasSequence("SQ_T2415_P1").StartsAt(230L);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
