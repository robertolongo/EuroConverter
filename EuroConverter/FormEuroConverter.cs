using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EuroConverter
{
    public partial class FormEuroConverter : Form
    {
        ServiceConverter serviceConverter = null;
        public FormEuroConverter()
        {
            InitializeComponent();
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            if (serviceConverter == null)
            {
                serviceConverter = new ServiceConverter();
                

                serviceConverter.ReadExchange(comboBoxCurrency);
            }
            serviceConverter.ConvertFromEuro(serviceConverter.CurrencyToEuro(Convert.ToDouble(textBox1.Text), comboBoxCurrency.Text), dataGridViewResults);
        }

         private void FormEuroConverter_Activated(object sender, EventArgs e)
        {
            if (serviceConverter == null)
            {
                serviceConverter = new ServiceConverter();
                serviceConverter.ReadExchange(comboBoxCurrency);
            }
        }


        private void EventTextChanged(object sender, EventArgs e)
        {
            try
            {
                labelError.Text = "";
                if (serviceConverter != null)
                    serviceConverter.ConvertFromEuro(serviceConverter.CurrencyToEuro(Convert.ToDouble(textBox1.Text), comboBoxCurrency.Text), dataGridViewResults);
            }
            catch (System.Exception ex)
            {
                labelError.Text = ex.Message;
            }
            
        }

        private void FormEuroConverter_Load(object sender, EventArgs e)
        {
            if (serviceConverter == null)
            {
                serviceConverter = new ServiceConverter();
                serviceConverter.InitializationLookup(comboBoxCurrency);
                serviceConverter.ReadExchange(comboBoxCurrency);

                labelError.Text = "";
            }



        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Value");
            dt.Columns.Add("Currency");
            dt.Columns.Add("Descr");

            DataRow dr = dt.NewRow();
            dr["Value"] = "abc";
            dr["Currency"] = "5";
            dr["Descr"] = "asdfsegzd";

            dt.Rows.Add(dr);

            foreach (DataRow row in dt.Rows)
            {
                int num = dataGridViewResults.Rows.Add();
                dataGridViewResults.Rows[num].Cells[0].Value = row["C1"].ToString();
                dataGridViewResults.Rows[num].Cells[1].Value = row["C2"].ToString();
                dataGridViewResults.Rows[num].Cells[2].Value = row["C3"].ToString();
            }


        }

        private void DataGridViewResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
