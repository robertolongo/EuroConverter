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

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ExportExchangeRatesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RateSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.ecb.europa.eu/stats/policy_and_exchange_rates/euro_reference_exchange_rates/html/index.en.html");
        }

        private void PDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.ecb.europa.eu/stats/shared/pdf/eurofxref.pdf");
        }

        private void CSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.ecb.europa.eu/stats/eurofxref/eurofxref.zip");
        }

        private void XMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");
        }

        private void RSSFeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.ecb.europa.eu/home/html/rss.en.html");
        }
    }
}
