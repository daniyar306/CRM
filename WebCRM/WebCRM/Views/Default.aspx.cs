using CRM.BLL.DTO;
using CRM.BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebCRM.Models;

namespace WebCRM
{
    public partial class Default : Page
    {
        IndPersonService IndividualPersonsService = IndPersonService.getInstance("Individual.csv");
        int incrementID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                List<IndividualPerson> IndividualPersons = new List<IndividualPerson>()
                 {
                   new IndividualPerson(3, "9325152", DateTime.Now.Date, "Человек1", DateTime.Today, null, "Baniyar", "Baniyar", "Baniyar", 2)
                  ,new IndividualPerson(1, "9325152", DateTime.Now.Date, "Человек1", DateTime.Today, null, "Daniyar", "Daniyar", "Daniyar", 1)
                  ,new IndividualPerson(2, "9325153", DateTime.Now.Date, "Человек1", DateTime.Today, null, "Amangeldi", "Amangeldi", "Amangeldi", 2)

                 };

                IndividualPersonsService.Create(IndividualPersons);

                this.BindRepeater();
            }
        }

        private void BindRepeater()
        {
            Repeater1.DataSource = Converter.ConvertToDatatable(IndividualPersonsService.GetAll(false));
            Repeater1.DataBind();
        }

        protected void Insert(object sender, EventArgs e)
        {
           
    //        IndividualPersonsService.Create(new IndividualPerson(incrementID++, txtIIN., DateTime CreateDate, string Create_Autor, DateTime UpdateDate, string Update_Autor, string Name, string SecondName, string LastName, int LegalPerson_Id))
            this.BindRepeater();
        }

        protected void OnEdit(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            this.ToggleElements(item, true);
        }

        private void ToggleElements(RepeaterItem item, bool isEdit)
        {
            //Toggle Buttons.
            item.FindControl("lnkEdit").Visible = !isEdit;
            item.FindControl("lnkUpdate").Visible = isEdit;
            item.FindControl("lnkCancel").Visible = isEdit;
            item.FindControl("lnkDelete").Visible = !isEdit;

            //Toggle Labels.
            item.FindControl("lblContactName").Visible = !isEdit;
            item.FindControl("lblCountry").Visible = !isEdit;

            //Toggle TextBoxes.
            item.FindControl("txtContactName").Visible = isEdit;
            item.FindControl("txtCountry").Visible = isEdit;
        }

        protected void OnCancel(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            this.ToggleElements(item, false);
        }

        protected void OnUpdate(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int customerId = int.Parse((item.FindControl("lblCustomerId") as Label).Text);
            string name = (item.FindControl("txtContactName") as TextBox).Text.Trim();
            string country = (item.FindControl("txtCountry") as TextBox).Text.Trim();

         /*   string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Customers_CRUD"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "UPDATE");
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Country", country);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindRepeater();*/
        }

        protected void OnDelete(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int customerId = int.Parse((item.FindControl("lblCustomerId") as Label).Text);

          /*  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Customers_CRUD"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "DELETE");
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindRepeater();*/
        }

    }
}