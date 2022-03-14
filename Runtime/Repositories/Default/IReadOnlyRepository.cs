using System.Collections.Generic;

namespace Juce.Cheats.Repositories
{
    public interface IReadOnlyRepository<TObject>
    {
        IReadOnlyList<TObject> Items { get; }

        bool Contains(TObject obj);
    }
}