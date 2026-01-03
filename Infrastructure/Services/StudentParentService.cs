using Npgsql;
using Dapper;

public class StudentParentService : ApplicationDB_Context
{
    public void AddStudentParent(StudentParent sp)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = @"insert into student_parents(student_id, parent_id, relationship) 
                      values(@student_id, @parent_id, @relationship)";
        conn.Execute(query, new
        {
            sp.student_id,
            sp.parent_id,
            sp.relationship
        });
    }

    public List<StudentParent> GetStudentParents()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var list = conn.Query<StudentParent>("select * from student_parents").ToList();
        return list;
    }

    public bool DeleteStudentParent(int id)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        return conn.Execute(
            "delete from student_parents where id = @id",
            new { id }
        ) > 0;
    }

    public string UpdateStudentParent(int id, int newStudentId, int newParentId, int newRelationship)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = @"update student_parents 
                      set student_id=@student_id, parent_id=@parent_id, relationship=@relationship 
                      where id=@id";
        var res = conn.Execute(query, new
        {
            id,
            student_id = newStudentId,
            parent_id = newParentId,
            relationship = newRelationship
        });
        return res == 0 ? "cant update StudentParent" : "StudentParent update successfully";
    }
}
