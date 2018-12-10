using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aufgabe_ListViewAndTreeView
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //this.listView1.View = View.Details;
            List<List<string>> rowlist = new List<List<string>>();
            rowlist.Add(new List<string> { "01", "Toller Song", "3:42", "Best Album" });
            rowlist.Add(new List<string> { "02", "Tollerer Song", "6:00", "Best Album" });
            rowlist.Add(new List<string> { "03", "Toller Song(DJ Wasweißich Remix)", "4:12", "Best Album Aniversary" });
            //Listen befüllen


            foreach(List<string> sublist in rowlist)//Listview aufbauen
            {
                ListViewItem list = new ListViewItem();
                list.Text = sublist.ElementAt(0);
                list.SubItems.Add(sublist.ElementAt<string>(1));
                list.SubItems.Add(sublist.ElementAt<string>(2));
                list.SubItems.Add(sublist.ElementAt<string>(3));
                this.listView1.Items.Add(list);
                
            }

            foreach(List<string> sublist in rowlist) //Treeview aufbauen
            {
                TreeNode node = this.treeView1.Nodes.Add(sublist.ElementAt<string>(3));
                
                node.Nodes.Add(sublist.ElementAt<string>(1));
            }
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e) //Das betreffende Element in Listview auswählen je nach dem was in Treevie mit Doppelklick ausgewählt wird
        {
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                listView1.Items[i].Selected = false;
            }
            TreeNode node =  this.treeView1.GetNodeAt(e.X, e.Y);
            ListViewItem item = (this.listView1.FindItemWithText(node.Text));
            //item.BackColor = Color.LightSteelBlue;
            listView1.Items[item.Index].Selected = true;
            listView1.Select();

        }
    }
}
