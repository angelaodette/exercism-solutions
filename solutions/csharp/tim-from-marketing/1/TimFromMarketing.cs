using System.Text;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        if (department == null)
        {
            department = "OWNER";
        }

        StringBuilder sb = new StringBuilder($"{name} - {department.ToUpper()}");
        
        if (id != null)
        {
            sb.Insert(0, $"[{id}] - ");
        }
        return sb.ToString();
    }
}
