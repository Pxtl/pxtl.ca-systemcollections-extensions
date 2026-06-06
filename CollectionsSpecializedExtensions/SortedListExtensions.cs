namespace CollectionsSpecializedExtensions;

/// <summary>
/// Extension methods for <see cref="SortedList{TKey, TValue}"/>.
/// </summary>
/// <remarks>
/// Provides LINQ-like extension methods to create <see cref="SortedList{TKey, TValue}"/> from
/// enumerable sources with custom sorting comparers.
/// </remarks>
public static class SortedListExtensions
{
    /// <summary>
    /// Creates a new <see cref="SortedList{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/> source sorted by key.
    /// </summary>
    /// <typeparam name="TSource">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys.</typeparam>
    /// <typeparam name="TValue">Type of keys.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="keySelector">The key selector function.</param>
    /// <param name="valueSelector">The key selector function.</param>
    /// <param name="comparer">The IComparer{TKey} for sorting keys.</param>
    /// <returns>A new <see cref="SortedList{TKey, TValue}"/> with the sorted data.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="source"/>, <paramref name="keySelector"/>, or <paramref name="comparer"/> is null.</exception>
    public static SortedList<TKey, TValue> ToSortedList<TSource, TKey, TValue>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TValue> valueSelector,
        IComparer<TKey> comparer)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(comparer, nameof(comparer));

        var dict = new SortedList<TKey, TValue>();
        foreach (var element in source)
        {
            dict[keySelector(element)] = valueSelector(element);
        }
        return dict;
    }
}
