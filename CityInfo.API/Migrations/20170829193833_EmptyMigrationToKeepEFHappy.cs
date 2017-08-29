using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CityInfo.API.Migrations
{
    public partial class EmptyMigrationToKeepEFHappy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: nameof(City.Description),
               table: "Cities");

            migrationBuilder.AddColumn<string>(
                name: nameof(City.Description),
                table: "Cities",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: nameof(City.Description),
               table: "Cities");

            migrationBuilder.AddColumn<int>(
                name: nameof(City.Description),
                table: "Cities",
                type: "int",
                nullable: true);
        }
    }
}
