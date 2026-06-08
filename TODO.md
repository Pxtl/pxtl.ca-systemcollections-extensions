# TODO

- Support arbitrary IDictionary, ISet, IList collections.

  - `ToIDictionary<TDictionary, TKey, TValue> where TDict : new(), IDictionary<TKey,TValue>()`
  - `ToIList<TList, TItem> where TList : new(), IList<TItem>()`
  - `ToISet<TSet> : new(), TSet<TItem>()`

- For each one also allow a factory lambda that returns an I* *without* the new() where-clause;
- Full unit tests for all 3 classes IDictionaryExtensions, IListExtensions, ISetExtensions.

<!-- IN PROGRESS -->

- Create IListExtensions.cs with factory support
- Create ISetExtensions.cs with factory support
- Add full tests for IListExtensions
- Add full tests for ISetExtensions
- Ensure SortedSetExtensions includes comparer support

<!-- COMPLETE -->