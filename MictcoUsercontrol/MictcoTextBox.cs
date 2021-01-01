using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MictcoUsercontrol
{
    public partial class MictcoTextBox : TextBox
    {
        
        public MictcoTextBox()
        {
            InitializeComponent();
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.BackColor = Color.LightPink;
        }
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.BackColor = SystemColors.Window;
        }
    }
}
