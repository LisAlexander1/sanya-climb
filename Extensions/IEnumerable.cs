using System.Collections.ObjectModel;

namespace Skalalazy.Extensions;

public static class IEnumerable
{
    public static ObservableCollection<T> ToObservableCollection<T>
        (this IEnumerable<T> source)
    {
        return source == null ? [] : new ObservableCollection<T>(source);
    }
}