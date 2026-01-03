using Npgsql;
using Dapper;

public class TeacherService : ApplicationDB_Context
{
    public void AddTeacher(Teacher teacher)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = @"insert into teachers(teacher_code, teacher_full_name, gender, dob, email, phone, is_active, join_date, working_days, created_at, updated_at) 
                      values(@teacher_code, @teacher_full_name, @gender, @dob, @email, @phone, @is_active, @join_date, @working_days, @created_at, @updated_at)";
        conn.Execute(query, new
        {
            teacher.teacher_code,
            teacher.teacher_full_name,
            teacher.gender,
            teacher.dob,
            teacher.email,
            teacher.phone,
            teacher.is_active,
            teacher.join_date,
            teacher.working_days,
            teacher.created_at,
            teacher.updated_at
        });
    }

    public List<Teacher> GetTeachers()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var list = conn.Query<Teacher>("select * from teachers").ToList();
        return list;
    }

    public bool DeleteTeacher(int id)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        return conn.Execute(
            "delete from teachers where id = @id",
            new { id }
        ) > 0;
    }

    public string UpdateTeacher(int id, string newCode, string newFullName, string newGender, DateTime newDob, string newEmail, string newPhone, bool newIsActive, DateTime newJoinDate, int newWorkingDays, DateTime newCreatedAt, DateTime newUpdatedAt)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = @"update teachers set 
                        teacher_code=@teacher_code, 
                        teacher_full_name=@teacher_full_name, 
                        gender=@gender, 
                        dob=@dob, 
                        email=@email, 
                        phone=@phone, 
                        is_active=@is_active, 
                        join_date=@join_date, 
                        working_days=@working_days, 
                        created_at=@created_at, 
                        updated_at=@updated_at 
                      where id=@id";
        var res = conn.Execute(query, new
        {
            id,
            teacher_code = newCode,
            teacher_full_name = newFullName,
            gender = newGender,
            dob = newDob,
            email = newEmail,
            phone = newPhone,
            is_active = newIsActive,
            join_date = newJoinDate,
            working_days = newWorkingDays,
            created_at = newCreatedAt,
            updated_at = newUpdatedAt
        });
        return res == 0 ? "cant update teacher" : "teacher update successfully";
    }
}
