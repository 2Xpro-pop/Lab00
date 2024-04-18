using PersonNamespace;
using StudentNamespace;

namespace TeacherNamespace
{ 
    [Serializable]
    public class Teacher : Person
    {
        public int TeacherId { get; set; }
        public required List<Student> Students { get; set; }


        public override void Print()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Students: {Students.Count}");
        }

        public override string ToString()
        {
            string s = "";
            
            foreach(var student in Students)
            {
                s += "\n" + student.ToString() + "\n";
            }
            return $"\nTeacher:\nName: {Name}, Age: {Age},\nStudents:" + s;
        }

    }
}
