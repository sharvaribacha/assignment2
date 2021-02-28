using System;
using System.Collections.Generic;
using System.Linq;

namespace assignment2
{
    class SharvariAssignment
    {
        static void Main(string[] args)
        {
            //Question1:
            int[] ar1 = { 2, 5, 1, 3, 4, 7 };
            int n1 = 3;
            ShuffleArray(ar1, n1);

            //Question 2 
            Console.WriteLine("Question 2");
            int[] ar2 = { 0, 1, 0, 3, 12 };
            MoveZeroes(ar2);
            Console.WriteLine("");

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 1, 2, 3, 1, 1, 3 };
            CoolPairs(ar3);
            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            int[] ar4 = { 2, 7, 11, 15 };
            int target = 9;
            TwoSum(ar4, target);
            Console.WriteLine();

            //Question 5
            Console.WriteLine("Question 5");
            string s5 = "korfsucy";
            int[] indices = { 6, 4, 3, 2, 1, 0, 5, 7 };
            RestoreString(s5, indices);
            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            string s61 = "bulls";
            string s62 = "sunny";
            if (Isomorphic(s61, s62))
            {
                Console.WriteLine("Yes the two strings are Isomorphic");
            }
            else
            {
                Console.WriteLine("No, the given strings are not Isomorphic");
            }
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int n8 = 19;
            if (HappyNumber(n8))
            {
                Console.WriteLine("{0} is a happy number", n8);
            }
            else
            {
                Console.WriteLine("{0} is not a happy number", n8);
            }
            Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            int[] ar9 = { 7, 1, 5, 3, 6, 4 };
            int profit = Stocks(ar9);
            if (profit == 0)
            {
                Console.WriteLine("No Profit is possible");
            }
            else
            {
                Console.WriteLine("Profit is {0}", profit);
            }
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int n10 = 3;
            Stairs(n10);
            Console.WriteLine();
        }
        //Question 1
        /// <summary>
        /// Shuffle the input array nums consisting of 2n elements in the form [x1,x2,...,xn,y1,y2,...,yn].
        /// Print the array in the form[x1, y1, x2, y2, ..., xn, yn].
        ///Example 1:
        ///Input: nums = [2,5,1,3,4,7], n = 3
        ///Output: [2,3,5,4,1,7]
        ///  Explanation: Since x1 = 2, x2 = 5, x3 = 1, y1 = 3, y2 = 4, y3 = 7 then the answer is [2,3,5,4,1,7].
        ///Example 2:
        ///Input: nums = [1,2,3,4,4,3,2,1], n = 4
        ///Output: [1,4,2,3,3,2,4,1]
        ///Example 3:
        ///Input: nums = [1,1,2,2], n = 2
        ///Output: [1,2,1,2]
        /// </summary>

        private static void ShuffleArray(int[] input, int n)
        {
            try
            {
                int[] finalResult = new int[input.Length];
                int size = input.Length;                    // Size of array to run loop
                int[] xvalues = new int[n];                 // int array to store xvalues (first n values)
                int[] yvalues = new int[n];                // int array to store yvalues (last n values)
                for (int f = 0; f < size; f++)
                {
                    if (f < n)
                    {
                        xvalues[f] = input[f];          // First n values, f = 0 to f = n-1
                    }
                    else
                    {
                        yvalues[f - n] = input[f];          // Last n values, f = n to f = size-1
                    }
                }
                int i = 0, j = 0, k = 0;
                while (i < n && j < n)
                {
                    finalResult[k++] = xvalues[i++];             // Fills elements from xvalues and yvalues alternatively
                    finalResult[k++] = yvalues[j++];
                }
                while (i < n)
                    finalResult[k++] = xvalues[i++];           // If any element is left behind from xvalues
                while (j < n)
                    finalResult[k++] = yvalues[j++];
                string space = "[";
                foreach (int x in finalResult)
                {
                    Console.Write(space + x);
                    space = ",";
                }
                Console.Write("]");
                Console.WriteLine();
                Console.WriteLine();
            }
            catch (Exception)
            {
                throw new Exception("Exception at Question1");
            }
        }

