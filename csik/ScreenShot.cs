using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Net.Http;

namespace csik
{
    public partial class ScreenShot : Form
    {
        TextBox text1, text2, text3, text4,text5;
        public ScreenShot(TextBox _text1, TextBox _text2, TextBox _text3, TextBox _text4, TextBox _text5)
        {
            InitializeComponent();
            this.text1 = _text1;
            this.text2 = _text2;
            this.text3 = _text3;
            this.text4 = _text4;
            this.text5 = _text5;
            if (!string.IsNullOrEmpty(text1.Text))
            {
                ChangeItem(text1, price1, yourPrice1);
            }
            if (!string.IsNullOrEmpty(text2.Text))
            {
                ChangeItem(text2, price2, yourPrice2);
            }
            if (!string.IsNullOrEmpty(text3.Text))
            {
                ChangeItem(text3, price3, yourPrice3);
            }
            if (!string.IsNullOrEmpty(text4.Text))
            {
                ChangeItem(text4, price4, yourPrice4);
            }
            if (!string.IsNullOrEmpty(text5.Text))
            {
                ChangeItem(text5, price5, yourPrice5);
            }
        }



        #region UiHandlers
 

        private void ChangeItem(TextBox name, Label price, Label yourPrice)
        {
            RestCient rClient = new RestCient();
            rClient.endPoint = name.Text;


            string strJSON = string.Empty;
            strJSON = rClient.makeRequest();

            Item item = JsonSerializer.Deserialize<Item>(rClient.makeRequest());
            item.itemName = name.Text;
            item.deleteZl();

            float val = Convert.ToSingle(item.lowest_price);
            int intVal = (int)val;
            price.Text = intVal.ToString();

            val = Convert.ToSingle(item.lowest_price) * 0.7f;
            intVal = (int)val;
            yourPrice.Text = intVal.ToString();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }


}
