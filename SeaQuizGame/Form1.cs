using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AD_CW
{
    public partial class Form1 : Form
    {
        FormScoreView fsv;
        FormQuiz fq;
        public Form1()
        {
            InitializeComponent();
            fsv = new FormScoreView();
            fq = new FormQuiz();
        }

        private void buttonScore_Click(object sender, EventArgs e)
        {
            fsv.Show();//When the score button is clicked, open the scoreboard form
        }

        private void buttonQuiz_Click(object sender, EventArgs e)
        {
            fq.Show();//When the quiz button is clicked, start the quiz
        }
    }
}
