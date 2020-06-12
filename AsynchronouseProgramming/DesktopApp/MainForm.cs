using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void LoadImageButton_Click(object sender, EventArgs e)
        {
            var url =
                "https://media.inquirer.com/storage/inquirer/projects/year-in-pictures-2019/photos/POY2019_RedC.JPG";

            var allImages = await Task.WhenAll(
                  LoadImageAsync(url),
                  LoadImageAsync(url),
                  LoadImageAsync(url),
                  LoadImageAsync(url),
                  LoadImageAsync(url),
                  LoadImageAsync(url),
                  LoadImageAsync(url),
                  LoadImageAsync(url));

            var pictureBoxes = new[]
            {
                pictureBox1,
                pictureBox2,
                pictureBox3,
                pictureBox4,
                pictureBox5,
                pictureBox6,
                pictureBox7,
                pictureBox8
            };

            var imageTasks = new List<Task<Image>>
            {
                LoadImageAsync(url),
                LoadImageAsync(url),
                LoadImageAsync(url),
                LoadImageAsync(url),

                LoadImageAsync(url),
                LoadImageAsync(url),
                LoadImageAsync(url),
                LoadImageAsync(url)
            };

            for (int i = 0; i < pictureBoxes.Length && imageTasks.Count > 0; i++)
            {
                var completedTask = await Task.WhenAny(imageTasks);
                imageTasks.Remove(completedTask);

                pictureBoxes[i].Image = await completedTask;
            }

            //pictureBox1.Image = allImages[0];
            //pictureBox2.Image = allImages[1];
            //pictureBox3.Image = allImages[2];
            //pictureBox4.Image = allImages[3];
            //pictureBox5.Image = allImages[4];
            //pictureBox6.Image = allImages[5];
            //pictureBox7.Image = allImages[6];
            //pictureBox8.Image = allImages[7];
        }

        private static Random random = new Random();
        private HttpClient httpClient = new HttpClient();

        private async Task<Image> LoadImageAsync(string url)
        {
            var response = await httpClient.GetAsync(url);

            var stream = await response.Content.ReadAsStreamAsync();

            await Task.Delay(random.Next(10, 3000));

            return Image.FromStream(stream);
        }

        private void synchronouseButton_Click(object sender, EventArgs e)
        {
            var result = Sum(100_000_000);

            MessageBox.Show($"synchronouse result = {result}");
        }

        private async void asynchronouseButton_Click(object sender, EventArgs e)
        {
            asynchronouseButton.Enabled = false;
            var result = await Task.Run(() => Sum(100_000_000));
            asynchronouseButton.Enabled = true;

            MessageBox.Show($"Asynchronouse result = {result}");
        }

        private BigInteger Sum(long number)
        {
            BigInteger result = 0;
            for (long i = 0; i < number; i++)
            {
                result += i;
            }

            return result;
        }
    }
}