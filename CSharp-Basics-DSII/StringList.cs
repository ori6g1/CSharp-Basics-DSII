using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StringList
{
    public int Count { get; private set; }
    public int Capacity { get; private set; }

    private string[] _stringList;

    public StringList()
    {
        _stringList = new string[4];
        Capacity = 4;
        Count = 0;
    }

    public StringList(int size)
    {
        _stringList = new string[size];
        Capacity = size;
        Count = 0;
    }

    public void Add(string stringToAdd)
    {
        if (Capacity == Count)
            resizeArray();

        _stringList[Count] = stringToAdd;
        Count++;
    }

    public void Remove(string stringToRemove) 
    {  
        int indexToRemove = int.MaxValue;
        
        for (int i = 0; i < Count; i++)
            if (stringToRemove == _stringList[i])
            {
                indexToRemove = i;
                break;
            }

        if (indexToRemove == int.MaxValue)
        {
            Console.WriteLine($"The string \"{stringToRemove}\" was not found.");
            return;
        }
            
        setListWithoutRemoved(indexToRemove);
        Count--;
    }

    public void RemoveAt(int index) 
    {
        if(index > Count - 1)
            throw new IndexOutOfRangeException($"The index {index} is out of range.");

        setListWithoutRemoved(index);
        Count--;
    }

    public void Clear()
    {
        for (int i = 0; i < Count; i++)
            _stringList[i] = null;
        Count = 0;
    }

    public void Print()
    {
        Console.Write("[");
        
        if (Count > 0)
        {
            for (int i = 0; i < Count - 1; i++)
                Console.Write($"\"{_stringList[i]}\", ");
            Console.Write($"\"{_stringList[Count - 1]}\"");
        }
        Console.WriteLine(" ]");
    }

    private void setListWithoutRemoved(int indexToRemove)
    {
        if (indexToRemove != Capacity - 1)
        {
            for (int i = 0; i < Capacity - 1; i++)
            {
                if (i >= indexToRemove)
                    _stringList[i] = _stringList[i + 1];
                else
                    _stringList[i] = _stringList[i];
            }
            if (Capacity == Count) _stringList[Count - 1] = null;
        }
        else
            _stringList[indexToRemove] = null;
    }

    private void resizeArray()
    {
        int newCapacity = Capacity * 2;
        string[] newArray = new string[newCapacity];
        
        for (int i = 0; i < newCapacity; i++)
        {
            if (i < Capacity)
                newArray[i] = _stringList[i];
            else
                newArray[i] = null;
        }

        Capacity = newCapacity;
        _stringList = newArray;
    }
}