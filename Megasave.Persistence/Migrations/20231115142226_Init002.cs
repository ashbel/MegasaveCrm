using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Megasave.Persistence.Migrations
{
    public partial class Init002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.CreateTable(
            //    name: "Activities",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
            //        Activity = table.Column<string>(type: "longtext", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        User = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
            //        ActivityDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
            //        Comment = table.Column<string>(type: "longtext", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
            //        Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
            //        CreatedBy = table.Column<string>(type: "longtext", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        LastModifiedBy = table.Column<string>(type: "longtext", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Activities", x => x.Id);
            //    })
            //    .Annotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.CreateTable(
            //    name: "Alerts",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
            //        SenderId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
            //        ReceiverId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
            //        Message = table.Column<string>(type: "longtext", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
            //        isRead = table.Column<bool>(type: "tinyint(1)", nullable: false),
            //        Title = table.Column<string>(type: "longtext", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        AlertType = table.Column<string>(type: "longtext", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
            //        Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
            //        CreatedBy = table.Column<string>(type: "longtext", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        LastModifiedBy = table.Column<string>(type: "longtext", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Alerts", x => x.Id);
            //    })
            //    .Annotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.CreateTable(
            //    name: "Banks",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
            //        Name = table.Column<string>(type: "longtext", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        Account = table.Column<string>(type: "longtext", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        BranchName = table.Column<string>(type: "longtext", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        Comment = table.Column<string>(type: "longtext", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
            //        Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
            //        CreatedBy = table.Column<string>(type: "longtext", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        LastModifiedBy = table.Column<string>(type: "longtext", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Banks", x => x.Id);
            //    })
            //    .Annotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.CreateTable(
            //    name: "Branches",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
            //        Name = table.Column<string>(type: "longtext", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
            //        Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
            //        CreatedBy = table.Column<string>(type: "longtext", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        LastModifiedBy = table.Column<string>(type: "longtext", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Branches", x => x.Id);
            //    })
            //    .Annotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.CreateTable(
            //    name: "Categories",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
            //        Name = table.Column<string>(type: "longtext", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
            //        Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
            //        CreatedBy = table.Column<string>(type: "longtext", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        LastModifiedBy = table.Column<string>(type: "longtext", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Categories", x => x.Id);
            //    })
            //    .Annotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.CreateTable(
            //    name: "Departments",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
            //        Name = table.Column<string>(type: "longtext", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
            //        Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
            //        CreatedBy = table.Column<string>(type: "longtext", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        LastModifiedBy = table.Column<string>(type: "longtext", nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Departments", x => x.Id);
            //    })
            //    .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EmailSmtp = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailAddress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailPort = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    emailUsername = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    emailPassword = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    emailSsl = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastModifiedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PayTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastModifiedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Contact = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Comment = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastModifiedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CashRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    tblBranchId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    User = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Comment = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastModifiedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashRequests_Branches_tblBranchId",
                        column: x => x.tblBranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Targets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    tblCategoryId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    Comment = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastModifiedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Targets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Targets_Categories_tblCategoryId",
                        column: x => x.tblCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BranchId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PayTypeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DocumentNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastModifiedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Batches_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Batches_PayTypes_PayTypeId",
                        column: x => x.PayTypeId,
                        principalTable: "PayTypes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BatchesHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BatchesId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Action = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastModifiedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchesHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatchesHistory_Batches_BatchesId",
                        column: x => x.BatchesId,
                        principalTable: "Batches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BatchId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastModifiedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    User = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Comment = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tblBatchId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastModifiedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Batches_tblBatchId",
                        column: x => x.tblBatchId,
                        principalTable: "Batches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SupplierId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    BranchId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CategoryId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Balance = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    User = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    tranDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Status = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BatchId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastModifiedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_BranchId",
                table: "Batches",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_PayTypeId",
                table: "Batches",
                column: "PayTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchesHistory_BatchesId",
                table: "BatchesHistory",
                column: "BatchesId");

            migrationBuilder.CreateIndex(
                name: "IX_CashRequests_tblBranchId",
                table: "CashRequests",
                column: "tblBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_BatchId",
                table: "Files",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_tblBatchId",
                table: "Payments",
                column: "tblBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Targets_tblCategoryId",
                table: "Targets",
                column: "tblCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BatchId",
                table: "Transactions",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BranchId",
                table: "Transactions",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryId",
                table: "Transactions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SupplierId",
                table: "Transactions",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "BatchesHistory");

            migrationBuilder.DropTable(
                name: "CashRequests");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Targets");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Batches");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "PayTypes");
        }
    }
}
