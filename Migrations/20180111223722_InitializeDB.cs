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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    templateHtmlFile = table.Column<string>(nullable: true),
                    templateImageFile = table.Column<string>(nullable: true),
                    templateName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalProfile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    address = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CV",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    creationDateTime = table.Column<string>(nullable: true),
                    profileId = table.Column<int>(nullable: false),
                    templateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CV", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CV_PersonalProfile_profileId",
                        column: x => x.profileId,
                        principalTable: "PersonalProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CV_CVTemplate_templateId",
                        column: x => x.templateId,
                        principalTable: "CVTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CVId = table.Column<int>(nullable: false),
                    graduationYear = table.Column<string>(nullable: true),
                    institute = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Education_CV_CVId",
                        column: x => x.CVId,
                        principalTable: "CV",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillAndCertificate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CVId = table.Column<int>(nullable: false),
                    Institute = table.Column<string>(nullable: true),
                    skillName = table.Column<string>(nullable: true),
                    year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillAndCertificate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillAndCertificate_CV_CVId",
                        column: x => x.CVId,
                        principalTable: "CV",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CVId = table.Column<int>(nullable: false),
                    Employer = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    endMonth = table.Column<string>(nullable: true),
                    endYear = table.Column<string>(nullable: true),
                    jobTitle = table.Column<string>(nullable: true),
                    startMonth = table.Column<string>(nullable: true),
                    startYear = table.Column<string>(nullable: true),
                    stillInRole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkHistory_CV_CVId",
                        column: x => x.CVId,
                        principalTable: "CV",
                        principalColumn: "Id",
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
