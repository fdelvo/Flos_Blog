using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DnD_Deutschland.Data.Migrations
{
    public partial class date_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ForumEntryDate",
                table: "ForumEntries",
                newName: "ForumEntryLastEditedDate");

            migrationBuilder.RenameColumn(
                name: "EntryDate",
                table: "Entries",
                newName: "EntryLastEditedDate");

            migrationBuilder.RenameColumn(
                name: "BlogEntryDate",
                table: "BlogEntries",
                newName: "BlogEntryLastEditedDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "ForumEntryCreatedDate",
                table: "ForumEntries",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryCreatedDate",
                table: "Entries",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BlogEntryCreatedDate",
                table: "BlogEntries",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForumEntryCreatedDate",
                table: "ForumEntries");

            migrationBuilder.DropColumn(
                name: "EntryCreatedDate",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "BlogEntryCreatedDate",
                table: "BlogEntries");

            migrationBuilder.RenameColumn(
                name: "ForumEntryLastEditedDate",
                table: "ForumEntries",
                newName: "ForumEntryDate");

            migrationBuilder.RenameColumn(
                name: "EntryLastEditedDate",
                table: "Entries",
                newName: "EntryDate");

            migrationBuilder.RenameColumn(
                name: "BlogEntryLastEditedDate",
                table: "BlogEntries",
                newName: "BlogEntryDate");
        }
    }
}
