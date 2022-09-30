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
    public partial class ss1366 : Form
    {
        TextBox text1, text2, text3, text4, text5, imgText1, imgText2, imgText3, imgText4, imgText5;

       

        public ss1366(TextBox _text1, TextBox _text2, TextBox _text3, TextBox _text4, TextBox _text5, TextBox _imgText1, TextBox _imgText2, 
            TextBox _imgText3, TextBox _imgText4, TextBox _imgText5, TextBox _coustomPrice1, TextBox _coustomPrice2, TextBox _coustomPrice3, 
            TextBox _coustomPrice4, TextBox _coustomPrice5)
        {
            InitializeComponent();
            this.text1 = _text1;
            this.text2 = _text2;
            this.text3 = _text3;
            this.text4 = _text4;
            this.text5 = _text5;
            this.imgText1 = _imgText1;
            this.imgText2 = _imgText2;
            this.imgText3 = _imgText3;
            this.imgText4 = _imgText4;
            this.imgText5 = _imgText5;
            if (!string.IsNullOrEmpty(text1.Text))
            {
                ChangeItem(text1, price1, yourPrice1, _coustomPrice1);

                if (!string.IsNullOrEmpty(imgText1.Text))
                {
                    ChangeImg(picture1, imgText1);
                }
            }
            if (!string.IsNullOrEmpty(text2.Text))
            {
                ChangeItem(text2, price2, yourPrice2, _coustomPrice2);

                if (!string.IsNullOrEmpty(imgText2.Text))
                {
                    ChangeImg(picture2, imgText2);
                }
            }
            if (!string.IsNullOrEmpty(text3.Text))
            {
                ChangeItem(text3, price3, yourPrice3, _coustomPrice3);

                if (!string.IsNullOrEmpty(imgText3.Text))
                {
                    ChangeImg(picture3, imgText3);
                }
            }
            if (!string.IsNullOrEmpty(text4.Text))
            {
                ChangeItem(text4, price4, yourPrice4, _coustomPrice4);
                if (!string.IsNullOrEmpty(imgText4.Text))
                {
                    ChangeImg(picture4, imgText4);
                }
            }
            if (!string.IsNullOrEmpty(text5.Text))
            {
                ChangeItem(text5, price5, yourPrice5, _coustomPrice5);

                if (!string.IsNullOrEmpty(imgText5.Text))
                {
                    ChangeImg(picture5, imgText5);
                }
            }
        }

        private void ChangeItem(TextBox name, Label price, Label yourPrice, TextBox coustomPrice)
        {
            RestCient rClient = new RestCient();
            rClient.endPoint = name.Text;

            string strJSON = string.Empty;
            strJSON = rClient.makeRequest();

            Item item = JsonSerializer.Deserialize<Item>(rClient.makeRequest());
            if (item.lowest_price != null)
            {
                name.BackColor = Color.White;
                item.itemName = name.Text;
                item.deleteZl();

                float val = Convert.ToSingle(item.lowest_price);
                int intVal = (int)val;
                price.Text = intVal.ToString();


                if (string.IsNullOrEmpty(coustomPrice.Text))
                {
                    val = Convert.ToSingle(item.lowest_price) * 0.7f;
                    intVal = (int)val;
                    yourPrice.Text = intVal.ToString();
                }
                else
                {
                    yourPrice.Text = coustomPrice.Text;
                }

            }
            else
            {
                name.BackColor = Color.Red;
            }
        }
        private void ChangeImg(PictureBox pictureBox, TextBox text)
        {
            pictureBox.Image = new Bitmap(text.Text);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
