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
    public partial class Contact : Page
    {
        LegalPersonService Service = LegalPersonService.getInstance("legel.csv",IndPersonService.getInstance("Individual.csv"));

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Service.GetAll(false) == null)
            {
                List<LegalPerson> IndividualPersons = new List<LegalPerson>()
                 {
                   new LegalPerson(3, "9325152", DateTime.Now.Date, "Человек1", DateTime.Today, null, "ТОО КазЦинк")
                  ,new LegalPerson(1, "9325152", DateTime.Now.Date, "Человек1", DateTime.Today, null, "ТОО Эмиль")
                  ,new LegalPerson(2, "9325153", DateTime.Now.Date, "Человек1", DateTime.Today, null, "ИП Пирогова")

                 };

                Service.Create(IndividualPersons);
            }
            if (!this.IsPostBack)
            {
                this.BindRepeater();
            }
        }
        public IEnumerable<string> GetCategories()
        {
            
            return new string[] { "Все" }.Concat(Service.GetAll(false).Select(g => g.IIN_BIN).Distinct().OrderBy(c => c));
        }
        private void BindRepeater(string Filter = "Все")
        {
            IEnumerable<LegalPerson> result;
            if (Filter == "Все")
                result = Service.GetAll(false);
            else
                result = Service.GetAll(false).Where(x => x.IIN_BIN == Filter);


            Repeater1.DataSource = Converter.ConvertToDatatable(result);
            Repeater1.DataBind();
        }

        protected void Insert(object sender, EventArgs e)
        {
            try
            {

                Service.Create(new LegalPerson(Convert.ToInt16(Id.Text), IIN_BIN.Text, DateTime.Now.Date, "", DateTime.Now.Date, "", Name.Text));

                this.BindRepeater();

            }
            catch (Exception ex)
            {

            }


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
            item.FindControl("lblId").Visible = !isEdit;
            item.FindControl("lblIIN").Visible = !isEdit;
            item.FindControl("lblName").Visible = !isEdit;
   

            //Toggle TextBoxes.
            item.FindControl("txtId").Visible = isEdit;
            item.FindControl("txtIIN").Visible = isEdit;
            item.FindControl("txtName").Visible = isEdit;
     

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
            int Id = int.Parse((item.FindControl("lblId") as Label).Text);
            string IIN = (item.FindControl("txtIIN") as TextBox).Text.Trim();
            string Name = (item.FindControl("txtName") as TextBox).Text.Trim();

         

            var indPerson = Service.GetAll(false).FirstOrDefault(x => x.Id == Id);
            if (indPerson != null)
            {
                indPerson.IIN_BIN = IIN;
                indPerson.FullName = Name;
             
                Service.Update(indPerson);

            }



            this.BindRepeater();
        }
        protected void OnFiltered(object sender, EventArgs e)
        {
            var g = ddList.SelectedValue;


            this.BindRepeater(g);

        }
        protected void OnDelete(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int Id = int.Parse((item.FindControl("lblId") as Label).Text);

            Service.Delete(Id);
            this.BindRepeater();

        }
    }
}