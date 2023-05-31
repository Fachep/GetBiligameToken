using System.Windows.Forms;

namespace GetBiligameToken
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://sdk.biligame.com/");
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(Page_load);
        }

        private void Page_load(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            object[] b = { "localStorage[\"4963-token\"]" };
            if (page_load_done) return;
            if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                return;
            if (e.Url == webBrowser1.Url)
            {

                var a = webBrowser1.Document.InvokeScript("eval", b);
                page_load_done = true;
                textBox1.Text = a.ToString();
            }
        }
    }
}