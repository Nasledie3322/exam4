using Npgsql;
using Dapper;
public class ParentService : ApplicationDB_Context
{
    public void AddParent(Parent parent)
    {
using var conn = new NpgsqlConnection(connString);
conn.Open();
var query = @"insert into parents(parent_code, parent_full_name, email, phone) values(@parent_code, @parent_full_name, @email, @phone)";
conn.Execute(query,new
{
    parent.parent_code,
    parent.parent_full_name,
    parent.email,
    parent.phone
});
    }

    public List<Parent> GetParent()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var parents = conn.Query<Parent>("select * from parents").ToList();
       return parents;
    }

    public bool DeleteParent(int parentId)
{
    using var conn = new NpgsqlConnection(connString);
    conn.Open();

    return conn.Execute(
        "delete from parents where id = @id",
        new { id = parentId }
    ) > 0;
}

public string UpdateParent(int parentId, string newParent_code, string newParent_full_name, string newEmail, string newPhone)
    {
        using var conn= new NpgsqlConnection(connString);
        conn.Open();
        var query = "update parents set parent_code=@parent_code , parent_full_name = @parent_full_name, email=@email, phone=@phone where id = @id";
        var res =conn.Execute(query, new
        {
           id= parentId,
           parent_code = newParent_code,
           parent_full_name = newParent_full_name ,
           email = newEmail,
        phone = newPhone
        });
        return res == 0 ? "cant update parent" : "parent update successfuly";
    }

}