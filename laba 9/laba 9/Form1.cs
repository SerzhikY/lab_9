using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var bike = BikeBuilder.Build();

            bike.Operate();

            var componentNames = bike.GetComponents()
                                           .Select(c => c.GetType().Name)
                                           .ToArray();

            MessageBox.Show($"The bike components are: {string.Join(", ", componentNames)}");


        }
    }
}
