﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SoccerInCanada : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.FindControl("header21").Visible = true;
        this.Master.FindControl("header").Visible = false;
    }
}