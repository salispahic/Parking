using ParkingLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingCalculator
{
    public partial class frmMain : Form
    {
        AvailableRates _rates;
        public frmMain()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try { 
                PatronTimeSpend pts = new PatronTimeSpend(this.dtpEntryDate.Value, this.dtpExitDate.Value);
                Result r = _rates.GetResult(pts);
                this.lblRateName.Text = r.RateName;
                this.lblTotalPrice.Text = r.TotalPrice.ToString();

            }catch(Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            _rates = new AvailableRates();
        }
    }
}
