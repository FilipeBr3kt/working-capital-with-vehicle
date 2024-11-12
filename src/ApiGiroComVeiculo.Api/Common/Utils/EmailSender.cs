using MailKit.Net.Smtp;
using MimeKit;

namespace ApiGiroComVeiculo.Api.Common.Utils;

public static class EmailSender
{
    private static IConfiguration? _config;
    private static string? _smtpPort;
    private static string? _smtpEmail;
    private static string? _smtpPassword;
    private static string? _smtpClient;

    public static void Configure(IConfiguration config)
    {
        _config = config;

        _smtpPort = _config.GetValue<string>("SecretsApi:Email:Port")!;
        _smtpEmail = _config.GetValue<string>("SecretsApi:Email:Email")!;
        _smtpPassword = _config.GetValue<string>("SecretsApi:Email:Password")!;
        _smtpClient = _config.GetValue<string>("SecretsApi:Email:Client")!;
    }

    public static void SendEmail(string toEmail, string username, string subject, string template)
    {
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress("RNX FIDC", _smtpEmail));
        email.To.Add(new MailboxAddress(username, toEmail));

        email.Subject = subject;
        email.Body = new TextPart("html") { Text = template };

        using var smtp = new SmtpClient();
        smtp.Connect(_smtpClient, Int32.Parse(_smtpPort!), false);

        smtp.Authenticate(_smtpEmail, _smtpPassword);

        smtp.Send(email);
        smtp.Disconnect(true);
    }
}
