using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Billing.Data.Migrations
{
    public partial class Updated_DB_Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OrganizationId",
                table: "billing_bill",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "billing_payment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    BillId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_billing_payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_billing_payment_billing_bill_BillId",
                        column: x => x.BillId,
                        principalTable: "billing_bill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillSpareParts",
                columns: table => new
                {
                    BillsId = table.Column<long>(type: "bigint", nullable: false),
                    SparePartsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillSpareParts", x => new { x.BillsId, x.SparePartsId });
                    table.ForeignKey(
                        name: "FK_BillSpareParts_billing_bill_BillsId",
                        column: x => x.BillsId,
                        principalTable: "billing_bill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillSpareParts_billing_sparepart_SparePartsId",
                        column: x => x.SparePartsId,
                        principalTable: "billing_sparepart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillTax",
                columns: table => new
                {
                    BillsId = table.Column<long>(type: "bigint", nullable: false),
                    TaxsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillTax", x => new { x.BillsId, x.TaxsId });
                    table.ForeignKey(
                        name: "FK_BillTax_billing_bill_BillsId",
                        column: x => x.BillsId,
                        principalTable: "billing_bill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillTax_billing_tax_TaxsId",
                        column: x => x.TaxsId,
                        principalTable: "billing_tax",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuotationSpareParts",
                columns: table => new
                {
                    QuotationsId = table.Column<long>(type: "bigint", nullable: false),
                    SparePartsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationSpareParts", x => new { x.QuotationsId, x.SparePartsId });
                    table.ForeignKey(
                        name: "FK_QuotationSpareParts_billing_quotation_QuotationsId",
                        column: x => x.QuotationsId,
                        principalTable: "billing_quotation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuotationSpareParts_billing_sparepart_SparePartsId",
                        column: x => x.SparePartsId,
                        principalTable: "billing_sparepart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuotationTax",
                columns: table => new
                {
                    QuotationsId = table.Column<long>(type: "bigint", nullable: false),
                    TaxsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationTax", x => new { x.QuotationsId, x.TaxsId });
                    table.ForeignKey(
                        name: "FK_QuotationTax_billing_quotation_QuotationsId",
                        column: x => x.QuotationsId,
                        principalTable: "billing_quotation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuotationTax_billing_tax_TaxsId",
                        column: x => x.TaxsId,
                        principalTable: "billing_tax",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_billing_bill_OrganizationId",
                table: "billing_bill",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_billing_payment_BillId",
                table: "billing_payment",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillSpareParts_SparePartsId",
                table: "BillSpareParts",
                column: "SparePartsId");

            migrationBuilder.CreateIndex(
                name: "IX_BillTax_TaxsId",
                table: "BillTax",
                column: "TaxsId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationSpareParts_SparePartsId",
                table: "QuotationSpareParts",
                column: "SparePartsId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationTax_TaxsId",
                table: "QuotationTax",
                column: "TaxsId");

            migrationBuilder.AddForeignKey(
                name: "FK_billing_bill_billing_organization_OrganizationId",
                table: "billing_bill",
                column: "OrganizationId",
                principalTable: "billing_organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_billing_bill_billing_organization_OrganizationId",
                table: "billing_bill");

            migrationBuilder.DropTable(
                name: "billing_payment");

            migrationBuilder.DropTable(
                name: "BillSpareParts");

            migrationBuilder.DropTable(
                name: "BillTax");

            migrationBuilder.DropTable(
                name: "QuotationSpareParts");

            migrationBuilder.DropTable(
                name: "QuotationTax");

            migrationBuilder.DropIndex(
                name: "IX_billing_bill_OrganizationId",
                table: "billing_bill");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "billing_bill");
        }
    }
}
