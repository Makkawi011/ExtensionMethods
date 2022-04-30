namespace ExtensionMethods;

public static class ExtensionMethod
{
    /// <summary>
    /// Distribute all items in the ItemToBeDistributed Collection to all collections in the source
    /// for example : 
    ///input:
    ///SourceCollection
    ///{
    ///    { 1, 2, 3 }
    ///    { 4, 5, 6 }
    ///}
    ///ItemToBeDistributedCollection
    ///{8 , 9}
    ///
    ///output
    ///{
    ///    { 1, 2, 3, 8 }
    ///    { 1, 2, 3, 9 }
    ///    { 4, 5, 6, 8 }
    ///    { 4, 5, 6, 9 }
    ///}
    /// </summary>
    /// <typeparam name="T">type of input and output collections elements</typeparam>
    /// <param name="source">input collection</param>
    /// <param name="ItemsToBeDistributedCollection">collection of items to be distribute</param>
    /// <returns>extended Collection Contain all collections in the source and all to etch of them 1 item of collection of items to be distribute </returns>
    public static IEnumerable<IEnumerable<T>> Distribute<T>
        (this IEnumerable<IEnumerable<T>> source, IEnumerable<T> ItemsToBeDistributedCollection)
    {
        if (ItemsToBeDistributedCollection.Count() == 0) 
            return source;

        var Sequance = (List<List<T>>) source;

        if (source.Count() == 0)
        {

            Enumerable
                .Range(0, ItemsToBeDistributedCollection.Count())
                .ToList()
                .ForEach(x => Sequance.Add(new List<T>()));

        }
        else
        {
            Sequance = (List<List<T>>)Sequance.Extend(source.Count() * ItemsToBeDistributedCollection.Count());
        }


        int i = 0;

        for (int j = 0; j < Sequance.Count(); j++)
        {
            if (i >= ItemsToBeDistributedCollection.Count()) i = 0;

            var item = ItemsToBeDistributedCollection.ElementAt(i);

            Sequance.ElementAt(j).Add(item);

            i++;
        }

        return Sequance;
    }

    /// <summary>
    /// repeate Enumerables in Source and put them in new Sequance of Enumerables of length you specify
    /// for example : 
    /// input:
    ///{
    ///    { 1, 2, 3 }
    ///    { 4, 5, 6 }
    ///}
    ///output = input.Scale(4);
    ///output :
    ///{
    ///  { 1, 2, 3 }
    ///  { 1, 2, 3 }
    ///  { 4, 5, 6 }
    ///  { 4, 5, 6 }
    ///}
    /// </summary>
    /// <typeparam name="T">type of input and output collections elements</typeparam>
    /// <param name="source">input collection</param>
    /// <param name="ScalLength">length of result sequance</param>
    /// <returns>new Sequance of Enumerables of length you specify </returns>
    /// <exception cref="ArgumentException">if length of source bigger than Scaling Length 
    /// or the mode of scale length on length of source didn't equal zero </exception>
    public static IEnumerable<IEnumerable<T>> Extend<T>
        (this IEnumerable<IEnumerable<T>> source, int ScalLength)
    {

        if (source.Count() > ScalLength || ScalLength % source.Count() != 0) 
            throw new ArgumentException();

        var Sequance = Enumerable.Empty<List<T>>().ToList();

        Enumerable.Range(0, ScalLength)
        .ToList().ForEach(x => Sequance.Add(new List<T>()));

        int numberOfTimesAnItemIsRepeated = (ScalLength / source.Count()) - 1;

        int counter = numberOfTimesAnItemIsRepeated;

        int j = 0;

        for (int i = 0; i < ScalLength; i++)
        {

            var items = source.ElementAt(j);
            Sequance.ElementAt(i).AddRange(items);

            if (counter == 0)
            {
                j++;
                counter = numberOfTimesAnItemIsRepeated;
            }
            else
            {
                counter--;
            }

        }


        return Sequance;
    }

    /// <summary>
    /// repeate elements in Source and put them in new Sequance of length you specify
    /// for example :
    /// new int[] {1,2,3}.DuplicatElements(6); 
    /// => the sequance result : {1,2,3,1,2,3}
    /// </summary>
    /// <typeparam name="T">type of input and output collections elements</typeparam>
    /// <param name="source">input collection</param>
    /// <param name="LengthOfNewSequance">the length of the new sequance that will contain duplicate elements</param>
    /// <returns>new sequance that will contain duplicate elements </returns>
    /// <exception cref="ArgumentException">if length of source bigger than length of new sequance</exception>
    public static IEnumerable<T> DuplicateElements<T>(this IEnumerable<T> source, int LengthOfNewSequance)
    {
        if (source.Count() > LengthOfNewSequance) 
            throw new ArgumentException();

        List<T> Sequance = new();
        for (int i = 0; i < LengthOfNewSequance; i = i + source.Count()) 
            Sequance.AddRange(source);

        return Sequance;
    }
}
