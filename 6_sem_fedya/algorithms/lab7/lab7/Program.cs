using System;

// Task 1
Console.WriteLine("Task 1");
Console.WriteLine(KmpAlgorithm("asjgfhksf_shdjsdbn", "_shdjsdbn"));
Console.WriteLine(KmpAlgorithm("123456782123", "lol"));

// Task 2
Console.WriteLine("\nTask 2");
BmAlgorithm("hello world", "l");

int[] GetPrefix(string str)
{
    var prefix = new int[str.Length];

    for (var i = 1; i < str.Length; i++)
    {
        var j = prefix[i - 1];
        
        while (j > 0 && str[i] != str[j])
        {
            j = prefix[j - 1];
        }

        if (str[i] == str[j])  prefix[i] = j + 1;
        else prefix[i] = j;
    }

    return prefix;
}

int KmpAlgorithm(string str, string temp)
{
    var prefix = GetPrefix(temp + '#' + str);
    for (var i = 0; i < str.Length; i++)
    {
        if (prefix[temp.Length + 1 + i] == temp.Length)
        {
            return i - temp.Length + 1;
        }
    }

    return -1;
}

int[] BadCharHeuristic(string str)
{
    var badChars = new int[256];

    for (var i = 0; i < badChars.Length; i++)
    {
        badChars[i] = -1;
    }
    
    for (var i = 0; i < str.Length; i++)
    {
        badChars[str[i]] = i;
    }

    return badChars;
}

void BmAlgorithm(string str, string tpl)
{
    var badChars = BadCharHeuristic(tpl);

    var shift = 0;
    
    while (shift <= (str.Length - tpl.Length))
    {
        var j = tpl.Length - 1;
        
        while (j >= 0 && tpl[j] == str[shift + j])
        {
            j--;
        }
        
        if (j < 0)
        {
            Console.WriteLine(shift);
            shift += (shift + tpl.Length < str.Length) ? tpl.Length - badChars[str[shift + tpl.Length]] : 1;
        }
        else
        {
            shift += Math.Max(1, j - badChars[str[shift + j]]);
        }
    }
}