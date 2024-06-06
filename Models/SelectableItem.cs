namespace Skalalazy.Models;

public class SelectableItem<T>
{
    public bool IsSelected { get; set; }
    public T Value { get; set; }
}