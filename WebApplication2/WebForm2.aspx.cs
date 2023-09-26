using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = string.Empty;
            StreamReader streamReader = new StreamReader(Server.MapPath(".") + "/archivo.txt");
            string[] lines = (streamReader.ReadToEnd()).Split('\n');
            streamReader.Close();
            string opcion = DropDownList1.SelectedValue.ToString();
            int lineCount = 0;
            foreach (string line in lines)
            {
                lineCount++;
                if (lineCount %2 ==0 )
                {
                    string cuenta = lines[lineCount - 2].ToString().TrimEnd('\r');
                    string tipo = lines[lineCount - 1].ToString().TrimEnd('\r');
                    if (tipo == opcion)
                    {
                        Label1.Text += $"{cuenta} ";
                        Label1.Text += $"{DropDownList1.SelectedItem.Text} <br> <hr>";
                    }

                }
            }
        }
    }
}