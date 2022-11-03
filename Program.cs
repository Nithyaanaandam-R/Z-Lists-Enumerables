
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        List<int> list = new List<int>();

        list.Add(1);
        list.Add(2);
        list.Add(5);
        list.Add(6);
        list.Add(7);
        list.Add(3);
        list.Add(4);
        list.Add(9);
        list.Add(10);
        list.Add(8);

        foreach(int i in list)
            Console.Write(i);

        Console.Write("\n Sorted List:");
        list.Sort();
        
        foreach(int i in list)
            Console.Write(i);

        Console.WriteLine("Index for element 4 using BinarySearch(in built): " + list.BinarySearch(4));

        Console.WriteLine("Index for element 4 using IndexOf: " + list.IndexOf(4)); 
        
        //difference is that index of returns the first occurence of value at the list
        //while Binary Search is an logaarithm to find elements in sorted list
        //Indexof works in unsorted list as well as list with duplicate values
        //while such lists are avoided to perform binary search 

        Console.WriteLine("\n You can remove elements using the Remove function.");
        list.Remove(9);
        Console.WriteLine("\n After removing 9");
        list.ForEach(x => Console.Write(x));
        
        Console.WriteLine("\n We can also remove elements on a condition using RemoveAll()");
        list.RemoveAll(x=> x%2 ==0 );

        list.ForEach(x =>Console.Write(x + " "));

        //Implementing IEnumerable

        list.Add(10);
        list.Add(15);
        list.Add(20);
        list.Add(19);

        IEnumerable<int> list2 = list.Where(x=> x>10);
        List<int> list3 = list.Where(x => x > 10).ToList(); //LINQ statemets return IEnumerable by default
        
        list.RemoveAll(x => x > 10);

        Console.Write("\n Elements greater than 10 using IEnumerable: ");
        foreach(var x in list2)
        {
            Console.Write(x + " ");
        }

        Console.Write("\n Elements greater than 10 in List: ");
        list3.ForEach(x => Console.Write(x + " "));

        //You would expect list2 to print 15, 20, 19 
        //But it doesn't. This is because IEnumerable do not store values rather the queries
        //So the compiler doesn't gathr values greater than 10 while it reads line-65
        //Instead stores the LINQ and whenever the object created(list 2) is referenced 
        //as in called/used - like in line-62, the query is run and the iterables are found 

        Console.WriteLine();

        IEnumerator<int> enumerator = list.GetEnumerator();
        while (enumerator.MoveNext())
        {
            Console.Write(enumerator.Current + " ");
        }

        //IEnumerator is the inner interface implemeted by IEnumerable. It contains two methods. 
        //(1) Move to the next itrerable element -> returns false when there is no next elemnet
        //(2) Get the value of the current element

        Console.WriteLine();

        var sequence = fun();
        while (sequence.MoveNext())
        {
            Console.Write(sequence.Current + " ");
        }

    }

    public static IEnumerator<int> fun()
    {
        yield return 0;
        yield return 1; 
        yield return 2;                         //yield makes it so that the flow of control resumes from the next control line of the function on next iteration
        yield return 3;                         //making the iterator do different tasks (depending on need) over multiple iterations
        yield return 4;
        yield return 5;
    }
}

