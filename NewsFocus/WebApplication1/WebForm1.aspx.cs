using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string demo_str = null;
            
            // client for NewsFocus Service
            ServiceReference3.Service1Client client = new ServiceReference3.Service1Client();
            
            //Splits input topics text
            string[] demo = TextBox1.Text.Split(' ');

            //Returns response string using service NewsFocus
            string[] re_str = client.NewsFocus(demo);

            for (int i = 0; i < re_str.Length; i++)
            {
                demo_str += "<br />" + "<a href=" + re_str[i] + " runat=\"server\">" + re_str[i]+ "</a>";
            }

            //List the URLs in Label
            Label1.Text = demo_str;
        }
    }
}