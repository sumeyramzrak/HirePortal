using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hireportal.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Profile");

            migrationBuilder.EnsureSchema(
                name: "Activites");

            migrationBuilder.EnsureSchema(
                name: "Main");

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "Profile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CompanyDescription = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    MembershipPlan = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    MembershipStartDate = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    MembershipEndDate = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    SupportEmail = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookUpTypes",
                schema: "Main",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemParameters",
                schema: "Main",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemParameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Profile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    VerificationId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookUps",
                schema: "Main",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LookUps_LookUps_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Main",
                        principalTable: "LookUps",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LookUps_LookUpTypes_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "Main",
                        principalTable: "LookUpTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyUsers",
                schema: "Profile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyUsers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Profile",
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyUsers_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Profile",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Debits",
                schema: "Activites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyUserId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 32, nullable: false),
                    LookUpTypeId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 32, nullable: false),
                    DebitName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    InformationNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debits_CompanyUsers_CompanyUserId",
                        column: x => x.CompanyUserId,
                        principalSchema: "Profile",
                        principalTable: "CompanyUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Debits_LookUpTypes_LookUpTypeId",
                        column: x => x.LookUpTypeId,
                        principalSchema: "Main",
                        principalTable: "LookUpTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenditures",
                schema: "Activites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyUserId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 32, nullable: false),
                    LookUpTypeId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 32, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ManagerID = table.Column<Guid>(type: "uniqueidentifier", maxLength: 32, nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenditures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenditures_CompanyUsers_CompanyUserId",
                        column: x => x.CompanyUserId,
                        principalSchema: "Profile",
                        principalTable: "CompanyUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenditures_LookUpTypes_LookUpTypeId",
                        column: x => x.LookUpTypeId,
                        principalSchema: "Main",
                        principalTable: "LookUpTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payrolls",
                schema: "Activites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Period = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CompanyUserId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 32, nullable: false),
                    LookUpTypeId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 32, nullable: false),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bounty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payrolls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payrolls_CompanyUsers_CompanyUserId",
                        column: x => x.CompanyUserId,
                        principalSchema: "Profile",
                        principalTable: "CompanyUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payrolls_LookUpTypes_LookUpTypeId",
                        column: x => x.LookUpTypeId,
                        principalSchema: "Main",
                        principalTable: "LookUpTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                schema: "Activites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyUserId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 32, nullable: false),
                    LookUpId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 32, nullable: false),
                    LookUpTypeId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 32, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PermissionDayCount = table.Column<double>(type: "float", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedManagerID = table.Column<Guid>(type: "uniqueidentifier", maxLength: 32, nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_CompanyUsers_CompanyUserId",
                        column: x => x.CompanyUserId,
                        principalSchema: "Profile",
                        principalTable: "CompanyUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissions_LookUps_LookUpId",
                        column: x => x.LookUpId,
                        principalSchema: "Main",
                        principalTable: "LookUps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissions_LookUpTypes_LookUpTypeId",
                        column: x => x.LookUpTypeId,
                        principalSchema: "Main",
                        principalTable: "LookUpTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                schema: "Activites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyUserId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 32, nullable: false),
                    LookUpTypeId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 32, nullable: false),
                    ShiftDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalHour = table.Column<int>(type: "int", nullable: false),
                    Break1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LunchBreak = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Break2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalBreak = table.Column<int>(type: "int", nullable: false),
                    TotalWorkHour = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shifts_CompanyUsers_CompanyUserId",
                        column: x => x.CompanyUserId,
                        principalSchema: "Profile",
                        principalTable: "CompanyUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shifts_LookUpTypes_LookUpTypeId",
                        column: x => x.LookUpTypeId,
                        principalSchema: "Main",
                        principalTable: "LookUpTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_CompanyId",
                schema: "Profile",
                table: "CompanyUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_UserId",
                schema: "Profile",
                table: "CompanyUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Debits_CompanyUserId",
                schema: "Activites",
                table: "Debits",
                column: "CompanyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Debits_LookUpTypeId",
                schema: "Activites",
                table: "Debits",
                column: "LookUpTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_CompanyUserId",
                schema: "Activites",
                table: "Expenditures",
                column: "CompanyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_LookUpTypeId",
                schema: "Activites",
                table: "Expenditures",
                column: "LookUpTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUps_ParentId",
                schema: "Main",
                table: "LookUps",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUps_TypeId",
                schema: "Main",
                table: "LookUps",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_CompanyUserId",
                schema: "Activites",
                table: "Payrolls",
                column: "CompanyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_LookUpTypeId",
                schema: "Activites",
                table: "Payrolls",
                column: "LookUpTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_CompanyUserId",
                schema: "Activites",
                table: "Permissions",
                column: "CompanyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_LookUpId",
                schema: "Activites",
                table: "Permissions",
                column: "LookUpId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_LookUpTypeId",
                schema: "Activites",
                table: "Permissions",
                column: "LookUpTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_CompanyUserId",
                schema: "Activites",
                table: "Shifts",
                column: "CompanyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_LookUpTypeId",
                schema: "Activites",
                table: "Shifts",
                column: "LookUpTypeId");
            migrationBuilder.MigrateUsers();
            migrationBuilder.MigrateLookups();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Debits",
                schema: "Activites");

            migrationBuilder.DropTable(
                name: "Expenditures",
                schema: "Activites");

            migrationBuilder.DropTable(
                name: "Payrolls",
                schema: "Activites");

            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "Activites");

            migrationBuilder.DropTable(
                name: "Shifts",
                schema: "Activites");

            migrationBuilder.DropTable(
                name: "SystemParameters",
                schema: "Main");

            migrationBuilder.DropTable(
                name: "LookUps",
                schema: "Main");

            migrationBuilder.DropTable(
                name: "CompanyUsers",
                schema: "Profile");

            migrationBuilder.DropTable(
                name: "LookUpTypes",
                schema: "Main");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "Profile");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Profile");
        }
    }
}
