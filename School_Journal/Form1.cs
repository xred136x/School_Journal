using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace School_Journal
{
    public partial class Form1 : Form
    {
        List<Journal> list = new List<Journal>();
        List<string> printableList = new List<string>();
        public Form1()
        {
            InitializeComponent();
            refreshList();
            showListInBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var journal = new Journal(textBoxSurname.Text, textBoxName.Text, DateTime.Now);
            list.Add(journal);
            saveToXml();
        }

        private void refreshList(string path = "Journal.xml")
        {
            Journal.Deserealize_it(path, out list);
            listBoxShow.Items.Clear();
            listBoxShow.Items.AddRange(updatePrintableList());
        }

        private void showListInBox()
        {
            StringBuilder sb = new StringBuilder();
            var counter = 0;
            foreach (var item in list)
            {
                sb.Append($"# {counter++} {item.Surname} {item.Name}\t\t {item.Birthday}\n");
            }
            MessageBox.Show(sb.ToString());
        }
        private string[] updatePrintableList()
        {
            printableList.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                printableList.Add(list[i].ToString());
            }
            var arr = printableList.ToArray();
            return arr;
        }
        private void saveToXml(string path = "Journal.xml")
        {
            Journal.Serealize_it(list, path);
            refreshList();
        }

    }
}
