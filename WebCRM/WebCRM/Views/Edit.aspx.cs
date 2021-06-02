using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCRM.Views
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                 
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
       /*     cn.Open();
            qry = "update StudentInfo set name='" + txtName.Text + "', age=" + txtAge.Text + " where id=" + Request.QueryString["id"];
            cmd = new SqlCommand(qry, cn);
            cmd.ExecuteNonQuery();
            Response.Write("<script> alert('Record Updated !') </script>");
            cn.Close();*/
        }


    }
}