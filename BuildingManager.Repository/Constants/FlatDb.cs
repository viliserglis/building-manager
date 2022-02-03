namespace BuildingManager.Repository.Constants;

public static class FlatDb
{
    public const string Schema = "building";

    public static class BuildingTables
    {
        public const string Flat = "flat";
        public const string PersonFlat = "person_flat";
        public const string WaterCounter = "water_counter";
        public const string WaterCounterMeasurement = "water_counter_measurement";
    }

    public static string WithSchema(this string table) => $"{Schema}.{table}";
}