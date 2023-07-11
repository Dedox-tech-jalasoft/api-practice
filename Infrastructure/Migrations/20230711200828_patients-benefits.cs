using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class patientsbenefits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientsBenefits",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    BenefitId = table.Column<int>(type: "int", nullable: false),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFullCoverage = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientsBenefits", x => new { x.PatientId, x.BenefitId });
                    table.ForeignKey(
                        name: "FK_PatientsBenefits_Benefits_BenefitId",
                        column: x => x.BenefitId,
                        principalTable: "Benefits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientsBenefits_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientsBenefits_BenefitId",
                table: "PatientsBenefits",
                column: "BenefitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientsBenefits");
        }
    }
}
