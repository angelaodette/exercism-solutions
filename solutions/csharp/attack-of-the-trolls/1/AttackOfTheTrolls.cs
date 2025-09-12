enum AccountType
{
    Guest,
    User,
    Moderator
}

[Flags]
enum Permission
{
    None = 0,
    Read = 1 << 1,
    Write = 1 << 2,
    Delete = 1 << 3,
    All = Read | Write | Delete
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        switch (accountType)
        {
            case AccountType.Guest:
                return Permission.Read;
            case AccountType.User:
                return Permission.Read | Permission.Write;
            case AccountType.Moderator:
                return Permission.All;
            default:
                return Permission.None;
        }
    }

    public static Permission Grant(Permission current, Permission grant)
    {
        var combined = current | grant;
        
        if (combined == Permission.All)
        {
            return Permission.All;
        }        
        return grant;        
    }

    public static Permission Revoke(Permission current, Permission revoke)
    {
        var updated = current & ~revoke;
        return updated;
    }

    public static bool Check(Permission current, Permission check) => (current & check) == check;
}
