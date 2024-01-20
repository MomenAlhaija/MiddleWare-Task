using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class Home : System.Web.UI.Page
    {
      public static int x = 0;
        public void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;

        }

        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (RadioButton1.Checked) Label1.Text = RadioButton1.Text;
            if(RadioButton2.Checked) Label1.Text  = RadioButton2.Text;
                
                    
                    
                    
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Label2.Text=RadioButtonList1.SelectedItem.ToString();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string Name = TextBox1.Text;
            string Email=TextBox2.Text;
            string Age=TextBox3.Text;
            TableRow row = new TableRow();
            TableCell tableCell1 = new TableCell();
            tableCell1.Text = Name;
            TableCell tableCell2 = new TableCell();
            tableCell2.Text = Email; 
            TableCell tableCell3 = new TableCell();
            tableCell3.Text = Age;
            TableCell[] cells=new TableCell[] { tableCell1, tableCell2, tableCell3 };
            row.Cells.AddRange(cells);

            Table1.Rows.Add(row);
        }
    }
}