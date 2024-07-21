using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class Hangman
    {
        
        private string[] stages =
            {
                // final state: head, torso, both arms, and both legs
                """
                       --------
                       |      |
                       |      O      Your Last Chance !
                       |     \|/
                       |      |
                       |     / \
                       -
                    """,
                // head, torso, both arms, and one leg
                """
                       --------
                       |      |
                       |      O
                       |     \|/
                       |      |
                       |     / 
                       -
                    """,
                // head, torso, and both arms
                """
                       --------
                       |      |
                       |      O
                       |     \|/
                       |      |
                       |      
                       -
                    """,
                // head, torso, and one arm
                """
                       --------
                       |      |
                       |      O
                       |     \|
                       |      |
                       |     
                       -
                    """,
                // head and torso
                """
                       --------
                       |      |
                       |      O
                       |      |
                       |      |
                       |     
                       -
                    """,
                // head
                """
                       --------
                       |      |
                       |      O
                       |    
                       |      
                       |     
                       -
                    """,
                // initial empty state
                """
                       --------
                       |      |
                       |      
                       |    
                       |      
                       |     
                       -
                    """,
            };

        private static List<string> words = new List<string>()
        {
            "apple", "banana", "cherry", "grape", "orange", "peach", "plum", "berry", "melon", "lemon",
            "mango", "pearl", "pear", "kiwi", "fig", "date", "plum", "lime", "cocoa", "grape",
            "milk", "bread", "juice", "egg", "rice", "bean", "corn", "tuna", "pasta", "cake",
            "bacon", "cheese", "sausage", "salad", "soup", "pizza", "hamburger", "hotdog", "tofu", "yogurt",
            "chair", "table", "lamp", "sofa", "bed", "desk", "mirror", "door", "window", "rug",
            "shoe", "shirt", "hat", "coat", "sock", "scarf", "glove", "jeans", "skirt", "dress",
            "ball", "bat", "bike", "boat", "kite", "toy", "book", "pen", "pencil", "brush",
            "cup", "plate", "fork", "spoon", "knife", "bowl", "pot", "pan", "mug", "glass",
            "dog", "cat", "fish", "bird", "cow", "duck", "sheep", "pig", "horse", "goat",
            "sun", "moon", "star", "sky", "cloud", "rain", "wind", "snow", "storm", "fog",
            "car", "bus", "train", "plane", "truck", "bike", "boat", "ship", "taxi", "scooter"
        };
        public string this[int index]
        {
            get => index < 0 ? stages[0] : stages[index];
        }

        public static string GetRandomWord()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, words.Count);
            return words[randomNumber];
        }

       
    }
}
