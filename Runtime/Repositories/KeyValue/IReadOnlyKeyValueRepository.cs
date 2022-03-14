using System.Collections.Generic;

namespace Juce.Cheats.Repositories
{
    public interface IReadOnlyKeyValueRepository<TId, TObject>
    {
        IReadOnlyList<TObject> Items { get; }

        bool TryGet(TId id, out TObject obj);
    }
}