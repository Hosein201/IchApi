namespace Utility
{
    public class Setting
    {
        /// <summary>
        /// Connection String for dbContext sql
        /// </summary>
        public SqlDbSetting SqlDbSetting { get; set; }
        /// <summary>
        /// Connection String for dbContext mongo
        /// </summary>
        public MongoDbSetting MogoDbSetting { get; set; }
    }

    public class SqlDbSetting
    {
        public string ConnectionSting { get; set; }
    }

    public class MongoDbSetting
    {
        public string ConnectionSting { get; set; }
    }
}
