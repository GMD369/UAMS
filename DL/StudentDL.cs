using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;
using UAMS.UI;

namespace UAMS.DL
{
    internal class StudentDL
    {
        public static List<StudentBL> StudentList = new List<StudentBL>();

        public static void AddIntoStudentList(StudentBL s)
        {
            StudentList.Add(s);
        }

        public static List<StudentBL> SortStudentsByMerit()
        {
            List<StudentBL> sortedStudentList = new List<StudentBL>();
            foreach (StudentBL s in StudentDL.StudentList)
            {
                s.CalculateMerit();
            }

            sortedStudentList = StudentList.OrderByDescending(o => o.merit).ToList();
            return sortedStudentList;
        }

        public static List<StudentBL> GetStudentsList()
        {
            return StudentList;
        }
        public static StudentBL AddStudent(StudentBL student)
        {
            StudentList.Add(student);
            return student;
        }

        public static void RemoveStudent(StudentBL student)
        {
            StudentList.Remove(student);
        }

        public static StudentBL RemoveStudentByName(string name)
        {
            foreach (StudentBL student in StudentList)
            {
                if (student.name == name)
                {
                    StudentList.ToList().Remove(student);
                }
            }
            return null;
        }

        public static StudentBL FindStudentByName(string name)
        {
            foreach (StudentBL student in StudentList)
            {
                if (student.name == name)
                {
                    return student;
                }
            }
            return null;
        }
        public static bool SaveStudent(StudentBL student)
        {
            string query = string.Format("insert into MyStudent(Roll, Name, Ecat, Matric, Fsc)  " +
                "VALUES({0}, '{1}', {2}, {3}, {4})",
                student.age, student.name, student.ecatMarks, student.merit, student.fscMarks);

            SqlConnection con = new SqlConnection(Program.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            int rowsAffacted = cmd.ExecuteNonQuery();
            con.Close();

            int count = 0;
            
            if (rowsAffacted > 0)
            {
                return true;
            }
            else { return false; }

        }
    }
}
