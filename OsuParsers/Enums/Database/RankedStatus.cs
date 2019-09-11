namespace OsuParsers.Enums.Database
{
    public enum RankedStatus
    {
        Unknown = 0,
        Unsubmitted = 1,
        Pending = 2, //same for wip & graveyard
        Unused = 3,
        Ranked = 4,
        Approved = 5,
        Qualified = 6,
        Loved = 7
    }
}
