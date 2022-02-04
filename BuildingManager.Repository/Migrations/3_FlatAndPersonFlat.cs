using BuildingManager.Repository.Constants;
using FluentMigrator;

namespace BuildingManager.Repository.Migrations;

[Migration(3, "Added Flat and Persons flats")]
public class FlatAndPersonFlat : Migration 
{
    public override void Up()
    {
        Create.Table(FlatDb.BuildingTables.Flat)
            .InSchema(FlatDb.Schema)
            .WithColumn("id").AsGuid().PrimaryKey().NotNullable()
            .WithColumn("number").AsInt16().NotNullable()
            .WithColumn("house_number").AsString().NotNullable()
            .WithColumn("area").AsDecimal(3, 1).NotNullable()
            .WithColumn("people_count").AsInt16().NotNullable();

        Create.Table(FlatDb.BuildingTables.PersonFlat)
            .InSchema(FlatDb.Schema)
            .WithColumn("flat_id").AsGuid().NotNullable().ForeignKey("flat_person", FlatDb.Schema, FlatDb.BuildingTables.Flat, "id")
            .WithColumn("person_id").AsGuid().NotNullable().ForeignKey("person_flat", DemographicsDb.Schema, DemographicsDb.Tables.Person, "id")
            .WithColumn("is_owner").AsBoolean().NotNullable();
    }

    public override void Down()
    {
        Delete.Table(FlatDb.BuildingTables.PersonFlat).InSchema(FlatDb.Schema);
        Delete.Table(FlatDb.BuildingTables.Flat).InSchema(FlatDb.Schema);
    }
}