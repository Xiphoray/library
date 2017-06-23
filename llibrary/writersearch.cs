using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace llibrary
{
    public partial class writersearch : Form
    {
        public string writer;
        public writersearch(string wr)
        {
            InitializeComponent();
            writer = wr;
            label2.Text = writer;
        }
    }
}
