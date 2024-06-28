using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;
using UAMS.DL;
using UAMS.UI;

namespace UAMS
{
    internal class Program
    {
        public static string ConnectionString = "DESKTOP-0P0ITHG\\SQLEXPRESS; Database=UMS; Trusted_Connection=true;";
        static void Main(string[] args)
        {
            string option;
            while (true) 
            {
                option = ConsoleUtility.Menu();
                ConsoleUtility.ClearScreen();
                ConsoleUtility.Header();

                if (option == "1")
                {
                    if (DegreeProgramDL.ProgramList.Count > 0)
                    {
                        StudentBL s = StudentUI.TakeInputForStudent();
                        StudentDL.AddIntoStudentList(s);
                        if(StudentDL.SaveStudent(s))
                        {
                            Console.WriteLine("Affected");
                        }
                        else
                        {
                            Console.WriteLine("Not");
                        }
                    }
                    else
                    {
                        Console.WriteLine("NO Degree Currently Being Offered.");
                    }
                }
                else if (option == "2")
                {
                    DegreeProgramBL d = DegreeUI.TakeInputForDegree();
                    DegreeProgramDL.addIntoDegreeList(d);
                }

                else if (option == "3")
                {
                    List<StudentBL> sortedStudentList = StudentDL.SortStudentsByMerit();
                    StudentBL.GiveAdmission(sortedStudentList);
                    StudentUI.PrintStudents();
                }

                else if (option == "4")
                {
                    StudentUI.viewRegisteredStudents();
                }
                else if (option == "5")
                {
                    string DegName = DegreeUI.TakeDegree();
                    StudentUI.ViewStudentInDegree(DegName);
                }
                else if (option == "6")
                {
                    string Name = StudentUI.TakeName();
                    StudentBL s = StudentBL.StudentPresent(Name);
                    if (s != null)
                    {
                        SubjectUI.ViewSubjects(s);
                        SubjectUI.RegisterSubjects(s);
                    }
                    else
                    {
                        Console.WriteLine("Student Not Found");
                    }
                }
                else if (option == "7")
                {
                    StudentUI.CalculateFeeForAll();
                }
                else if (option == "8")
                {
                    return;
                }
                ConsoleUtility.ClearScreen();
            }
        }

    }
}

