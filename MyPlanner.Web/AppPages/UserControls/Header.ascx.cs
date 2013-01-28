﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyPlanner.Models;

namespace MyPlanner.AppPages.UserControls
{
    public partial class Header : System.Web.UI.UserControl
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page.Title = Constants.APP_TITLE;   
        }
    }
}