using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Changemakers.job.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateJobsToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobs_JobCategories_CategoryId",
                table: "jobs");

            migrationBuilder.DropIndex(
                name: "IX_jobs_CategoryId",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "ContactNumberx",
                table: "jobs");

            migrationBuilder.CreateIndex(
                name: "IX_jobs_JobCategoryId",
                table: "jobs",
                column: "JobCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_JobCategories_JobCategoryId",
                table: "jobs",
                column: "JobCategoryId",
                principalTable: "JobCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobs_JobCategories_JobCategoryId",
                table: "jobs");

            migrationBuilder.DropIndex(
                name: "IX_jobs_JobCategoryId",
                table: "jobs");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ContactNumberx",
                table: "jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_jobs_CategoryId",
                table: "jobs",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_JobCategories_CategoryId",
                table: "jobs",
                column: "CategoryId",
                principalTable: "JobCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
