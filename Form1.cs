using System;
using System.Drawing;
using System.Windows.Forms;
using RestSharp;

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

        private void file_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "select file";
            ofd.InitialDirectory = @"C:\";
            ofd.Filter = "All files (*.*)|*.*|Image File (*.bmp; *.jpeg; *.jpg; *.png)|*.bmp; *.jpeg; *.jpg; *.png";
            ofd.FilterIndex = 2;
            ofd.ShowDialog();
            filePath.Text = ofd.FileName;
            pictureBox.Image = new Bitmap(ofd.FileName);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string apiKey = "acc_9c5c51261ab01d5";
            string apiSecret = "b680d8eedfbe4612f74f93e42c02b25f";
            string imageUrl = "https://docs.imagga.com/static/images/docs/sample/japan-605234_1280.jpg";
            string image = filePath.Text;
            string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));
 



            var client = new RestClient("https://api.imagga.com");

            // POST request
            var request = new RestRequest("v2/uploads", Method.Post);
            request.AlwaysMultipartFormData = true;
            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));
            request.AddFile("image", image);



            RestResponse response = await client.ExecuteAsync(request);
            //Console.WriteLine(response.Content);
            //Console.ReadLine();
            

            //GET request
            request = new RestRequest("v2/tags", Method.Get);
            // request.AddParameter("image_id", (get upload ID from post");
                request.AddParameter("image_url", imageUrl);
                request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));

            response = await client.GetAsync(request);
            Console.WriteLine(response.Content);
            Console.ReadLine();


            

        }

    }
}
