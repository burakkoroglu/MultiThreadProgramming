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

namespace ParallelForEach.CancelationToken
{
    public partial class Form1 : Form
    {

        CancellationTokenSource ct;


        public Form1()
        {
            InitializeComponent();
            ct = new CancellationTokenSource();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ct = new CancellationTokenSource(); // her click'te yeni token ver 
            List<string> urls = new List<string>()
            {
                "https://www.google.com",
                "https://www.amazon.com",
                "https://www.twitter.com",
                "https://www.microsoft.com"
            };


            HttpClient httpClient = new HttpClient();


            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken = ct.Token;

            Task.Run(() => // Task.Run ile foreach i farklıbir  thread üzerinde çalıştır 
           {
               try
               {
                   Parallel.ForEach<string>(urls, parallelOptions, (url) =>
                   {
                       string content = httpClient.GetStringAsync(url).Result;

                       string data = $"{url}  : {content.Length}";

                       parallelOptions.CancellationToken.ThrowIfCancellationRequested();

                       listBox1.Invoke((MethodInvoker)delegate
                       {
                           listBox1.Items.Add(data);
                       });

                   });
               }
               catch (Exception ex)
               {

                   MessageBox.Show("İşlem Iptal Edildi : " + ex.Message.ToString());
               }
               
           });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ct.Cancel();
        }
    }
}
