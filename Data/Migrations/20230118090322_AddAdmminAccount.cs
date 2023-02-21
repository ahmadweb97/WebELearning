using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace WebELearning.Data.Migrations
{
    public partial class AddAdmminAccount : Migration
    {
        const string Admin_User_GUID = "3ecbfcea-f2c4-4b44-9e94-bfb45862310d";
        const string Admin_Role_GUID = "cf6dbdac-47d9-4108-8ce9-0992532942f3";


        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var passwordHash = hasher.HashPassword(null, "Admin@123");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO AspNetUsers(Id,UserName,NormalizedUserName,Email,EmailConfirmed,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,AccessFailedCount,NormalizedEmail,PasswordHash,SecurityStamp,FirstName )");
            sb.AppendLine("VALUES(");
            sb.AppendLine($"'{Admin_User_GUID}'");
            sb.AppendLine(", 'admin@webelearning.com.lb'");
            sb.AppendLine(", 'ADMIN@WEBELEARNING.COM.LB'");
            sb.AppendLine(", 'admin@webelearning.com.lb'");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 'ADMIN@WEBELEARNING.COM.LB'");
            sb.AppendLine($", '{passwordHash}'");
            sb.AppendLine(", ''");
            sb.AppendLine($", 'Admin'");
            sb.AppendLine(")");

            migrationBuilder.Sql(sb.ToString());
            migrationBuilder.Sql($"INSERT INTO AspNetRoles(Id, Name, NormalizedName) VALUES('{Admin_Role_GUID}', 'Admin', 'ADMIN')");
            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles(UserId, RoleId) VALUES('{Admin_User_GUID}', '{Admin_Role_GUID}')");




        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId= '{Admin_User_GUID}' AND RoleId = '{Admin_Role_GUID}' ");
            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHERE Id= '{Admin_User_GUID}' ");
            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id= '{Admin_Role_GUID}' ");

        }
    }
}
