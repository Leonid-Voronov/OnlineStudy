using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextLibrary", menuName = "ScriptableObjects/TextLibrary")]
public class TextLibrarySo : ScriptableObject
{
    [SerializeField] private List<TextEntry> _textEntries = new ();
    private Dictionary<string, string> _textDictionary;
    
    public string GetTextEntry(string key)
    {
        if (_textDictionary.TryGetValue(key, out var entry))
        {
            return entry;
        }
        else
        {
            Debug.LogWarning($"{key} not found, please check sound library");
            return "Error: text not found";
        }
    }

    private void OnEnable()
    {
        _textDictionary?.Clear();
        _textDictionary = new();
        foreach (var textEntry in _textEntries)
        {
            _textDictionary[textEntry.Key] = textEntry.Value;
        }
    }
}

[Serializable]
public class TextEntry
{
    [field: SerializeField] public string Key { get; private set; }
    [field: SerializeField][field: TextArea] public string Value { get; private set; }
}
