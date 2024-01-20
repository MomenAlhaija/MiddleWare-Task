using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace WebForm2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string Cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            using (SqlConnection sqlConnection = new SqlConnection(Cs)) {
               
                SqlDataAdapter adapter = new SqlDataAdapter("select*from Products", sqlConnection);               
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }

           
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection sqlConnection = new SqlConnection(Cs))
            {
                string Query = ("select*from Products where Product_id=" + ProductIDtxt.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(Query, sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                ViewState["SQL_Query"]= Query;
                ViewState["Data_Set"] = ds;

                if (ds.Tables[0].Rows.Count>0)
                {
                   DataRow dr= ds.Tables[0].Rows[0];
                   ProductNametxt.Text= dr["Product_Name"].ToString();
                    ProductPricetxt.Text = dr["Product_Price"].ToString();
                }
             
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Cs))
            {

                SqlDataAdapter Adapter = new SqlDataAdapter((string)ViewState["SQL_Query"], sqlConnection);
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(Adapter);
                DataSet ds = (DataSet)ViewState["Data_Set"];
                if (ds.Tables[0].Rows.Count > 0) 
                    Adapter.Update(ds);
               
            }
        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {

        }
    }
}