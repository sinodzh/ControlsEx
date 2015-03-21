using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxEx1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxEx1_EditValueChanging(object sender, ControlsEx.ChangingEventArgs e)
        {
            //简单的过滤abc和100
            if (e.NewValue.ToString() == "abc")
                e.Cancel = true;
        }

        private void textBoxEx2_EditValueChanging(object sender, ControlsEx.ChangingEventArgs e)
        {
            //简单的过滤100
            
            int temp = Convert.ToInt32(e.NewValue);
            if (temp == 100)
                e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }



    }
}
