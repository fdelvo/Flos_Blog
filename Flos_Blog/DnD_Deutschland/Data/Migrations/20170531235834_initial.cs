using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DnD_Deutschland.Data.Migrations
{
    public partial class initial : Migration
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
                name: "BlogEntries",
                columns: table => new
                {
                    BlogEntryId = table.Column<Guid>(nullable: false),
                    BlogEntryAuthorId = table.Column<string>(nullable: true),
                    BlogEntryContent = table.Column<string>(nullable: false),
                    BlogEntryDate = table.Column<DateTime>(nullable: false),
                    BlogEntryTitle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogEntries", x => x.BlogEntryId);
                    table.ForeignKey(
                        name: "FK_BlogEntries_AspNetUsers_BlogEntryAuthorId",
                        column: x => x.BlogEntryAuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    EntryId = table.Column<Guid>(nullable: false),
                    EntryAuthorId = table.Column<string>(nullable: true),
                    EntryContent = table.Column<string>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    EntryTitle = table.Column<string>(nullable: false)
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
                });

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
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<Guid>(nullable: false),
                    BlogEntryId = table.Column<Guid>(nullable: true),
                    TagKeyword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                    table.ForeignKey(
                        name: "FK_Tags_BlogEntries_BlogEntryId",
                        column: x => x.BlogEntryId,
                        principalTable: "BlogEntries",
                        principalColumn: "BlogEntryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ForumEntries",
                columns: table => new
                {
                    ForumEntryId = table.Column<Guid>(nullable: false),
                    ForumEntryAuthorId = table.Column<string>(nullable: true),
                    ForumEntryCategoryForumCategoryId = table.Column<Guid>(nullable: true),
                    ForumEntryContent = table.Column<string>(nullable: false),
                    ForumEntryDate = table.Column<DateTime>(nullable: false),
                    ForumEntryTitle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumEntries", x => x.ForumEntryId);
                    table.ForeignKey(
                        name: "FK_ForumEntries_AspNetUsers_ForumEntryAuthorId",
                        column: x => x.ForumEntryAuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForumEntries_ForumCategories_ForumEntryCategoryForumCategoryId",
                        column: x => x.ForumEntryCategoryForumCategoryId,
                        principalTable: "ForumCategories",
                        principalColumn: "ForumCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(nullable: false),
                    BlogEntryCommentBlogEntryId = table.Column<Guid>(nullable: true),
                    CommentAuthorId = table.Column<string>(nullable: true),
                    CommentContent = table.Column<string>(nullable: false),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    CommentOnComment = table.Column<Guid>(nullable: false),
                    ForumEntryCommentForumEntryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_BlogEntries_BlogEntryCommentBlogEntryId",
                        column: x => x.BlogEntryCommentBlogEntryId,
                        principalTable: "BlogEntries",
                        principalColumn: "BlogEntryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_CommentAuthorId",
                        column: x => x.CommentAuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_ForumEntries_ForumEntryCommentForumEntryId",
                        column: x => x.ForumEntryCommentForumEntryId,
                        principalTable: "ForumEntries",
                        principalColumn: "ForumEntryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogEntries_BlogEntryAuthorId",
                table: "BlogEntries",
                column: "BlogEntryAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogEntryCommentBlogEntryId",
                table: "Comments",
                column: "BlogEntryCommentBlogEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentAuthorId",
                table: "Comments",
                column: "CommentAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ForumEntryCommentForumEntryId",
                table: "Comments",
                column: "ForumEntryCommentForumEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_EntryAuthorId",
                table: "Entries",
                column: "EntryAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumEntries_ForumEntryAuthorId",
                table: "ForumEntries",
                column: "ForumEntryAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumEntries_ForumEntryCategoryForumCategoryId",
                table: "ForumEntries",
                column: "ForumEntryCategoryForumCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_BlogEntryId",
                table: "Tags",
                column: "BlogEntryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "ForumEntries");

            migrationBuilder.DropTable(
                name: "BlogEntries");

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
