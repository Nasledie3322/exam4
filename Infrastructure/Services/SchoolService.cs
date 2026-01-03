using Npgsql;
using Dapper;
public class SchoolService : ApplicationDB_Context
{
    public void AddSchool(School school)
    {
using var conn = new NpgsqlConnection(connString);
conn.Open();
var query = @"insert into schools(school_title, level_count, is_active) values(@school_title, @level_count, @is_active)";
conn.Execute(query,new
{
    school.school_title,
    school.level_count,
    school.is_active,
});
    }

    public List<School> GetSchool()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var schools = conn.Query<School>("select * from schools").ToList();
       return schools;
    }

    public bool DeleteSchool(int schoolId)
{
    using var conn = new NpgsqlConnection(connString);
    conn.Open();

    return conn.Execute(
        "delete from schools where id = @id",
        new { id = schoolId }
    ) > 0;
}

public string UpdateSchool(int schoolId, string newSchool_title, string newLevel_count, string newIs_active)
    {
        using var conn= new NpgsqlConnection(connString);
        conn.Open();
        var query = "update schools set school_title=@school_title , level_count = @level_count, is_active=@is_active where id = @id";
        var res =conn.Execute(query, new
        {
           id= schoolId,
           school_title = newSchool_title,
           level_count = newLevel_count ,
           is_active = newIs_active,
        });
        return res == 0 ? "cant update school" : "school update successfuly";
    }

}