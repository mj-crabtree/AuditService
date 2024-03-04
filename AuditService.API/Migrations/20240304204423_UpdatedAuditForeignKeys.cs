using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuditService.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAuditForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditEvents_TrackedFiles_TrackedFileId",
                table: "AuditEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_AuditEvents_TrackedUsers_TrackedUserId",
                table: "AuditEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrackedUsers",
                table: "TrackedUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrackedFiles",
                table: "TrackedFiles");

            migrationBuilder.RenameTable(
                name: "TrackedUsers",
                newName: "TrackedUser");

            migrationBuilder.RenameTable(
                name: "TrackedFiles",
                newName: "TrackedFile");

            migrationBuilder.AddColumn<Guid>(
                name: "RecipientId",
                table: "AuditEvents",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrackedUser",
                table: "TrackedUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrackedFile",
                table: "TrackedFile",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AuditEvents_RecipientId",
                table: "AuditEvents",
                column: "RecipientId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditEvents_TrackedFile_TrackedFileId",
                table: "AuditEvents",
                column: "TrackedFileId",
                principalTable: "TrackedFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuditEvents_TrackedUser_RecipientId",
                table: "AuditEvents",
                column: "RecipientId",
                principalTable: "TrackedUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuditEvents_TrackedUser_TrackedUserId",
                table: "AuditEvents",
                column: "TrackedUserId",
                principalTable: "TrackedUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditEvents_TrackedFile_TrackedFileId",
                table: "AuditEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_AuditEvents_TrackedUser_RecipientId",
                table: "AuditEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_AuditEvents_TrackedUser_TrackedUserId",
                table: "AuditEvents");

            migrationBuilder.DropIndex(
                name: "IX_AuditEvents_RecipientId",
                table: "AuditEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrackedUser",
                table: "TrackedUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrackedFile",
                table: "TrackedFile");

            migrationBuilder.DropColumn(
                name: "RecipientId",
                table: "AuditEvents");

            migrationBuilder.RenameTable(
                name: "TrackedUser",
                newName: "TrackedUsers");

            migrationBuilder.RenameTable(
                name: "TrackedFile",
                newName: "TrackedFiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrackedUsers",
                table: "TrackedUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrackedFiles",
                table: "TrackedFiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditEvents_TrackedFiles_TrackedFileId",
                table: "AuditEvents",
                column: "TrackedFileId",
                principalTable: "TrackedFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuditEvents_TrackedUsers_TrackedUserId",
                table: "AuditEvents",
                column: "TrackedUserId",
                principalTable: "TrackedUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
