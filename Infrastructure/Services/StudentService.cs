using Npgsql;
using Dapper;

public class StudentService : ApplicationDB_Context
{
    public void AddStudent(Student student)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = @"insert into students(student_code, student_full_name, gender, dob, email, phone, school_id, stage, section, is_active, join_date, created_at, updated_at) 
                      values(@student_code, @student_full_name, @gender, @dob, @email, @phone, @school_id, @stage, @section, @is_active, @join_date, @created_at, @updated_at)";
        conn.Execute(query, new
        {
            student.student_code,
            student.student_full_name,
            student.gender,
            student.dob,
            student.email,
            student.phone,
            student.school_id,
            student.stage,
            student.section,
            student.is_active,
            student.join_date,
            student.created_at,
            student.updated_at
        });
    }

    public List<Student> GetStudents()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var list = conn.Query<Student>("select * from students").ToList();
        return list;
    }

    public bool DeleteStudent(int id)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        return conn.Execute(
            "delete from students where id = @id",
            new { id }
        ) > 0;
    }

    public string UpdateStudent(int id, string newStudentCode, string newFullName, string newGender, DateTime newDob, string newEmail, string newPhone, int newSchoolId, int newStage, string newSection, bool newIsActive, DateTime newJoinDate, DateTime newCreatedAt, DateTime newUpdatedAt)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = @"update students set 
                        student_code=@student_code, 
                        student_full_name=@student_full_name, 
                        gender=@gender, 
                        dob=@dob, 
                        email=@email, 
                        phone=@phone, 
                        school_id=@school_id, 
                        stage=@stage, 
                        section=@section, 
                        is_active=@is_active, 
                        join_date=@join_date, 
                        created_at=@created_at, 
                        updated_at=@updated_at 
                      where id=@id";
        var res = conn.Execute(query, new
        {
            id,
            student_code = newStudentCode,
            student_full_name = newFullName,
            gender = newGender,
            dob = newDob,
            email = newEmail,
            phone = newPhone,
            school_id = newSchoolId,
            stage = newStage,
            section = newSection,
            is_active = newIsActive,
            join_date = newJoinDate,
            created_at = newCreatedAt,
            updated_at = newUpdatedAt
        });
        return res == 0 ? "cant update student" : "student update successfully";
    }
}
