using BuildingManager.Repository.Constants;
using FluentMigrator;

namespace BuildingManager.Repository.Migrations;

[Migration(2, "Create person talbe")]
public class CreatePerson : Migration
{
    public override void Up()
    {
        Create.Table(DemographicsDb.Tables.Person)
            .WithDescription("Holds information about the individual persons")
            .InSchema(DemographicsDb.Schema)
            .WithColumn("id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("firstname").AsString().NotNullable()
            .WithColumn("lastname").AsString().NotNullable()
            .WithColumn("code").AsString().NotNullable()
            .WithColumn("created_at").AsDateTime();
    }

    public override void Down()
    {
        Delete.Table(DemographicsDb.Tables.Person);
    }
}