namespace Fermat.Template.PgSql.Shared.Constants;

public static class AppSettingConsts
{
    #region System
    public static class System
    {
        public const string Name = "System.Name";
        public const string Version = "System.Version";
        public const string Description = "System.Description";
        public const string MaintenanceMode = "System.MaintenanceMode";
        public const string DefaultLanguage = "System.DefaultLanguage";
        public const string DefaultTimezone = "System.DefaultTimezone";
        public const string MaxFileSize = "System.MaxFileSize";
        public const string AllowedFileTypes = "System.AllowedFileTypes";
    }
    #endregion

    #region Email
    public static class Email
    {
        public const string SmtpServer = "Email.SmtpServer";
        public const string SmtpPort = "Email.SmtpPort";
        public const string SmtpUsername = "Email.SmtpUsername";
        public const string SmtpPassword = "Email.SmtpPassword";
        public const string SmtpEnableSsl = "Email.SmtpEnableSsl";
        public const string FromAddress = "Email.FromAddress";
        public const string FromName = "Email.FromName";
    }
    #endregion
}