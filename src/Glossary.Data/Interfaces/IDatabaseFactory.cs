namespace Company.Glossary.Data.Interfaces
{
    public interface IDatabaseFactory<out T> where T : class
    {
        T Get();
    }
}
