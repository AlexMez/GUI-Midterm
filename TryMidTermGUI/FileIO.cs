using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TryMidTermGUI
{
    class FileIO
    {

        public static List<Books> GetList()
        {

            //new list called catalogue
            List<Books> Catalogue = new List<Books>();
            StreamReader reader = new StreamReader("../../OurDataBase.txt ");

            //this is one line from text file or one book
            char[] comma = { ',' };
            var lineCount = File.ReadLines("../../OurDataBase.txt").Count();
            for (int i = 0; i < lineCount; i++)

            {
                string line = reader.ReadLine();
                //string[] book = new string[4];
                string[] book = line.Split(comma);
                string Title = book[0];
                string Author = book[1];
                string Status = book[2];
                string DueDate = book[3];
                Catalogue.Add(new Books(Title, Author, Status, DueDate));
            }
            reader.Close();
            return Catalogue;
        }

        public static void Checkout(List<Books> inputCatalogue, string ItemToCheckOut)
        {

            // Console.Write("Please Enter The Name Of The Book You Would Like To Check Out: ");
            ItemToCheckOut = ItemToCheckOut.ToUpper();
            DateTime myDateTime = new DateTime();
            myDateTime = DateTime.Now;
            int count = 0;
            foreach (var item in inputCatalogue)
            {
                string TitleUpper = item.BTitle.ToUpper();

                if (TitleUpper == ItemToCheckOut && !(item.BStatus == "Checked-out"))
                {

                    item.BStatus = "Book is Checked-out";
                    item.BDueDate = myDateTime.AddDays(14).ToShortDateString();
                    //Console.WriteLine($"{item.BTitle} is checked out.");
                    //Console.WriteLine($"and is Due Back On {item.BDueDate}");

                    MessageBox.Show($"{item.BTitle} is checked out.");
                    MessageBox.Show($"and is Due Back On {item.BDueDate}");

                }

                else
                {
                    count++;
                }
            }

            if (count == inputCatalogue.Count)
            {
                MessageBox.Show("Book is Not Available");
                //Console.WriteLine("Book is Not Available");
            }

            WriteToText(inputCatalogue);
        }

        public static void WriteToText(List<Books> inputList)
        {
            StreamWriter sw = new StreamWriter("../../OurDataBase.txt", false);
            foreach (var item in inputList)
            {
                sw.WriteLine(item.BTitle + "," + item.BAuthor + "," + item.BStatus + ","
                    + item.BDueDate);
            }
            sw.Close();
        }


        public static List<Books> AddBooks(List<Books> inputList, string inputChoiceTitle,string inputChoiceAuthor)
        {

            string ChoiceTitle = inputChoiceAuthor;
            string ChoiceAuthor = inputChoiceAuthor;
            //Console.WriteLine("Please Enter in The Information For The Book You Are Donating:\n");
            //Console.Write("Book Title: ");
            
            //ChoiceTitle = Validation.GetValidString();
            //Console.Write("Book Author: ");
            //ChoiceAuthor = Validation.GetValidString();

            string Status = "Available";
            string DueDate = "N/A";

            inputList.Add(new Books(ChoiceTitle, ChoiceAuthor, Status, DueDate));
            Console.WriteLine("Thank You For Donating " + ChoiceTitle + " By " + ChoiceAuthor);

            MessageBox.Show("Thank You For Donating " + ChoiceTitle + " By " + ChoiceAuthor);

            return inputList;

        }

        public static void Return(List<Books> inputCatalogue, string whatevs)
        {
            //Console.Write("Please Enter The Name Of The Book You Would Like To Return: ");
            string ItemToReturn = whatevs.ToUpper();
            DateTime myDateTime = new DateTime();
            myDateTime = DateTime.Now;
            int count = 0;
            foreach (var item in inputCatalogue)
            {
                string TitleUpper = item.BTitle.ToUpper();
                if (TitleUpper == ItemToReturn && !(item.BStatus == "Avaiable"))
                {
                    item.BStatus = "Available";
                    item.BDueDate = "N/A";

                    MessageBox.Show($"Thank You for Returning {item.BTitle}.");
                    //Console.WriteLine($"Thank You for Returning {item.BTitle}.");
                    //if (Convert.ToDouble(item.BDueDate) > Convert.ToDouble(myDateTime))
                    //{
                    //    Console.WriteLine("your item is late you owe us money");
                    //}
                }

                else
                {
                    count++;
                }
            }

            if (count == inputCatalogue.Count)
            {
                MessageBox.Show($"Thank You for Returning the book!");
            }
            WriteToText(inputCatalogue);
        }

        public static void SearchByAuthor(List<Books> inputCatalogue, string KeyWordSearch555)
        {
            //Console.WriteLine("Enter a Keyword to Search for a Book By Author: ");
            int count = 0;
            char[] space = { ' ' };


            string KeyWordSearch222 = KeyWordSearch555.ToUpper();

            foreach (var item in inputCatalogue)
            {
                string KeyWordSearch = item.BAuthor.ToUpper();
                if (KeyWordSearch222.Split(space).Contains(KeyWordSearch))
                {

                    MessageBox.Show("Yes We Have Title:\t" + item.BTitle);
                    

                    //Console.WriteLine("Yes We Have: ");

                    //Console.WriteLine("Title:\t" + item.BTitle);
                    //Console.WriteLine("Author:\t" + item.BAuthor);
                    //Console.WriteLine("Status:\t" + item.BStatus);
                    //Console.WriteLine("DueDate:\t" + item.BDueDate);
                    //Console.WriteLine("\n=====================================\n");
                }

                else
                {
                    count++;
                }
            }

            if (count == inputCatalogue.Count)
            {
                MessageBox.Show("we do not seem to have that");
            }
        }
    }
}
