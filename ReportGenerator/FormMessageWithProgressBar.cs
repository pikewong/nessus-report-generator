using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportGenerator
{
    public partial class FormMessageWithProgressBar : Form
    {
        int totalNumber=0;
        int finishedNumber=0;

        public FormMessageWithProgressBar(String text, int totalNumber)
        {
            InitializeComponent();
            this.labelText.Text = text;
            this.totalNumber = totalNumber;
            this.labelTotalNumber.Text = " / " + totalNumber.ToString();
            this.progressBar.Maximum = totalNumber;
            this.progressBar.Value = 0;
            this.progressBar.Update();
            this.TopMost = true;
        }

        public FormMessageWithProgressBar()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        public void setText(string text)
        {
            this.labelText.Text = text;
        }

        public void setTotalNumber(int totalNumber)
        {
            this.totalNumber = totalNumber;
            this.labelTotalNumber.Text = " /  " + totalNumber.ToString();
            this.progressBar.Maximum = totalNumber;
            this.progressBar.Value = 0;
            this.progressBar.Update();
        }

        public int getFinishedNumber()
        {
            return finishedNumber;
        }

        public void setFinishedNumber(int finishedNumber)
        {
            this.finishedNumber = finishedNumber;
            this.labelfinishedNumber.Text = finishedNumber.ToString();
            this.progressBar.Value = finishedNumber > totalNumber ? totalNumber : finishedNumber;
            this.progressBar.Update();
        }



    }
}
