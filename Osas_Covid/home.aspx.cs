using Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using static Core.CovidService;

namespace Osas_Covid
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<grpCases> cases = new CovidController().Get();
                SetYearsList(yearlist, cases);
                GridView1.DataSource = cases;
                GridView1.DataBind();
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Mês";
                e.Row.Cells[1].Text = "Total";
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = DateTime.Parse(e.Row.Cells[0].Text).ToString("MMMM/yyyy");
            }
        }
        protected void OnChange_YearList(object sender, EventArgs e)
        {
            List<grpCases> cases = new CovidController().Get();
            GridView1.DataSource = yearlist.SelectedValue == "Todos" ?
                cases :
                cases.FindAll(i => i.mes.ToString().EndsWith(yearlist.SelectedValue));
            GridView1.DataBind();
        }

        public void SetYearsList(DropDownList dropdownlist, List<grpCases> data)
        {
            dropdownlist.DataSource = data.GroupBy(r => r.mes.Split('/')[1]).Select(g => new ListItem { Value = g.Key }).ToList();
            dropdownlist.Items.Add("Todos");
            dropdownlist.DataBind();
        }
    }
}