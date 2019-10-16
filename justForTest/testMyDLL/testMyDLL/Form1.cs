using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using myDLL;

namespace testMyDLL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IOperate op = new Operate1();
            int c;
            c = op.getSum(5, 9);
            //c = operate.getSum(5, 9);
            Console.WriteLine(c);
        }
    }
}
