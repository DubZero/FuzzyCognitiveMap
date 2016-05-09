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
        // Сохранение настроек 
        private void bntApply_Click(object sender, EventArgs e)
        {            
            if (k1Num.Value + k2Num.Value != 1 && radioButton1.Checked)
            {
                MessageBox.Show("Сумма коэффициентов k1 и k2 должна быть равна 1!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Settings.Function = funcBox.SelectedIndex;
            if (radioButton1.Checked == true)
                Settings.ArgFunc = 1;
            else if (radioButton2.Checked == true)
                Settings.ArgFunc = 2;
            Settings.SaveToXLS = chbSaveToXls.Checked;
            Settings.AdvancedReport = chbAdnReport.Checked;
            Settings.k1 = k1Num.Value;
            Settings.k2 = k2Num.Value;
            Settings.feedback = feedback.Value;
            this.Close();                     
        }
        // Считывание настроек с окна
        private void Set_Load(object sender, EventArgs e)
        {
            funcBox.SelectedIndex = Settings.Function;
            if (Settings.ArgFunc == 1)
                radioButton1.Checked = true;
            else if(Settings.ArgFunc == 2)
                radioButton2.Checked = true;
            chbSaveToXls.Checked = Settings.SaveToXLS;
            chbAdnReport.Checked = Settings.AdvancedReport;
            k1Num.Value = Settings.k1;
            k2Num.Value = Settings.k2;
            feedback.Value = Settings.feedback;

            if (Settings.ArgFunc == 2)
            {
                k1Num.Enabled = false;
                k2Num.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                k1Num.Enabled = true;
                k2Num.Enabled = true;
                feedback.Enabled = false;
            }
            else
            {
                k1Num.Enabled = false;
                k2Num.Enabled = false;
                feedback.Enabled = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Help help = new Help())
            {

                help.ShowDialog();
            }
        }
    }
}
