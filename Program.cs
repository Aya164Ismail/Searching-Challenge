using System;
using System.Collections.Generic;
using System.Linq;

class MainClass
{

    public static string SearchingChallenge(string[] strArr)
    {
        for (int x = 0; x < strArr.Length; x++)
        {
            string s = "";
            if (x == 0)
            {
                s = strArr[x].Substring(2, strArr[x].Length - 3);
            }
            else if (x == strArr.Length - 1)
            {
                s = strArr[x].Substring(1, strArr[x].Length - 3);
            }
            else
            {
                s = strArr[x].Substring(1, strArr[x].Length - 2);
            }
            strArr[x] = s;
        }
        // code goes here
        List<string> splitNumber = new List<string>();
        List<string> characters = new List<string>();
        Array.Sort(strArr);
        int count = 0;
        for (int x = 0; x < strArr.Length; x++)
        {
            if (strArr == null)
            {
                break;
            }
            string[] spliting = strArr[x].Split(":");
            characters.Add(spliting[0]);
            splitNumber.Add(spliting[1]);
            if (count > 0)
            {
                if (characters[count - 1] == characters[count])
                {
                    splitNumber[count - 1] = (Int32.Parse(splitNumber[count - 1]) + Int32.Parse(splitNumber[count])).ToString();
                    characters.RemoveAt(count);
                    splitNumber.RemoveAt(count);
                    //count = count;
                }
                else
                {
                    count++;
                }
            }
            else if (splitNumber[x] == "0")
            {
                characters.RemoveAt(count);
                splitNumber.RemoveAt(count);
                count = x;
            }
            else
            {
                count++;
            }
        }
        string result = "";
        int countForZeroValue = 0;
        for (int x = 0; x < count; x++)
        {
            if (splitNumber[countForZeroValue] == "0")
            {
                characters.RemoveAt(x);
                splitNumber.RemoveAt(x);
                //countForZeroValue = countForZeroValue;
            }
            else if (result != "")
            {
                result = result + "," + characters[countForZeroValue] + ":" + splitNumber[countForZeroValue];
                countForZeroValue++;
            }
            else
            {
                result = characters[countForZeroValue] + ":" + splitNumber[countForZeroValue];
                countForZeroValue++;
            }
        }
        return result;
    }
    static void Main()
    {
        // keep this function call here
        Console.WriteLine(SearchingChallenge(Console.ReadLine().Split(", ")));
    }

}