using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DnD_Deutschland.Data;

namespace DnD_Deutschland.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170528152128_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DnD_Deutschland.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Alias");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DnD_Deutschland.Models.Comment", b =>
                {
                    b.Property<Guid>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BlogEntryCommentEntryId");

                    b.Property<string>("CommentAuthorId");

                    b.Property<string>("CommentContent")
                        .IsRequired();

                    b.Property<DateTime>("CommentDate");

                    b.Property<Guid?>("CommentEntryCommentCommentId");

                    b.Property<Guid?>("ForumEntryCommentEntryId");

                    b.HasKey("CommentId");

                    b.HasIndex("BlogEntryCommentEntryId");

                    b.HasIndex("CommentAuthorId");

                    b.HasIndex("CommentEntryCommentCommentId");

                    b.HasIndex("ForumEntryCommentEntryId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("DnD_Deutschland.Models.Entry", b =>
                {
                    b.Property<Guid>("EntryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("EntryAuthorId");

                    b.Property<string>("EntryContent")
                        .IsRequired();

                    b.Property<DateTime>("EntryDate");

                    b.Property<string>("EntryTitle")
                        .IsRequired();

                    b.HasKey("EntryId");

                    b.HasIndex("EntryAuthorId");

                    b.ToTable("Entries");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Entry");
                });

            modelBuilder.Entity("DnD_Deutschland.Models.ForumCategory", b =>
                {
                    b.Property<Guid>("ForumCategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ForumCategoryDescription");

                    b.Property<string>("ForumCategoryName");

                    b.HasKey("ForumCategoryId");

                    b.ToTable("ForumCategories");
                });

            modelBuilder.Entity("DnD_Deutschland.Models.Tag", b =>
                {
                    b.Property<Guid>("TagId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BlogEntryEntryId");

                    b.Property<string>("TagKeyword");

                    b.HasKey("TagId");

                    b.HasIndex("BlogEntryEntryId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DnD_Deutschland.Models.BlogEntry", b =>
                {
                    b.HasBaseType("DnD_Deutschland.Models.Entry");


                    b.ToTable("BlogEntry");

                    b.HasDiscriminator().HasValue("BlogEntry");
                });

            modelBuilder.Entity("DnD_Deutschland.Models.ForumEntry", b =>
                {
                    b.HasBaseType("DnD_Deutschland.Models.Entry");

                    b.Property<Guid>("ForumEntryCategoryForumCategoryId");

                    b.HasIndex("ForumEntryCategoryForumCategoryId");

                    b.ToTable("ForumEntry");

                    b.HasDiscriminator().HasValue("ForumEntry");
                });

            modelBuilder.Entity("DnD_Deutschland.Models.Comment", b =>
                {
                    b.HasOne("DnD_Deutschland.Models.BlogEntry", "BlogEntryComment")
                        .WithMany()
                        .HasForeignKey("BlogEntryCommentEntryId");

                    b.HasOne("DnD_Deutschland.Models.ApplicationUser", "CommentAuthor")
                        .WithMany()
                        .HasForeignKey("CommentAuthorId");

                    b.HasOne("DnD_Deutschland.Models.Comment", "CommentEntryComment")
                        .WithMany()
                        .HasForeignKey("CommentEntryCommentCommentId");

                    b.HasOne("DnD_Deutschland.Models.ForumEntry", "ForumEntryComment")
                        .WithMany()
                        .HasForeignKey("ForumEntryCommentEntryId");
                });

            modelBuilder.Entity("DnD_Deutschland.Models.Entry", b =>
                {
                    b.HasOne("DnD_Deutschland.Models.ApplicationUser", "EntryAuthor")
                        .WithMany()
                        .HasForeignKey("EntryAuthorId");
                });

            modelBuilder.Entity("DnD_Deutschland.Models.Tag", b =>
                {
                    b.HasOne("DnD_Deutschland.Models.BlogEntry")
                        .WithMany("BlogEntryTags")
                        .HasForeignKey("BlogEntryEntryId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DnD_Deutschland.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DnD_Deutschland.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DnD_Deutschland.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DnD_Deutschland.Models.ForumEntry", b =>
                {
                    b.HasOne("DnD_Deutschland.Models.ForumCategory", "ForumEntryCategory")
                        .WithMany()
                        .HasForeignKey("ForumEntryCategoryForumCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
