namespace CollectionsSpecializedExtensions;

/// <summary>
/// Extension methods for <see cref="SortedList{TKey,TValue}"/>.
/// </summary>
/// <remarks>
/// Provides LINQ-like extension methods to create <see cref="SortedList{TKey,TValue}"/> from
/// enumerable sources using custom selector functions and comparison.
/// </remarks>
public static class SortedListExtensions
{
    /// <summary>
    /// Creates a new <see langword="SortedList"/> from an <see langword="IEnumerable"/> source.
    /// </summary>
    /// <returns>A new <see langword="SortedList"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"/>
    public static SortedList<TKey, TValue> ToSortedList<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> source)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        return new SortedList<TKey, TValue>(source);
    }

    /// <summary>
    /// Creates a new <see langword="SortedList"/> from an <see langword="IEnumerable"/> source.
    /// </summary>
    /// <returns>A new <see langword="SortedList"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"/>
    public static SortedList<TKey, TValue> ToSortedList<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> source,
        IComparer<TKey> value)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(source, nameof(value));
        return new SortedList<TKey, TValue>(source, value);
    }

    /// <summary>
    /// Creates a new <see langword="SortedList"/> from an <see langword="IEnumerable"/>.
    /// </summary>
    /// <typeparam name="TSource">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys.</typeparam>
    /// <returns>A new <see langword="SortedList"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"/>
    public static SortedList<TKey, TSource> ToSortedList<TKey, TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));

        var list = new SortedList<TKey, TSource>();
        foreach (var element in source)
        {
            list[keySelector(element)] = element;
        }
        return list;
    }

    /// <summary>
    /// Creates a new <see langword="SortedList"/> from an <see langword="IEnumerable"/>.
    /// </summary>
    /// <typeparam name="TSource">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys.</typeparam>
    /// <returns>A new <see langword="SortedList"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"/>
    public static SortedList<TKey, TSource> ToSortedList<TKey, TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        IComparer<TKey> value)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(source, nameof(value));

        var list = new SortedList<TKey, TSource>(value);
        foreach (var element in source)
        {
            list[keySelector(element)] = element;
        }
        return list;
    }

    /// <summary>
    /// Creates a new <see langword="SortedList"/> with key and value selectors.
    /// </summary>
    /// <returns>A new <see langword="SortedList"/> with the key-selector and value-selector mapped data.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <param name="keySelector">A selector for keys.</param>
    /// <param name="valueSelector">A selector for values.</param>
    public static SortedList<TKey, TValue> ToSortedList<TSource, TKey, TValue>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TValue> valueSelector)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(valueSelector, nameof(valueSelector));

        var list = new SortedList<TKey, TValue>();
        foreach (var element in source)
        {
            var key = keySelector(element);
            var value = valueSelector(element);
            list[key] = value;
        }
        return list;
    }

    /// <summary>
    /// Creates a new <see langword="SortedList"/> with key and value selectors.
    /// </summary>
    /// <returns>A new <see langword="SortedList"/> with the key-selector and value-selector mapped data.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <param name="keySelector">A selector for keys.</param>
    /// <param name="valueSelector">A selector for values.</param>
    public static SortedList<TKey, TValue> ToSortedList<TSource, TKey, TValue>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TValue> valueSelector,
        IComparer<TKey> value)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(valueSelector, nameof(valueSelector));
        ArgumentNullException.ThrowIfNull(source, nameof(value));

        var list = new SortedList<TKey, TValue>(value);
        foreach (var element in source)
        {
            var key = keySelector(element);
            var value = valueSelector(element);
            list[key] = value;
        }
        return list;
    }

    /// <summary>
    /// Creates a new <see langword="SortedList"/> from an <see langword="IEnumerable"/> of tuples.
    /// </summary>
    /// <returns>A new <see langword="SortedList"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException">The <paramref name="source"/> is null.</exception>
    public static SortedList<TKey, TValue> ToSortedList<TKey, TValue>(
        this IEnumerable<(TKey, TValue)> source)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));

        var list = new SortedList<TKey, TValue>();
        foreach (var (item1, item2) in source)
        {
            list[item1] = item2;
        }
        return list;
    }

    /// <summary>
    /// Creates a new <see langword="SortedList"/> from an <see langword="IEnumerable"/> of tuples.
    /// </summary>
    /// <returns>A new <see langword="SortedList"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException">The <paramref name="source"/> is null.</exception>
    public static SortedList<TKey, TValue> ToSortedList<TKey, TValue>(
        this IEnumerable<(TKey, TValue)> source,
        IComparer<TKey> value)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(source, nameof(value));

        var list = new SortedList<TKey, TValue>(value);
        foreach (var (item1, item2) in source)
        {
            list[item1] = item2;
        }
        return list;
    }
}
