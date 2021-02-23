using System;
using System.Drawing;
using System.Windows.Forms;
namespace MictcoUsercontrol
{
    public partial class MictcoTextBox : TextBox
    {
        public Color EnterColor { get; set; } = Color.LightPink;
        public Color LeaveColor { get; set; } = Color.White;
      
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.BackColor = EnterColor;
        }
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.BackColor = LeaveColor;
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Return && e.Handled == false)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Down && e.Handled == false)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up && e.Handled == false)
            {
                SendKeys.Send("+{TAB}");
                e.Handled = true;
            }
        }
        public MictcoTextBox()
        {
            InitializeComponent();
        }
    }
}
