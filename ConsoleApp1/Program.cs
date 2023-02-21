using ConsoleApp1;

const string variable = "21 + 3 / (32 - 567)";
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
    if (isNumeric == true)
    { 
        simbols.Push(el); 
       //Console.WriteLine(simbols);

    }

    if (isNumeric == false)
    {
        if (el == "*" || el == "/")
        {
            opers.Push(el);
        }
        if (el == "+" || el == "-")
        {
            if (opers.Check("*") == "*" || opers.Check("/") == "/")
            {
                //opers.Pull();
                opers.Push(el);
                Console.WriteLine(opers.GetElements()[0]);
            }
            else
            {
                //opers.Push(el);
            }
        }   
        //Console.WriteLine(opers.Check("+"));
        
        
        
    }    
    //Console.WriteLine("el = " + el);
    //Console.WriteLine("isNumeric = " + isNumeric);
}

//Console.WriteLine(opers.GetElements()[0]);









