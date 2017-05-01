using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TryMidTermGUI
{
    public partial class Form1 : Form
    {

        


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<Books> temp = FileIO.GetList();

            //foreach (Books b in temp)
            //{ dataGridView1.Rows.Add(b.BTitle, b.BAuthor);

            //}

            FileIO.Checkout(temp, textBox1.Text);
           

    }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Books> temp = FileIO.GetList();

            foreach (Books b in temp)
            {
                dataGridView1.Rows.Add(b.BTitle, b.BAuthor,b.BStatus,b.BDueDate);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

           
        }

        private void button3_Click(object sender, EventArgs e)
        {

            List<Books> temp = FileIO.GetList();

            //foreach (Books b in temp)
            //{ dataGridView1.Rows.Add(b.BTitle, b.BAuthor);

            //}

            FileIO.Return(temp, textBox4.Text);


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            List<Books> temp = FileIO.GetList();



            FileIO.WriteToText(FileIO.AddBooks(temp, textBox2.Text, textBox3.Text));

            dataGridView1.Rows.Clear();
            foreach (Books b in temp)
            {
                dataGridView1.Rows.Add(b.BTitle, b.BAuthor,b.BStatus,b.BDueDate);

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            List<Books> temp = FileIO.GetList();

            FileIO.Return(temp, textBox4.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<Books> temp = FileIO.GetList();

            FileIO.SearchByAuthor(temp, textBox5.Text);



        }

        private void button5_Click(object sender, EventArgs e)
        {



        }
    }

}
