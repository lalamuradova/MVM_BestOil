using MVM_BestOil.Model;
using MVM_BestOil.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVM_BestOil
{
    public partial class Form1 : Form,IMainView
    {
        public List<Oil> Oils { set { comboBox1.DataSource = null; comboBox1.DataSource = value; } }
        public Oil SelectedOil { get { return comboBox1.SelectedItem as Oil; } set { comboBox1.SelectedItem = value; } }
        public string Price { get { return priceTxtbox.Text; } set { priceTxtbox.Text = value; } }
        public bool QuantityChecked { get { return LitrRadiobtn.Checked; } set { LitrRadiobtn.Checked = value; } }
        public string LitrText { get { return LiterTxtBox.Text; } set { LiterTxtBox.Text = value; } }
        public string MoneyText { get { return MoneyTxtBox.Text; } set { MoneyTxtBox.Text = value; } }
        public string TotalText { get {return TotalPriceLBL.Text; } set { TotalPriceLBL.Text = value; } }
        public List<Refuiler> Refuilers { set { listBox1.DataSource = null; listBox1.DataSource = value; } }
        public bool MoneyEnable { get { return MoneyTxtBox.Enabled; } set { MoneyTxtBox.Enabled = value; } }
        public bool LitrEnable { get { return LiterTxtBox.Enabled; } set { LiterTxtBox.Enabled = value; } }
        public EventHandler<EventArgs> ComboboxChange { get ; set; }
        public EventHandler<EventArgs> QuantityChange { get; set; }
        public EventHandler<EventArgs> MoneyChange { get; set ; }
        public EventHandler<EventArgs> CalculateChange { get ; set; }
        public  EventHandler<EventArgs> ShowAllPaymentChange { get; set; }

        public Form1()
        {
            InitializeComponent();
            comboBox1.DisplayMember = "Name";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboboxChange?.Invoke(sender, e);
            }
            catch (Exception)
            {
                
            }
          
        }

        private void LitrRadiobtn_CheckedChanged(object sender, EventArgs e)
        {
            QuantityChange.Invoke(sender, e);
        }

        private void CalculateBtn_Click(object sender, EventArgs e)
        {
            CalculateChange(sender, e);
        }

        private void MoneyRadiobtn_CheckedChanged(object sender, EventArgs e)
        {
            MoneyChange.Invoke(sender, e);
        }

        private void ShowAllPaymentBtn_Click(object sender, EventArgs e)
        {
            ShowAllPaymentChange.Invoke(sender, e);
        }
    }
}
