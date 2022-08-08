using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AD_CW
{
    public partial class FormScoreView : Form
    {
        public FormScoreView()
        {
            InitializeComponent();
        }

        private void FormScoreView_Load(object sender, EventArgs e)
        {

        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            listBoxPlayer.Items.Clear();//Clear the listbox everytime the button is clicked
            listBoxPlayer.Items.Add("Player name        Score");//Add the header for the Listbox
            listBoxPlayer.Items.Add("━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            //clear List box first before listing records
            foreach (var item in DBSingleton.Instance.ViewPlayers())
            {
                listBoxPlayer.Items.Add(item);//List the scores for each player in the database table.
            }
        }
    }
}
