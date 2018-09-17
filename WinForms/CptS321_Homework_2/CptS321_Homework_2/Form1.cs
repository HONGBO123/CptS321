using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CptS321_Homework_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Variables for use in generating random int list
            int minRange = 0, maxRange = 20000, maxSize = 10000;

            Random rand = new Random();

            // initialize new list of size maxSize
            List<int> randomInts = new List<int>(maxSize);

            // generates maxSize # of random ints and adds to list randomInts
            for (int i = 0; i < maxSize; i++)
            {
                randomInts.Add(rand.Next(minRange, maxRange));
            }

            
            // BEGIN APPROACH 1
            // This approach includes one for loop, which iterates n times, so that is immediately O(N) complexity, then we have an if statement, 
            // including 2 functions (ContainsKey() and Add()) which are both constant time, therefore our time complexity worst case is O(N)
            // initialize Dictionary for approach 1
            Dictionary<int, int> approachOne = new Dictionary<int, int>(maxSize);

            // Add each int in randomInts into dictionary approachOne, as long as it does not already contain that int
            foreach (int x in randomInts)
            {
                // Enter if statement if dictionary does not already contains value num
                if (!approachOne.ContainsKey(x))
                {
                    // Hash in value num
                    approachOne.Add(x, x);
                }
            }
            // Final count of unique numbers in approachOne
            int approachOneCount = approachOne.Count;

            // BEGIN APPROACH 2

            // Counter for each unique number
            int approachTwoCount = 0;
            // 2 loops to compare every value to every value in the same randomInts list
            for (int i = 0; i < maxSize; i++)
            {
                // Start with true,
                bool unique = true;
                // Always start one higher than i so you don't compare the same value
                for (int j = i + 1; j < maxSize && unique; j++)
                {
                    // found duplicate, unique = false
                    if (randomInts[i] == randomInts[j])
                    {
                        unique = false;
                    }
                }
                // no duplicate, unique = true still, increment counter
                if (unique)
                {
                    approachTwoCount++;
                }
            }

            // BEGIN APPROACH 3

            // Built in sort for lists
            randomInts.Sort();

            // counter for unique ints
            int approachThreeCount = 0;

            // log (n), one for loop to go through the whole list
            for (int i = 1; i <= maxSize; i++)
            {
                // Base case, compare the last index with a number higher than possible
                if ((i == (maxSize)) && (randomInts[i - 1] < (maxRange + 1)))
                {
                    approachThreeCount++;
                }
                // Since it's sorted we can just compare pairs of values, iterating down the list
                else if (randomInts[i] > randomInts[i-1])
                {
                    // unique int, iterate counter
                    approachThreeCount++;
                }
            }
            textBox1.Text = "1. HashSet method: " + approachOneCount.ToString() + " unique numbers" + Environment.NewLine +
                            "This method is O(N), we have one loop, iterating through the whole list and then two constant functions, containsKey() and Add()" + Environment.NewLine +
                            "2. O(1) storage method: " + approachTwoCount.ToString() + " unique numbers" + Environment.NewLine +
                            "3. Sorted method: " + approachThreeCount.ToString() + " unique numbers" + Environment.NewLine;


        }
    }
}
