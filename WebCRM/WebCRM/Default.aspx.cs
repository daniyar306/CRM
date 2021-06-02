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
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IndividualPersonsService.GetAll(false) == null)
            {
                List<IndividualPerson> IndividualPersons = new List<IndividualPerson>()
                 {
                   new IndividualPerson(3, "9325152", DateTime.Now.Date, "Человек1", DateTime.Today, null, "Baniyar", "Baniyar", "Baniyar", 2)
                  ,new IndividualPerson(1, "9325152", DateTime.Now.Date, "Человек1", DateTime.Today, null, "Daniyar", "Daniyar", "Daniyar", 1)
                  ,new IndividualPerson(2, "9325153", DateTime.Now.Date, "Человек1", DateTime.Today, null, "Amangeldi", "Amangeldi", "Amangeldi", 2)

                 };

                IndividualPersonsService.Create(IndividualPersons);
            }
            if (!this.IsPostBack)
            {
                this.BindRepeater();
            }
        }

        public IEnumerable<string> GetCategories()
        {
            return new string[] { "Все" }.Concat(IndividualPersonsService.GetAll(false).Select(g => g.IIN_BIN).Distinct().OrderBy(c => c));
        }

        private void BindRepeater(string Filter= "Все")
        {
            IEnumerable<IndividualPerson> result;
            if (Filter == "Все")
                result = IndividualPersonsService.GetAll(false);
            else
                result= IndividualPersonsService.GetAll(false).Where(x=>x.IIN_BIN== Filter);

            Repeater1.DataSource = Converter.ConvertToDatatable(result);
            Repeater1.DataBind();
        }

        protected void Insert(object sender, EventArgs e)
        {
            try
            {

                IndividualPersonsService.Create(new IndividualPerson(Convert.ToInt16(Id.Text), IIN_BIN.Text, DateTime.Now.Date, "", DateTime.Now.Date, "", Name.Text, SecondName.Text, LastName.Text, Convert.ToInt16(LegalPerson_Id.Text)));

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
            item.FindControl("lblLastName").Visible = !isEdit;
            item.FindControl("lblSecondName").Visible = !isEdit;
            item.FindControl("lblLegalPerson_Id").Visible = !isEdit;
    
            //Toggle TextBoxes.
            item.FindControl("txtId").Visible = isEdit;
            item.FindControl("txtIIN").Visible = isEdit;
            item.FindControl("txtName").Visible = isEdit;
            item.FindControl("txtLastName").Visible = isEdit;
            item.FindControl("txtSecondName").Visible = isEdit;
            item.FindControl("txtLegalPerson_Id").Visible = isEdit;
        
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

            string LastName = (item.FindControl("txtLastName") as TextBox).Text.Trim();
            string SecondName = (item.FindControl("txtSecondName") as TextBox).Text.Trim();
            int LPersId = int.Parse((item.FindControl("txtLegalPerson_Id") as TextBox).Text.Trim());

            var indPerson = IndividualPersonsService.GetAll(false).FirstOrDefault(x=>x.Id==Id);
            if (indPerson != null) 
            {
                indPerson.IIN_BIN = IIN;
                indPerson.Name = Name;
                indPerson.LastName = LastName;
                indPerson.SecondName = SecondName;
                indPerson.LegalPerson_Id = LPersId;
                IndividualPersonsService.Update(indPerson);

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
           
                IndividualPersonsService.Delete(Id);
                this.BindRepeater();
            
        }

    }
}