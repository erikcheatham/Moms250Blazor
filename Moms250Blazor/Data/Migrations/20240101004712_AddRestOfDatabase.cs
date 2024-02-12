using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moms250Blazor.Migrations
{
    /// <inheritdoc />
    public partial class AddRestOfDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_AspNetUsers_ApplicationUserId",
                table: "AspNetUsers",
                column: "ApplicationUserId");

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantFullName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    ApplicantFName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ApplicantLName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ApplicantState = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    ApplicantChapter = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ApplicationType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ApplicationStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ApplicationDateAssigned = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChapterContact = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Registrar = table.Column<bool>(type: "bit", nullable: true),
                    ChapterContactEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    VerifyingGenie = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FirstReview = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfLastAIRLetter = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateComplete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NCUpdateRequested = table.Column<bool>(type: "bit", nullable: true),
                    HelpRequest = table.Column<bool>(type: "bit", nullable: true),
                    ReassignmentRequest = table.Column<bool>(type: "bit", nullable: true),
                    AAARequest = table.Column<bool>(type: "bit", nullable: true),
                    ARTRequest = table.Column<bool>(type: "bit", nullable: true),
                    SeniorCoordinatorRequest = table.Column<bool>(type: "bit", nullable: true),
                    CoordinatorRequest = table.Column<bool>(type: "bit", nullable: true),
                    ReturnRequest = table.Column<bool>(type: "bit", nullable: true),
                    DocReceived = table.Column<bool>(type: "bit", nullable: true),
                    PermissionLetter = table.Column<bool>(type: "bit", nullable: true),
                    SelectedCoordinator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateProblem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastContactWithChapterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MemberInitials = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    VolunteerContactChapter = table.Column<bool>(type: "bit", nullable: true),
                    SpecialTeamRequest = table.Column<bool>(type: "bit", nullable: true),
                    PatriotNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PatriotName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    NewChildOfPatriot = table.Column<bool>(type: "bit", nullable: true),
                    NewPatriot = table.Column<bool>(type: "bit", nullable: true),
                    Correction = table.Column<bool>(type: "bit", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentsForAll",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Group = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentsForAll", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Object = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    StateAb = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateAb);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_To_Assignments",
                        column: x => x.AssignmentID,
                        principalTable: "Assignments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    DateAssigned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeadVolunteer = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Volunteers_AppUser",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "ApplicationUserId");
                    table.ForeignKey(
                        name: "FK_Volunteers_Assignments",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_AssignmentID",
                table: "Attachments",
                column: "AssignmentID");

            migrationBuilder.CreateIndex(
                name: "idx_AppUserId",
                table: "Volunteers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "idx_AssignmentId",
                table: "Volunteers",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "idx_LeadVolunteer",
                table: "Volunteers",
                column: "LeadVolunteer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "AttachmentsForAll");

            migrationBuilder.DropTable(
                name: "ExceptionLog");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AspNetUsers_ApplicationUserId",
                table: "AspNetUsers");
        }
    }
}
