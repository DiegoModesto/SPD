using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SPD.Api.Authentication.Migrations
{
    public partial class InitialCatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FullfilmentComplete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolesClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolesClaim_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UsersLogin_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UsersRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersToken",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UsersToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("af1fc231-ac96-432f-bf08-1f0d267d067e"), "3b836cff-28b2-4c06-99b9-b1a08a4d4879", "Owner", "Owner" },
                    { new Guid("500d9387-7e1c-4652-9317-381fc350afb9"), "e16e8bb2-ebeb-409d-8be9-9e544334dcd0", "Administrator", "Administrator" },
                    { new Guid("a9f0bccc-bb0b-49cc-8d48-3ae5fa775113"), "137a7edf-529a-4226-8d27-33974fd485ef", "Manager", "Manager" },
                    { new Guid("c733461c-736c-4df6-8d8c-a5ce67978414"), "5c340b38-9c55-42d2-a902-cb18c0d228b8", "Editor", "Editor" },
                    { new Guid("06333882-6970-4f7b-bfcd-8b3858588b17"), "3b447ed0-47aa-4fcc-9b01-182a26e025e2", "Buyer", "Buyer" },
                    { new Guid("86298c9d-11f1-4c7d-b7a7-5adbf3a904cc"), "cdc716ff-b1b7-4291-817d-bf626829a1c5", "Business", "Business" },
                    { new Guid("0f7af0a8-0ffa-4138-8089-535ec9f252f3"), "096795f4-1d8d-4c7c-8b3a-f7c1d8357bd3", "Seller", "Seller" },
                    { new Guid("621259df-1421-4948-a367-9abafbf0b114"), "3552be63-1e06-47d8-9fc1-46f3cde56eef", "Subscriber", "Subscriber" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "FullfilmentComplete", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("8a1e1d77-c92e-4750-aba7-dd4c17851179"), 0, "14729aab-5009-4f17-ae5e-ce280b9b6f25", "diego.modesto@company.com", false, "Diego", false, "Modesto", true, null, "DIEGO.MODESTO@COMPANY.COM", "DIEGO.MODESTO", "AQAAAAEAACcQAAAAEFJYX3v7QDVR3s30dR9szO174kWhYWWiYH6WODdrrr7rOXr4CYSJqLnLke5Vj04hxw==", null, false, "53698001-b21d-4442-91bb-0ab846f3cd02", false, "diego.modesto" },
                    { new Guid("f1d3ec4c-337a-4f74-86a7-28fe0b311a32"), 0, "7f4ba486-b20f-4c53-899b-761b5dda821d", "samuel.souza@company.com", false, "Samuel", false, "Souza", true, null, "SAMUEL.SOUZA@COMPANY.COM", "SAMUEL.SOUZA", "AQAAAAEAACcQAAAAEHq9oAZn9fLM4ToNr0pElxlEYzca5KWJS5jQFJZAG7vkBbRak4Iy8HJ9Gae6Zx2ZOQ==", null, false, "2163f504-d5da-446c-a416-4f8060968fc7", false, "samuel.souza" },
                    { new Guid("4bbd9499-52fd-4781-9082-b4285adfcce7"), 0, "64c31317-c895-4a74-ae30-ace019d4a428", "user.buyer@company.com", false, "User", false, "Buyer", true, null, "USER.BUYER@COMPANY.COM", "USER.BUYER", "AQAAAAEAACcQAAAAEBmCF1onfADv8p+Z3bTNTGT5XOAKyedHCkY5hKccCh6mrNj4W5iHsre8zwNFx+icOg==", null, false, "df3f0796-0555-4bfd-bdf2-a8f41b33585b", false, "user.buyer" },
                    { new Guid("26c1dc42-2936-4fd9-9043-457c4915adc5"), 0, "6f33e624-7c74-4da5-bee9-1b540d392b33", "user.Seller@company.com", false, "User", false, "Seller", true, null, "USER.SELLER@COMPANY.COM", "USER.SELLER", "AQAAAAEAACcQAAAAEFLaqpxypJz5hKZGImXeJRfx8ZUSjSC3b4ph6HShK+hpCeBtx9re75WH1NAGv1h/6w==", null, false, "6cd8d627-829c-4aad-8e34-f086e02a0c5f", false, "user.seller" }
                });

            migrationBuilder.InsertData(
                table: "UsersRole",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("8a1e1d77-c92e-4750-aba7-dd4c17851179"), new Guid("af1fc231-ac96-432f-bf08-1f0d267d067e") },
                    { new Guid("f1d3ec4c-337a-4f74-86a7-28fe0b311a32"), new Guid("500d9387-7e1c-4652-9317-381fc350afb9") },
                    { new Guid("4bbd9499-52fd-4781-9082-b4285adfcce7"), new Guid("06333882-6970-4f7b-bfcd-8b3858588b17") },
                    { new Guid("26c1dc42-2936-4fd9-9043-457c4915adc5"), new Guid("0f7af0a8-0ffa-4138-8089-535ec9f252f3") }
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolesClaim_RoleId",
                table: "RolesClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersLogin_UserId",
                table: "UsersLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRole_RoleId",
                table: "UsersRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolesClaim");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UsersLogin");

            migrationBuilder.DropTable(
                name: "UsersRole");

            migrationBuilder.DropTable(
                name: "UsersToken");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
