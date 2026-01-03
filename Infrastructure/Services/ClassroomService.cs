using Npgsql;
using Dapper;
public class ClassroomService : ApplicationDB_Context
{
    public void AddClassroom(Classroom classroom)
    {
using var conn = new NpgsqlConnection(connString);
conn.Open();
var query = @"insert into classrooms(capacity, room_type, description) values(@capacity, @room_type, @description)";
conn.Execute(query,new
{
    classroom.capacity,
    classroom.room_type,
    classroom.description
});
    }

    public List<Classroom> GetClassroom()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var classrooms = conn.Query<Classroom>("select * from classrooms").ToList();
       return classrooms;
    }

    public bool DeleteClassroom(int classroomId)
{
    using var conn = new NpgsqlConnection(connString);
    conn.Open();

    return conn.Execute(
        "delete from classrooms where id = @id",
        new { id = classroomId }
    ) > 0;
}

public string UpdateClassroom(int classroomId, string newRoom_type, string newDescription)
    {
        using var conn= new NpgsqlConnection(connString);
        conn.Open();
        var query = "update classrooms set room_type=@room_type , description = @description where id = @id";
        var res =conn.Execute(query, new
        {
           id= classroomId,
           class_name = newRoom_type,
           section = newDescription 
        });
        return res == 0 ? "cant update classroom" : "classroom update successfuly";
    }

}