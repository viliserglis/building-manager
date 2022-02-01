using BuildingManager.Repository.Constants;
using FluentMigrator;

namespace BuildingManager.Repository.Migrations;

[Migration(1, "Initial migration for schemas")]
public class Initial : Migration
{
    public override void Up()
    {
        Create.Schema(DemographicsDb.Schema);
        Create.Schema(BuildingDb.Schema);
    }

    public override void Down()
    {
        Delete.Schema(DemographicsDb.Schema);
        Delete.Schema(DemographicsDb.Schema);
    }
}