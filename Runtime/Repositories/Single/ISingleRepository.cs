namespace Juce.Cheats.Repositories
{
    public interface ISingleRepository<TObject> : IReadOnlySingleRepository<TObject>
    {
        void Set(TObject obj);
        void Clear();
    }
}
