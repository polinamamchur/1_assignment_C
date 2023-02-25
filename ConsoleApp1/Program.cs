using System.ComponentModel.Design;
using ConsoleApp1;

string variable = Console.ReadLine();
ArrayList tokens = new ArrayList();
Stack opers = new Stack();
Queue simbols = new Queue();
char[] operators = new[] { '+', '-', '*', '/' , '^'};
char[] brackets = new[] { '(', ')' };
string buff = "";
StackDouble calculate = new StackDouble();

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

    else if (isNumeric == false)

    {
        if (el == "(")
        {
            opers.Push("(");
        }
        if (el == "^")
        {
            opers.Push("^");
        }

        if (el == "*")
        {
            opers.Push("*");
            
        }

        if (el == "/")
        {
            opers.Push("/");
            
        }

        if (el == "+" || el == "-")

        {
            if (opers.Check("*") == "*" || opers.Check("/") == "/" || opers.Check("+") == "+" ||  opers.Check("-") == "-" || opers.Check("^") == "^")
            {
                simbols.Push(opers.Pull());
                opers.Push(el);

                
            }
            else
            {
                opers.Push(el);
                
            }
        }

        if (el == ")")
        {
            while (opers.Check("(") != "(")
            {
                simbols.Push(opers.Pull());
            }

            opers.Pull();
        }
    }
}
//Console.WriteLine(opers.Check("+"))

while (!opers.IsEmpty())
{
    simbols.Push(opers.Pull());
}


Console.WriteLine(string.Join(" ", simbols.GetElements())); 
foreach (string n in simbols)
{
    if ((n != "+" && n != "-" && n != "/" && n != "*" && n != "^"))
    {
        var nu = Convert.ToDouble(n);
        calculate.Push(nu);
    }
    else
    {
        var element1 = calculate.Pop();
        var element2 = calculate.Pop();
        if (n == "+")
        {
            double sum = element1 + element2;
            calculate.Push(sum);
        }
        else if (n == "-")
        {
            double diff = element2 - element1;
            calculate.Push(diff);
        }
        else if (n == "*")
        {
            double prod = element1 * element2;
            calculate.Push(prod);
        }
        else if (n == "/")
        {
            double quot = element2 / element1;
            calculate.Push(quot);
        }
        else if (n == "^")
        {
            double power = Math.Pow(element2, element1);
            calculate.Push(power);
        }
    }
}
Console.WriteLine(calculate.Pop());
