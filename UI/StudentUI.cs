using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;
using UAMS.DL;

namespace UAMS.UI
{
    internal class StudentUI
    {
        public static StudentBL TakeInputForStudent()
        {
            string Name;
            int Age;
            double FSCMarks;
            double EcatMarks;
            List<DegreeProgramBL> Preferences = new List<DegreeProgramBL>();
            Console.Write("Enter Student Name: ");
            Name = Console.ReadLine();
            Console.Write("Enter Student Age: ");
            Age = int.Parse(Console.ReadLine());
            Console.Write("Enter Student FSc Marks: ");
            FSCMarks = double.Parse(Console.ReadLine());
            Console.Write("Enter Student Ecat Marks: ");
            EcatMarks = double.Parse(Console.ReadLine());
            Console.WriteLine("Available Degree Programs");
            UI.DegreeUI.ViewDegreePrograms();

            Console.Write("Enter how many preferences to Enter: ");
            int Count = int.Parse(Console.ReadLine());
            for (int x = 0; x < Count; x++)
            {
                string degName = Console.ReadLine();
                bool flag = false;
                foreach (DegreeProgramBL dp in DegreeProgramDL.ProgramList)
                {
                    if (degName == dp.degreeName && !(Preferences.Contains(dp)))
                    {
                        Preferences.Add(dp);
                        flag = true;
                    }
                }

                if (flag == false)
                {
                    Console.WriteLine("Enter Valid Degree Program Name");
                    x--;
                }
            }

            StudentBL s = new StudentBL(Name, Age, FSCMarks, EcatMarks, Preferences);
            return s;
        }

        public static void PrintStudents()
        {
            foreach (StudentBL s in StudentDL.StudentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + " got Admission in " + s.regDegree.degreeName);
                }
                else
                {
                    Console.WriteLine(s.name + " did not get Admission");
                }
            }
        }

        public static void viewRegisteredStudents()
        {
            Console.WriteLine("Name\tFSC\tEcat\tAge\tRegistered");
            foreach (StudentBL s in StudentDL.StudentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age+ "\tYes");
                }
                else
                {
                    Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age + "\tNO");
                }
            }
        }

        public static string TakeName()
        {
            Console.Write("Enter the Student Name: ");
            string name = Console.ReadLine();
            return name;
        }

        public static void CalculateFeeForAll()
        {
            foreach (StudentBL s in StudentDL.StudentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + " has " + s.CalculateFee() + " fees");
                }
            }
        }

        public static void ViewStudentInDegree(string degName)
        {
            Console.WriteLine("Name\tFSC\tEcat\tAge");
            foreach (StudentBL s in StudentDL.StudentList)
            {
                if (s.regDegree != null)
                {
                    if (degName == s.regDegree.degreeName)
                    {
                        Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age);
                    }
                }
            }
        }
    }
}
