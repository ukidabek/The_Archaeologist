using System;

namespace Weapons
{
    public interface IClip 
    {
       int Counter { get; }
       int Count { get; }
       event Action OnClipEmpty;
       void Reload();
    }
}