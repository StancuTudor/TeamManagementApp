namespace TeamManagementApp.Utils
{
    public enum Selection
    {
        New = -3,
        Null = -2,
        Any = -1,
        Specific = 0
    }
    public enum ActiveSelection
    {
        OnlyInactive = 0,
        OnlyActive = 1,
        All = 2
    }

    public enum FormType
    {
        New,
        Edit,
        ViewOnly
    }
}
