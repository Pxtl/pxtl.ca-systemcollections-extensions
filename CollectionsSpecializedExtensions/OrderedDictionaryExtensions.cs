namespace CollectionsSpecializedExtensions;

/// <summary>
/// Extension methods for <see cref="OrderedDictionary{TKey,TValue}"/>.
/// </summary>
/// <remarks>
/// Provides LINQ-like extension methods to create <see cref="OrderedDictionary{TKey,TValue}"/> from
/// enumerable sources using custom selector functions and pattern tuples.
/// </remarks>
public static class OrderedDictionaryExtensions
{
    /// <summary>
    /// Creates a new <see langword="OrderedDictionary"/> from an <see langword="IEnumerable"/> source.
    /// </summary>
    /// <returns>A new <see langword="OrderedDictionary"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"/>
    public static OrderedDictionary<TKey, TValue> ToOrderedDictionary<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> source)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        return new OrderedDictionary<TKey, TValue>(source);
    }

    /// <summary>
    /// Creates a new <see langword="OrderedDictionary"/> from an <see langword="IEnumerable"/> source.
    /// </summary>
    /// <returns>A new <see langword="OrderedDictionary"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"/>
    public static OrderedDictionary<TKey, TValue> ToOrderedDictionary<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> source,
        IEqualityComparer<TKey> equalityComparer)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(source, nameof(equalityComparer));
        return new OrderedDictionary<TKey, TValue>(source, equalityComparer);
    }

    /// <summary>
    /// Creates a new <see langword="OrderedDictionary"/> from an <see langword="IEnumerable"/>.
    /// </summary>
    /// <typeparam name="TSource">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys.</typeparam>
    /// <returns>A new <see langword="OrderedDictionary"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"/>
    public static OrderedDictionary<TKey, TSource> ToOrderedDictionary<TKey, TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));

        var dictionary = new OrderedDictionary<TKey, TSource>();
        foreach (var element in source)
        {
            dictionary[keySelector(element)] = element;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see langword="OrderedDictionary"/> from an <see langword="IEnumerable"/>.
    /// </summary>
    /// <typeparam name="TSource">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys.</typeparam>
    /// <returns>A new <see langword="OrderedDictionary"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"/>
    public static OrderedDictionary<TKey, TSource> ToOrderedDictionary<TKey, TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        IEqualityComparer<TKey> equalityComparer)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(source, nameof(equalityComparer));

        var dictionary = new OrderedDictionary<TKey, TSource>(equalityComparer);
        foreach (var element in source)
        {
            dictionary[keySelector(element)] = element;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see langword="OrderedDictionary"/> with key and value selectors.
    /// </summary>
    /// <returns>A new <see langword="OrderedDictionary"/> with the key-selector and value-selector mapped data.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <param name="keySelector">A selector for keys.</param>
    /// <param name="valueSelector">A selector for values.</param>
    public static OrderedDictionary<TKey, TValue> ToOrderedDictionary<TSource, TKey, TValue>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TValue> valueSelector)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(valueSelector, nameof(valueSelector));

        var dictionary = new OrderedDictionary<TKey, TValue>();
        foreach (var element in source)
        {
            var key = keySelector(element);
            var value = valueSelector(element);
            dictionary[key] = value;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see langword="OrderedDictionary"/> with key and value selectors.
    /// </summary>
    /// <returns>A new <see langword="OrderedDictionary"/> with the key-selector and value-selector mapped data.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <param name="keySelector">A selector for keys.</param>
    /// <param name="valueSelector">A selector for values.</param>
    public static OrderedDictionary<TKey, TValue> ToOrderedDictionary<TSource, TKey, TValue>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TValue> valueSelector,
        IEqualityComparer<TKey> equalityComparer)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(valueSelector, nameof(valueSelector));
        ArgumentNullException.ThrowIfNull(source, nameof(equalityComparer));

        var dictionary = new OrderedDictionary<TKey, TValue>(equalityComparer);
        foreach (var element in source)
        {
            var key = keySelector(element);
            var value = valueSelector(element);
            dictionary[key] = value;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see langword="OrderedDictionary"/> from an <see langword="IEnumerable"/> of tuples.
    /// </summary>
    /// <returns>A new <see langword="OrderedDictionary"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"/>
    public static OrderedDictionary<TKey, TValue> ToOrderedDictionary<TKey, TValue>(
        this IEnumerable<(TKey, TValue)> source)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));

        var dictionary = new OrderedDictionary<TKey, TValue>();
        foreach (var item in source)
        {
            dictionary[item.Item1] = item.Item2;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see langword="OrderedDictionary"/> from an <see langword="IEnumerable"/> of tuples.
    /// </summary>
    /// <returns>A new <see langword="OrderedDictionary"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    public static OrderedDictionary<TKey, TValue> ToOrderedDictionary<TKey, TValue>(
        this IEnumerable<(TKey, TValue)> source,
        IEqualityComparer<TKey> equalityComparer)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(source, nameof(equalityComparer));

        var dictionary = new OrderedDictionary<TKey, TValue>(equalityComparer);
        foreach (var item in source)
        {
            dictionary[item.Item1] = item.Item2;
        }
        return dictionary;
    }
}
