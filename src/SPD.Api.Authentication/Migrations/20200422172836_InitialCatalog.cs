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
                    { new Guid("94ebd846-586a-4d4a-877c-7b7439032d59"), "1ddaed2a-69fc-4cde-95b6-4a0a57c00eaf", "Owner", "Owner" },
                    { new Guid("94ce009f-8e1b-4ac2-8a68-a3c358617529"), "a2173766-3f8d-48fd-b24d-5371c79ba70a", "Administrator", "Administrator" },
                    { new Guid("99cc1d0e-ffa3-47c4-be06-5cd6e8a3ba9b"), "2b5d93c9-229e-4bea-adbb-f558270f6f28", "Manager", "Manager" },
                    { new Guid("ba23acff-786a-4fb1-bd86-a78220d30b10"), "831131ca-1ccc-476b-87e2-cf478d167e0c", "Editor", "Editor" },
                    { new Guid("8693637e-16ab-4f8d-9cbf-2e53981b35ab"), "934cdbb6-cd4b-4089-9c47-80274e072d21", "Buyer", "Buyer" },
                    { new Guid("74b4c15c-8f37-4499-bdf1-b06dede91508"), "fccf3f4e-367a-4fd0-accb-117ab827e576", "Business", "Business" },
                    { new Guid("1710308e-509d-40ae-a0d6-3f4feccba1b0"), "5b76f3e0-0618-4748-866f-b5f468431cc2", "Seller", "Seller" },
                    { new Guid("b69a3a7c-0e3d-46b6-90c2-d33f0132b684"), "f49bb0ec-ed89-461f-80da-5a89a2a31762", "Subscriber", "Subscriber" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "FullfilmentComplete", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("330180fa-48d7-4a63-a6f2-d94a68d003f4"), 0, "5404e1e8-5622-4e6c-9c44-607d064b12d8", "diego.modesto@company.com", false, "Diego", false, "Modesto", false, null, null, null, "AQAAAAEAACcQAAAAEBpaNBWctUDCszBxTLIr35uZ3rziQ1iqdwHr9EvKw3t5sjUwyshFo0pg3fanhfWujQ==", null, false, null, false, "diego.modesto" },
                    { new Guid("3dcc7d9a-2982-4be5-9d31-fc2c54fa512b"), 0, "6198f0cd-9f02-4d81-85b9-4453e1f7123b", "samuel.souza@company.com", false, "Samuel", false, "Souza", false, null, null, null, "AQAAAAEAACcQAAAAELL6J7F17EXVxH6Dlf5VHfvPU3t8Aaw7IXci99QgYnBFFjpLB2BAhUeCPspgm4Px1g==", null, false, null, false, "samuel.souza" },
                    { new Guid("95ae70c7-43b9-4880-8c16-e555d5f04577"), 0, "01949a8a-0149-478a-b15a-4e7b7a2b754b", "user.buyer@company.com", false, "User", false, "Buyer", false, null, null, null, "AQAAAAEAACcQAAAAEDRA6FKS7OVVEzLZuo9sVG40JprHS3uK84cMAd6yZb5+7uvzcH4ixYORkBmSYjWpPg==", null, false, null, false, "user.buyer" },
                    { new Guid("444d83ca-4f89-4263-9e29-175df2d3dfe6"), 0, "2b0530fd-12d9-4a78-8888-a3796f9eadfb", "user.Seller@company.com", false, "User", false, "Seller", false, null, null, null, "AQAAAAEAACcQAAAAEDv2g/XfOGQPk9SRP/kVYf7M4prTUSe9ibi2LCMOzsZt7RCIteGNAS08nmgzvWJUiw==", null, false, null, false, "user.seller" }
                });

            migrationBuilder.InsertData(
                table: "UsersRole",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("330180fa-48d7-4a63-a6f2-d94a68d003f4"), new Guid("94ebd846-586a-4d4a-877c-7b7439032d59") },
                    { new Guid("3dcc7d9a-2982-4be5-9d31-fc2c54fa512b"), new Guid("94ce009f-8e1b-4ac2-8a68-a3c358617529") },
                    { new Guid("95ae70c7-43b9-4880-8c16-e555d5f04577"), new Guid("8693637e-16ab-4f8d-9cbf-2e53981b35ab") },
                    { new Guid("444d83ca-4f89-4263-9e29-175df2d3dfe6"), new Guid("1710308e-509d-40ae-a0d6-3f4feccba1b0") }
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
