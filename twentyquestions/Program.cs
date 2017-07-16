using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twentyquestions
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<Question> tree = new BinarySearchTree<Question>();

            Console.WriteLine(int.MaxValue / 2);

            Question first = new Question("is it a thing?", int.MaxValue / 2, false);

            tree.Add(first);


            while (true)
            {
                BSTNode<Question> current = tree.Root;
                BSTNode<Question> previous = null;
                bool lastWasYes = false;

                while (current != null)
                {
                    Console.WriteLine(current.Value);
                    string yesorno = Console.ReadLine();


                    if (yesorno == "yes" || yesorno == "yeah" || yesorno == "yea" || yesorno == "ye")  //yes is left btw
                    {
                        previous = current;
                        current = current.leftChild;
                        lastWasYes = true;
                    }
                    else if (yesorno == "no" || yesorno == "nah")  //therefore no is right
                    {
                        previous = current;
                        current = current.rightChild;
                        lastWasYes = false;
                    }
                    else
                    {
                        Console.WriteLine("i'm sorry i dont understand");
                    }

                }

                if (previous.Value.finalAnswer && lastWasYes)
                {
                    Console.WriteLine("yay! i got it right \n would you like to play again?");
                    string yesornah = Console.ReadLine();

                    if (yesornah == "yes" || yesornah == "yeah" || yesornah == "yea" || yesornah == "ye")
                    {
                        Console.WriteLine("\nlet's try this again");
                        continue;
                    }
                    else if (yesornah == "no" || yesornah == "nah")
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("i'm sorry i dont understand");
                    }
                }

                Console.WriteLine("oh no, i can't \n what was your word?");
                string answer = Console.ReadLine();
                Console.WriteLine("what would be a question that you would respond yes to if you were thinking about {0}?", answer);
                string newQuestion = Console.ReadLine();
                int newID = 0;
                int upperBound = 0;
                int lowerBound = 0;
                if (lastWasYes)
                {
                    lowerBound = tree.ToList().Where(x => x.ID < previous.Value.ID).LastOrDefault()?.ID ?? 0;
                    upperBound = previous.Value.ID;
                }
                else
                {
                    lowerBound = previous.Value.ID;
                    upperBound = tree.ToList().Where(x => x.ID > previous.Value.ID).FirstOrDefault()?.ID ?? int.MaxValue;

                }
                newID = lowerBound + (upperBound - lowerBound) / 2;
                tree.Add(new Question(newQuestion, newID, false));
                if(!lastWasYes)
                {
                    upperBound = newID;
                    lowerBound = previous.Value.ID;
                    tree.Add(new Question($"is it {answer}?", lowerBound + (upperBound - lowerBound) / 2, true));
                }
                else
                {
                    upperBound = newID;
                    tree.Add(new Question($"is it {answer}?", lowerBound + (upperBound - lowerBound) / 2, true));
                }
                Console.WriteLine("\nlet's try this again");

            }
            

            foreach (Question item in tree.ToList())
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
            
    }
}

