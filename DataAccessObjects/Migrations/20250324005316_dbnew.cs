using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessObjects.Migrations
{
    /// <inheritdoc />
    public partial class dbnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expertises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expertises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacilityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperationDay = table.Column<DateOnly>(type: "date", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facilities_FacilityTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "FacilityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Articles_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Professionals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ExpertiseId = table.Column<int>(type: "int", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkingHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpertiseId1 = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professionals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professionals_Expertises_ExpertiseId",
                        column: x => x.ExpertiseId,
                        principalTable: "Expertises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Professionals_Expertises_ExpertiseId1",
                        column: x => x.ExpertiseId1,
                        principalTable: "Expertises",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Professionals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacilityDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacilityDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilityDepartments_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicServices_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ArticleImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleImage_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderId = table.Column<int>(type: "int", nullable: true),
                    ProviderType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Facility",
                        column: x => x.ProviderId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivateServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionalId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivateServices_Professionals_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalTable: "Professionals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalSpecialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionalId = table.Column<int>(type: "int", nullable: true),
                    SpecialtyId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalSpecialties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessionalSpecialties_Professionals_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalTable: "Professionals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessionalSpecialties_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    ProviderId = table.Column<int>(type: "int", nullable: true),
                    ProviderType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    ServiceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Facility",
                        column: x => x.ProviderId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_PrivateService",
                        column: x => x.ServiceId,
                        principalTable: "PrivateServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Professional",
                        column: x => x.ProviderId,
                        principalTable: "Professionals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_PublicService",
                        column: x => x.ServiceId,
                        principalTable: "PublicServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalRecordId = table.Column<int>(type: "int", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Các bài viết về các chủ đề y tế, chăm sóc sức khỏe, và bệnh lý.", "Y tế" },
                    { 2, "Các bài viết về dinh dưỡng, chế độ ăn uống và cách duy trì sức khỏe qua thực phẩm.", "Dinh dưỡng" },
                    { 3, "Các bài viết về các bệnh lý phổ biến, nguyên nhân và cách phòng ngừa.", "Bệnh lý" },
                    { 4, "Các bài viết về cách chăm sóc sức khỏe bản thân và gia đình.", "Chăm sóc sức khỏe" },
                    { 5, "Các bài viết về các loại phẫu thuật, quy trình và phục hồi sau phẫu thuật.", "Phẫu thuật" },
                    { 6, "Các bài viết về sức khỏe tinh thần, tâm lý học và cách duy trì tinh thần khỏe mạnh.", "Sức khỏe tâm lý" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Chuyên điều trị các bệnh lý nội khoa như tim mạch, tiêu hóa, thần kinh.", "Khoa Nội" },
                    { 2, "Chuyên phẫu thuật và điều trị các bệnh lý ngoại khoa.", "Khoa Ngoại" },
                    { 3, "Chuyên chăm sóc sức khỏe phụ nữ, mang thai, sinh nở và các vấn đề liên quan.", "Khoa Sản" },
                    { 4, "Chuyên điều trị các bệnh lý liên quan đến trẻ em và trẻ sơ sinh.", "Khoa Nhi" },
                    { 5, "Chuyên thực hiện các xét nghiệm chẩn đoán bệnh lý.", "Khoa Xét nghiệm" },
                    { 6, "Chuyên thực hiện các kỹ thuật hình ảnh như X-quang, MRI, CT scan.", "Khoa Chẩn đoán hình ảnh" },
                    { 7, "Chuyên điều trị các vấn đề về răng miệng và các bệnh lý liên quan.", "Khoa Răng Hàm Mặt" },
                    { 8, "Chuyên khám và điều trị các bệnh lý về mắt.", "Khoa Mắt" },
                    { 9, "Chuyên khám và điều trị các bệnh lý về tai, mũi, họng.", "Khoa Tai Mũi Họng" },
                    { 10, "Chuyên điều trị các bệnh lý về da và thẩm mỹ.", "Khoa Da Liễu" },
                    { 11, "Chuyên cấp cứu và điều trị các bệnh nhân trong tình trạng khẩn cấp.", "Khoa Cấp cứu" },
                    { 12, "Chuyên theo dõi và điều trị bệnh nhân trong tình trạng nguy kịch.", "Khoa Hồi sức tích cực" },
                    { 13, "Chuyên điều trị các vấn đề liên quan đến tâm lý, stress và trầm cảm.", "Khoa Tâm lý" },
                    { 14, "Chuyên phục hồi chức năng cho bệnh nhân sau tai nạn hoặc phẫu thuật.", "Khoa Phục hồi chức năng" },
                    { 15, "Chuyên điều trị các bệnh lý liên quan đến hệ tiết niệu và thận.", "Khoa Tiết niệu" },
                    { 16, "Chuyên điều trị các bệnh lý về tim và mạch máu.", "Khoa Tim mạch" },
                    { 17, "Chuyên điều trị các bệnh lý liên quan đến hệ hô hấp như phổi và khí quản.", "Khoa Hô hấp" },
                    { 18, "Chuyên điều trị các bệnh lý về nội tiết như tiểu đường, tuyến giáp.", "Khoa Nội tiết" },
                    { 19, "Chuyên điều trị các bệnh lý ung thư và các bệnh lý ác tính.", "Khoa Ung bướu" },
                    { 20, "Chuyên tư vấn và điều trị các vấn đề liên quan đến dinh dưỡng.", "Khoa Dinh dưỡng" }
                });

            migrationBuilder.InsertData(
                table: "Expertises",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Tốt nghiệp đại học Y khoa hệ chính quy (6 năm).", "Bác sĩ đa khoa" },
                    { 2, "Tốt nghiệp đại học Y học cổ truyền (6 năm).", "Bác sĩ y học cổ truyền" },
                    { 3, "Tốt nghiệp đại học chuyên khoa Răng - Hàm - Mặt (6 năm).", "Bác sĩ Răng - Hàm - Mặt" },
                    { 4, "Tốt nghiệp đại học chuyên ngành Y học dự phòng (6 năm).", "Bác sĩ Y học dự phòng" },
                    { 5, "Tốt nghiệp đại học ngành Dược (5 năm).", "Dược sĩ đại học" },
                    { 6, "Tốt nghiệp đại học ngành Điều dưỡng (4 năm).", "Cử nhân Điều dưỡng" },
                    { 7, "Đào tạo chuyên sâu 3 năm sau khi tốt nghiệp bác sĩ đa khoa.", "Bác sĩ nội trú" },
                    { 8, "Đào tạo sau đại học chuyên sâu trong lĩnh vực y khoa (2 năm).", "Bác sĩ chuyên khoa I" },
                    { 9, "Cấp cao hơn chuyên khoa I, đào tạo tiếp 2-3 năm.", "Bác sĩ chuyên khoa II" },
                    { 10, "Học vị thạc sĩ ngành y khoa (2 năm).", "Thạc sĩ Y khoa" },
                    { 11, "Học vị tiến sĩ y học, chuyên sâu nghiên cứu (3-5 năm).", "Tiến sĩ Y khoa" },
                    { 12, "Học hàm Phó Giáo sư, có nhiều nghiên cứu và đóng góp khoa học.", "Phó Giáo sư - Tiến sĩ" },
                    { 13, "Học hàm Giáo sư, chuyên gia đầu ngành y tế.", "Giáo sư - Tiến sĩ" }
                });

            migrationBuilder.InsertData(
                table: "FacilityTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Bệnh viện do nhà nước sở hữu và quản lý, cung cấp dịch vụ y tế cho người dân với chi phí thấp hơn.", "Bệnh viện công" },
                    { 2, "Bệnh viện thuộc sở hữu của các cá nhân hoặc tổ chức tư nhân, cung cấp dịch vụ y tế với chất lượng cao và chi phí có thể cao hơn.", "Bệnh viện tư" },
                    { 3, "Cơ sở cung cấp dịch vụ y tế cơ bản và phòng ngừa cho cộng đồng.", "Trung tâm y tế" }
                });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Chuyên ngành điều trị các bệnh lý nội bộ của cơ thể như bệnh tim mạch, tiêu hóa, hô hấp, thận.", "Chuyên khoa Nội" },
                    { 2, "Chuyên ngành liên quan đến phẫu thuật và điều trị các bệnh lý cần can thiệp phẫu thuật.", "Chuyên khoa Ngoại" },
                    { 3, "Chuyên ngành chuyên sâu về bệnh lý tim mạch, bao gồm các bệnh liên quan đến tim và mạch máu.", "Chuyên khoa Tim mạch" },
                    { 4, "Chuyên ngành chẩn đoán và điều trị các bệnh liên quan đến hệ thần kinh như đột quỵ, động kinh.", "Chuyên khoa Thần kinh" },
                    { 5, "Chuyên ngành chăm sóc và điều trị các bệnh lý về da như mụn, eczema, bệnh vảy nến.", "Chuyên khoa Da liễu" },
                    { 6, "Chuyên ngành điều trị các bệnh lý liên quan đến hệ sinh sản và chăm sóc sức khỏe phụ nữ.", "Chuyên khoa Sản phụ khoa" },
                    { 7, "Chuyên ngành chăm sóc sức khỏe và điều trị bệnh lý cho trẻ em.", "Chuyên khoa Nhi" },
                    { 8, "Chuyên ngành điều trị và quản lý các bệnh lý ung thư.", "Chuyên khoa Ung bướu" },
                    { 9, "Chuyên ngành điều trị và chăm sóc các bệnh lý về mắt, bao gồm đục thủy tinh thể, tật khúc xạ.", "Chuyên khoa Mắt" },
                    { 10, "Chuyên ngành liên quan đến các bệnh lý tai, mũi, họng và các cấu trúc liên quan.", "Chuyên khoa Tai Mũi Họng" },
                    { 11, "Chuyên ngành tập trung vào phục hồi sức khỏe cho bệnh nhân sau phẫu thuật, tai nạn, hoặc các bệnh lý nghiêm trọng.", "Chuyên khoa Phục hồi chức năng" },
                    { 12, "Chuyên ngành sử dụng các phương pháp y học cổ truyền như châm cứu, bấm huyệt để điều trị bệnh.", "Chuyên khoa Y học cổ truyền" },
                    { 13, "Chuyên ngành nghiên cứu và điều trị các bệnh lý về hô hấp như viêm phổi, hen suyễn.", "Chuyên khoa Hô hấp" },
                    { 14, "Chuyên ngành điều trị các bệnh lý liên quan đến nội tiết tố như tiểu đường, rối loạn tuyến giáp.", "Chuyên khoa Nội tiết" },
                    { 15, "Chuyên ngành chăm sóc sức khỏe răng miệng, bao gồm điều trị sâu răng, chỉnh hình răng miệng.", "Chuyên khoa Nha khoa" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "Fullname", "Gender", "ImgUrl", "Password", "PhoneNumber", "Role", "Status" },
                values: new object[,]
                {
                    { 1, new DateOnly(1990, 1, 1), "admin@example.com", "Admin", "Nam", null, "ad123456", "0901234567", "Admin", "Active" },
                    { 2, new DateOnly(1995, 5, 20), "patient1@example.com", "Trần Thị B", "Nữ", null, "pa123456", "0902345678", "Patient", "Active" },
                    { 3, new DateOnly(1996, 10, 12), "patient2@example.com", "Nguyễn Thị C", "Nữ", null, "pa123456", "0903456789", "Patient", "Active" },
                    { 4, new DateOnly(1985, 3, 15), "professional1@example.com", "Lê Minh D", "Nam", null, "pro123456", "0904567890", "Professional", "Active" },
                    { 5, new DateOnly(1987, 7, 30), "professional2@example.com", "Phan Minh E", "Nam", null, "pro123456", "0905678901", "Professional", "Inactive" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedAt", "CreatedById", "Status", "Title" },
                values: new object[,]
                {
                    { 1, 1, "<p>Kiểm tra sức khỏe định kỳ là một trong những phương pháp quan trọng giúp phát hiện sớm các vấn đề sức khỏe tiềm ẩn. Việc kiểm tra thường xuyên không chỉ giúp bạn hiểu rõ hơn về tình trạng sức khỏe của mình mà còn giúp bác sĩ đưa ra các biện pháp điều trị kịp thời nếu phát hiện ra vấn đề.</p><p><strong>Các lợi ích chính của việc kiểm tra sức khỏe định kỳ bao gồm:</strong></p><ol><li><strong>Phát hiện sớm các bệnh lý tiềm ẩn</strong>: Việc kiểm tra sức khỏe giúp phát hiện sớm các bệnh lý như tiểu đường, huyết áp cao, hay các vấn đề tim mạch mà bạn có thể không nhận ra. Việc phát hiện sớm giúp điều trị hiệu quả hơn, giảm thiểu các biến chứng nghiêm trọng về sau.</li><li><strong>Tiết kiệm chi phí điều trị</strong>: Việc phát hiện bệnh sớm sẽ giúp bạn tiết kiệm chi phí điều trị, bởi vì bệnh sẽ dễ dàng được điều trị hơn khi phát hiện ở giai đoạn đầu. Điều này không chỉ giúp giảm chi phí cá nhân mà còn giúp hệ thống y tế giảm gánh nặng.</li><li><strong>Tăng tuổi thọ</strong>: Các kiểm tra định kỳ giúp phát hiện sớm các yếu tố nguy cơ sức khỏe và điều chỉnh kịp thời, từ đó tăng khả năng sống lâu. Ví dụ, việc kiểm soát mức huyết áp hoặc cholesterol có thể giúp giảm nguy cơ đột quỵ và các bệnh tim mạch.</li><li><strong>Cải thiện chất lượng cuộc sống</strong>: Việc kiểm tra sức khỏe sẽ giúp bạn có lối sống lành mạnh hơn, với chế độ ăn uống và tập thể dục phù hợp. Điều này sẽ giúp bạn có nhiều năng lượng hơn và cảm thấy tự tin vào sức khỏe của mình.</li><li><strong>Giảm căng thẳng và lo âu</strong>: Khi bạn biết rằng sức khỏe của mình ổn định, bạn sẽ cảm thấy an tâm và ít lo lắng hơn. Việc biết rằng bạn không mắc bệnh gì nghiêm trọng giúp bạn giảm bớt lo âu, từ đó cải thiện tâm trạng và chất lượng cuộc sống.</li></ol>", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "5 Lợi Ích Của Việc Kiểm Tra Sức Khỏe Định Kỳ" },
                    { 2, 1, "<p>Tiêm chủng là một trong những phương pháp phòng ngừa bệnh hiệu quả nhất mà chúng ta có. Việc tiêm chủng định kỳ giúp cơ thể tạo ra miễn dịch đối với các bệnh truyền nhiễm, bảo vệ không chỉ cho bản thân mà còn cho cộng đồng. Dưới đây là những lý do tại sao tiêm chủng là quan trọng và cần thiết:</p><p><strong>1. Bảo vệ khỏi bệnh truyền nhiễm</strong>: Tiêm chủng giúp cơ thể chống lại các bệnh như sởi, thủy đậu, viêm gan B, bạch hầu và nhiều bệnh khác. Bằng cách tiêm phòng, bạn giảm nguy cơ mắc phải các bệnh này, giúp bạn bảo vệ sức khỏe của mình và những người xung quanh. Các bệnh truyền nhiễm có thể gây hậu quả nghiêm trọng, thậm chí là tử vong, nhưng có thể phòng ngừa dễ dàng nhờ tiêm chủng.</p><p><strong>2. Bảo vệ cộng đồng</strong>: Tiêm chủng không chỉ giúp bảo vệ bản thân mà còn giúp bảo vệ những người xung quanh, đặc biệt là những người không thể tiêm chủng như trẻ em, phụ nữ mang thai hoặc người có hệ miễn dịch yếu. Khi càng nhiều người trong cộng đồng tiêm phòng, khả năng lây lan của bệnh sẽ giảm thiểu, từ đó bảo vệ cả cộng đồng khỏi sự bùng phát của các dịch bệnh.</p><p><strong>3. Ngăn ngừa dịch bệnh</strong>: Khi đủ nhiều người trong cộng đồng được tiêm phòng, các dịch bệnh sẽ không có cơ hội bùng phát, giúp bảo vệ cả cộng đồng khỏi những đợt dịch nguy hiểm. Điều này đã được chứng minh qua nhiều quốc gia trên thế giới khi tiêm chủng giúp ngăn ngừa sự bùng phát của các bệnh như sởi, bại liệt, và cúm.</p><p><strong>4. Giảm chi phí chăm sóc sức khỏe</strong>: Khi tiêm chủng, bạn giảm nguy cơ mắc bệnh, từ đó giảm chi phí điều trị và chăm sóc y tế lâu dài. Các bệnh do không tiêm phòng có thể tốn kém hơn rất nhiều trong việc điều trị và chăm sóc sau này.</p><p><strong>5. Đảm bảo an toàn cho trẻ em</strong>: Việc tiêm chủng cho trẻ em giúp bảo vệ các em khỏi những bệnh tật nguy hiểm và giảm tỷ lệ tử vong do bệnh truyền nhiễm. Trẻ em có hệ miễn dịch yếu, nên việc tiêm chủng là biện pháp cần thiết để bảo vệ các em khỏi các mối đe dọa bệnh tật.</p>", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "Tầm Quan Trọng Của Việc Tiêm Chủng Định Kỳ" },
                    { 3, 2, "<p>Một chế độ ăn uống cân bằng là nền tảng quan trọng để duy trì sức khỏe. Để có một chế độ ăn uống lành mạnh, bạn cần đảm bảo rằng cơ thể nhận được đủ các nhóm chất dinh dưỡng cần thiết. Sau đây là một số lời khuyên để duy trì chế độ ăn uống cân bằng và hợp lý:</p><p><strong>1. Ăn đủ 5 nhóm thực phẩm</strong>: Đảm bảo rằng mỗi bữa ăn của bạn bao gồm đủ các nhóm thực phẩm như tinh bột (gạo, khoai), protein (thịt, cá, đậu), chất béo lành mạnh (dầu olive, bơ), vitamin và khoáng chất (rau xanh, trái cây), và chất xơ. Việc kết hợp đa dạng các thực phẩm sẽ cung cấp đầy đủ dinh dưỡng cho cơ thể.</p><p><strong>2. Hạn chế thức ăn chế biến sẵn</strong>: Thực phẩm chế biến sẵn chứa nhiều chất bảo quản, đường và muối, có thể gây hại cho sức khỏe nếu tiêu thụ quá nhiều. Hãy tránh thức ăn nhanh, thực phẩm chiên rán, và thay vào đó là các món ăn tươi sống, chế biến tại nhà.</p><p><strong>3. Uống đủ nước</strong>: Cung cấp đủ nước cho cơ thể là một yếu tố quan trọng trong chế độ ăn uống. Nước giúp cơ thể hấp thu chất dinh dưỡng, giải độc và duy trì nhiệt độ cơ thể ổn định. Bạn nên uống ít nhất 8 cốc nước mỗi ngày và uống thêm nếu bạn tham gia các hoạt động thể thao.</p><p><strong>4. Ăn nhiều rau củ quả</strong>: Rau củ quả chứa nhiều vitamin, khoáng chất và chất xơ, giúp hỗ trợ hệ tiêu hóa, tăng cường hệ miễn dịch và giúp da khỏe mạnh. Hãy cố gắng ăn ít nhất 5 khẩu phần rau quả mỗi ngày để cung cấp các dưỡng chất thiết yếu cho cơ thể.</p><p><strong>5. Kiểm soát lượng đường và muối</strong>: Việc giảm lượng đường và muối trong chế độ ăn uống có thể giúp ngăn ngừa các bệnh lý như tiểu đường, huyết áp cao và bệnh tim. Bạn nên hạn chế các thực phẩm ngọt và thức uống có gas, thay vào đó là ăn trái cây tươi và sử dụng gia vị tự nhiên.</p>", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "Chế Độ Ăn Uống Cân Bằng Cho Sức Khỏe" },
                    { 4, 2, "<p>Hệ tiêu hóa đóng một vai trò quan trọng trong việc duy trì sức khỏe. Khi hệ tiêu hóa hoạt động tốt, cơ thể sẽ hấp thụ dinh dưỡng hiệu quả, giảm nguy cơ mắc các bệnh lý và cải thiện chất lượng cuộc sống. Dưới đây là một số thực phẩm giúp cải thiện hệ tiêu hóa:</p><p><strong>1. Sữa chua</strong>: Sữa chua chứa các vi khuẩn có lợi giúp duy trì sự cân bằng của hệ vi sinh đường ruột, từ đó giúp hệ tiêu hóa hoạt động hiệu quả hơn. Các lợi khuẩn này giúp cải thiện sự hấp thu chất dinh dưỡng và tăng cường hệ miễn dịch.</p><p><strong>2. Chuối</strong>: Chuối là một nguồn cung cấp chất xơ tuyệt vời, giúp cải thiện nhu động ruột và ngăn ngừa táo bón. Chuối cũng có thể làm dịu dạ dày và giúp giảm cảm giác đầy bụng.</p><p><strong>3. Rau xanh</strong>: Các loại rau như rau cải, rau bina và bông cải xanh chứa nhiều chất xơ và vitamin, giúp tăng cường chức năng tiêu hóa và làm sạch đường ruột. Rau xanh giúp cải thiện nhu động ruột và giảm nguy cơ mắc bệnh về đường tiêu hóa.</p><p><strong>4. Hạt chia</strong>: Hạt chia giàu chất xơ, giúp cải thiện nhu động ruột và giảm táo bón. Ngoài ra, hạt chia còn cung cấp các axit béo omega-3 có lợi cho sức khỏe.</p><p><strong>5. Gừng</strong>: Gừng có tính kháng viêm và có thể giúp làm dịu dạ dày, hỗ trợ tiêu hóa và giảm đầy bụng. Uống trà gừng hoặc thêm gừng tươi vào các món ăn có thể giúp cải thiện hệ tiêu hóa.</p>", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "Thực Phẩm Giúp Cải Thiện Hệ Tiêu Hóa" },
                    { 5, 1, "<p>Bệnh tim mạch là một trong những nguyên nhân hàng đầu gây tử vong trên toàn cầu. Tuy nhiên, bệnh tim mạch có thể được phòng ngừa thông qua các biện pháp thay đổi lối sống lành mạnh. Dưới đây là những phương pháp phòng ngừa hiệu quả bệnh tim mạch:</p><p><strong>1. Duy trì một chế độ ăn uống lành mạnh</strong>: Chế độ ăn uống giàu trái cây, rau củ, ngũ cốc nguyên hạt, và giảm thiểu các thực phẩm giàu chất béo bão hòa và cholesterol sẽ giúp bảo vệ tim mạch. Hãy bổ sung các thực phẩm giàu omega-3 như cá hồi và các loại hạt giúp làm giảm nguy cơ bệnh tim.</p><p><strong>2. Tập thể dục thường xuyên</strong>: Các nghiên cứu đã chứng minh rằng việc tập thể dục thường xuyên, ít nhất 30 phút mỗi ngày, giúp cải thiện sức khỏe tim mạch. Việc này giúp tăng cường lưu thông máu, kiểm soát huyết áp và cholesterol.</p><p><strong>3. Kiểm soát cân nặng</strong>: Thừa cân làm tăng nguy cơ mắc bệnh tim mạch. Việc duy trì cân nặng hợp lý thông qua chế độ ăn uống và luyện tập sẽ giảm thiểu gánh nặng cho tim, giúp tim hoạt động hiệu quả hơn.</p><p><strong>4. Hạn chế căng thẳng</strong>: Căng thẳng kéo dài có thể làm tăng huyết áp và làm tổn thương mạch máu. Hãy áp dụng các phương pháp giảm stress như thiền, yoga, hoặc đi bộ để giảm mức độ căng thẳng trong cuộc sống hàng ngày.</p><p><strong>5. Kiểm tra sức khỏe định kỳ</strong>: Việc kiểm tra sức khỏe định kỳ, bao gồm kiểm tra huyết áp và mức cholesterol, sẽ giúp bạn phát hiện sớm các yếu tố nguy cơ và có biện pháp can thiệp kịp thời để bảo vệ sức khỏe tim mạch.</p>", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "Cách Phòng Ngừa Bệnh Tim Mạch" },
                    { 6, 3, "<p>Ung thư phổi là một trong những loại ung thư nguy hiểm và có tỷ lệ tử vong cao. Việc phát hiện bệnh sớm sẽ giúp điều trị hiệu quả và cải thiện cơ hội sống sót. Dưới đây là một số dấu hiệu cảnh báo ung thư phổi mà bạn không nên bỏ qua:</p><p><strong>1. Ho kéo dài</strong>: Ho kéo dài, đặc biệt là ho có đờm hoặc ho ra máu, có thể là dấu hiệu của ung thư phổi. Nếu bạn có ho liên tục trong nhiều tuần, hãy đi kiểm tra để xác định nguyên nhân.</p><p><strong>2. Khó thở</strong>: Khó thở hoặc cảm giác hụt hơi khi làm những việc bình thường có thể là triệu chứng của bệnh ung thư phổi. Sự tắc nghẽn trong phổi do khối u có thể làm giảm khả năng hô hấp của bạn.</p><p><strong>3. Đau ngực</strong>: Đau hoặc cảm giác tức ngực, đặc biệt là khi ho hoặc thở sâu, có thể là dấu hiệu của ung thư phổi. Cơn đau có thể lan ra vai hoặc lưng, đặc biệt khi khối u chèn ép lên các cơ quan lân cận.</p><p><strong>4. Giảm cân không rõ lý do</strong>: Giảm cân đột ngột mà không thay đổi chế độ ăn uống hoặc lối sống có thể là một dấu hiệu của ung thư phổi. Đây là triệu chứng chung của nhiều loại ung thư, trong đó có ung thư phổi.</p><p><strong>5. Mệt mỏi kéo dài</strong>: Cảm giác mệt mỏi và yếu ớt kéo dài có thể là dấu hiệu của ung thư phổi. Khi các tế bào ung thư phát triển, cơ thể sẽ trở nên mệt mỏi hơn, và năng lượng của bạn sẽ giảm sút.</p><p>Việc kiểm tra y tế kịp thời sẽ giúp phát hiện ung thư phổi ở giai đoạn sớm, từ đó tăng cơ hội điều trị và cải thiện khả năng sống sót của bệnh nhân.</p>", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "Những Dấu Hiệu Cảnh Báo Ung Thư Phổi" }
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "Address", "Description", "District", "ImgUrl", "Name", "OperationDay", "Province", "Status", "TypeId", "Ward" },
                values: new object[,]
                {
                    { 1, "Số 1, Phố Lê Thánh Tông", "Bệnh viện công cung cấp dịch vụ y tế chuyên nghiệp với chi phí hợp lý.", "Quận Hoàn Kiếm", null, "Bệnh viện Đa khoa Quốc tế Hà Nội", new DateOnly(2025, 3, 17), "Thành phố Hà Nội", "Active", 1, "Phường Hàng Bạc" },
                    { 2, "Số 25, Đường Lý Thường Kiệt", "Bệnh viện tư chuyên cung cấp dịch vụ y tế chất lượng cao.", "Quận 10", null, "Bệnh viện Đa khoa Vạn Hạnh", new DateOnly(2025, 3, 17), "Thành phố Hồ Chí Minh", "Active", 2, "Phường Phú Trung" },
                    { 3, "Số 45, Đường Võ Văn Tần", "Trung tâm y tế cung cấp dịch vụ chăm sóc sức khỏe cơ bản cho cộng đồng.", "Quận 3", null, "Trung tâm Y tế Quận 3", new DateOnly(2025, 3, 17), "Thành phố Hồ Chí Minh", "Active", 3, "Phường 7" },
                    { 4, "Số 78, Phố Giải Phóng", "Bệnh viện công lớn chuyên khoa về nội, ngoại, và các chuyên khoa khác.", "Quận Đống Đa", null, "Bệnh viện Bạch Mai", new DateOnly(2025, 3, 17), "Thành phố Hà Nội", "Active", 1, "Phường Phương Liên" },
                    { 5, "Số 458, Đường Minh Khai", "Bệnh viện tư quốc tế với các dịch vụ khám chữa bệnh tiên tiến và chuyên nghiệp.", "Quận Cầu Giấy", null, "Bệnh viện Quốc tế Vinmec", new DateOnly(2025, 3, 17), "Thành phố Hà Nội", "Active", 2, "Phường Dịch Vọng" },
                    { 6, "Số 50, Đường Nguyễn Văn Linh", "Trung tâm y tế cung cấp các dịch vụ chăm sóc sức khỏe cộng đồng và các dịch vụ phòng ngừa.", "Quận 7", null, "Trung tâm Y tế Quận 7", new DateOnly(2025, 3, 17), "Thành phố Hồ Chí Minh", "Active", 3, "Phường Phú Mỹ" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Note", "UserId" },
                values: new object[,]
                {
                    { 1, "Bệnh nhân có tiền sử bệnh tim mạch", 2 },
                    { 2, "Bệnh nhân bị tiểu đường type 2 và huyết áp cao", 3 }
                });

            migrationBuilder.InsertData(
                table: "Professionals",
                columns: new[] { "Id", "Address", "Degree", "District", "Experience", "ExpertiseId", "ExpertiseId1", "Province", "RequestStatus", "UserId", "Ward", "WorkingHours" },
                values: new object[,]
                {
                    { 1, "Số 10, Đường X", "Bác sĩ đa khoa", "Quận Ba Đình", "Có 10 năm kinh nghiệm trong lĩnh vực khám chữa bệnh", 1, null, "Thành phố Hà Nội", "Approved", 4, "Phường Cửa Đông", "8:00 - 17:00" },
                    { 2, "Số 15, Đường Y", "Bác sĩ y học cổ truyền", "Quận 1", "Có 5 năm kinh nghiệm trong điều trị các bệnh lý bằng y học cổ truyền", 2, null, "Thành phố Hồ Chí Minh", "Pending", 5, "Phường Bến Nghé", "9:00 - 18:00" }
                });

            migrationBuilder.InsertData(
                table: "FacilityDepartments",
                columns: new[] { "Id", "DepartmentId", "FacilityId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 2 },
                    { 4, 4, 2 },
                    { 5, 5, 3 },
                    { 6, 6, 3 },
                    { 7, 7, 4 },
                    { 8, 8, 4 },
                    { 9, 9, 5 },
                    { 10, 10, 5 },
                    { 11, 11, 6 },
                    { 12, 12, 6 }
                });

            migrationBuilder.InsertData(
                table: "PrivateServices",
                columns: new[] { "Id", "Description", "Name", "Price", "ProfessionalId" },
                values: new object[,]
                {
                    { 1, "Khám tổng quát để kiểm tra sức khỏe định kỳ.", "Khám bệnh tổng quát", 300000m, 1 },
                    { 2, "Khám sức khỏe phụ khoa cho nữ giới.", "Khám sức khỏe phụ khoa", 350000m, 1 },
                    { 3, "Khám các bệnh lý về tim mạch, huyết áp và các bệnh lý liên quan.", "Khám bệnh lý tim mạch", 500000m, 1 },
                    { 4, "Sử dụng y học cổ truyền để điều trị các bệnh lý như đau nhức, viêm nhiễm.", "Điều trị bằng y học cổ truyền", 500000m, 2 },
                    { 5, "Điều trị đau lưng bằng phương pháp châm cứu truyền thống.", "Châm cứu điều trị đau lưng", 400000m, 2 },
                    { 6, "Xoa bóp và bấm huyệt giúp giảm căng thẳng và mệt mỏi.", "Xoa bóp bấm huyệt", 350000m, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProfessionalSpecialties",
                columns: new[] { "Id", "ProfessionalId", "SpecialtyId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 12 }
                });

            migrationBuilder.InsertData(
                table: "PublicServices",
                columns: new[] { "Id", "Description", "FacilityId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Khám tổng quát để kiểm tra sức khỏe định kỳ.", 1, "Khám bệnh tổng quát", 300000m },
                    { 2, "Xét nghiệm máu để kiểm tra các chỉ số sức khỏe.", 1, "Xét nghiệm máu", 150000m },
                    { 3, "Khám các bệnh lý về tim mạch, huyết áp và các bệnh lý liên quan.", 1, "Khám bệnh lý tim mạch", 500000m },
                    { 4, "Sử dụng phương pháp y học cổ truyền để điều trị các bệnh lý như đau nhức, viêm nhiễm.", 2, "Điều trị bằng y học cổ truyền", 400000m },
                    { 5, "Châm cứu để điều trị các cơn đau lưng mãn tính.", 2, "Châm cứu điều trị đau lưng", 350000m },
                    { 6, "Xoa bóp và bấm huyệt giúp giảm căng thẳng và mệt mỏi.", 2, "Xoa bóp bấm huyệt", 250000m },
                    { 7, "Khám các bệnh lý về tai mũi họng như viêm họng, viêm amidan.", 1, "Khám tai mũi họng", 200000m },
                    { 8, "Khám mắt để kiểm tra sức khỏe mắt, phát hiện các bệnh lý như cận thị, loạn thị.", 1, "Khám mắt", 250000m },
                    { 9, "Sử dụng thuốc thảo dược để điều trị các bệnh lý như cảm cúm, tiêu hóa.", 2, "Điều trị bằng thuốc thảo dược", 300000m },
                    { 10, "Khám và kiểm tra tình trạng răng miệng, phát hiện sâu răng, viêm lợi.", 3, "Khám răng miệng", 250000m },
                    { 11, "Lấy cao răng, giúp làm sạch răng miệng và ngăn ngừa bệnh về nướu.", 3, "Lấy cao răng", 150000m },
                    { 12, "Cấy ghép răng implant cho những người mất răng.", 3, "Cấy ghép răng implant", 1000000m },
                    { 13, "Dịch vụ tẩy trắng răng giúp cải thiện màu sắc răng miệng.", 3, "Tẩy trắng răng", 500000m }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Date", "Description", "PatientId", "PaymentId", "ProviderId", "ProviderType", "ServiceId", "ServiceType", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 31, 10, 0, 0, 0, DateTimeKind.Unspecified), "Khám bệnh tổng quát cho bệnh nhân", 1, null, 1, "Professional", 1, "Private", "AwaitingPayment" },
                    { 2, new DateTime(2025, 3, 31, 14, 0, 0, 0, DateTimeKind.Unspecified), "Điều trị bằng y học cổ truyền cho bệnh nhân", 2, null, 1, "Professional", 4, "Private", "AwaitingPayment" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PaymentId",
                table: "Appointments",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ProviderId",
                table: "Appointments",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ServiceId",
                table: "Appointments",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleImage_ArticleId",
                table: "ArticleImage",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CreatedById",
                table: "Articles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_MedicalRecordId",
                table: "Attachments",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_TypeId",
                table: "Facilities",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityDepartments_DepartmentId",
                table: "FacilityDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityDepartments_FacilityId",
                table: "FacilityDepartments",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_AppointmentId",
                table: "MedicalRecords",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserId",
                table: "Patients",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateServices_ProfessionalId",
                table: "PrivateServices",
                column: "ProfessionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Professionals_ExpertiseId",
                table: "Professionals",
                column: "ExpertiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Professionals_ExpertiseId1",
                table: "Professionals",
                column: "ExpertiseId1");

            migrationBuilder.CreateIndex(
                name: "IX_Professionals_UserId",
                table: "Professionals",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalSpecialties_ProfessionalId",
                table: "ProfessionalSpecialties",
                column: "ProfessionalId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalSpecialties_SpecialtyId",
                table: "ProfessionalSpecialties",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicServices_FacilityId",
                table: "PublicServices",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PatientId",
                table: "Reviews",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProviderId",
                table: "Reviews",
                column: "ProviderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleImage");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "FacilityDepartments");

            migrationBuilder.DropTable(
                name: "ProfessionalSpecialties");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "PrivateServices");

            migrationBuilder.DropTable(
                name: "PublicServices");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Professionals");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "Expertises");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FacilityTypes");
        }
    }
}