        //Question 2:
        /// <summary>
        /// Write a method to move all 0's to the end of the given array. You should maintain the relative order of the non-zero elements. 
        /// You must do this in-place without making a copy of the array.
        /// Example:
        ///Input: [0,1,0,3,12]
        /// Output: [1,3,12,0,0]
        /// </summary>

        private static void MoveZeroes(int[] input)
        {
            try
            {
                int n = input.Length;      // Size of the input array for looping                                        
                int count = 0;
                for (int i = 0; i < n; i++)
                {
                    if (input[i] != 0)
                    {
                        input[count++] = input[i];       // Adjusting the non-zero values first
                    }
                }
                while (count < n)
                {
                    input[count++] = 0;       // Filling zeros at the end
                }
                string space = "[";
                foreach (int i in input)
                {
                    Console.Write(space + i);
                    space = ",";
                }
                Console.Write("]");
                Console.WriteLine();
            }
            catch (Exception)
            {
                throw new Exception("Exception at Question2");
            }
        }

        //Question 3
        /// <summary>
        /// For an array of integers - nums
        ///A pair(i, j) is called cool if nums[i] == nums[j] and i<j
        ///Print the number of cool pairs
        ///Example 1
        ///Input: nums = [1,2,3,1,1,3]
        ///Output: 4
        ///Explanation: There are 4 cool pairs (0,3), (0,4), (3,4), (2,5) 
        ///Example 3:
        ///Input: nums = [1, 2, 3]
        ///Output: 0
        ///Constraints: time complexity should be O(n).
        /// </summary>

        private static void CoolPairs(int[] input)
        {
            try
            {
                int coolPairs = 0;
                int size = input.Length;
                Dictionary<int, int> countDict = new Dictionary<int, int>();     // Creating Dictionary for storing the frequency
                for (int i = 0; i < size; i++)
                {
                    if (countDict.ContainsKey((int)input[i]))
                    {                           // Finding frequency of each element
                        countDict[(int)input[i]] += 1;
                    }
                    else
                    {
                        countDict.Add((int)input[i], 1);
                    }
                }
                foreach (KeyValuePair<int, int> kv in countDict)
                {                         // Depending on frequency, calculating the cool pairs
                    if (kv.Value > 1)
                    {
                        coolPairs += ((kv.Value - 1) * (kv.Value)) / 2;
                    }
                }
                Console.WriteLine(coolPairs);
            }
            catch (Exception)
            {
                throw new Exception("Exception at Question3");
            }
        }

        //Question 4:
        /// <summary>
        /// Given integer target and an array of integers, print indices of the two numbers such that they add up to the target.
        ///You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /// You can print the answer in any order
        ///Example 1:
        ///Input: nums = [2,7,11,15], target = 9
        /// Output: [0,1]
        ///Output: Because nums[0] + nums[1] == 9, we print [0, 1].
        ///Example 2:
        ///Input: nums = [3,2,4], target = 6
        ///Output: [1,2]
        ///Example 3:
        ///Input: nums = [3,3], target = 6
        ///Output: [0,1]
        ///Constraints: Time complexity should be O(n)
        /// </summary>
        private static void TwoSum(int[] nums, int target)
        {
            try
            {
                int[] finalSumPair = new int[2];
                HashSet<int> hashset = new HashSet<int>();         // Hashset for storing element and checking
                for (int i = 0; i < nums.Length; i++)
                {
                    if (hashset.Contains(target - nums[i]))
                    {                               // Checking if already have the difference
                        finalSumPair[0] = target - nums[i];
                        finalSumPair[1] = i;       // storing the index
                    }
                    hashset.Add(nums[i]);        // Adding the number to the hashset
                }
                for (int i = 0; i < nums.Length; i++)
                {
                    if (finalSumPair[0] == nums[i])
                    {
                        finalSumPair[0] = i;          // storing the index
                    }
                }
                string space = "[";
                foreach (int x in finalSumPair)
                {
                    Console.Write(space + x);
                    space = ",";
                }
                Console.Write("]");
                Console.WriteLine();
            }
            catch (Exception)
            {
                throw new Exception("Exception at Question4");
            }
        }

