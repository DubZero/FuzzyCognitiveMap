using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FCM
{
    public partial class Set : Form
    {
        public Set()
        {
            InitializeComponent();
        }
        
        private bool SaveSets = false;
        
        public void DefaultSettings()
        {
            Settings.Function = 1;
            Settings.ArgFunc = 1;
            Settings.SaveToXLS = false;
            Settings.AdvancedReport = false;
            Settings.k1 = 0;
            Settings.k2 = 0;
        }

        private void bntApply_Click(object sender, EventArgs e)
        {
            SaveSets = true;
        }

        private void Set_Load(object sender, EventArgs e)
        {
            
            if (!SaveSets)            
                DefaultSettings();
            funcBox.SelectedIndex = Settings.Function;
            if (Settings.ArgFunc == 1)
                radioButton1.Checked = true;
            else if(Settings.ArgFunc == 2)
                radioButton2.Checked = true;
            chbSaveToXls.Checked = Settings.SaveToXLS;
            chbAdnReport.Checked = Settings.AdvancedReport;
            k1Num.Value = Settings.k1;
            k2Num.Value = Settings.k2;                


            if(Settings.ArgFunc == 2)
            {
                k1Num.Enabled = false;
                k2Num.Enabled = false;
            }

        }
    }
}
