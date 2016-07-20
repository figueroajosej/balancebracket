<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
</Query>

void Main()
{
      string[] tests = new string [13]
	  { 
        "[]",
        "{}",
        "{[]}",
        "[{}]",
        "{{",
        "[[",
        "[",
        "{",
        "{]",
        "][",
        "{{{{]]]]",
        "{{]",
		"{}((({{[]}()})))"
      };

      foreach(var t in tests)
	  {
        IsBalanced(t).Dump();
      }
}

// Define other methods and classes here
bool GetClosing(char b,out char c)
{
	Dictionary<char,char> brackets = new Dictionary<char, char>() 
	{
        { '(', ')' },
        { '[', ']' },
        { '{', '}' },
    };	
	return brackets.TryGetValue(b, out c);
}

bool IsBalanced(string input)
{
    Stack<char> s = new Stack<char>();
	  
	foreach(char b in input)
	{
		char c;
		if(GetClosing(b, out c))
		{  	
			s.Push(c);			
        }
		else
		{			
			if((s.Count == 0) || (b != s.Pop()))
			{        	
         	 	return false;
			}
		}
	}	
    return (s.Count == 0);
}


