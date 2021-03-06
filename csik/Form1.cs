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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        #region UiHandlers
        private void submit_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox1.Text))
            {
                ChangeItem(textBox1, price1, yourPrice1);
            }
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                ChangeItem(textBox2, price2, yourPrice2);
            }
            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                ChangeItem(textBox3, price3, yourPrice3);
            }
            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                ChangeItem(textBox4, price4, yourPrice4);
            }
            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                ChangeItem(textBox5, price5, yourPrice5);
            }
        }

        private void ChangeItem(TextBox name, Label price, Label yourPrice)
        {
            RestCient rClient = new RestCient();
            rClient.endPoint = name.Text;
            debugOutput("RESTClient Object created.");

            string strJSON = string.Empty;
            strJSON = rClient.makeRequest();

            Item item = JsonSerializer.Deserialize<Item>(rClient.makeRequest());
            if(item.lowest_price != null)
            {
                name.BackColor = Color.White;
                item.itemName = name.Text;
                item.deleteZl();

                float val = Convert.ToSingle(item.lowest_price);
                int intVal = (int)val;
                price.Text = intVal.ToString();

                val = Convert.ToSingle(item.lowest_price) * 0.7f;
                intVal = (int)val;
                yourPrice.Text = intVal.ToString();
            }
            else
            {
                name.BackColor = Color.Red;
            }           
        }

        private void debugOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }

        private void otwórz_Click(object sender, EventArgs e)
        {
            ScreenShot form = new ScreenShot(textBox1, textBox2, textBox3, textBox4, textBox5, imgUrl1, imgUrl2, imgUrl3, imgUrl4, imgUrl5);
            form.Show();
        }


        #endregion

        private void imgButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";

            if(open.ShowDialog() == DialogResult.OK)
            {
                picture1.Image = new Bitmap(open.FileName);

                imgUrl1.Text = open.FileName;
            }
        }

        private void imgButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";

            if (open.ShowDialog() == DialogResult.OK)
            {
                picture2.Image = new Bitmap(open.FileName);

                imgUrl2.Text = open.FileName;
            }
        }

        private void imgButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";

            if (open.ShowDialog() == DialogResult.OK)
            {
                picture3.Image = new Bitmap(open.FileName);

                imgUrl3.Text = open.FileName;
            }
        }

        private void imgButton4_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";

            if (open.ShowDialog() == DialogResult.OK)
            {
                picture4.Image = new Bitmap(open.FileName);

                imgUrl4.Text = open.FileName;
            }
        }

        private void imgButton5_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";

            if (open.ShowDialog() == DialogResult.OK)
            {
                picture5.Image = new Bitmap(open.FileName);

                imgUrl5.Text = open.FileName;
            }
        }
    }
}
