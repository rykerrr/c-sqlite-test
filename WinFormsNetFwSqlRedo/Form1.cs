using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinFormsNetFwSqlRedo
{
    public partial class Form1 : Form
    {
        private readonly List<GameEntry> entries = new List<GameEntry>();
        private Form2 addingForm = null;

        public Form1()
        {
            InitializeComponent();
            AllocConsole();
        }

        private void LoadListFromDatabase()
        {
            var newEntries = SQLConnectionHandler.GetEntriesFromDatabase();

            entries.Clear();
            entries.AddRange(newEntries);
        }

        private void LoadListToListBox()
        {
            listBox1.Items.Clear();
            
            foreach (var entry in entries)
            {
                listBox1.Items.Add(entry.ToString());
            }
        }

        private void SortByX(Comparison<GameEntry> comparison)
        {
            if (listBox1.Items.Count == 0) LoadListFromDatabase();

            entries.Sort(comparison);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var form2Exists = addingForm != null;

            if (form2Exists)
            {
                Console.WriteLine(@"Form 2 exists");
                
                return;
            }

            Console.WriteLine(@"Creating form 2");
            
            addingForm = new Form2 {Enabled = true};
            addingForm.Show();
            
            addingForm.onCreateNewEntry += () =>
            {
                LoadListFromDatabase();
                LoadListToListBox();
            };
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadListFromDatabase();
            LoadListToListBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // id

            SortByX((a, b) =>
            {
                if (a.Id > b.Id) return 1;
                else if (a.Id < b.Id) return -1;
                else return 0;
            });

            LoadListToListBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // name

            SortByX((a, b) => string.CompareOrdinal(a.Name, b.Name));

            LoadListToListBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // publisher

            SortByX((a, b) => string.CompareOrdinal(a.Publisher, b.Publisher));

            LoadListToListBox();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // production studio

            SortByX((a, b) => string.CompareOrdinal(a.ProductionStudio, b.ProductionStudio));

            LoadListToListBox();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // release date

            SortByX((a, b) => string.CompareOrdinal(a.ReleaseDate, b.ReleaseDate));

            LoadListToListBox();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // cost

            SortByX((a, b) =>
            {
                if (a.AverageCost > b.AverageCost) return 1;
                else if (a.AverageCost < b.AverageCost) return -1;
                else return 0;
            });

            LoadListToListBox();
        }
        
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}