using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamProject.Infrustracture.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Header = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    AuthorName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 10000, nullable: false),
                    PostedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsModified = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PostId = table.Column<Guid>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsModified = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    QuestionHeader = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    ExamId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsModified = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Option = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    IsCorrect = table.Column<bool>(type: "INTEGER", nullable: false),
                    QuestionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsModified = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionOptions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorName", "Content", "CreatedDate", "Header", "IsActive", "IsModified", "ModifiedDate", "PostedDate" },
                values: new object[] { new Guid("8f934f31-162d-4676-b5eb-fe49beab544f"), "Matt Simon", "THIS MORNING, THE UN’s Intergovernmental Panel on Climate Change dropped its most contentious report yet. Following previous installments on how humanity’s abuses of the land and the sea are exacerbating climate change, and how things are generally not good (although hope is not altogether lost), this one tackles the thorniest question: how we’re supposed to come together as a species to fix this mess. The assessment, which was authored by hundreds of scientists, makes it clear that humanity has the tools to fight climate change. It just lacks the political will to do it. “The jury has reached the verdict and it is damning,' said António Guterres, the secretary-general of the United Nations, during a Monday press conference announcing the findings, calling the report “a litany of broken climate promises. It is a file of shame cataloging the empty pledges that put us firmly on track toward an unlivable world.' He invoked climate catastrophes—“unprecedented heat waves, terrifying storms, widespread water shortages, the extinction of a million species of plants and animals”—and warned against those who would brush the report aside. “This is not fiction or exaggeration. It is what science tells us will result from our current energy policies,” he said. One of the report’s more sobering conclusions is that we would need to cut emissions by 43 percent by 2030 and keep warming to the Paris Agreement’s goal of 1.5 degrees Celsius.Yet countries’ current climate pledges are setting up an increase in emissions between now and then, the report’s authors conclude.We need emissions to peak by 2025, they write, but without dramatically strengthening mitigation efforts, we’re on track to see an alarming 3.2 degrees Celsius of warming by the end of the century.", new DateTime(2022, 4, 5, 9, 36, 49, 593, DateTimeKind.Local).AddTicks(8274), "Technology Can Fix the Climate Mess—but Not Without Help", true, false, null, new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorName", "Content", "CreatedDate", "Header", "IsActive", "IsModified", "ModifiedDate", "PostedDate" },
                values: new object[] { new Guid("6660f126-5f36-4201-ba84-1611c2c3f4b6"), "BRENDA STOLYAR", "TIRED OF TRACKING your workouts with your iPhone but don't want to drop a ton of cash on a shiny, new smartwatch? Well, you're in luck. The Apple Watch Series 7 (8/10, WIRED Recommends) is on sale for up to $70 off (for both sizes and models, including cellular), which means you can purchase the smartwatch for as low as $329. It frequently dips in price, but this is the cheapest we've tracked so far. If you're planning to purchase it through Amazon,we recommend you don't wait too long—the deal is only valid until April 5", new DateTime(2022, 4, 5, 9, 36, 49, 594, DateTimeKind.Local).AddTicks(6926), "The Apple Watch Series 7 Is at Its Lowest Price Ever", true, false, null, new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorName", "Content", "CreatedDate", "Header", "IsActive", "IsModified", "ModifiedDate", "PostedDate" },
                values: new object[] { new Guid("55b19274-4c92-44da-81fa-aee9092d2a94"), "WILL BEDINGFIELD", "EVEN WHEN FASHION and video games seemed, in the popular imagination at least, polar opposite pursuits, players have always liked to dress up. Now, fashion in games isn’t just grand cosplay festivals or finding a neat mask for Link: it’s tapped into older industries, and no better demonstration of this fact is Roblox, where, for instance, a Gucci bag sold for $4,115, or 350,000 Robux, $800 more than the real thing.In fact Roblox, now played by close to 50 million people each day and the most valuable video game company in the US, is one platform where character customization, and the self - expression it affords, is fundamental to the experience.Now Roblox has created a new system that improves this customization: “layered clothing.” It has the potential to further the company's goals of being more than a game: a place—whisper it, a metaverse—for games.", new DateTime(2022, 4, 5, 9, 36, 49, 594, DateTimeKind.Local).AddTicks(6946), "Roblox’s ‘Layered Clothing’ Is Here—but Don’t Call It an NFT", true, false, null, new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorName", "Content", "CreatedDate", "Header", "IsActive", "IsModified", "ModifiedDate", "PostedDate" },
                values: new object[] { new Guid("5bdffe30-83f5-43aa-a33f-6895869354ac"), "WIRED STAFF", "PERHAPS IT’S SOMETHING in the air, but right now it seems as though half the new books on shelves deal with the climate crisis in some way. The environment is central to at least three of the 15 books on WIRED’s latest recommendations for readers. But that’s just the start. The books on this list also cover language, Blackness, the death of facts, and dolphin handjobs. When we say there’s something here for everyone, we truly mean it. These are our picks for the books we think you should read this spring and summer.", new DateTime(2022, 4, 5, 9, 36, 49, 594, DateTimeKind.Local).AddTicks(6949), "WIRED’s Picks for the 15 Books You Need to Read This Summer", true, false, null, new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorName", "Content", "CreatedDate", "Header", "IsActive", "IsModified", "ModifiedDate", "PostedDate" },
                values: new object[] { new Guid("2ba84daf-59cb-4bfa-b6fe-ebdc6950826b"), "MEGHAN O'GIEBLYN", "I'M KIND OF an anxious, obsessive texter. I never quite know what to say, but the worst is when I see someone typing—in iMessage, in Slack, whatever—and then they stop typing. And ultimately send nothing! What were they going to say? Am I allowed to ask? Surely I'm allowed to ask. Dear Nervous,You're certainly not alone in dreading this quirk of digital communication. The ellipsis, one of the most common indicators that someone is typing, is meant to create a sense of anticipation, recalling the pauses in fictional dialog or the ominous cliffhanger (to be continued …) that begs us to follow the dots, like a breadcrumb trail, to the narrative's conclusion.To watch the symbol disappear without the expected message is to experience the sinking disappointment we associate with paywalled articles and unresolved television seasons—stories without ends—and the absence of resolution can breed paranoia.Perhaps your conversational partner got abruptly distracted in the middle of her text.Perhaps she is obsessively rereading what she just wrote, weighing whether or not to press Send.Perhaps she was about to tell you, finally, what she really thinks of you, but at the last moment reconsidered.The ellipsis is also used in print to signal an omission, and it's this latter usage that comes to mind when the typing stops and no message arrives, leaving you with nothing more than the knowledge that the words signified by those three dots were deemed unworthy of your attention—or worse, you were deemed unworthy of them.", new DateTime(2022, 4, 5, 9, 36, 49, 594, DateTimeKind.Local).AddTicks(6952), "If Someone Is Typing, Then Stops … Can I Ask Why?", true, false, null, new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_PostId",
                table: "Exams",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionOptions_QuestionId",
                table: "QuestionOptions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ExamId",
                table: "Questions",
                column: "ExamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "QuestionOptions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
