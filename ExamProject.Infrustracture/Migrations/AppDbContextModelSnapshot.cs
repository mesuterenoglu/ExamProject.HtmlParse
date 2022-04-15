﻿// <auto-generated />
using System;
using ExamProject.Infrustracture.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExamProject.Infrustracture.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("ExamProject.Domain.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ExamProject.Domain.Entities.Exam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsModified")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("ExamProject.Domain.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsModified")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PostedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8f934f31-162d-4676-b5eb-fe49beab544f"),
                            AuthorName = "Matt Simon",
                            Content = "THIS MORNING, THE UN’s Intergovernmental Panel on Climate Change dropped its most contentious report yet. Following previous installments on how humanity’s abuses of the land and the sea are exacerbating climate change, and how things are generally not good (although hope is not altogether lost), this one tackles the thorniest question: how we’re supposed to come together as a species to fix this mess. The assessment, which was authored by hundreds of scientists, makes it clear that humanity has the tools to fight climate change. It just lacks the political will to do it. “The jury has reached the verdict and it is damning,' said António Guterres, the secretary-general of the United Nations, during a Monday press conference announcing the findings, calling the report “a litany of broken climate promises. It is a file of shame cataloging the empty pledges that put us firmly on track toward an unlivable world.' He invoked climate catastrophes—“unprecedented heat waves, terrifying storms, widespread water shortages, the extinction of a million species of plants and animals”—and warned against those who would brush the report aside. “This is not fiction or exaggeration. It is what science tells us will result from our current energy policies,” he said. One of the report’s more sobering conclusions is that we would need to cut emissions by 43 percent by 2030 and keep warming to the Paris Agreement’s goal of 1.5 degrees Celsius.Yet countries’ current climate pledges are setting up an increase in emissions between now and then, the report’s authors conclude.We need emissions to peak by 2025, they write, but without dramatically strengthening mitigation efforts, we’re on track to see an alarming 3.2 degrees Celsius of warming by the end of the century.",
                            CreatedDate = new DateTime(2022, 4, 5, 9, 36, 49, 593, DateTimeKind.Local).AddTicks(8274),
                            Header = "Technology Can Fix the Climate Mess—but Not Without Help",
                            IsActive = true,
                            IsModified = false,
                            PostedDate = new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("6660f126-5f36-4201-ba84-1611c2c3f4b6"),
                            AuthorName = "BRENDA STOLYAR",
                            Content = "TIRED OF TRACKING your workouts with your iPhone but don't want to drop a ton of cash on a shiny, new smartwatch? Well, you're in luck. The Apple Watch Series 7 (8/10, WIRED Recommends) is on sale for up to $70 off (for both sizes and models, including cellular), which means you can purchase the smartwatch for as low as $329. It frequently dips in price, but this is the cheapest we've tracked so far. If you're planning to purchase it through Amazon,we recommend you don't wait too long—the deal is only valid until April 5",
                            CreatedDate = new DateTime(2022, 4, 5, 9, 36, 49, 594, DateTimeKind.Local).AddTicks(6926),
                            Header = "The Apple Watch Series 7 Is at Its Lowest Price Ever",
                            IsActive = true,
                            IsModified = false,
                            PostedDate = new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("55b19274-4c92-44da-81fa-aee9092d2a94"),
                            AuthorName = "WILL BEDINGFIELD",
                            Content = "EVEN WHEN FASHION and video games seemed, in the popular imagination at least, polar opposite pursuits, players have always liked to dress up. Now, fashion in games isn’t just grand cosplay festivals or finding a neat mask for Link: it’s tapped into older industries, and no better demonstration of this fact is Roblox, where, for instance, a Gucci bag sold for $4,115, or 350,000 Robux, $800 more than the real thing.In fact Roblox, now played by close to 50 million people each day and the most valuable video game company in the US, is one platform where character customization, and the self - expression it affords, is fundamental to the experience.Now Roblox has created a new system that improves this customization: “layered clothing.” It has the potential to further the company's goals of being more than a game: a place—whisper it, a metaverse—for games.",
                            CreatedDate = new DateTime(2022, 4, 5, 9, 36, 49, 594, DateTimeKind.Local).AddTicks(6946),
                            Header = "Roblox’s ‘Layered Clothing’ Is Here—but Don’t Call It an NFT",
                            IsActive = true,
                            IsModified = false,
                            PostedDate = new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("5bdffe30-83f5-43aa-a33f-6895869354ac"),
                            AuthorName = "WIRED STAFF",
                            Content = "PERHAPS IT’S SOMETHING in the air, but right now it seems as though half the new books on shelves deal with the climate crisis in some way. The environment is central to at least three of the 15 books on WIRED’s latest recommendations for readers. But that’s just the start. The books on this list also cover language, Blackness, the death of facts, and dolphin handjobs. When we say there’s something here for everyone, we truly mean it. These are our picks for the books we think you should read this spring and summer.",
                            CreatedDate = new DateTime(2022, 4, 5, 9, 36, 49, 594, DateTimeKind.Local).AddTicks(6949),
                            Header = "WIRED’s Picks for the 15 Books You Need to Read This Summer",
                            IsActive = true,
                            IsModified = false,
                            PostedDate = new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("2ba84daf-59cb-4bfa-b6fe-ebdc6950826b"),
                            AuthorName = "MEGHAN O'GIEBLYN",
                            Content = "I'M KIND OF an anxious, obsessive texter. I never quite know what to say, but the worst is when I see someone typing—in iMessage, in Slack, whatever—and then they stop typing. And ultimately send nothing! What were they going to say? Am I allowed to ask? Surely I'm allowed to ask. Dear Nervous,You're certainly not alone in dreading this quirk of digital communication. The ellipsis, one of the most common indicators that someone is typing, is meant to create a sense of anticipation, recalling the pauses in fictional dialog or the ominous cliffhanger (to be continued …) that begs us to follow the dots, like a breadcrumb trail, to the narrative's conclusion.To watch the symbol disappear without the expected message is to experience the sinking disappointment we associate with paywalled articles and unresolved television seasons—stories without ends—and the absence of resolution can breed paranoia.Perhaps your conversational partner got abruptly distracted in the middle of her text.Perhaps she is obsessively rereading what she just wrote, weighing whether or not to press Send.Perhaps she was about to tell you, finally, what she really thinks of you, but at the last moment reconsidered.The ellipsis is also used in print to signal an omission, and it's this latter usage that comes to mind when the typing stops and no message arrives, leaving you with nothing more than the knowledge that the words signified by those three dots were deemed unworthy of your attention—or worse, you were deemed unworthy of them.",
                            CreatedDate = new DateTime(2022, 4, 5, 9, 36, 49, 594, DateTimeKind.Local).AddTicks(6952),
                            Header = "If Someone Is Typing, Then Stops … Can I Ask Why?",
                            IsActive = true,
                            IsModified = false,
                            PostedDate = new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ExamProject.Domain.Entities.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ExamId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsModified")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("QuestionHeader")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("ExamProject.Domain.Entities.QuestionOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsModified")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Option")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("QuestionId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionOptions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ExamProject.Domain.Entities.Exam", b =>
                {
                    b.HasOne("ExamProject.Domain.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("ExamProject.Domain.Entities.Question", b =>
                {
                    b.HasOne("ExamProject.Domain.Entities.Exam", "Exam")
                        .WithMany("Questions")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("ExamProject.Domain.Entities.QuestionOption", b =>
                {
                    b.HasOne("ExamProject.Domain.Entities.Question", null)
                        .WithMany("Options")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("ExamProject.Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("ExamProject.Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamProject.Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("ExamProject.Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ExamProject.Domain.Entities.Exam", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("ExamProject.Domain.Entities.Question", b =>
                {
                    b.Navigation("Options");
                });
#pragma warning restore 612, 618
        }
    }
}
