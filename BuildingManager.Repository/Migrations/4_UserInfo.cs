using BuildingManager.Repository.Constants;
using FluentMigrator;

namespace BuildingManager.Repository.Migrations;

[Migration(4, "Addded user identeties and roles")]
public class UserInfo : Migration
{
    public override void Up()
    {
        Create.Table(DemographicsDb.Tables.Person).InSchema(DemographicsDb.Schema)
            .WithColumn("id").AsGuid().PrimaryKey().NotNullable()
            .WithColumn("username").AsString().NotNullable()
            .WithColumn("password").AsString().NotNullable()
            .WithColumn("role").AsString()
            .WithColumn("person_id").AsGuid()
            .ForeignKey("person_user", DemographicsDb.Schema, DemographicsDb.Tables.Person, "id");

        Create.Table(DemographicsDb.Tables.Claims).InSchema(DemographicsDb.Schema)
            .WithColumn("person_id").AsGuid()
            .ForeignKey("person_claims", DemographicsDb.Schema, DemographicsDb.Tables.Person, "id")
            .WithColumn("claim").AsString()
            .WithColumn("value").AsString();
    }

    public override void Down()
    {
    }
}