        //Question 5:
        /// <summary>
        /// Given a string s and an integer array indices of the same length.
        ///The string s will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.
        ///Print the shuffled string.
        ///Example 1
        ///Input: s = "korfsucy", indices = [6,4,3,2,1,0,5,7]
        ///Output: "usfrocky"
        ///Explanation: As shown in the assignment document, “K” should be at index 6, “O” should be at index 4 and so on. “korfsucy” becomes “usfrocky”
        ///Example 2:
        ///Input: s = "USF", indices = [0,1,2]
        ///Output: "USF"
        ///Explanation: After shuffling, each character remains in its position.
        ///Example 3:
        ///Input: s = "ockry", indices = [1, 2, 3, 0, 4]
        ///Output: "rocky"
        /// </summary>
        private static void RestoreString(string s5, int[] indices)
        {
            try
            {
                char[] s = s5.ToCharArray();                                                                // Char array to store characters of the string
                var dictionary = indices.Zip(s, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);   // Mapping the indices with respective characters
                var finalDictionary = new SortedDictionary<int, char>(dictionary);                          // Sorting the dictionary according to the keys .i.e., indices
                string answer = "";
                foreach (KeyValuePair<int, char> kv in finalDictionary)
                {
                    answer += kv.Value;
                }
                Console.WriteLine(answer);
            }
            catch (Exception)
            {
                throw new Exception("Exception at Question5");
            }
        }

        //Question 6
        /// <summary>
        /// Determine whether two give strings s1 and s2, are isomorphic.
        ///Two strings are isomorphic if the characters in s1 can be replaced to get s2.
        ///All occurrences of a character must be replaced with another character while preserving the order of characters.
        ///No two characters may map to the same character but a character may map to itself.
        ///Example 1:
        ///Input:s1 = “bulls” s2 = “sunny” 
        ///Output : True
        ///Explanation: ‘b’ can be replaced with ‘s’ and similarly ‘u’ with ‘u’, ‘l’ with ‘n’ and ‘s’ with ‘y’.
        ///Example 2:
        ///Input: s1 = “usf” s2 = “add”
        ///Output : False
        ///Explanation: ‘u’ can be replaced with ‘a’, but ‘s’ and ‘f’ should be replaced with ‘d’ to produce s2, which is not possible. So False.
        ///Example 3:
        ///Input : s1 = “ab” s2 = “aa”
        ///Output: False
        /// </summary>
        private static bool Isomorphic(string st1, string st2)
        {
            try
            {
                char[] s1 = st1.ToCharArray();             // Converting string into characters
                char[] s2 = st2.ToCharArray();            // Converting string into characters
                Dictionary<char, char> hashmap = new Dictionary<char, char>();        // hashmap to map corresponding characters
                bool decision = true;
                for (int i = 0; i < s1.Length; i++)
                {
                    if (hashmap.ContainsKey(s1[i]))
                    {
                        if (hashmap[s1[i]] == s2[i])
                        {
                            continue;
                        }
                        else
                        {
                            decision = false;
                            break;
                        }
                    }
                    if (hashmap.ContainsValue(s2[i]))
                    {
                        var myKey = hashmap.FirstOrDefault(x => x.Value == s2[i]).Key;
                        if (s1[i] == myKey)
                        {
                            continue;
                        }
                        else
                        {
                            decision = false;
                            break;
                        }
                    }
                    else
                    {
                        hashmap.Add(s1[i], s2[i]);
                    }
                }
                if (decision)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw new Exception("Exception at Question6");
            }
        }

