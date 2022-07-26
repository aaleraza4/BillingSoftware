using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Billing.Data.Migrations
{
    public partial class stabledatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_billing_bill_QuotationRepairing_billing_quotation_QuotationId",
                table: "billing_bill_QuotationRepairing");

            migrationBuilder.DropForeignKey(
                name: "FK_billing_bill_QuotationRepairing_billing_Repairing_RepairingId",
                table: "billing_bill_QuotationRepairing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_billing_bill_QuotationRepairing",
                table: "billing_bill_QuotationRepairing");

            migrationBuilder.DropColumn(
                name: "LaborAmount",
                table: "billing_quotation");

            migrationBuilder.DropColumn(
                name: "RepairAmount",
                table: "billing_quotation");

            migrationBuilder.RenameTable(
                name: "billing_bill_QuotationRepairing",
                newName: "billing_quotation_QuotationRepairing");

            migrationBuilder.RenameIndex(
                name: "IX_billing_bill_QuotationRepairing_RepairingId",
                table: "billing_quotation_QuotationRepairing",
                newName: "IX_billing_quotation_QuotationRepairing_RepairingId");

            migrationBuilder.RenameIndex(
                name: "IX_billing_bill_QuotationRepairing_QuotationId",
                table: "billing_quotation_QuotationRepairing",
                newName: "IX_billing_quotation_QuotationRepairing_QuotationId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "billing_quotation_sparepart",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount",
                table: "billing_quotation_sparepart",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TaxApplied",
                table: "billing_quotation_sparepart",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxPercent",
                table: "billing_quotation_sparepart",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InvoiceDate",
                table: "billing_quotation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "OrganizationTypeId",
                table: "billing_quotation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkTypeId",
                table: "billing_quotation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "billing_quotation_QuotationRepairing",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount",
                table: "billing_quotation_QuotationRepairing",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TaxApplied",
                table: "billing_quotation_QuotationRepairing",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxPercent",
                table: "billing_quotation_QuotationRepairing",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_billing_quotation_QuotationRepairing",
                table: "billing_quotation_QuotationRepairing",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_billing_quotation_QuotationRepairing_billing_quotation_QuotationId",
                table: "billing_quotation_QuotationRepairing",
                column: "QuotationId",
                principalTable: "billing_quotation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_billing_quotation_QuotationRepairing_billing_Repairing_RepairingId",
                table: "billing_quotation_QuotationRepairing",
                column: "RepairingId",
                principalTable: "billing_Repairing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_billing_quotation_QuotationRepairing_billing_quotation_QuotationId",
                table: "billing_quotation_QuotationRepairing");

            migrationBuilder.DropForeignKey(
                name: "FK_billing_quotation_QuotationRepairing_billing_Repairing_RepairingId",
                table: "billing_quotation_QuotationRepairing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_billing_quotation_QuotationRepairing",
                table: "billing_quotation_QuotationRepairing");

            migrationBuilder.DropColumn(
                name: "TaxAmount",
                table: "billing_quotation_sparepart");

            migrationBuilder.DropColumn(
                name: "TaxApplied",
                table: "billing_quotation_sparepart");

            migrationBuilder.DropColumn(
                name: "TaxPercent",
                table: "billing_quotation_sparepart");

            migrationBuilder.DropColumn(
                name: "InvoiceDate",
                table: "billing_quotation");

            migrationBuilder.DropColumn(
                name: "OrganizationTypeId",
                table: "billing_quotation");

            migrationBuilder.DropColumn(
                name: "WorkTypeId",
                table: "billing_quotation");

            migrationBuilder.DropColumn(
                name: "TaxAmount",
                table: "billing_quotation_QuotationRepairing");

            migrationBuilder.DropColumn(
                name: "TaxApplied",
                table: "billing_quotation_QuotationRepairing");

            migrationBuilder.DropColumn(
                name: "TaxPercent",
                table: "billing_quotation_QuotationRepairing");

            migrationBuilder.RenameTable(
                name: "billing_quotation_QuotationRepairing",
                newName: "billing_bill_QuotationRepairing");

            migrationBuilder.RenameIndex(
                name: "IX_billing_quotation_QuotationRepairing_RepairingId",
                table: "billing_bill_QuotationRepairing",
                newName: "IX_billing_bill_QuotationRepairing_RepairingId");

            migrationBuilder.RenameIndex(
                name: "IX_billing_quotation_QuotationRepairing_QuotationId",
                table: "billing_bill_QuotationRepairing",
                newName: "IX_billing_bill_QuotationRepairing_QuotationId");

            migrationBuilder.AlterColumn<int>(
                name: "Rate",
                table: "billing_quotation_sparepart",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "LaborAmount",
                table: "billing_quotation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RepairAmount",
                table: "billing_quotation",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Rate",
                table: "billing_bill_QuotationRepairing",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_billing_bill_QuotationRepairing",
                table: "billing_bill_QuotationRepairing",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_billing_bill_QuotationRepairing_billing_quotation_QuotationId",
                table: "billing_bill_QuotationRepairing",
                column: "QuotationId",
                principalTable: "billing_quotation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_billing_bill_QuotationRepairing_billing_Repairing_RepairingId",
                table: "billing_bill_QuotationRepairing",
                column: "RepairingId",
                principalTable: "billing_Repairing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
