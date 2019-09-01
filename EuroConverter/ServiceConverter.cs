using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace EuroConverter
{
    
    class ServiceConverter
    {
        XmlDocument xmlExchange = null;

        Dictionary<string, double> rates = null;
        Dictionary<string, string> currencyDesc = null;

        public void InitializationLookup(ComboBox comboboxCurrency)
        {
            currencyDesc = new Dictionary<string, string>();
            currencyDesc.Add("EUR", "Euro");
            currencyDesc.Add("USD", "US dollar");
            currencyDesc.Add("JPY", "Japanese yen");
            currencyDesc.Add("BGN", "Bulgarian lev");
            currencyDesc.Add("CZK", "Czech koruna");
            currencyDesc.Add("DKK", "Danish krone");
            currencyDesc.Add("GBP", "Pound sterling");
            currencyDesc.Add("HUF", "Hungarian forint");
            currencyDesc.Add("PLN", "Polish zloty");
            currencyDesc.Add("RON", "Romanian leu");
            currencyDesc.Add("SEK", "Swedish krona");
            currencyDesc.Add("CHF", "Swiss franc");
            currencyDesc.Add("ISK", "Icelandic krona");
            currencyDesc.Add("NOK", "Norwegian krone");
            currencyDesc.Add("HRK", "Croatian kuna");
            currencyDesc.Add("RUB", "Russian rouble");
            currencyDesc.Add("TRY", "Turkish lira");
            currencyDesc.Add("AUD", "Australian dollar");
            currencyDesc.Add("BRL", "Brazilian real");
            currencyDesc.Add("CAD", "Canadian dollar");
            currencyDesc.Add("CNY", "Chinese yuan renminbi");
            currencyDesc.Add("HKD", "Hong Kong dollar");
            currencyDesc.Add("IDR", "Indonesian rupiah");
            currencyDesc.Add("ILS", "Israeli shekel");
            currencyDesc.Add("INR", "Indian rupee");
            currencyDesc.Add("KRW", "South Korean won");
            currencyDesc.Add("MXN", "Mexican peso");
            currencyDesc.Add("MYR", "Malaysian ringgit");
            currencyDesc.Add("NZD", "New Zealand dollar");
            currencyDesc.Add("PHP", "Philippine peso");
            currencyDesc.Add("SGD", "Singapore dollar");
            currencyDesc.Add("THB", "Thai baht");
            currencyDesc.Add("ZAR", "South African rand");
        }

        public void ReadExchange(ComboBox comboboxCurrency)
        {
            xmlExchange = new XmlDocument();
            rates = new Dictionary<string, double>();

            // Add first item to currency combobox and dictionary
            comboboxCurrency.Items.Clear();
            comboboxCurrency.Items.Add("EUR");
            comboboxCurrency.SelectedIndex = 0;
            rates.Add("EUR", 1);

            xmlExchange.Load("http://www.ecb.int/stats/eurofxref/eurofxref-daily.xml");
            foreach(XmlNode xmlNode in xmlExchange.DocumentElement.ChildNodes[2].ChildNodes[0].ChildNodes)
            {
                string tmpValue = xmlNode.Attributes["rate"].Value;
                NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
                CultureInfo provider = new CultureInfo("en-GB");
                rates.Add(xmlNode.Attributes["currency"].Value, Double.Parse(tmpValue, style, provider));
                comboboxCurrency.Items.Add(xmlNode.Attributes["currency"].Value);
            }
        }

        public double CurrencyToEuro(double value, string currency)
        {
            return value / rates[currency];
        }

        public void ConvertFromEuro(double euro, DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            foreach (KeyValuePair<string, double> entry in rates)
            {
                int num = dataGridView.Rows.Add();
                dataGridView.Rows[num].Cells[0].Value = Convert.ToString(euro * entry.Value);
                dataGridView.Rows[num].Cells[1].Value = entry.Key;
                dataGridView.Rows[num].Cells[2].Value = currencyDesc.ContainsKey(entry.Key) ? currencyDesc[entry.Key] : "";

            }

        }

    }
}
