using System;
using System.Windows.Forms;

namespace WinFormsNetFwSqlRedo
{
    public partial class Form2 : Form
    {
        public event Action onCreateNewEntry = delegate { };
        
        private GameEntry entry = new GameEntry();
        
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // create entry

            SQLConnectionHandler.SaveNewEntry(entry);
            
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            entry = new GameEntry();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // name

            entry.Name = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // publisher
            
            entry.Publisher = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // production studio
            
            entry.ProductionStudio = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // release date
            
            entry.ReleaseDate = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // cost
            if (textBox5.Text == "")
            {
                entry.AverageCost = 0m;

                return;
            }
            
            entry.AverageCost = Convert.ToDecimal(textBox5.Text);
        }
    }
}