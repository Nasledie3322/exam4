using Npgsql;
using Dapper;
public class ClassStudentService : ApplicationDB_Context
{
    public void AddClassStudent(ClassStudent classStudent)
    {
using var conn = new NpgsqlConnection(connString);
conn.Open();
var query = @"insert into class_students(class_id, student_id) values(@class_id, @student_id)";
conn.Execute(query,new
{
    classStudent.class_id,
    classStudent.student_id,
});
    }

    public List<ClassStudent> GetClassStudent()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var classStudents = conn.Query<ClassStudent>("select * from class_students").ToList();
       return classStudents;
    }

    public bool DeleteClassStudent(int classStudentId)
{
    using var conn = new NpgsqlConnection(connString);
    conn.Open();

    return conn.Execute(
        "delete from class_students where id = @id",
        new { id = classStudentId }
    ) > 0;
}

public string UpdateClassStudent(int classStudentId, string newClass_id, string newStudent_id)
    {
        using var conn= new NpgsqlConnection(connString);
        conn.Open();
        var query = "update class_students set class_id=@class_id , student_id = @student_id where id = @id";
        var res =conn.Execute(query, new
        {
           id= classStudentId,
           class_id = newClass_id,
           student_id = newStudent_id 
        });
        return res == 0 ? "cant update ClassStudent" : "ClassStudent update successfuly";
    }

}