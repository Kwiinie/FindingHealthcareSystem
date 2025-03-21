using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessObjects.Migrations
{
    /// <inheritdoc />
    public partial class db : Migration
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
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        name: "FK_Review_Professional",
                        column: x => x.ProviderId,
                        principalTable: "Professionals",
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
                    { 1, "Cơ sở y tế chuyên điều trị các bệnh lý đa dạng.", "Bệnh viện" },
                    { 2, "Cơ sở y tế nhỏ, chủ yếu khám chữa bệnh ngoại trú.", "Phòng khám" },
                    { 3, "Cửa hàng cung cấp thuốc và các sản phẩm y tế.", "Nhà thuốc" }
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
                table: "Patients",
                columns: new[] { "Id", "Note", "UserId" },
                values: new object[,]
                {
                    { 1, "Bệnh nhân có tiền sử bệnh tim mạch", 2 },
                    { 2, "Bệnh nhân bị tiểu đường type 2 và huyết áp cao", 3 }
                });

            migrationBuilder.InsertData(
                table: "Professionals",
                columns: new[] { "Id", "Address", "City", "Degree", "District", "Experience", "ExpertiseId", "ExpertiseId1", "Province", "RequestStatus", "UserId", "WorkingHours" },
                values: new object[,]
                {
                    { 1, "Số 10, Đường X, Hà Nội", "Hà Nội", "Bác sĩ đa khoa", "Ba Đình", "Có 10 năm kinh nghiệm trong lĩnh vực khám chữa bệnh", 1, null, "Hà Nội", "Approved", 4, "Thứ 2 - Thứ 6, 8:00 - 17:00" },
                    { 2, "Số 15, Đường Y, Hồ Chí Minh", "Hồ Chí Minh", "Bác sĩ y học cổ truyền", "Quận 1", "Có 5 năm kinh nghiệm trong điều trị các bệnh lý bằng y học cổ truyền", 2, null, "Hồ Chí Minh", "Pending", 5, "Thứ 2 - Thứ 7, 9:00 - 18:00" }
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
