internal class DbContext
{
    public object QuestaoUmModel { get; internal set; }

    internal Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}