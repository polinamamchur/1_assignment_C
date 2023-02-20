using ConsoleApp1;

const string variable = "21 + (32 - 567)";
ArrayList tokens = new ArrayList();
Stack opers = new Stack();
Queue simbols = new Queue();
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
        if (buff.Length > 0)
        {
            tokens.Add(buff);
            buff = "";
        }
        
        tokens.Add(s + "");
        
    }
}

if (buff.Length > 0)
{ 
    tokens.Add(buff);
}

//Console.WriteLine(tokens);
//tokens.RemoveAt(tokens.Count - 1);
//Console.WriteLine(tokens.GetElements()[0]);
//tokens.RemoveAt(0);

foreach (var el in tokens.GetElements())
{
    //Console.WriteLine(el);
    int number;
    bool isNumeric = int.TryParse(el, out number);
    Console.WriteLine("el = " + el);
    Console.WriteLine("isNumeric = " + isNumeric);
}


//foreach (var token in tokens)


//Stack<string> simbols = new Stack<string>(tokens);
//foreach (var simbol in simbols) Console.WriteLine(simbol);
//simbols.Pop("21")


Queue b = new Queue();
b.Push("3");
b.Push("a");
string pull = b.Pull();
string pull2 = b.Pull();
Console.WriteLine("pull = " + pull );
Console.WriteLine("pull2 = " + pull2 );







