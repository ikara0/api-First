namespace BilgeAdam.Common
{
    public class Settings
    {
        public DatabaseSetting Database { get; set; }
    }

    public class DatabaseSetting
    {
        public string ConnectionString { get; set; }
    }
}