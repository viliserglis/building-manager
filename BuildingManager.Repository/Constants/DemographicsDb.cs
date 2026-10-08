namespace BuildingManager.Repository.Constants;

public static class DemographicsDb
{
    public const string Schema = "demographics";
    
    public static class Tables
    {
        public const string Person = "person";
        public const string Claims = "claims";
    }

    //public static string WithSchema(this string table) => $"{Schema}.{table}";
}