using Npgsql;
using Dapper;

public class SubjectService : ApplicationDB_Context
{
    public void AddSubject(Subject subject)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = @"insert into subjects(title, school_id, stage, term, carry_mark, created_at, updated_at) 
                      values(@title, @school_id, @stage, @term, @carry_mark, @created_at, @updated_at)";
        conn.Execute(query, new
        {
            subject.title,
            subject.school_id,
            subject.stage,
            subject.term,
            subject.carry_mark,
            subject.created_at,
            subject.updated_at
        });
    }

    public List<Subject> GetSubjects()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var list = conn.Query<Subject>("select * from subjects").ToList();
        return list;
    }

    public bool DeleteSubject(int id)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        return conn.Execute(
            "delete from subjects where id = @id",
            new { id }
        ) > 0;
    }

    public string UpdateSubject(int id, string newTitle, int newSchoolId, int newStage, int newTerm, int newCarryMark, DateTime newCreatedAt, DateTime newUpdatedAt)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = @"update subjects set 
                        title=@title, 
                        school_id=@school_id, 
                        stage=@stage, 
                        term=@term, 
                        carry_mark=@carry_mark, 
                        created_at=@created_at, 
                        updated_at=@updated_at 
                      where id=@id";
        var res = conn.Execute(query, new
        {
            id,
            title = newTitle,
            school_id = newSchoolId,
            stage = newStage,
            term = newTerm,
            carry_mark = newCarryMark,
            created_at = newCreatedAt,
            updated_at = newUpdatedAt
        });
        return res == 0 ? "cant update subject" : "subject update successfully";
    }
}
