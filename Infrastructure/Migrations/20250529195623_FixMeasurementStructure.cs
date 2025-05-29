using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixMeasurementStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Goals");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Workouts",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "ProgressPhotos",
                newName: "PhotoUrl");

            migrationBuilder.RenameColumn(
                name: "DateUploaded",
                table: "ProgressPhotos",
                newName: "TakenAt");

            migrationBuilder.RenameColumn(
                name: "Fats",
                table: "NutritionLogs",
                newName: "Fat");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Goals",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Deadline",
                table: "Goals",
                newName: "TargetDate");

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "WorkoutEntries",
                type: "double",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "ProgressPhotos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MealType",
                table: "NutritionLogs",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<double>(
                name: "Biceps",
                table: "Measurements",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Chest",
                table: "Measurements",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Waist",
                table: "Measurements",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Measurements",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsAchieved",
                table: "Goals",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ProgressPhotos_UserId1",
                table: "ProgressPhotos",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressPhotos_Users_UserId1",
                table: "ProgressPhotos",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgressPhotos_Users_UserId1",
                table: "ProgressPhotos");

            migrationBuilder.DropIndex(
                name: "IX_ProgressPhotos_UserId1",
                table: "ProgressPhotos");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ProgressPhotos");

            migrationBuilder.DropColumn(
                name: "MealType",
                table: "NutritionLogs");

            migrationBuilder.DropColumn(
                name: "Biceps",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Chest",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Waist",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "IsAchieved",
                table: "Goals");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Workouts",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TakenAt",
                table: "ProgressPhotos",
                newName: "DateUploaded");

            migrationBuilder.RenameColumn(
                name: "PhotoUrl",
                table: "ProgressPhotos",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "Fat",
                table: "NutritionLogs",
                newName: "Fats");

            migrationBuilder.RenameColumn(
                name: "TargetDate",
                table: "Goals",
                newName: "Deadline");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Goals",
                newName: "Type");

            migrationBuilder.AlterColumn<float>(
                name: "Weight",
                table: "WorkoutEntries",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Measurements",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<float>(
                name: "Value",
                table: "Measurements",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Value",
                table: "Goals",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
