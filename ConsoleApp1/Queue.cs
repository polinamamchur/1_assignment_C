namespace ConsoleApp1;

public class Queue
{
    private const int Capacity = 50;

    private string[] _array = new string[Capacity];

    private int _pointer;

    public void Push(string value)
    {
        if (_pointer == _array.Length)
        {
            // this code is raising an exception about reaching stack limit
            throw new Exception("Stack overflowed");
        }

        _array[_pointer] = value;
        _pointer++;
    }

    public string Pull()
    {
        if (_pointer == 0)
        {
            //you can also raise an exception here, but we're simple returning nothing
            return null;
        }

        var value = _array[0];

        // змістити елементи списку ліворуч на одиницю
        for (int i = 1; i <= _pointer; i++)
        {
            int index = i - 1;
            _array[index] = _array[i];
            Console.WriteLine("index = " + index);
            Console.WriteLine(_array[index]); 
        }
        
        _pointer--;


        // _array.RemoveAt(value);
        return value;
    }
}
