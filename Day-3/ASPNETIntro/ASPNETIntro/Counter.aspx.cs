using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNETIntro
{
    public partial class Counter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var number1 = int.Parse(this.txtNumber1.Text);
            var number2 = int.Parse(this.txtNumber2.Text);
            var result = number1 + number2;
            this.lblResult.Text = result.ToString();
        }
    }
}