using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c___downloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Download_Click(object sender, EventArgs e)
        {
            string url = URLlink.Text; // URL entered by user in TextBox
            string userProfilePath = Environment.GetEnvironmentVariable("USERPROFILE");

            // Extract the file name from the URL and sanitize it
            string fileName = Path.GetFileName(url); // This will grab the file name from the URL (e.g., "song.mp3")

            // Sanitize the filename to ensure it's valid
            fileName = SanitizeFileName(fileName);

            // Combine with user profile path for saving the file
            string filePath = Path.Combine(userProfilePath, fileName);

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Optionally, set headers if needed (e.g., user-agent)
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

                    // Send a HEAD request to get the file size without downloading it yet
                    var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));

                    // Ensure the response is successful
                    response.EnsureSuccessStatusCode();

                    // Get the total file size from the Content-Length header
                    long totalFileSize = response.Content.Headers.ContentLength.GetValueOrDefault();
                    if (totalFileSize == 0)
                    {
                        MessageBox.Show("Unable to determine file size.");
                        return;
                    }

                    // Start downloading the file
                    using (Stream contentStream = await client.GetStreamAsync(url))
                    {
                        // Create a buffer to read the file in chunks
                        byte[] buffer = new byte[8192]; // 8KB buffer
                        int bytesRead;
                        long totalBytesRead = 0;

                        // Open the file to save the content
                        using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            // Read the stream in chunks
                            while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                // Write the chunk to the file
                                await fileStream.WriteAsync(buffer, 0, bytesRead);

                                // Update the progress
                                totalBytesRead += bytesRead;
                                double progressPercentage = (double)totalBytesRead / totalFileSize * 100;
                                double downloadedMB = totalBytesRead / (1024.0 * 1024.0);
                                double totalMB = totalFileSize / (1024.0 * 1024.0);

                                // Update progress bar and labels
                                Progress.Value = (int)progressPercentage;
                                Size.Text = $"{downloadedMB:F1}MB of {totalMB:F1}MB ({progressPercentage:F1}%)";
                            }
                        }
                    }
                    MessageBox.Show("File downloaded successfully to: " + filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error downloading file: " + ex.Message);
            }
        }

        // Function to sanitize the filename by removing invalid characters
        private string SanitizeFileName(string fileName)
        {
            // Replace invalid characters with underscores
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(c, '_');
            }
            return fileName;
        }
    }
}
