﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;

namespace UAMS.UI
{
    internal class SubjectUI
    {
        public static SubjectBL TakeInputForSubject()
        {
            string Code;
            string Type;
            int CreditHours;
            int SubjectFees;

            Console.Write("Enter Subject Code: ");
            Code = Console.ReadLine();
            Console.Write("Enter Subject Type: ");
            Type = Console.ReadLine();
            Console.Write("Enter Subject Credit Hours: ");
            CreditHours = int.Parse(Console.ReadLine());
            Console.Write("Enter Subject Fees: ");
            SubjectFees = int.Parse(Console.ReadLine());
            SubjectBL sub = new SubjectBL(Code, Type, CreditHours, SubjectFees);
            return sub;
        }

        public static void ViewSubjects(StudentBL s)
        {
            if (s.regDegree != null)
            {
                Console.WriteLine("Sub Code\tSub Type");
                foreach (SubjectBL sub in s.regDegree.subjects)
                {
                    Console.WriteLine(sub.code + "\t\t" + sub.type);
                }
            }
        }

        public static void RegisterSubjects(StudentBL s)
        {
            Console.WriteLine("Enter how many subject you want to register");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.Write("Enter the subject Code");
                string code = Console.ReadLine();
                bool Flag = false;
                foreach (SubjectBL sub in s.regDegree.subjects)
                {
                    if (code == sub.code && !(s.regSubject.Contains(sub)))
                    {
                        s.RegStudentSubject(sub);
                        Flag = true;
                        break;
                    }
                }
                if (Flag == false)
                {
                    Console.WriteLine("Enter Valid Course");
                    i--;
                }

            }
        }

    }
}
