using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace KNN
{
    //https://github.com/MicrocontrollersAndMore
    //https://www.youtube.com/watch?v=VfpjswS95mo
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var t = (int)'a';
        }

        private void Train_Click(object sender, EventArgs e)
        {
            var train = new Train();
            train.Show();
        }

        private void Test_Click(object sender, EventArgs e)
        {
            var test = new Test();
            test.Show();
        }
    }


 


}
