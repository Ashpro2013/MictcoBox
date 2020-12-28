using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mictco_Box
{
    public partial class FormBase : Form
    {
        #region PrivateVariables
        public Point downPoint = Point.Empty;
        #endregion

        #region Constructor
        public FormBase()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void BaseForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        private void BaseForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            downPoint = new Point(e.X, e.Y);
        }
        private void BaseForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (downPoint == Point.Empty)
            {
                return;
            }
            Point location = new Point(
                this.Left + e.X - downPoint.X,
                this.Top + e.Y - downPoint.Y);
            this.Location = location;
        }
        private void BaseForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            downPoint = Point.Empty;
        }
        private void BaseForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.White, 2),
                       this.DisplayRectangle);
        }
        private void BaseForm_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        #endregion
    }
}
