using static ExtensionMethods.ExtensionMethod;


#region DuplicatElements Function
Console.WriteLine("____________________________________DuplicatElements Function__________________________________\n");

//{ 1, 2, 3 }
var OneTowThree = Enumerable
    .Range(1, 3)
    .ToList();

//{ 1, 2, 3, 1, 2, 3 }
var OneTowThreeOneTowThree =
    OneTowThree.DuplicateElements(6);

//print the input
Console.WriteLine("------------------- Input: ---------------");
OneTowThree
    .ToList()
    .ForEach(x => Console.Write(x + "\t"));//{ 1, 2, 3 }

//print the result
Console.WriteLine("\n------------------- Output: --------------");
OneTowThreeOneTowThree
    .ToList()
    .ForEach(x => Console.Write(x + "\t"));//{ 1, 2, 3, 1, 2, 3 }

#endregion



#region Extend Function
Console.WriteLine("\n____________________________________Scale Function__________________________________\n");

//input:
//{
//    { 1, 2, 3 }
//    { 4, 5, 6 }
//}
List<List<int>> source = new()
{
    new List<int> { 1, 2, 3 },
    new List<int> { 4, 5, 6 }
};


//output :
//{
//  { 1, 2, 3 }
//  { 1, 2, 3 }
//  { 4, 5, 6 }
//  { 4, 5, 6 }
//}
int ScalLength = 4;
var result = source
    .Extend(ScalLength);

//print the input
Console.WriteLine("------------------- Input: ---------------");
Enumerable.Range(0, source.Count())
    .ToList()
    .ForEach(i => Console.WriteLine(String.Join("\t", source.ElementAt(i))));

//print the result
Console.WriteLine("------------------- Output: ---------------");
Enumerable.Range(0, result.Count())
    .ToList()
    .ForEach(i => Console.WriteLine(String.Join("\t", result.ElementAt(i))));

#endregion



#region Distribute Function
Console.WriteLine("\n____________________________________Distribute Function__________________________________\n");

//input:
//SourceCollection
//{
//    { 1, 2, 3 }
//    { 4, 5, 6 }
//}
//ItemToBeDistributedCollection
//{8 , 9}
List<List<int>> SourceCollection = new()
{
    new List<int> { 1, 2, 3 },
    new List<int> { 4, 5, 6 }
};

IEnumerable<int> ItemToBeDistributedCollection = Enumerable
    .Range(8, SourceCollection.Count); //{8 , 9}

//output
//{
//    { 1, 2, 3, 8 }
//    { 1, 2, 3, 9 }
//    { 4, 5, 6, 8 }
//    { 4, 5, 6, 9 }
//}

IEnumerable<IEnumerable<int>> OutputCollection = SourceCollection
    .Distribute(ItemToBeDistributedCollection);



//print the input
Console.WriteLine("------------------- Input: ---------------");
Enumerable.Range(0, SourceCollection.Count())
    .ToList()
    .ForEach(i => Console.WriteLine(String.Join("\t", SourceCollection.ElementAt(i))));

//print the result
Console.WriteLine("------------------- Output: ---------------");
Enumerable.Range(0, OutputCollection.Count())
    .ToList()
    .ForEach(i => Console.WriteLine(String.Join("\t", OutputCollection.ElementAt(i))));


#endregion
