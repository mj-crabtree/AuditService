using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuditService.Migrations
{
    /// <inheritdoc />
    public partial class AddFileClassifiedEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrentClassification",
                table: "AuditEvents",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewClassificationTier",
                table: "AuditEvents",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OldClassificationTier",
                table: "AuditEvents",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SuccessfulClassification",
                table: "AuditEvents",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentClassification",
                table: "AuditEvents");

            migrationBuilder.DropColumn(
                name: "NewClassificationTier",
                table: "AuditEvents");

            migrationBuilder.DropColumn(
                name: "OldClassificationTier",
                table: "AuditEvents");

            migrationBuilder.DropColumn(
                name: "SuccessfulClassification",
                table: "AuditEvents");
        }
    }
}
