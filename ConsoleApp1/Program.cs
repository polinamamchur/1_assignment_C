const string variable = "21 + (32 - 567)";
ArrayList tokens = new ArrayList();
Stack simbols = new Stack();
//Queue<string> d = new Queue<string>();
char[] operators = new[] { '+', '-', '*', '/' };
char[] brackets = new[] { '(', ')' };
string buff = "";

// char? oper = null;


foreach (var s in variable)
{ 
    if (s == ' ')
    { 
        continue;
    }
    
    if (Char.IsDigit(s)) 
    {
        buff += s;
    }
    else
    {
        if (buff != "")
        {
            tokens.Add(buff);
            buff = "";
        }
        
        tokens.Add(s + "");
        
    }
}

if (buff != "")
{ 
    tokens.Add(buff);
}

//Console.WriteLine(tokens);
//tokens.RemoveAt(tokens.Count - 1);
//Console.WriteLine(tokens.GetElements()[0]);
//tokens.RemoveAt(0);

foreach (var el in tokens.GetElements())
{
    Console.WriteLine(el);
}



//foreach (var token in tokens)


//Stack<string> simbols = new Stack<string>(tokens);
//foreach (var simbol in simbols) Console.WriteLine(simbol);
//simbols.Pop("21");


public class ArrayList
{
    private string[] _array = new string[10];

    private int _pointer = 0;

    public void Add(string element)
    {
        _array[_pointer] = element;
        _pointer += 1;

        if (_pointer == _array.Length)
        {
            var extendedArray = new string[_array.Length * 2];
            for (var i = 0; i < _array.Length; i++)
            {
                extendedArray[i] = _array[i];
            }

            _array = extendedArray;
            //this also can be achieved via
            //Array.Resize(ref _array, _array.Length * 2);
        }
    }

    public void Remove(string element)
    {
        for (var i = 0; i < _pointer; i++)
        {
            if (_array[i] == element)
            {
                for (var j = i; j < _pointer - 1; j++)
                {
                    _array[j] = _array[j + 1];
                }

                _pointer -= 1;
                return;
            }
        }
    }

    public string GetAt(int index)
    {
        return _array[index];
    }

    public int IndexOf(string element)
    {
        for (var i = 0; i < _array.Length; i++)
        {
            if (_array[i] == element)
            {
                return i;
            }
        }
        return -1;
    }
    
    public bool Contains(string element)
    {
        return IndexOf(element) != -1;
    }
    
    public int Count()
    {
        return _pointer;
    }

    public string[] GetElements()
    {
        return _array;
    }
}

public class Stack
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

        var value = _array[_pointer];
        _pointer--;
        return value;
    }
}

