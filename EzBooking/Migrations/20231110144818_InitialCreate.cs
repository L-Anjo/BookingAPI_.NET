using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EzBooking.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    id_feedback = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    classification = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.id_feedback);
                });

            migrationBuilder.CreateTable(
                name: "PaymentStates",
                columns: table => new
                {
                    id_paymentStates = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStates", x => x.id_paymentStates);
                });

            migrationBuilder.CreateTable(
                name: "PostalCodes",
                columns: table => new
                {
                    postalCode = table.Column<int>(type: "int", nullable: false),
                    concelho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    district = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalCodes", x => x.postalCode);
                });

            migrationBuilder.CreateTable(
                name: "StatusHouses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusHouses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id_user);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    id_house = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    doorNumber = table.Column<int>(type: "int", nullable: false),
                    floorNumber = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: true),
                    priceyear = table.Column<double>(type: "float", nullable: true),
                    guestsNumber = table.Column<int>(type: "int", nullable: false),
                    road = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    propertyAssessment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codDoor = table.Column<int>(type: "int", nullable: true),
                    sharedRoom = table.Column<bool>(type: "bit", nullable: false),
                    postalCode = table.Column<int>(type: "int", nullable: false),
                    StatusHouseid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.id_house);
                    table.ForeignKey(
                        name: "FK_Houses_PostalCodes_postalCode",
                        column: x => x.postalCode,
                        principalTable: "PostalCodes",
                        principalColumn: "postalCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Houses_StatusHouses_StatusHouseid",
                        column: x => x.StatusHouseid,
                        principalTable: "StatusHouses",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Houses_postalCode",
                table: "Houses",
                column: "postalCode");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_StatusHouseid",
                table: "Houses",
                column: "StatusHouseid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "PaymentStates");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PostalCodes");

            migrationBuilder.DropTable(
                name: "StatusHouses");
        }
    }
}
