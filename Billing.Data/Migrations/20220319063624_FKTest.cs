using Microsoft.EntityFrameworkCore.Migrations;

namespace Billing.Data.Migrations
{
    public partial class FKTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OrganizationId",
                table: "billing_quotation",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationType",
                table: "billing_organization",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_billing_quotation_OrganizationId",
                table: "billing_quotation",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_billing_quotation_billing_organization_OrganizationId",
                table: "billing_quotation",
                column: "OrganizationId",
                principalTable: "billing_organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_billing_quotation_billing_organization_OrganizationId",
                table: "billing_quotation");

            migrationBuilder.DropIndex(
                name: "IX_billing_quotation_OrganizationId",
                table: "billing_quotation");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "billing_quotation");

            migrationBuilder.DropColumn(
                name: "OrganizationType",
                table: "billing_organization");
        }
    }
}
