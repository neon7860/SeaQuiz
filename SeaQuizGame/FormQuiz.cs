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
    public partial class FormQuiz : Form
    {   //Variables declared with camel case convention
        int correctAnswer;
        int questionNumber = 1;//Quiz starts with first question. (Case 1 of switch case)
        int score;
        int percentage;
        int totalQuestions;
        string textboxAnswer;

        public FormQuiz()
        {
            InitializeComponent();
            WhatQuestion(questionNumber);
            totalQuestions = 14;
            textBoxName.Visible = false;//Setting form elements to false to hide from user.
            lblName.Visible = false;
            lblSubmit.Visible = false;
            buttonSave.Visible = false;
            textBoxInput.Visible = false;
            button3.Visible = false;
        }
        private void SubmitAnswerEvent(object sender, EventArgs e)//Event control for questions with textbox
        {//validates whether user input is the answer
            if (textBoxInput.Text.ToLower() == textboxAnswer)
            {
                score++;//Increment score if text input matches answer
            }
            questionNumber++;
            WhatQuestion(questionNumber);
        }

        private void CheckAnswerEvent(object sender, EventArgs e)//Event control to check multiple choice questions
        {//validates whether the tag of the button clicked is = to the correct answer(tag)
            var senderObject = (Button)sender;

            int buttonTag = Convert.ToInt32(senderObject.Tag);

            if(buttonTag == correctAnswer)
            {
                score++;//Increment score if button tag matches the correct answer
            }

            if (questionNumber == totalQuestions)//Display score, percentage when all questions have been answered
            {
                percentage = (int)Math.Round((double)(score * 100) / totalQuestions);


                if (percentage > 49)
                {
                    DialogResult dr; //Show results
                    dr = MessageBox.Show("Quiz has finished! You passed!" + Environment.NewLine +
                        "You have answered " + score + " questions correctly" + Environment.NewLine +
                        "Your total percentage is " + percentage + "%" + Environment.NewLine +
                        "Save Score?", "Final Results!", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes) //If yes button is clicked, hide other form elements and show elements for saving score
                    {
                        pictureBoxQuiz.Visible = false;
                        button1.Visible = false;
                        button2.Visible = false;
                        lblCategory.Visible = false;
                        lblQuestion.Visible = false;
                        lblName.Visible = true;
                        textBoxName.Visible = true;
                        buttonSave.Visible = true;
                        lblSubmit.Visible = true;
                    }
                    else
                        Environment.Exit(1); //If no is clicked, exit the application

                    questionNumber = 0;
                    WhatQuestion(questionNumber);
                }
                else
                {
                    DialogResult dr;//Display results if percentage was below 50% with answers.
                    dr = MessageBox.Show("Quiz has finished! You failed." + Environment.NewLine +
                        "You have answered " + score + " questions correctly" + Environment.NewLine +
                        "Your total percentage is " + percentage + "%" + Environment.NewLine +
                        "Here are the Answers:" + Environment.NewLine +
                        "1) 7" + Environment.NewLine +
                        "2) Frogfish" + Environment.NewLine +
                        "3) Head" + Environment.NewLine +
                        "4) Emperor" + Environment.NewLine +
                        "5) 150" + Environment.NewLine +
                        "6) Drake" + Environment.NewLine +
                        "7) Krill" + Environment.NewLine +
                        "8) True" + Environment.NewLine +
                        "9) Whale Shark" + Environment.NewLine +
                        "10) Japanese Spidercrab" + Environment.NewLine +
                        "11) Dolphin" + Environment.NewLine +
                        "12) Alligator" + Environment.NewLine +
                        "13) Mammals" + Environment.NewLine + 
                        "14) True" + Environment.NewLine +
                        "Save Score?", "Final Results!", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes) //If yes button is clicked, hide other form elements and show others
                    {
                        pictureBoxQuiz.Visible = false;
                        button1.Visible = false;
                        button2.Visible = false;
                        lblCategory.Visible = false;
                        lblQuestion.Visible = false;
                        lblName.Visible = true;
                        textBoxName.Visible = true;
                        buttonSave.Visible = true;
                        lblSubmit.Visible = true;
                    }
                    else
                        Environment.Exit(1);

                    questionNumber = 0;
                    WhatQuestion(questionNumber);

                }
            }

            questionNumber++;
            WhatQuestion(questionNumber);
        }
        //Method starts with a capital letter
        #region Switch Case questions
        private void WhatQuestion(int qnum)//Decision used here.
        {//For each case, display question, answers, control objects, image and category.
            switch(qnum)
            {
                case 1://question 1
                    pictureBoxQuiz.Image = Properties.Resources.Turtle;
                    lblCategory.Text = "Reptile";

                    lblQuestion.Text = "How many species of marine turtles are there?";

                    button1.Text = "7";
                    button2.Text = "8";

                    correctAnswer = 1;

                    break;
                case 2://question 2
                    pictureBoxQuiz.Image = Properties.Resources.Frogfish;
                    lblCategory.Text = "Fish";

                    lblQuestion.Text = "Can you name this fish found in the waters off Indonesia?";

                    button1.Text = "Frogfish";
                    button2.Text = "Exotic Pufferfish";

                    correctAnswer = 1;

                    break;
                case 3:
                    pictureBoxQuiz.Image = Properties.Resources.Shrimp;
                    lblCategory.Text = "Crustacean";

                    lblQuestion.Text = "The heart of a shrimp is located on its ____";

                    button1.Text = "Tail";
                    button2.Text = "Head";

                    correctAnswer = 2;

                    break;
                case 4:
                    pictureBoxQuiz.Image = Properties.Resources.Penguin;
                    lblCategory.Text = "Bird";

                    lblQuestion.Text = "What is the largest living penguin breed?";

                    button1.Text = "Emperor";
                    button2.Text = "Magellanic";

                    correctAnswer = 1;

                    break;
                case 5:
                    pictureBoxQuiz.Image = Properties.Resources.Duck;
                    lblCategory.Text = "Bird";

                    lblQuestion.Text = "How many species of duck are there?";

                    button1.Text = "73";
                    button2.Text = "150";

                    correctAnswer = 2;

                    break;
                case 6:
                    pictureBoxQuiz.Image = Properties.Resources.Duck;
                    lblCategory.Text = "Bird";

                    lblQuestion.Text = "What is a male duck called?";

                    button1.Text = "Mallard";
                    button2.Text = "Drake";

                    correctAnswer = 2;

                    break;
                case 7:
                    pictureBoxQuiz.Image = Properties.Resources.Penguin;
                    lblCategory.Text = "Bird";

                    lblQuestion.Text = "What do emeperor penguins eat?";

                    button1.Text = "Krill";
                    button2.Text = "Ice";

                    correctAnswer = 1;

                    break;
                case 8:
                    pictureBoxQuiz.Image = Properties.Resources.Frogfish;
                    lblCategory.Text = "Fish";

                    lblQuestion.Text = "Many fish give birth by laying eggs?";

                    button1.Text = "True";
                    button2.Text = "False";

                    correctAnswer = 1;

                    break;
                case 9:
                    pictureBoxQuiz.Image = Properties.Resources.Shark;
                    lblCategory.Text = "Fish";

                    lblQuestion.Text = "Which is the largest of all sharks?";

                    button1.Text = "Great White Shark";
                    button2.Text = "Whale Shark";

                    correctAnswer = 2;

                    break;
                case 10:
                    pictureBoxQuiz.Image = Properties.Resources.Crab;
                    lblCategory.Text = "Crustacean";

                    lblQuestion.Text = "What are the biggest crabs in the world?";

                    button1.Text = "Red King Crab";
                    button2.Text = "Japanese Spidercrab";

                    correctAnswer = 2;

                    break;
                case 11:
                    button1.Visible = false;//Hide multiple choice buttons
                    button2.Visible = false;
                    textBoxInput.Visible = true;//Show textbox and button for submitting fill in the gap questions
                    button3.Visible = true;
                    pictureBoxQuiz.Image = Properties.Resources.Orca;
                    lblCategory.Text = "Mammal";

                    lblQuestion.Text = "Orcas are the largest species of the _______ family.";

                    textboxAnswer = "dolphin";

                    break;
                case 12:
                    textBoxInput.Visible = false;//hide textbox elements
                    button3.Visible = false;
                    button1.Visible = true;//Show multiple choice button elements
                    button2.Visible = true;
                    pictureBoxQuiz.Image = Properties.Resources.Alligator;
                    lblCategory.Text = "Reptile";

                    lblQuestion.Text = "Is this an alligator or crocodile?";

                    button1.Text = "Crocodile";
                    button2.Text = "Alligator";

                    correctAnswer = 2;

                    break;
                case 13:
                    button1.Visible = false;
                    button2.Visible = false;
                    textBoxInput.Visible = true;
                    button3.Visible = true;
                    pictureBoxQuiz.Image = Properties.Resources.Dolphin;
                    lblCategory.Text = "Mammal";

                    lblQuestion.Text = "Dolphins are not fish! They are _______.";

                    textboxAnswer = "mammals";

                    break;
                case 14:
                    button1.Visible = true;
                    button2.Visible = true;
                    textBoxInput.Visible = false;
                    button3.Visible = false;
                    pictureBoxQuiz.Image = Properties.Resources.Alligator;
                    lblCategory.Text = "Reptile";

                    lblQuestion.Text = "Crocodiles are reptiles?";

                    button1.Text = "True";
                    button2.Text = "False";

                    correctAnswer = 1;

                    break;
                
            }
            #endregion
        }

        private void buttonSave_Click(object sender, EventArgs e) //button4 click event
        {

            if (ValidateChildren(ValidationConstraints.Enabled))
            {


                int s = score; //Set s to the score value
                MessageBox.Show(DBSingleton.Instance.SaveScore(textBoxName.Text, s));


                lblSubmit.Text = "The score of " + textBoxName + " was saved.";
            }

        }

        private void TBValidating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                e.Cancel = true;
                textBoxName.Focus();
                errorProviderName.SetError(textBoxName, "Name needed to save score!");
            }
            else
            {
                e.Cancel = false;
                errorProviderName.SetError(textBoxName, "");
            }
        }

        private void FormQuiz_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
