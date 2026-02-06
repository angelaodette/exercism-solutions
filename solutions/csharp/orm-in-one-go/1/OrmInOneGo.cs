public class Orm
{
    private Database _database;

    public Orm(Database database)
    {
        _database = database;
    }

    
    public void Write(string data)
    {     
        using var dbResource = _database;
        try
        {
            dbResource.BeginTransaction();
            dbResource.Write(data);
            dbResource.EndTransaction();
        }
        catch
        {
            dbResource.Dispose();
            throw;
        }

    }

    public bool WriteSafely(string data)
    {
        using var dbResource = _database;
        try
        {
            dbResource.BeginTransaction();
            dbResource.Write(data);
            dbResource.EndTransaction();
            return true;
        }
        catch
        {
            dbResource.Dispose();
            return false;
        }
    }
}
