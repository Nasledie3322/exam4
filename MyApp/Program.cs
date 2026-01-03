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
                    schoolService.AddSchool(new School { school_title = title, level_count = levelCount, is_active = isActive });
                    break;

                case "2":
                    foreach (var s in schoolService.GetSchool())
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
                    foreach (var st in studentService.GetStudents())
                        Console.WriteLine($"{st.id} - {st.student_full_name} - Code: {st.student_code} - Active: {st.is_active}");
                    break;

                case "7":
                    Console.Write("Student ID: ");
                    int stId = int.Parse(Console.ReadLine());
                    Console.Write("New full name: ");
                    string newFullName = Console.ReadLine();
                    Console.Write("Is active (true/false): ");
                    bool newActive = bool.Parse(Console.ReadLine());
                    Console.WriteLine(studentService.UpdateStudent(stId, null, newFullName, null, DateTime.Now, null, null, 0, 0, null, newActive, DateTime.Now, DateTime.Now, DateTime.Now));
                    break;

                case "8":
                    Console.Write("Student ID: ");
                    int dsId = int.Parse(Console.ReadLine());
                    Console.WriteLine(studentService.DeleteStudent(dsId));
                    break;

                case "9":
                    Console.Write("Student ID: ");
                    int spStudentId = int.Parse(Console.ReadLine());
                    Console.Write("Parent ID: ");
                    int spParentId = int.Parse(Console.ReadLine());
                    Console.Write("Relationship (number): ");
                    int spRel = int.Parse(Console.ReadLine());
                    studentParentService.AddStudentParent(new StudentParent
                    {
                        student_id = spStudentId,
                        parent_id = spParentId,
                        relationship = spRel
                    });
                    break;

                case "10":
                    foreach (var sp in studentParentService.GetStudentParents())
                        Console.WriteLine($"{sp.id} - Student: {sp.student_id} - Parent: {sp.parent_id} - Rel: {sp.relationship}");
                    break;

                case "11":
                    Console.Write("StudentParent ID: ");
                    int uspId = int.Parse(Console.ReadLine());
                    Console.Write("New Student ID: ");
                    int nStId = int.Parse(Console.ReadLine());
                    Console.Write("New Parent ID: ");
                    int nPrId = int.Parse(Console.ReadLine());
                    Console.Write("New Relationship: ");
                    int nRel = int.Parse(Console.ReadLine());
                    Console.WriteLine(studentParentService.UpdateStudentParent(uspId, nStId, nPrId, nRel));
                    break;

                case "12":
                    Console.Write("StudentParent ID: ");
                    int dspId = int.Parse(Console.ReadLine());
                    Console.WriteLine(studentParentService.DeleteStudentParent(dspId));
                    break;

                case "13":
                    Console.Write("Subject title: ");
                    string subTitle = Console.ReadLine();
                    Console.Write("School ID: ");
                    int subSchoolId = int.Parse(Console.ReadLine());
                    Console.Write("Stage: ");
                    int subStage = int.Parse(Console.ReadLine());
                    Console.Write("Term: ");
                    int subTerm = int.Parse(Console.ReadLine());
                    Console.Write("Carry mark: ");
                    int subMark = int.Parse(Console.ReadLine());
                    DateTime subNow = DateTime.Now;
                    subjectService.AddSubject(new Subject
                    {
                        title = subTitle,
                        school_id = subSchoolId,
                        stage = subStage,
                        term = subTerm,
                        carry_mark = subMark,
                        created_at = subNow,
                        updated_at = subNow
                    });
                    break;

                case "14":
                    foreach (var sub in subjectService.GetSubjects())
                        Console.WriteLine($"{sub.id} - {sub.title} - School: {sub.school_id} - Stage: {sub.stage} - Term: {sub.term}");
                    break;

                case "15":
                    Console.Write("Subject ID: ");
                    int usId = int.Parse(Console.ReadLine());
                    Console.Write("New title: ");
                    string nSubTitle = Console.ReadLine();
                    Console.Write("New Carry mark: ");
                    int nCarry = int.Parse(Console.ReadLine());
                    Console.WriteLine(subjectService.UpdateSubject(usId, nSubTitle, 0, 0, 0, nCarry, DateTime.Now, DateTime.Now));
                    break;

                case "16":
                    Console.Write("Subject ID: ");
                    int dsbId = int.Parse(Console.ReadLine());
                    Console.WriteLine(subjectService.DeleteSubject(dsbId));
                    break;

                case "17":
                    Console.Write("Teacher code: ");
                    string tCode = Console.ReadLine();
                    Console.Write("Full name: ");
                    string tName = Console.ReadLine();
                    Console.Write("Gender: ");
                    string tGender = Console.ReadLine();
                    Console.Write("DOB (yyyy-MM-dd): ");
                    DateTime tDob = DateTime.Parse(Console.ReadLine());
                    Console.Write("Email: ");
                    string tEmail = Console.ReadLine();
                    Console.Write("Phone: ");
                    string tPhone = Console.ReadLine();
                    Console.Write("Is active (true/false): ");
                    bool tActive = bool.Parse(Console.ReadLine());
                    Console.Write("Join date (yyyy-MM-dd): ");
                    DateTime tJoin = DateTime.Parse(Console.ReadLine());
                    Console.Write("Working days: ");
                    int tDays = int.Parse(Console.ReadLine());
                    DateTime tNow = DateTime.Now;
                    teacherService.AddTeacher(new Teacher
                    {
                        teacher_code = tCode,
                        teacher_full_name = tName,
                        gender = tGender,
                        dob = tDob,
                        email = tEmail,
                        phone = tPhone,
                        is_active = tActive,
                        join_date = tJoin,
                        working_days = tDays,
                        created_at = tNow,
                        updated_at = tNow
                    });
                    break;

                case "18":
                    foreach (var t in teacherService.GetTeachers())
                        Console.WriteLine($"{t.id} - {t.teacher_full_name} - Code: {t.teacher_code} - Active: {t.is_active}");
                    break;

                case "19":
                    Console.Write("Teacher ID: ");
                    int utId = int.Parse(Console.ReadLine());
                    Console.Write("New full name: ");
                    string ntName = Console.ReadLine();
                    Console.Write("Is active (true/false): ");
                    bool ntActive = bool.Parse(Console.ReadLine());
                    Console.WriteLine(teacherService.UpdateTeacher(utId, null, ntName, null, DateTime.Now, null, null, ntActive, DateTime.Now, 0, DateTime.Now, DateTime.Now));
                    break;

                case "20":
                    Console.Write("Teacher ID: ");
                    int dtId = int.Parse(Console.ReadLine());
                    Console.WriteLine(teacherService.DeleteTeacher(dtId));
                    break;

                case "0":
                    return;
            }
        }
    }
}
