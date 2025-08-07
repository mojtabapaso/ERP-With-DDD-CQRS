namespace ERP.Infrastructure.Persistence.Configurations;

public static class SqlDataTypes
{
    public const string NVARCHAR_MAX = "NVARCHAR(MAX)";
    public static string NVARCHAR(int length) => $"NVARCHAR({length})";
    public const string VARCHAR_MAX = "VARCHAR(MAX)";
    public static string VARCHAR(int length) => $"VARCHAR({length})";
    public const string INT = "INT";
    public const string TINYINT = "TINYINT";
    public const string BIGINT = "BIGINT";
    public const string BIT = "BIT";
    public const string DATETIME = "DATETIME";
    public static string DECIMAL(int precision, int scale) => $"DECIMAL({precision}, {scale})";
    public const string FLOAT = "FLOAT";
    public const string TEXT = "TEXT";
    public const string UNIQUEIDENTIFIER = "UNIQUEIDENTIFIER";
}
