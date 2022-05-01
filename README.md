# ExtensionMethods
A set of extension methods tested by **XUnit** .

### **Methods** :

- #### ``` DuplicatElements```

repeate elements in Source and put them in new Sequance of length you specify 
For Example :

input : {1 ,2 ,3 }
```
IEnumerable<int> OneTowThree = Enumerable.Range(1, 3);
int LengthOfNewSequance = 6; 
```

output : {1, 2, 3, 1, 2, 3}
```
IEnumerable<int> OneTowThreeOneTowThree = 
    OneTowThree.DuplicateElements(6);
```

- #### ``` Extend ```
repeate Enumerables in Source and put them in new Sequance of Enumerables of length you specify
For Example :

input:
{
    { 1, 2, 3 }
    { 4, 5, 6 }
}

```
List<List<int>> source = new()
{
    new List<int> { 1, 2, 3 },
    new List<int> { 4, 5, 6 }
};
```

output :
{
  { 1, 2, 3 }
  { 1, 2, 3 }
  { 4, 5, 6 }
  { 4, 5, 6 }
}

```
int ScalLength = 4;
var result = source
    .Extend(ScalLength);
```

- #### ``` Distribute ```
 Distribute all items in the ItemToBeDistributed Collection to all collections in the source
 For Example :

input:
SourceCollection
{
    { 1, 2, 3 }
    { 4, 5, 6 }
}
ItemToBeDistributedCollection
{ 8 , 9}

```
List<List<int>> SourceCollection = new()
{
    new List<int> { 1, 2, 3 },
    new List<int> { 4, 5, 6 }
};

IEnumerable<int> ItemToBeDistributedCollection = Enumerable
    .Range(8, SourceCollection.Count); //{8 , 9}
```

output
{
    { 1, 2, 3, 8 }
    { 1, 2, 3, 9 }
    { 4, 5, 6, 8 }
    { 4, 5, 6, 9 }
}

```
IEnumerable<IEnumerable<int>> OutputCollection = SourceCollection
    .Distribute(ItemToBeDistributedCollection);
```
