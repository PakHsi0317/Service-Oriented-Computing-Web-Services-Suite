using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.MyService;
using System.Web.Services.Description;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            ServiceReference1.Service1Client service1Client = new ServiceReference1.Service1Client();

            Stream fileStream = FileUpload1.FileContent;
            string result = service1Client.WordCount1(fileStream);

            System.Web.UI.HtmlControls.HtmlTextArea Output1 =
            (System.Web.UI.HtmlControls.HtmlTextArea)(FindControl("TextArea1"));
            Output1.Value = result;

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            // Clear the ListBox before displaying new results
            ListBox1.Items.Clear();
            string url = TextBox1.Text;

            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            string[] wsdlAddresses = client.getWsdlAddress(url);

            // Display the WSDL addresses on the page
            foreach (string wsdlAddress in wsdlAddresses)
            {
                ListBox1.Items.Add(wsdlAddress);
                //Response.Write(wsdlAddress + "<br/>");
            }
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client service1Client = new ServiceReference1.Service1Client();
            // Call the Number2Words method to convert the input number to words
            string result = service1Client.Number2Words(TextBox2.Text);

            // Display the result in TextBox3
            TextBox3.Text = result;
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button5_Click1(object sender, EventArgs e)
        {
            string message = TextBox4.Text;

            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "message/plain";


                byte[] responseBytes = client.DownloadData($"http://webstrar33.fulton.asu.edu/page4/Service1.svc/ToMorseCode?message={message}");


                string morseCode = responseBytes != null ? Encoding.UTF8.GetString(responseBytes, 0, responseBytes.Length) : "";

                morseCode = Regex.Replace(morseCode, "<.*?>", string.Empty);

                TextBox5.Text = morseCode;

            }

        }

        protected void Button4_Click1(object sender, EventArgs e)
        {
            ServiceReference3.ServiceClient client = new ServiceReference3.ServiceClient();

            string decodedString = client.Decode(TextBox6.Text);

            TextBox7.Text = decodedString.ToString().TrimEnd();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string url = TextBox1.Text; // assuming TextBox1 is where you input the url of the wsdl
            ServiceReference4.Service1Client client = new ServiceReference4.Service1Client();  
            try
            {
                string[] operations = client.GetWsOperations(url);
                ListBox1.Items.Clear(); // assuming ListBox1 is where you display the operations
                foreach (string operation in operations)
                {
                    ListBox1.Items.Add(operation);
                }
            }
            catch (Exception ex)
            {
                ListBox1.Items.Add("wrong files.");
            }
        }
    }

}