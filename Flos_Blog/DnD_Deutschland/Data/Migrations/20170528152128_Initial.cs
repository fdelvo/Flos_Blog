using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DnD_Deutschland.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ForumCategories",
                columns: table => new
                {
                    ForumCategoryId = table.Column<Guid>(nullable: false),
                    ForumCategoryDescription = table.Column<string>(nullable: true),
                    ForumCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumCategories", x => x.ForumCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    EntryId = table.Column<Guid>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    EntryAuthorId = table.Column<string>(nullable: true),
                    EntryContent = table.Column<string>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    EntryTitle = table.Column<string>(nullable: false),
                    ForumEntryCategoryForumCategoryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.EntryId);
                    table.ForeignKey(
                        name: "FK_Entries_AspNetUsers_EntryAuthorId",
                        column: x => x.EntryAuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entries_ForumCategories_ForumEntryCategoryForumCategoryId",
                        column: x => x.ForumEntryCategoryForumCategoryId,
                        principalTable: "ForumCategories",
                        principalColumn: "ForumCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(nullable: false),
                    BlogEntryCommentEntryId = table.Column<Guid>(nullable: true),
                    CommentAuthorId = table.Column<string>(nullable: true),
                    CommentContent = table.Column<string>(nullable: false),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    CommentEntryCommentCommentId = table.Column<Guid>(nullable: true),
                    ForumEntryCommentEntryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Entries_BlogEntryCommentEntryId",
                        column: x => x.BlogEntryCommentEntryId,
                        principalTable: "Entries",
                        principalColumn: "EntryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_CommentAuthorId",
                        column: x => x.CommentAuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_CommentEntryCommentCommentId",
                        column: x => x.CommentEntryCommentCommentId,
                        principalTable: "Comments",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Entries_ForumEntryCommentEntryId",
                        column: x => x.ForumEntryCommentEntryId,
                        principalTable: "Entries",
                        principalColumn: "EntryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<Guid>(nullable: false),
                    BlogEntryEntryId = table.Column<Guid>(nullable: true),
                    TagKeyword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                    table.ForeignKey(
                        name: "FK_Tags_Entries_BlogEntryEntryId",
                        column: x => x.BlogEntryEntryId,
                        principalTable: "Entries",
                        principalColumn: "EntryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogEntryCommentEntryId",
                table: "Comments",
                column: "BlogEntryCommentEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentAuthorId",
                table: "Comments",
                column: "CommentAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentEntryCommentCommentId",
                table: "Comments",
                column: "CommentEntryCommentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ForumEntryCommentEntryId",
                table: "Comments",
                column: "ForumEntryCommentEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_EntryAuthorId",
                table: "Entries",
                column: "EntryAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ForumEntryCategoryForumCategoryId",
                table: "Entries",
                column: "ForumEntryCategoryForumCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_BlogEntryEntryId",
                table: "Tags",
                column: "BlogEntryEntryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "ForumCategories");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Alias",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
