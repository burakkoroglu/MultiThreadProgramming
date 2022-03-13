using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CancelationToken
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        CancellationTokenSource ct = new CancellationTokenSource();
        private async void button1_Click(object sender, EventArgs e)
        {
            Task<HttpResponseMessage> myTask;
            try
            {

                myTask = new HttpClient().GetAsync("https://localhost:44333/api/Home", ct.Token);

                
                await myTask;
                var content = await myTask.Result.Content.ReadAsStringAsync();

                richTextBox1.Text = content;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                richTextBox1.Text = ex.Message;
            }

            
        }

        private  void button2_Click(object sender, EventArgs e)
        {
            
            ct.Cancel();
        }
    }
}
