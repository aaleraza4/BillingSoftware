using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Billing.Data.Migrations
{
    public partial class RepairingWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Rate",
                table: "billing_bill_sparepart",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "billing_Repairing",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_billing_Repairing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "billing_bill_QuotationRepairing",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepairingId = table.Column<long>(type: "bigint", nullable: false),
                    Rate = table.Column<long>(type: "bigint", nullable: false),
                    QuotationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_billing_bill_QuotationRepairing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_billing_bill_QuotationRepairing_billing_quotation_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "billing_quotation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_billing_bill_QuotationRepairing_billing_Repairing_RepairingId",
                        column: x => x.RepairingId,
                        principalTable: "billing_Repairing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_billing_bill_QuotationRepairing_QuotationId",
                table: "billing_bill_QuotationRepairing",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_billing_bill_QuotationRepairing_RepairingId",
                table: "billing_bill_QuotationRepairing",
                column: "RepairingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "billing_bill_QuotationRepairing");

            migrationBuilder.DropTable(
                name: "billing_Repairing");

            migrationBuilder.AlterColumn<int>(
                name: "Rate",
                table: "billing_bill_sparepart",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
