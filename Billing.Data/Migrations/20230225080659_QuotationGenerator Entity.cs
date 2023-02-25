using Microsoft.EntityFrameworkCore.Migrations;

namespace Billing.Data.Migrations
{
    public partial class QuotationGeneratorEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_billing_bill_billing_tax_TaxId",
                table: "billing_bill");

            migrationBuilder.DropForeignKey(
                name: "FK_billing_quotation_billing_tax_TaxId",
                table: "billing_quotation");

            migrationBuilder.DropIndex(
                name: "IX_billing_quotation_TaxId",
                table: "billing_quotation");

            migrationBuilder.DropIndex(
                name: "IX_billing_bill_TaxId",
                table: "billing_bill");

            migrationBuilder.DropColumn(
                name: "TaxId",
                table: "billing_quotation");

            migrationBuilder.DropColumn(
                name: "TaxId",
                table: "billing_bill");

            migrationBuilder.CreateTable(
                name: "billing_QuotationGenerator",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncrQuotationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_billing_QuotationGenerator", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "billing_QuotationGenerator");

            migrationBuilder.AddColumn<long>(
                name: "TaxId",
                table: "billing_quotation",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TaxId",
                table: "billing_bill",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_billing_quotation_TaxId",
                table: "billing_quotation",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_billing_bill_TaxId",
                table: "billing_bill",
                column: "TaxId");

            migrationBuilder.AddForeignKey(
                name: "FK_billing_bill_billing_tax_TaxId",
                table: "billing_bill",
                column: "TaxId",
                principalTable: "billing_tax",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_billing_quotation_billing_tax_TaxId",
                table: "billing_quotation",
                column: "TaxId",
                principalTable: "billing_tax",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
