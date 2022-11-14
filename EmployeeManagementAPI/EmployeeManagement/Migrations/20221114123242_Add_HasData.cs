using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Migrations
{
    public partial class Add_HasData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "ParentDepartmentId" },
                values: new object[] { "4d6f96bf-dc9e-44f8-a8f7-02b798db0d49", "D 1", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: "4d6f96bf-dc9e-44f8-a8f7-02b798db0d49");
        }
    }
}
