using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TirandoAsRodinhas.Migrations
{
    public partial class RelacionandoParceirosAndEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocsFinanceiros_Parceiros_ParceiroId",
                table: "DocsFinanceiros");

            migrationBuilder.AddColumn<Guid>(
                name: "EmpresaId",
                table: "Parceiros",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmpresaId",
                table: "DocsFinanceiros",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Parceiros_EmpresaId",
                table: "Parceiros",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_DocsFinanceiros_EmpresaId",
                table: "DocsFinanceiros",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocsFinanceiros_Empresas_EmpresaId",
                table: "DocsFinanceiros",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocsFinanceiros_Parceiros_ParceiroId",
                table: "DocsFinanceiros",
                column: "ParceiroId",
                principalTable: "Parceiros",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parceiros_Empresas_EmpresaId",
                table: "Parceiros",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocsFinanceiros_Empresas_EmpresaId",
                table: "DocsFinanceiros");

            migrationBuilder.DropForeignKey(
                name: "FK_DocsFinanceiros_Parceiros_ParceiroId",
                table: "DocsFinanceiros");

            migrationBuilder.DropForeignKey(
                name: "FK_Parceiros_Empresas_EmpresaId",
                table: "Parceiros");

            migrationBuilder.DropIndex(
                name: "IX_Parceiros_EmpresaId",
                table: "Parceiros");

            migrationBuilder.DropIndex(
                name: "IX_DocsFinanceiros_EmpresaId",
                table: "DocsFinanceiros");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Parceiros");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "DocsFinanceiros");

            migrationBuilder.AddForeignKey(
                name: "FK_DocsFinanceiros_Parceiros_ParceiroId",
                table: "DocsFinanceiros",
                column: "ParceiroId",
                principalTable: "Parceiros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