        //Question 7
        /// <summary>
        /// Given a list of the scores of different students, items, where items[i] = [IDi, scorei]
        ///represents one score from a student with IDi, calculate each student's top five average.
        /// Print the answer as an array of pairs result, where result[j] = [IDj, topFiveAveragej] represents the student with IDj and their top five average.Sort result by IDj in increasing order.
        /// A student's top five average is calculated by taking the sum of their top five scores and dividing it by 5 using integer division.
        /// Example 1:
        /// Input: items = [[1, 91], [1,92], [2,93], [2,97], [1,60], [2,77], [1,65], [1,87], [1,100], [2,100], [2,76]]
        /// Output: [[1,87],[2,88]]
        /// Explanation: 
        /// The student with ID = 1 got scores 91, 92, 60, 65, 87, and 100. Their top five average is (100 + 92 + 91 + 87 + 65) / 5 = 87.
        /// The student with ID = 2 got scores 93, 97, 77, 100, and 76. Their top five average is (100 + 97 + 93 + 77 + 76) / 5 = 88.6, but with integer division their average converts to 88.
        /// Example 2:
        /// Input: items = [[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100]]
        /// Output: [[1,100],[7,100]]
        /// Constraints:
        /// 1 <= items.length <= 1000
        /// items[i].length == 2
        /// 1 <= IDi <= 1000
        /// 0 <= scorei <= 100
        /// For each IDi, there will be at least five scores.
        /// </summary>
        private static void HighFive(int[,] students)
        {
            try
            {
                int rowsBegin = students.GetLowerBound(0);
                int rowsEnd = students.GetUpperBound(0);
                int nRows = rowsEnd - rowsBegin + 1;
                int columnsBegin = students.GetLowerBound(1);
                int columnsEnd = students.GetUpperBound(1);
                int nColumns = columnsEnd - columnsBegin + 1;
                int[][] jArray = new int[nRows][];          // Converting 2D array to jagged array
                for (int i = 0; i < nRows; i++)
                {
                    jArray[i] = new int[nColumns];
                    for (int j = 0; j < nColumns; j++)
                    {
                        jArray[i][j] = students[i + rowsBegin, j + columnsBegin];
                    }
                }
                var dict = new Dictionary<int, int[]>();        // Dictionary to store keys and values array
                foreach (int[] x in jArray)
                {
                    if (dict.ContainsKey(x[0]))
                    {
                        int i = 0;
                        int[] temp = new int[dict[x[0]].Length + 1];
                        foreach (int val in dict[x[0]])
                        {
                            temp[i] = val;
                            i++;
                        }
                        temp[i] = x[1];
                        dict[x[0]] = temp;
                    }
                    else
                    {
                        dict[x[0]] = new int[] { x[1] };
                    }
                }
                var result = new Dictionary<int, int>();          // Dictionary to store averages
                foreach (KeyValuePair<int, int[]> kv in dict)
                {
                    int sum = 0;
                    int[] temp = kv.Value;
                    for (int x = 0; x < 5; x++)
                    {
                        int maxVal = temp.Max();
                        sum += maxVal;
                        int f = Array.IndexOf(temp, maxVal);
                        List<int> temp2 = new List<int>(temp);
                        temp2.RemoveAt(f);
                        temp = temp2.ToArray();
                    }
                    result[kv.Key] = sum / 5;
                }
                foreach (KeyValuePair<int, int> kv in result)
                {
                    Console.WriteLine("[" + kv.Key + "," + kv.Value + "]");
                }
            }
            catch (Exception)
            {
                throw new Exception("Exception at Question7");
            }
        }

