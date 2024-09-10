using RestSharp;

namespace ImageUploaderTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select image to be upload.";
            openFileDialog1.Filter = "Image Only(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = Path.GetFullPath(openFileDialog1.FileName);
                        lblFilePath.Text = path;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload image.");
                }
            }
            catch (Exception ex)
            {
                //it will give if file is already exits..
                MessageBox.Show(ex.Message);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = Path.GetFileName(openFileDialog1.FileName);
                if (filename == null)
                {
                    MessageBox.Show("Please select a valid image.");
                }
                else
                {
                    // Upload image to web server
                    using (var fileStream = File.Open(openFileDialog1.FileName, FileMode.Open))
                    {
                        var client = new RestClient("https://localhost:7208/api"); // Your server URL
                        var request = new RestRequest("/file/upload/", Method.Post);

                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            // Copy file stream to memory stream
                            await fileStream.CopyToAsync(memoryStream);

                            // Add the image file to the request
                            request.AddFile("file", memoryStream.ToArray(), filename);
                            request.AlwaysMultipartFormData = true;

                            // Execute the request and get the response
                            var response = await client.ExecuteAsync(request);
                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                MessageBox.Show("Image uploaded successfully");
                            }
                            else
                            {
                                MessageBox.Show("Image upload failed. Server returned: " + response.StatusCode);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unexpected error occured.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}