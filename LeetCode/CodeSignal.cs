using System.Text;

namespace LeetCode;
public class CodeSignal
{
    //In this task, you are required to write a C# function that takes a string as input and identifies all consecutive groups of identical pairs of characters within it.
    //A group can be defined as a segment of the text where the same pair of characters is repeated consecutively.
    //Your function should return a string representing all the repeating character pairs and the number of their repetitions.
    //For instance, if the input string is "aaabbabbababaca", your function should output: "aa1ab1ba1bb1ab2ac1a1".
    //Note that if the length of the input string is odd, the last character is not paired with any other and is just added to the resulting string with repetition count 1.
    //Unlike in the lesson, the input strings for this task are guaranteed to consist only of lowercase alphabetic characters. The length of the string will not exceed 500 characters.

    public static string GetConsecutivePairs(string s)
    {
        StringBuilder output = new StringBuilder();
        string currentPair = null; string lastPair = null;
        int currentLength = 0;

        for (int i = 0; i < s.Length - 1; i += 2)
        {
            currentPair = s[i].ToString() + s[i + 1].ToString();

            if (currentPair == lastPair)
            {
                currentLength++;
            }
            else
            {
                if (lastPair != null)
                {
                    output.Append(lastPair);
                    output.Append(currentLength);
                }

                lastPair = currentPair;
                currentLength = 1;
            }
        }

        if (lastPair != null)
        {
            output.Append(lastPair);
            output.Append(currentLength);
        }

        if (s.Length % 2 != 0)
        {
            output.Append(s[s.Length - 1]);
            output.Append(1);
        }

        return output.ToString();
    }


    // *** Unusual Array Traversal ***
    // You are provided with an array of n integers, where n ranges from 1 to 501 and is always an odd number.
    // The elements of the array span values from -10^6 to 10^6, inclusive. The goal is to return a new array constructed by traversing the initial array in a specific order, outlined as follows:
    // 1) Begin with the middle element of the array.
    // 2) For each subsequent pair of elements, alternate between taking two elements from the left and two elements from the right, relative to the middle.
    // 3) If fewer than two elements remain on either side, include all the remaining elements from that side.
    // 4) Continue this process until all elements of the array have been traversed.
    // You cant use 
    // For example, for array = [1, 2, 3, 4, 5, 6, 7], your function should return [4, 2, 3, 5, 6, 1, 7]. And for array = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11], your function should return [6, 4, 5, 7, 8, 2, 3, 9, 10, 1, 11].

    public static List<int> UnusualTraversal(List<int> array)
    {
        List<int> output = new List<int>();

        int mid = array.Count / 2;
        int left = mid - 1; int right = mid + 1;

        output.Add(array[mid]);


        while (left >= 0 || right < array.Count)
        {

            if (left - 1 >= 0)
            {
                output.Add(array[left - 1]);
                output.Add(array[left]);
                left -= 2;
            }
            else if (left == 0)
            {
                output.Add(array[left]);
                left--;
            }

            if (right + 1 < array.Count)
            {
                output.Add(array[right]);
                output.Add(array[right + 1]);
                right += 2;
            }
            else if (right == array.Count - 1)
            {
                output.Add(array[right]);
                right++;
            }
        }

        return output;
    }

}
