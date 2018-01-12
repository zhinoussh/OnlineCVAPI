using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineCVAPI.Migrations
{
    public partial class InitializeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CVTemplate",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    templateHtmlFile = table.Column<string>(maxLength: 50, nullable: true),
                    templateImageFile = table.Column<string>(maxLength: 50, nullable: true),
                    templateName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVTemplate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PersonalProfile",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    address = table.Column<string>(maxLength: 100, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    firstName = table.Column<string>(maxLength: 50, nullable: true),
                    lastName = table.Column<string>(maxLength: 50, nullable: true),
                    phoneNumber = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalProfile", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CV",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    creationDateTime = table.Column<string>(maxLength: 50, nullable: true),
                    profileId = table.Column<int>(nullable: false),
                    templateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CV", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CV_PersonalProfile_profileId",
                        column: x => x.profileId,
                        principalTable: "PersonalProfile",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CV_CVTemplate_templateId",
                        column: x => x.templateId,
                        principalTable: "CVTemplate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CVId = table.Column<int>(nullable: false),
                    graduationYear = table.Column<string>(maxLength: 10, nullable: true),
                    institute = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Education_CV_CVId",
                        column: x => x.CVId,
                        principalTable: "CV",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillAndCertificate",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CVId = table.Column<int>(nullable: false),
                    Institute = table.Column<string>(maxLength: 50, nullable: true),
                    skillName = table.Column<string>(maxLength: 50, nullable: true),
                    year = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillAndCertificate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SkillAndCertificate_CV_CVId",
                        column: x => x.CVId,
                        principalTable: "CV",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkHistory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CVId = table.Column<int>(nullable: false),
                    Employer = table.Column<string>(maxLength: 50, nullable: true),
                    Location = table.Column<string>(maxLength: 50, nullable: true),
                    endMonth = table.Column<string>(maxLength: 4, nullable: true),
                    endYear = table.Column<string>(maxLength: 4, nullable: true),
                    jobTitle = table.Column<string>(maxLength: 50, nullable: true),
                    startMonth = table.Column<string>(maxLength: 4, nullable: true),
                    startYear = table.Column<string>(maxLength: 4, nullable: true),
                    stillInRole = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkHistory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkHistory_CV_CVId",
                        column: x => x.CVId,
                        principalTable: "CV",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CV_profileId",
                table: "CV",
                column: "profileId");

            migrationBuilder.CreateIndex(
                name: "IX_CV_templateId",
                table: "CV",
                column: "templateId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_CVId",
                table: "Education",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillAndCertificate_CVId",
                table: "SkillAndCertificate",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistory_CVId",
                table: "WorkHistory",
                column: "CVId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "SkillAndCertificate");

            migrationBuilder.DropTable(
                name: "WorkHistory");

            migrationBuilder.DropTable(
                name: "CV");

            migrationBuilder.DropTable(
                name: "PersonalProfile");

            migrationBuilder.DropTable(
                name: "CVTemplate");
        }
    }
}
