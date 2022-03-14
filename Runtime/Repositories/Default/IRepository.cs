namespace Juce.Cheats.Repositories
{
    public interface IRepository<TObject> : IReadOnlyRepository<TObject>
    {
        void Add(TObject obj);
        void Remove(TObject obj);
        void Clear();
    }
}
