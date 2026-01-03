
class Program
{
    static void Main()
    {
        var schoolService = new SchoolService();
        var studentService = new StudentService();
        var studentParentService = new StudentParentService();
        var subjectService = new SubjectService();
        var teacherService = new TeacherService();

        while (true)
        {
            Console.WriteLine("\n1.Add School");
            Console.WriteLine("2.Show Schools");
            Console.WriteLine("3.Update School");
            Console.WriteLine("4.Delete School");

            Console.WriteLine("5.Add Student");
            Console.WriteLine("6.Show Students");
            Console.WriteLine("7.Update Student");
            Console.WriteLine("8.Delete Student");

            Console.WriteLine("9.Add StudentParent");
            Console.WriteLine("10.Show StudentParents");
            Console.WriteLine("11.Update StudentParent");
            Console.WriteLine("12.Delete StudentParent");

            Console.WriteLine("13.Add Subject");
            Console.WriteLine("14.Show Subjects");
            Console.WriteLine("15.Update Subject");
            Console.WriteLine("16.Delete Subject");

            Console.WriteLine("17.Add Teacher");
            Console.WriteLine("18.Show Teachers");
            Console.WriteLine("19.Update Teacher");
            Console.WriteLine("20.Delete Teacher");

            Console.WriteLine("0.Exit");
            Console.Write("Choose: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("School title: ");
                    string title = Console.ReadLine();
                    Console.Write("Level count: ");
                    int levelCount = int.Parse(Console.ReadLine());
                    Console.Write("Is active (true/false): ");
                    bool isActive = bool.Parse(Console.ReadLine());
                    schoolService.AddSchool(new School
                    {
                        school_title = title,
                        level_count = levelCount,
                        is_active = isActive
                    });
                    break;

                case "2":
                    var schools = schoolService.GetSchool();
                    foreach (var s in schools)
                        Console.WriteLine($"{s.id} - {s.school_title} - Levels: {s.level_count} - Active: {s.is_active}");
                    break;

                case "3":
                    Console.Write("School ID: ");
                    int sid = int.Parse(Console.ReadLine());
                    Console.Write("New title: ");
                    string nTitle = Console.ReadLine();
                    Console.Write("New level count: ");
                    string nLevel = Console.ReadLine();
                    Console.Write("Is active (true/false): ");
                    string nActive = Console.ReadLine();
                    Console.WriteLine(schoolService.UpdateSchool(sid, nTitle, nLevel, nActive));
                    break;

                case "4":
                    Console.Write("School ID: ");
                    int dsid = int.Parse(Console.ReadLine());
                    Console.WriteLine(schoolService.DeleteSchool(dsid));
                    break;

                case "5":
                    Console.Write("Student code: ");
                    string sCode = Console.ReadLine();
                    Console.Write("Full name: ");
                    string sName = Console.ReadLine();
                    Console.Write("Gender: ");
                    string sGender = Console.ReadLine();
                    Console.Write("DOB (yyyy-MM-dd): ");
                    DateTime sDob = DateTime.Parse(Console.ReadLine());
                    Console.Write("Email: ");
                    string sEmail = Console.ReadLine();
                    Console.Write("Phone: ");
                    string sPhone = Console.ReadLine();
                    Console.Write("School ID: ");
                    int sSchoolId = int.Parse(Console.ReadLine());
                    Console.Write("Stage: ");
                    int sStage = int.Parse(Console.ReadLine());
                    Console.Write("Section: ");
                    string sSection = Console.ReadLine();
                    Console.Write("Is active (true/false): ");
                    bool sActive = bool.Parse(Console.ReadLine());
                    DateTime now = DateTime.Now;
                    studentService.AddStudent(new Student
                    {
                        student_code = sCode,
                        student_full_name = sName,
                        gender = sGender,
                        dob = sDob,
                        email = sEmail,
                        phone = sPhone,
                        school_id = sSchoolId,
                        stage = sStage,
                        section = sSection,
                        is_active = sActive,
                        join_date = now,
                        created_at = now,
                        updated_at = now
                    });
                    break;

                case "6":
                    var students = studentService.GetStudents();
                    foreach (var st in students)
                        Console.WriteLine($"{st.id} - {st.student_full_name} - Code: {st.student_code} - Active: {st.is_active}");
                    break;

                case "7":
                    Console.Write("Student ID: ");
                    int stId = int.Parse(Console.ReadLine());
                 
                    break;

                case "8":
                    Console.Write("Student ID: ");
                    int dsId = int.Parse(Console.ReadLine());
                    Console.WriteLine(studentService.DeleteStudent(dsId));
                    break;

                case "0":
                    return;
            }
        }
    }
}
