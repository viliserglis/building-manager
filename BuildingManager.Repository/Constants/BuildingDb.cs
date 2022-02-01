namespace BuildingManager.Repository.Constants;

public static class BuildingDb
{
    public const string Schema = "building";

    public static class Tables
    {
        public const string Flat = "flat";
        public const string WaterCounter = "water_counter";
        public const string WaterCounterMeasurement = "water_counter_measurement";
    }
}