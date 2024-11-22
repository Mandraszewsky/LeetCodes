using System.Text;

public class Solution
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    private static readonly Dictionary<string, int> romanSymbols = new Dictionary<string, int>
    {
            {"I", 1},
            {"II", 2},
            {"III", 3},
            {"IV", 4},
            {"V", 5},
            {"IX", 9},
            {"X", 10},
            {"XL", 40},
            {"L", 50},
            {"XC", 90},
            {"C", 100},
            {"CD", 400},
            {"D", 500},
            {"CM", 900},
            {"M", 1000}
    };

    static void Main(string[] args)
    {
        //var result = IndexesofSubarraySum([5, 3, 4], 2);
        //var result = MissingInArray([1, 2, 3, 5]);
        //var result = MaxSumInArray([2, 3, -8, 7, -1, 2, 3]);
        //var result = PeakElement([1, 1, 1]);
        //var result = KnapsackProblem(4, [1, 2, 3], [4, 5, 1]);
        //var result = StringPalindrome("mabam");
        //var result = FindPairGivenDifference([5, 20, 3, 2, 5, 80], 78);
        //var result = MatSearch([[3, 30, 38], [44, 52, 54], [57, 60, 62]], 62);
        //var result = MinNumberOfCoins(43);
        //var result = ProductPair([10, 20, 9, 40], 400);
        //var result = IntToRoman(100);

        //Console.WriteLine(result);

    }

    public static string IntToRoman(int num)
    {

        StringBuilder romanNumber = new StringBuilder();
        int i = romanSymbols.Count() - 1;

        string[] romanIndexes = new string []
        {
             "I","II","III","IV","V","IX","X","XL","L","XC","C","CD","D","CM","M"
        };

        while (num != 0)
        {
            if (num >= romanSymbols[romanIndexes[i]])
            {
                num -= romanSymbols[romanIndexes[i]];
                romanNumber.Append(romanIndexes[i]);
            }
            else
            {
                i--;
            }
        }

        return romanNumber.ToString();
    }

    public static bool ProductPair(int[] arr, long x)
    {
        //first try:
        //for (int i = 0; i < arr.Length; i++)
        //{
        //    for (int j = i + 1; j < arr.Length; j++)
        //    {
        //        if ((long)arr[i] * arr[j] == x)
        //            return true;
        //    }
        //}

        //return false;

        //second try (better):
        Array.Sort(arr);

        int left = 0; int right = arr.Length - 1;

        while (left < right)
        {
            long currentProduct = (long)arr[left] * arr[right];

            if (currentProduct == x)
                return true;

            if (currentProduct > x)
                right--;
            else
                left++;
        }

        return false;

    }


    public static List<int> MinNumberOfCoins(int n)
    {
        List<int> result = new List<int>();
        int[] currency = { 1, 2, 5, 10, 20, 50, 100, 200, 500, 2000 };

        for (int i = currency.Length - 1; i >= 0; i--)
        {
            while (n >= currency[i])
            {
                n -= currency[i];
                result.Add(currency[i]);
            }
        }

        return result;
    }

    public static bool MatSearch(int[][] mat, int x)
    {
        for (int i = 0; i < mat.Length; i++)
        {
            for (int j = 0; j < mat[i].Length; j++)
            {
                if (mat[i][j] == x)
                    return true;
            }
        }

        return false;
    }

    public static bool FindPairGivenDifference(int[] arr, int x)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[i] - arr[j] == x && i != j)
                    return true;
            }
        }

        return false;
    }


    public ListNode RemoveDuplicatesFromLinkedList(ListNode head)
    {
        ListNode current = head;

        while (current != null && current.next != null)
        {
            if (current.val == current.next.val)
            {
                current.next = current.next.next;
            } else
            {
                current = current.next;
            }
        }

        return head;
    }


    public static bool StringPalindrome(string str1)
    {
        char[] stringToChars = str1.ToCharArray();

        Array.Reverse(stringToChars);

        string str2 = new string(stringToChars);


        return str1 == str2 ? true : false;
    }


    public static int KnapsackProblem(int capacity, int[] val, int[] wt)
    {
        var itemsCount = val.Count();

        int[,] K = new int[itemsCount + 1, capacity + 1];

        for (int i = 0; i <= itemsCount; ++i)
        {
            for (int w = 0; w <= capacity; ++w)
            {
                if (i == 0 || w == 0)
                    K[i, w] = 0;
                else if (wt[i - 1] <= w)
                    K[i, w] = Math.Max(val[i - 1] + K[i - 1, w - wt[i - 1]], K[i - 1, w]);
                else
                    K[i, w] = K[i - 1, w];
            }
        }

        return K[itemsCount, capacity];
    }


    public static int[] PeakElement(int[] nums)
    {
        int[] peakElements = new int[nums.Length];
        int index = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (i == 0)
            {
                if (nums[i] >= nums[i + 1])
                    peakElements[index++] = nums[i];

            }
            else if (i >= 0 && i < nums.Length - 1) {
                if (nums[i] >= nums[i - 1] && nums[i] >= nums[i + 1])
                {
                    peakElements[index++] = nums[i];
                }
            }
            else if (i == nums.Length - 1) {
                if (nums[i] >= nums[i - 1])
                    peakElements[index++] = nums[i];
            }
        }

        return peakElements;
    }

    public static int MaxSumInArray(int[] nums)
    {
        int maxSum = nums[0];
        int currentSum = nums[0];

        for (int i = 0; i < nums.Length; i++)
        {
            currentSum = Math.Max(currentSum + nums[i], nums[i]);
            maxSum = Math.Max(maxSum, currentSum);
        }

        return maxSum;
    }

    public static int MissingInArray(int[] nums)
    {
        int missingIndex = 0;

        Array.Sort(nums);

        if (nums.Length == 1)
            missingIndex = 2;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] + 1 != nums[i + 1])
            {
                missingIndex = i + 2;
                break;
            }
        }

        return missingIndex;
    }

    public static int[] IndexesofSubarraySum(int[] nums, int target)
    {

        int result = 0;
        bool isTarget = false;
        int[] indexResult = new int[2];

        for (int i = 0; i < nums.Length; i++)
        {
            result = 0;
            indexResult[0] = i+1;

            for (int j = i; j < nums.Length; j++)
            {
                if (result == target)
                {
                    isTarget = true;
                    indexResult[1] = j;
                    break;
                }

                result = result + nums[j];
            }

            if (isTarget)
                break;
        }

        if(!isTarget)
            indexResult[0] = -1;


        return indexResult;
    }

    public static bool CanJump(int[] nums)
    {

        int landingIndex = 0;

        for (int currentIndex = 0; currentIndex < nums.Length; currentIndex++)
        {
            if (currentIndex > landingIndex)
            {
                return false;
            }

            if (landingIndex >= nums.Length)
            {
                return true;
            }

            landingIndex = Math.Max(landingIndex, currentIndex + nums[currentIndex]);
        }


        return true;
    }
}