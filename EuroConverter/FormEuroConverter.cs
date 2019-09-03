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
                

                serviceConverter.ReadExchange(comboBoxCurrency, textBoxDate);
            }
            serviceConverter.ConvertFromEuro(serviceConverter.CurrencyToEuro(Convert.ToDouble(textBox1.Text), comboBoxCurrency.Text), dataGridViewResults);
        }

         private void FormEuroConverter_Activated(object sender, EventArgs e)
        {
            if (serviceConverter == null)
            {
                serviceConverter = new ServiceConverter();
                serviceConverter.ReadExchange(comboBoxCurrency, textBoxDate);
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
                serviceConverter.ReadExchange(comboBoxCurrency, textBoxDate);

                labelError.Text = "";
            }



        }

        private void DataGridViewResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
