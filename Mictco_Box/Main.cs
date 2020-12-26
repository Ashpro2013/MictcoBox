using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
namespace Mictco_Box
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        #region Private Variables
        DBContext db = new DBContext();
        Button slotButton;
        int x = 10, y = 10;
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
            if (!slot.OccupaidStatus)
            {
                slotButton.BackColor = Color.Blue;
            }
            else
            {
                if (slot.InStatus)
                {
                    slotButton.BackColor = Color.Red;
                }
                else
                {
                    slotButton.BackColor = Color.Green;
                }
            }
            slotButton.Text = slot.Name;
            slotButton.Tag = slot.Id;
            slotButton.Click += slotButton_Click;
            slotButton.Size = new Size(100, 30);
            slotButton.Location = new Point(x, y);
            if (!pnlSlots.Contains(slotButton))
            {
                pnlSlots.Controls.Add(slotButton);
            }
            x = x + 110;
           
        }

        void slotButton_Click(object sender, EventArgs e)
        {
            Button btnSlot = (Button)sender;
            SlotView frm = new SlotView();
            Slot slot  = db.Slots.FirstOrDefault(x => x.Id == btnSlot.Tag.ToInt32());
            frm.slot = slot;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (!slot.OccupaidStatus)
                {
                    btnSlot.BackColor = Color.Blue;
                }
                else
                {
                    if (slot.InStatus)
                    {
                        btnSlot.BackColor = Color.Red;
                    }
                    else
                    {
                        btnSlot.BackColor = Color.Green;
                    }
                }
            }
        }
        #endregion
        #region Events
        private void LoadMethod()
        {
            x = 10;
            y = 10;
            pnlSlots.Controls.Clear();
            foreach (var item in db.Boxes)
            {
                foreach (var slot in db.Slots.Where(z => z.FK_BoxId == item.Id).ToList())
                {
                    AddSlotMethod(slot);
                }
                x = 10;
                y = y + 40;
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {
            //string path = @"Data Source=C:\Users\MICTCO\Documents\MICTCOBOXDB.sdfData Source=DESKTOP-2S972LR\SQLR2;Initial Catalog=MICTCODB;User ID=sa;Password=***********";
            string path = @"Data Source=DESKTOP-2S972LR\SQLR2;Initial Catalog=MICTCODB;User ID=sa;Password=wf";
            Properties.Settings.Default.Connection = path;
            Properties.Settings.Default.Save();
            
            LoadMethod();
        }

        private void btnBox_Click(object sender, EventArgs e)
        {
            BoxView frm = new BoxView();
            frm.FormClosing += frm_FormClosing;
            frm.ShowDialog();
        }

        void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadMethod();
        }
       

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomerView frm = new CustomerView();
            frm.ShowDialog();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            StaffView frm = new StaffView();
            frm.ShowDialog();
        }
    }
        #endregion
}