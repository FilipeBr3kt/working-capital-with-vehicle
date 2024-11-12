using ApiGiroComVeiculo.Api.Common.Abstractions;
using ApiGiroComVeiculo.Api.Common.DTOs;
using ApiGiroComVeiculo.Api.Common.Responses;
using ApiGiroComVeiculo.Api.Database;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ApiGiroComVeiculo.Api.Common.Repositories;

public class StoredProceduresRepository : IStoredProcedureRepository
{
    private readonly Database.DatabaseContext _dbContext;

    public StoredProceduresRepository(Database.DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ValidateProtocolProcedureResponse> VerifyUserInformation(VerifyUserInformationDTO model,
        CancellationToken cancellationToken)
    {
        var parameters = new[]
        {
            new SqlParameter("@id_sessao", 1),
            new SqlParameter("@ins_federal", model.Cnpj),
            new SqlParameter("@vei_placa", model.Plate),

            new SqlParameter("@id", SqlDbType.Int) { Direction = ParameterDirection.Output },
            new SqlParameter("@nr_protocolo", SqlDbType.VarChar, 20) { Direction = ParameterDirection.Output },
            new SqlParameter("@nome", SqlDbType.VarChar, 100) { Direction = ParameterDirection.Output },
            new SqlParameter("@bl_atendimento", SqlDbType.Bit) { Direction = ParameterDirection.Output },
            new SqlParameter("@ult_dias", SqlDbType.Int) { Direction = ParameterDirection.Output },
            new SqlParameter("@dm_status", SqlDbType.TinyInt) { Direction = ParameterDirection.Output },
            new SqlParameter("@dm_situacao", SqlDbType.TinyInt) { Direction = ParameterDirection.Output },
            new SqlParameter("@result", SqlDbType.Bit) { Direction = ParameterDirection.Output },
            new SqlParameter("@msg", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output }
        };

        await _dbContext.Database.ExecuteSqlRawAsync(
            "EXEC SP_API_T2208_P1 @id_sessao, @ins_federal, @vei_placa, @id OUT, @nr_protocolo OUT, @nome OUT, " +
            "@bl_atendimento OUT, @ult_dias OUT, @dm_status OUT, @dm_situacao OUT, @result OUT, @msg OUT",
            parameters
        );

        return new ValidateProtocolProcedureResponse()
        {
            Id = parameters[3].Value as int? ?? 0,
            NrProtocolo = parameters[4].Value as string,
            Nome = parameters[5].Value as string,
            BlAtendimento = parameters[6].Value as bool? ?? false,
            UltDias = parameters[7].Value as int? ?? -1,
            DmStatus = parameters[8].Value as byte? ?? 0,
            DmSituacao = parameters[9].Value as byte? ?? 0,
            Result = parameters[10].Value as bool? ?? false,
            Msg = parameters[11].Value as string
        };
    }

    public async Task<InsertProtocolProcedureResponse> InsertProtocolAsync(InsertProtocolDTO model,
        CancellationToken cancellation)
    {
        var parameters = new List<SqlParameter>
        {
            //Proposal
            new("@id_sessao", model.SessionId) { Direction = ParameterDirection.Input },
            new("@id_termo", model.TermId) { Direction = ParameterDirection.Input },
            new("@id_indicacao", model.IndicationId) { Direction = ParameterDirection.Input },
            new("@id_motivo", model.ReasonId) { Direction = ParameterDirection.Input },
            new("@id_parceiro", model.PartnerId) { Direction = ParameterDirection.Input },
            new("@id_loja", model.StoreId) { Direction = ParameterDirection.Input },
            new("@id_canal", model.ChannelId) { Direction = ParameterDirection.Input },
            new("@ds_mot_emprestimo", model.ReasonDescription) { Direction = ParameterDirection.Input },
            //Customer
            new("@ins_federal", model.CustomerCNPJ) { Direction = ParameterDirection.Input },
            new("@nome", model.CustomerName) { Direction = ParameterDirection.Input },
            new("@nm_fantasia", model.CustomerFantasyName) { Direction = ParameterDirection.Input },
            new("@vl_faturamento", model.CustomerInvoiceAmount) { Direction = ParameterDirection.Input },
            new("@dm_porte", model.CustomerBusinessSizeStatus) { Direction = ParameterDirection.Input },
            //Partner
            new("@soc_nome", model.PartnerName) { Direction = ParameterDirection.Input },
            new("@soc_ins_federal", model.PartnerCPF) { Direction = ParameterDirection.Input },
            //Contact
            new("@nm_contato", model.ContactName) { Direction = ParameterDirection.Input },
            new("@email", model.ContactEmail) { Direction = ParameterDirection.Input },
            new("@fon_ddd", (short)model.ContactPhoneDdd),
            //{ Value = command.ContactPhoneDdd, Direction = ParameterDirection.Input },
            new("@fon_num", model.ContactPhoneNumber) { Direction = ParameterDirection.Input },
            //Vehicle
            new("@vei_placa", model.VehiclePlate),
            new("@vei_ano_modelo", (short)model.VehicleModelYear),
            //{ Value = command.VehicleModelYear, Direction = ParameterDirection.Input },
            new("@vei_ano_fabric", (short)model.VehicleMarketValue),
            //{ Value = command.VehicleMarketValue, Direction = ParameterDirection.Input },
            new("@vei_valor", model.VehicleMarketValue) { Direction = ParameterDirection.Input },
            new("@vei_marca", model.VehicleBrand) { Direction = ParameterDirection.Input },
            new("@vei_modelo", model.VehicleModel) { Direction = ParameterDirection.Input },
            new("@dm_vei_tipo", model.VehicleTypeId) { Direction = ParameterDirection.Input }, // 1=Car, 2=Bike
            new("@bl_vei_nome", model.IsVehicleInCustomerName) { Direction = ParameterDirection.Input },
            new("@vei_fin_quitado", model.IsVehicleFullyPaid) { Direction = ParameterDirection.Input },
            //Operation
            new("@vl_solicitado", model.RequestedAmount) { Direction = ParameterDirection.Input },
            new("@qt_mes_prazo", (short)model.TermDuration),
            //{ Value = command.TermDuration, Direction = ParameterDirection.Input },
            new("@bl_aceite", model.IsAcceptanceId) { Direction = ParameterDirection.Input },
            new("@bl_termo", model.IsAcceptanceTermId) { Direction = ParameterDirection.Input },
            new("@dh_aceite", model.AcceptanceDate) { Direction = ParameterDirection.Input },
            new("@dh_ini_termo", model.TermStartDate) { Direction = ParameterDirection.Input },
            new("@dh_ter_termo", model.TermEndDate) { Direction = ParameterDirection.Input },
            new("@dh_ini_cad", model.RegistrationStartDate) { Direction = ParameterDirection.Input },
            new("@dh_ter_cad", model.RegistrationEndDate) { Direction = ParameterDirection.Input },
            new("@nr_ip", model.IpAddress) { Direction = ParameterDirection.Input },

            //Output
            new("@id_protocolo", SqlDbType.Int) { Direction = ParameterDirection.Output },
            new("@nr_protocolo", SqlDbType.VarChar, 20) { Direction = ParameterDirection.Output },
            new("@senha", SqlDbType.VarChar, 100) { Direction = ParameterDirection.Output },
            new("@result", SqlDbType.Bit) { Direction = ParameterDirection.Output },
            new("@msg", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output }
        };

        await _dbContext.Database.ExecuteSqlRawAsync(
            "EXEC SP_API_T2208_C1 @id_sessao, @id_termo, @id_indicacao, @id_motivo, @id_parceiro, " +
            "@id_loja, @id_canal, @ds_mot_emprestimo, @ins_federal, @nome, @nm_fantasia, @vl_faturamento, " +
            "@dm_porte, @soc_nome, @soc_ins_federal, @nm_contato, @email, @fon_ddd, @fon_num, @vei_placa, " +
            "@vei_ano_modelo, @vei_ano_fabric, @vei_valor, @vei_marca, @vei_modelo, @dm_vei_tipo, @bl_vei_nome," +
            " @vei_fin_quitado, @vl_solicitado, @qt_mes_prazo, @bl_aceite, @bl_termo, @dh_aceite, @dh_ini_termo," +
            " @dh_ter_termo, @dh_ini_cad, @dh_ter_cad, @nr_ip, @id_protocolo OUT, @nr_protocolo OUT, @senha OUT," +
            "@result OUT, @msg OUT",
            parameters);

        return new InsertProtocolProcedureResponse
        {
            IdProtocolo = parameters[36].Value as int? ?? 0,
            NrProtocolo = parameters[37].Value as string,
            Senha = parameters[38].Value as string,
            Result = parameters[39].Value as bool? ?? false,
            Msg = parameters[40].Value as string
        };
    }
}