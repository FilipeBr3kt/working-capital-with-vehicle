namespace ApiGiroComVeiculo.Api.Common.Constants;

public static class ProtocolSituation
{
    public record ColorPalette(string Dark, string Light);

    public record ProtocolStatus(int Id, string Title, ColorPalette Color, string Description);

    public static List<ProtocolStatus> GetProtocolStatuses()
    {
        var list = new List<ProtocolStatus>
        {
            new(0, "Cancelado", new ColorPalette("#ef4444", "#fee2e2"),
                "Sua proposta foi encerrada por sua solicitação. Você pode solicitar uma nova análise."),
            new(1, "Aguardando", new ColorPalette("#3b82f6", "#dbeafe"),
                "Sua proposta está na fila aguardando atendimento, aguarde que o atendente entrará em contato."),
            new(2, "Em Análise", new ColorPalette("#3b82f6", "#dbeafe"),
                "Seu cadastro está passando pela conferência de documentos, em breve retornaremos para você."),
            new(3, "Pré-Aprovado", new ColorPalette("#3b82f6", "#dbeafe"),
                "Seu crédito está em fase de aprovação, para continuar precisaremos dos documentos para conferência no setor de análise de crédito. A proposta expira após 30 dias."),
            new(4, "Pendente", new ColorPalette("#facc15", "#fef9c3"),
                "Sua proposta está aguardando recebimento e/ou conferência dos documentos."),
            new(5, "Aprovado", new ColorPalette("#22c55e", "#dcfce7"),
                "Seu crédito foi aprovado! Agora aguardamos a assinatura do contrato e em breve efetuaremos o pagamento desta solicitação. A proposta expira após 30 dias."),
            new(6, "Reprovado", new ColorPalette("#ef4444", "#fee2e2"),
                "Sua proposta foi reprovada de acordo com a política de crédito. Você pode fazer uma nova tentativa em 60 dias."),
            new(7, "Pago", new ColorPalette("#065f46", "#6ee7b7"),
                "Proposta finalizada! Você recebeu o valor na conta informada."),
            new(8, "Em Atendimento", new ColorPalette("#3b82f6", "#dbeafe"),
                "Sua proposta está sendo atendida nesse instante, aguarde que o atendente entrará em contato."),
            new(9, "Expirado", new ColorPalette("#ef4444", "#fee2e2"),
                "Sua proposta expirou devido ao prazo de validade ter sido ultrapassado. Você pode solicitar uma nova análise."),
            new(10, "Digitando", new ColorPalette("#a1a1aa", "#fafafa"),
                "Você está preenchendo os detalhes da proposta antes de enviá-la para análise.")
        };

        return list;
    }
}
