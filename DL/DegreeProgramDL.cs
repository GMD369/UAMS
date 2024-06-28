using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;
using UAMS.UI;

namespace UAMS.DL
{
    internal class DegreeProgramDL
    {
        public static List<DegreeProgramBL> ProgramList = new List<DegreeProgramBL>();
        public static void addIntoDegreeList(DegreeProgramBL d)
        {
            ProgramList.Add(d);
        }

        public static DegreeProgramBL IsDegreeExist(string title)
        {
            foreach (DegreeProgramBL degreeProgram in ProgramList)
            {
                if (degreeProgram.degreeName == title) return degreeProgram;
            }
            return null;
        }
    }
}
