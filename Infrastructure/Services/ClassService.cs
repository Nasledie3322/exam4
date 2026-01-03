using Npgsql;
using Dapper;
public class ClassService : ApplicationDB_Context
{
    public void AddClass(Class Class)
    {
using var conn = new NpgsqlConnection(connString);
conn.Open();
var query = @"insert into classs(class_name, section) values(@class_name, @section)";
conn.Execute(query,new
{
    Class.class_name,
    Class.section
});
    }

    public List<Class> GetClass()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var classs = conn.Query<Class>("select * from classs").ToList();
       return classs;
    }

    public bool DeleteClass(int classId)
{
    using var conn = new NpgsqlConnection(connString);
    conn.Open();

    return conn.Execute(
        "delete from classs where id = @id",
        new { id = classId }
    ) > 0;
}

public string UpdateClass(int classId, string newClass_name, string newSection)
    {
        using var conn= new NpgsqlConnection(connString);
        conn.Open();
        var query = "update classs set class_name=@class_name , section = @section where id = @id";
        var res =conn.Execute(query, new
        {
           id= classId,
           class_name = newClass_name,
           section = newSection 
        });
        return res == 0 ? "cant update class" : "class update successfuly";
    }

}