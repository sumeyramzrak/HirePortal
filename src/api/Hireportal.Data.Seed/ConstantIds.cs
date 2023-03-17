using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Seed
{
    public static class ConstantIds
    {
        public class User
        {
            public static Guid AdminId = new Guid("63F34CCB-C779-4C82-A1AE-A76C5248BF23");
        }

        public class LookupType
        {
            public static Guid DebitsId = new Guid("C868A137-EFAD-446A-8A62-211574F51241");
            public static Guid ExpenditureId = new Guid("AA2BE2D9-CBB8-4D19-813F-E17B843853F3");
            public static Guid PayrollId = new Guid("6136224D-139B-4F14-A76A-1CEB95F42BF1");
            public static Guid PermissionId = new Guid("A161CAF4-B0BF-4297-B6B8-8E45F8434CD1");
            public static Guid ShiftId = new Guid("F6FC0FD6-CA31-4C8A-BBD1-DBD5A1CEA2B9");
        }

        public class Lookup
        {
           
            public static Guid ComputerId = new Guid("D8ABEFAC-4BE4-4F85-8005-4EA0A89F8A0F");
            public static Guid CarId = new Guid("9F54B2FE-8619-4E20-AE7F-16AEA3C0D43C");

            public static Guid TransportaionId = new Guid("ED680A7D-CBFE-45EA-9B1C-B3EFB4DF4FF6");
            public static Guid MealTicketId = new Guid("3957E6E7-7319-4AEE-B820-EF3E1CF7AC4B");

            public static Guid SalaryId = new Guid("3D0016A4-EE36-4D33-8339-70663D3406C0");
            public static Guid WeeklyPaymentId = new Guid("ECD5DFFA-7421-4ACE-9398-B47D0C42FC4A");

            public static Guid AnnualLeaveId = new Guid("2CEBFF62-6F18-4DA4-9D9F-C3F7EAE1F887");
            public static Guid BirthLeaveId = new Guid("61727180-8615-4E1F-902A-6270D09CE459");

            public static Guid MorningShiftId = new Guid("F525FD75-634A-46CB-984B-5ADC8EEA1022");
            public static Guid NightShiftId = new Guid("AF7A232A-D098-4ADD-803B-F55426424DC0");

        }
    }
}
