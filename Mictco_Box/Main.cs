using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Mictco_Box
{
    public partial class Main : Form
    {
        #region Private Variables
        DBContext db = new DBContext();
        Button slotButton;
        int w = 10, y = 10;
        #endregion

        #region Constructor
        public Main()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void AddSlotMethod(Slot slot)
        {
            
            slotButton = new Button();
            ButtonColorChangeMethod(slotButton, slot);
            slotButton.ForeColor = Color.White;
            slotButton.FlatStyle = FlatStyle.Flat;
            slotButton.Text = slot.Name;
            slotButton.Tag = slot.Id;
            if (slot.FK_CustomerId != null && slot.OccupaidStatus==1)
            {
                ToolTip ttMain = new ToolTip();
                ttMain.AutoPopDelay = 5000;
                ttMain.InitialDelay = 1000;
                ttMain.ReshowDelay = 500;
                ttMain.ShowAlways = true;
                ttMain.SetToolTip(this.slotButton, db.Customers.FirstOrDefault(x => x.Id == slot.FK_CustomerId).Name);
            }
            slotButton.Click += slotButton_Click;
            slotButton.Size = new Size(100, 30);
            slotButton.Location = new Point(w, y);
            if (!pnlSlots.Contains(slotButton))
            {
                pnlSlots.Controls.Add(slotButton);
            }
            w = w + 110;
        }
        private void OpenForm(Form frm, int X = 25, int Y = 25, string sForm = null)
        {
            try
            {
                if (frm.IsDisposed)
                {
                    Type type = frm.GetType();
                    Form form = (Form)Activator.CreateInstance(type);
                    form.TopLevel = false;
                    TabPage tbp = new TabPage();
                    tbp.Name = frm.Name;
                    tbp.Text = frm.Text;
                    tbp.BackgroundImageLayout = ImageLayout.Stretch;
                    tbp.BackColor = Color.FromArgb(32, 30, 45);
                    this.tabMdi.TabPages.Add(tbp);
                    this.tabMdi.SelectedTab = tbp;
                    tbp.Controls.Add(form);
                    form.Location = new Point(X, Y);
                    form.FormClosed += Form_FormClosed;
                    form.Show();
                    form.Focus();
                    form.BringToFront();
                }
                else
                {
                    frm.TopLevel = false;
                    TabPage tbp = new TabPage();
                    tbp.Name = frm.Name;
                    tbp.Text = frm.Text;
                    tbp.BackgroundImageLayout = ImageLayout.Stretch;
                    tbp.BackColor = Color.FromArgb(32, 30, 45);
                    this.tabMdi.TabPages.Add(tbp);
                    this.tabMdi.SelectedTab = tbp;
                    tbp.Controls.Add(frm);
                    frm.Location = new Point(X, Y);
                    frm.FormClosed += Form_FormClosed;
                    frm.Show();
                    frm.Focus();
                    frm.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form form = (Form)sender;
            if (form.Parent is TabPage)
            {
                TabPage tbp = (TabPage)form.Parent;
                tabMdi.TabPages.Remove(tbp);
                tabMdi.SelectedTab = tabMdi.TabPages[0];
            }
            if (form.Name == "BoxView") { LoadMethod(); }
        }
        void slotButton_Click(object sender, EventArgs e)
        {
            Button btnSlot = (Button)sender;
            SlotView frm = new SlotView();
            Slot slot  = db.Slots.FirstOrDefault(x => x.Id == btnSlot.Tag.ToInt32());
            frm.slot = slot;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ButtonColorChangeMethod(btnSlot, slot);
            }
        }
        private static void ButtonColorChangeMethod(Button btnSlot, Slot slot)
        {
            if (slot.OccupaidStatus == 0)
            {
                btnSlot.BackColor = Color.Gray;
            }
            else
            {
                if (slot.InStatus == 1)
                {
                    btnSlot.BackColor = Color.Blue;
                }
                else
                {
                    btnSlot.BackColor = Color.Green;
                }
            }
        }
        #endregion

        #region Events
        private void LoadMethod()
        {
            w = 10;
            y = 10;
            pnlSlots.Controls.Clear();
            foreach (var item in db.Boxes)
            {
                foreach (var slot in db.Slots.Where(z => z.FK_BoxId == item.Id).ToList())
                {
                    AddSlotMethod(slot);
                }
                w = 10;
                y = y + 40;
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            lblUser.Text = db.Staffs.FirstOrDefault(x => x.Id == User.iUserId).Name;
            LoadMethod();
        }
        private void btnBox_Click(object sender, EventArgs e)
        {
            
            BoxView frm = new BoxView();
            OpenForm(frm);
        }
        void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadMethod();
        }
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomerView frm = new CustomerView();
            OpenForm(frm);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            this.tabMdi.SelectedTab = tpDashboard;
        }
        private void btnReports_Click(object sender, EventArgs e)
        {
            TransactionView frm = new TransactionView();
            OpenForm(frm,0,0);
        }
        private void tabMdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabMdi.SelectedIndex==0)
            {
                LoadMethod();
            }
        }
        private void btnAllReport_Click(object sender, EventArgs e)
        {
            Report frm = new Report();
            OpenForm(frm,0,0);
        }
        private void btnStaff_Click(object sender, EventArgs e)
        {
            StaffView frm = new StaffView();
            OpenForm(frm);
        }
        #endregion
    }
}