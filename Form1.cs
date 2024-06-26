﻿// describes behavior of buttons

using RestSharp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void File_Click(object sender, EventArgs e)
        {
            // opens file explorer allowing user to choose a file
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "select file",
                InitialDirectory = @"C:\Users\2003474\Downloads",
                Filter = "All files (*.*)|*.*|Image File (*.bmp; *.jpeg; *.jpg; *.png)|*.bmp; *.jpeg; *.jpg; *.png",
                FilterIndex = 2
            };
            ofd.ShowDialog();
            filePath.Text = ofd.FileName;
            pictureBox.Image = new Bitmap(ofd.FileName);
            button1.Visible = true;
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;
            progressBar4.Value = 0;
            progressBar5.Value = 0;

            // sets up the server
            string apiKey = "acc_9c5c51261ab01d5";
            string apiSecret = "b680d8eedfbe4612f74f93e42c02b25f";
            string image = filePath.Text;
            string basicAuthValue = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));
            var client = new RestClient("https://api.imagga.com");


            // gets an image id
            var request = new RestRequest("v2/uploads", Method.Post)
            {
                AlwaysMultipartFormData = true
            };
            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));
            request.AddFile("image", image);

            RestResponse response = await client.ExecuteAsync(request);

            dynamic x = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);
            var result = x.result;
            string upload_id = result.upload_id;




            // gets the describing words 
            request = new RestRequest("v2/tags", Method.Get);
            request.AddParameter("image_upload_id", upload_id);
            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));

            response = await client.GetAsync(request);
            x = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);
            result = x.result;
            var tagsPlaceholder = result.tags;
            Tag[] tags = new Tag[10];


            for (int i = 0; i < tags.Length; i++)
            {
                Console.Out.WriteLine();
                tags[i] = new Tag
                {
                    confidence = tagsPlaceholder[i].confidence,
                    name = tagsPlaceholder[i].tag.en,
                };
            }

            // prints everything to screen
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;

            progressBar1.Visible = true;
            progressBar2.Visible = true;
            progressBar3.Visible = true;
            progressBar4.Visible = true;
            progressBar5.Visible = true;

            textBox1.Text = tags[0].name + ":";
            textBox2.Text = tags[1].name + ":";
            textBox3.Text = tags[2].name + ":";
            textBox4.Text = tags[3].name + ":";
            textBox5.Text = tags[4].name + ":";


            progressBar1.Value = (int)tags[0].confidence;
            progressBar2.Value = (int)tags[1].confidence;
            progressBar3.Value = (int)tags[2].confidence;
            progressBar4.Value = (int)tags[3].confidence;
            progressBar5.Value = (int)tags[4].confidence;

            textBox10.Text = (int)tags[0].confidence + "%";
            textBox9.Text = (int)tags[1].confidence + "%";
            textBox8.Text = (int)tags[2].confidence + "%";
            textBox7.Text = (int)tags[3].confidence + "%";
            textBox6.Text = (int)tags[4].confidence + "%";



        }

        private void aboutMe_Click(object sender, EventArgs e)
        {
            aboutMeText.Visible = !aboutMeText.Visible;
        }
    }
}
