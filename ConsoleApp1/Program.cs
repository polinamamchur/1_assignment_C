using ConsoleApp1;

const string variable = "4 + (32 / 8) ";
ArrayList tokens = new ArrayList();
Stack opers = new Stack();
Queue simbols = new Queue();
char[] operators = new[] { '+', '-', '*', '/' };
char[] brackets = new[] { '(', ')' };
string buff = "";
Stack calculate = new Stack();

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
       
        // if (tokens.Contains(el))
        // {
        //     var priority = priorities[el];
        // }
        
        if (el == "+" || el == "-" || el == "*" || el == "/")
        {
            if (opers.Check("*") == "*" || opers.Check("/") == "/")
            { 
                simbols.Push(opers.Pull());
                opers.Push(el);
                
            }
            else
            {
                opers.Push(el);
                
            }
            if (el == ")")
            {
                while (opers.Check("(") != "(")
                {
                    simbols.Push(opers.Pull());
                    
                }
                
            }
        }
        //Console.WriteLine(opers.Check("+"));
    }
   
}

while (!opers.IsEmpty())
{
   simbols.Push(opers.Pull());
       
}

foreach (var n in simbols.GetElements())
{
    int number;
    bool isNumeric = int.TryParse(n, out number);
    if (isNumeric == true)
    {
        calculate.Push(n);
    }
    else
    {
        float element1, element2;

        if (float.TryParse(calculate.Pop(), out element1) && float.TryParse(calculate.Pop(), out element2))
        {
            if (n == "+")
            {
                float sum = element1 + element2;
                //Console.WriteLine("sum =" + sum);
                string result1 = sum.ToString();
                calculate.Push(result1);
            }
            else if (n == "-")
            {
                float diff = element1 - element2;
                string result2 = diff.ToString();
                calculate.Push(result2);
            }
            else if (n == "*")
            {
                float prod = element1 * element2;
                string result3 = prod.ToString();
                calculate.Push(result3);
            }
            else if (n == "/")
            {
                float quot = element1 / element2;
                string result4 = quot.ToString();
                calculate.Push(result4);
                
            }
            Console.WriteLine(calculate.Pop());
            
        }

    }
   
}








