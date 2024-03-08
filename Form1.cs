using System;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
//using Newtonsoft.Json;
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

        private void File_Click(object sender, EventArgs e)
        {
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
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            string apiKey = "acc_9c5c51261ab01d5";
            string apiSecret = "b680d8eedfbe4612f74f93e42c02b25f";
            string image = filePath.Text;
            string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));
 



            var client = new RestClient("https://api.imagga.com");

            // POST request
            var request = new RestRequest("v2/uploads", Method.Post)
            {
                AlwaysMultipartFormData = true
            };
            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));
            request.AddFile("image", image);

            RestResponse response = await client.ExecuteAsync(request);
            //dynamic postResponse = JsonSerializer.Deserialize<dynamic>(response.Content);
            //string uploadID = postResponse.result.upload_id;
            dynamic x = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);
            var result = x.result;
            string upload_id = result.upload_id;




            //GET request
            request = new RestRequest("v2/tags", Method.Get);
            request.AddParameter("image_upload_id", upload_id);
            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));

            response = await client.GetAsync(request);
            Console.WriteLine(response.Content);
            x = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);
            result = x.result;
            var tagsPlaceholder = result.tags;
            Tag[] tags = new Tag[10];
            for(int i = 0; i < tags.Length; i++)
            {
                Console.Out.WriteLine();
                tags[i].confidence = tagsPlaceholder[i].confidence.ToObject<decimal>();
                tags[i].confidence = tagsPlaceholder[i].tag.en.ToString();
            }





        }

    }
}
