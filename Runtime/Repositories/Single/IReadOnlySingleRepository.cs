﻿namespace Juce.Cheats.Repositories
{
    public interface IReadOnlySingleRepository<TObject>
    {
        bool HasItem { get; }

        bool Contains(TObject obj);
        bool TryGet(out TObject obj);
    }
}