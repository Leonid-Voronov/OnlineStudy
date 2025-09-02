using UnityEngine;
using Zenject;

public class TextLibraryEntriesService : ITextEntriesService
{
    private readonly TextLibrarySo _textLibrarySo;

    [Inject]
    public TextLibraryEntriesService(TextLibrarySo textLibrarySo) => _textLibrarySo = textLibrarySo;

    public string GetTextEntry(string key) => _textLibrarySo.GetTextEntry(key);
}

/// <summary>
/// Interface to get any text in a game
/// </summary>
public interface ITextEntriesService
{
    public string GetTextEntry(string key);
}
