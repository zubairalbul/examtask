using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace examtask.Migrations
{
    /// <inheritdoc />
    public partial class f : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Patients_slot_number",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_slot_number",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PId",
                table: "Bookings",
                column: "PId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Patients_PId",
                table: "Bookings",
                column: "PId",
                principalTable: "Patients",
                principalColumn: "PId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Patients_PId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_PId",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_slot_number",
                table: "Bookings",
                column: "slot_number");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Patients_slot_number",
                table: "Bookings",
                column: "slot_number",
                principalTable: "Patients",
                principalColumn: "PId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
