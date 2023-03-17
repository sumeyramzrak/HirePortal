using Hireportal.Common;
using Hireportal.Data.Seed;

namespace Microsoft.EntityFrameworkCore.Migrations;

public static class MigrationBuilderExtensions
{
    public static void MigrateUsers(this MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData("Users",
                                    new string[]
                                    {
                                        "Id", "UserName", "FullName", "Email", "Department", "Address", "Phone", "Position", "Password", "VerificationId", "UserType", "IsApproved", "IsActive", "IsDeleted", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy"
                                    },
                                    new object[,]
                                    {
                                    //123.
                                        { ConstantIds.User.AdminId, "admin","Esengul Mizrak", "admin@hireportal.com", "asd","asd","asd","asd", "a5813ad799f804b5cc8d127f9c7e4e09cf96ce2135b9f77b379881a0ab2d1aec","asd",  0, true,true, false,DateTime.Now,null, DateTime.Now,null},
                                    },
                                    schema: "Profile"); 
    }

    public static void MigrateLookups(this MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData("LookUpTypes",
                                    new string[]
                                    {
                                        "Id", "Name","IsActive", "IsDeleted", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy"
                                    },
                                    new object[,]
                                    {
                                        {  ConstantIds.LookupType.DebitsId, "Zimmetler", true, false, DateTime.Now, null, DateTime.Now, null },
                                        {  ConstantIds.LookupType.ExpenditureId, "Harcamalar",  true, false, DateTime.Now, null, DateTime.Now, null },
                                        {  ConstantIds.LookupType.PayrollId, "Odemeler",  true, false, DateTime.Now, null, DateTime.Now, null },
                                        {  ConstantIds.LookupType.PermissionId, "Izinler",  true, false, DateTime.Now, null, DateTime.Now, null },
                                        {  ConstantIds.LookupType.ShiftId, "Mesailer",  true, false, DateTime.Now, null, DateTime.Now, null },
                                    },
                                    schema: "Main");

        migrationBuilder.InsertData("LookUps",
                                    new string[]
                                    {
                                        "Id", "Name", "TypeId", "ParentId", "IsActive", "IsDeleted", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy"
                                    },
                                    new object[,]
                                    {
                                        {  ConstantIds.Lookup.ComputerId, "Bilgisayar", ConstantIds.LookupType.DebitsId, ConstantIds.Lookup.ComputerId, true, false, DateTime.Now, null, DateTime.Now, null },
                                        {  ConstantIds.Lookup.CarId, "Bilgisayar", ConstantIds.LookupType.DebitsId, ConstantIds.Lookup.CarId, true,  false, DateTime.Now, null, DateTime.Now, null },

                                        { ConstantIds.Lookup.TransportaionId, "Yol Masrafi", ConstantIds.LookupType.ExpenditureId,  ConstantIds.Lookup.TransportaionId,  true, false, DateTime.Now, null, DateTime.Now, null },
                                        { ConstantIds.Lookup.MealTicketId, "Yol Masrafi", ConstantIds.LookupType.ExpenditureId,  ConstantIds.Lookup.MealTicketId,  true, false, DateTime.Now, null, DateTime.Now, null },

                                        { ConstantIds.Lookup.SalaryId, "Maas", ConstantIds.LookupType.PayrollId, ConstantIds.Lookup.SalaryId,  true, false, DateTime.Now, null, DateTime.Now, null },
                                        { ConstantIds.Lookup.WeeklyPaymentId, "Maas", ConstantIds.LookupType.PayrollId, ConstantIds.Lookup.WeeklyPaymentId,  true, false, DateTime.Now, null, DateTime.Now, null },

                                        { ConstantIds.Lookup.AnnualLeaveId, "Yillik Izni", ConstantIds.LookupType.PermissionId, ConstantIds.Lookup.AnnualLeaveId, true,  false, DateTime.Now, null, DateTime.Now, null },
                                        { ConstantIds.Lookup.BirthLeaveId, "Yillik Izni", ConstantIds.LookupType.PermissionId, ConstantIds.Lookup.BirthLeaveId, true,  false, DateTime.Now, null, DateTime.Now, null },


                                        { ConstantIds.Lookup.MorningShiftId, "Sabah Mesasi", ConstantIds.LookupType.ShiftId, ConstantIds.Lookup.MorningShiftId, true, false, DateTime.Now, null, DateTime.Now, null },
                                        { ConstantIds.Lookup.NightShiftId, "Sabah Mesasi", ConstantIds.LookupType.ShiftId, ConstantIds.Lookup.NightShiftId, true,  false, DateTime.Now, null, DateTime.Now, null },
                                    },
                                    schema: "Main");
    }
}