        //Question 8
        /// <summary>
        /// Write an algorithm to determine if a number n is happy.
        ///A happy number is a number defined by the following process:
        ///•	Starting with any positive integer, replace the number by the sum of the squares of its digits.
        ///•	Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
        ///•	Those numbers for which this process ends in 1 are happy.
        ///Return true if n is a happy number, and false if not.
        ///Example 1:
        ///Input: n = 19
        ///Output: true
        ///Explanation:
        ///12 + 92 = 82
        ///82 + 22 = 68
        ///62 + 82 = 100
        ///12 + 02 + 02 = 1
        ///Example 2:
        ///Input: n = 2
        ///Output: false
        ///Constraints:
        ///1 <= n <= 231 - 1
        /// </summary>

        private static bool HappyNumber(int n)
        {
            try
            {
                char[] sn = n.ToString().ToCharArray();
                int[] fn = Array.ConvertAll(sn, c => (int)Char.GetNumericValue(c));            // Converting the number into char array
                while (sn.Length > 1)
                {                            // Processing
                    int sum = 0;
                    for (int i = 0; i < fn.Length; i++)
                    {
                        sum += (int)Math.Pow(fn[i], 2);
                    }
                    sn = sum.ToString().ToArray();
                    fn = Array.ConvertAll(sn, c => (int)Char.GetNumericValue(c));
                }
                if (fn[0] == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw new Exception("Exception at Question8");
            }
        }

        //Question 9
        /// <summary>
        /// Professor Manish is planning to invest in stocks. He has the data of the price of a stock for the next n days.  
        /// Tell him the maximum profit he can earn from the given stock prices.Choose a single day to buy a stock and choose another day in the future to sell the stock for a profit
        /// If you cannot achieve any profit return 0.
        /// Example 1:
        /// Input: prices = [7,1,5,3,6,4]
        /// Output: 5
        /// Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        /// Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
        /// Example 2:
        /// Input: prices = [7,6,4,3,1]
        /// Output: 0
        ///Explanation: In this case, no transactions are done and the max profit = 0.
        ///Try to solve it in O(n) time complexity.
        /// </summary>

        private static int Stocks(int[] prices)
        {
            try
            {
                int maxVal = 0;
                int temp = -1;
                int n = prices.Length;
                
                for (int i = 0; i < n; i++) // finding minimum stock to buy
                {
                    if (temp < 0)  //if the initiator value is less than 0 
                    {
                        temp = prices[i];
                    }
                    if (temp > prices[i]) //if the initiator value is greater than 0 
                    {
                        temp = prices[i];
                    }
                    else
                    {
                        if (prices[i] - temp > maxVal) //finding the maximum stock to sell 
                        {
                            maxVal = prices[i] - temp;
                        }
                    }
                }
                return maxVal;
            }
            catch (Exception)
            {
                throw new Exception("Exception at Question9");
            }
        }

        //Question 10
        /// <summary>
        /// Professor Clinton is climbing the stairs in the Muma College of Business. He generally takes one or two steps at a time.
        /// One day he came across an idea and wanted to find the total number of unique ways that he can climb the stairs. Help Professor Clinton.
        /// Print the number of unique ways. 
        /// Example 1:
        ///Input: n = 2
        ///Output: 2
        ///Explanation: There are two ways to climb to the top.
        ///1. 1 step + 1 step
        ///2. 2 steps
        ///Example 2:
        ///Input: n = 3
        ///Output: 3
        ///Explanation: There are three ways to climb to the top.
        ///1. 1 step + 1 step + 1 step
        ///2. 1 step + 2 steps
        ///3. 2 steps + 1 step
        ///Hint : Use the concept of Fibonacci series.
        /// </summary>

        private static void Stairs(int steps)
        {
            try
            {
                int n = steps + 1;
                int[] fibVal = new int[n + 1];
                fibVal[0] = 0;
                fibVal[1] = 1;
                for (int i = 2; i <= n; i++) //finding number of ways to walk 
                {
                    fibVal[i] = fibVal[i - 2] + fibVal[i - 1];
                }
                Console.WriteLine(fibVal[n]);
            }
            catch (Exception)
            {
                throw new Exception("Exception at Question10");
            }
        }
    }
}
