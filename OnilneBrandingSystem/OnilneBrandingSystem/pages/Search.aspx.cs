﻿using OnilneBrandingSystem.Classes;
using OnilneBrandingSystem.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnilneBrandingSystem.pages
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillPage();
        }
        private void FillPage()
        {
            string keywords = "";
            if (!string.IsNullOrEmpty(Request.QueryString["keywords"]))
            {
                keywords = Request.QueryString["keywords"];
            }
            List<brandClass> brandList = brandDAL.GetBrandsBYKeywords(keywords);
            if(brandList.Count==0)
            {
                lblError.Text = "No Brands Found";
            }
            StringBuilder sb = new StringBuilder();

            foreach(brandClass brand in brandList)
            {
                sb.Append(string.Format(@"
                        <a href='brandDetail.aspx?id={0}'>
                    <div class='brand-box'>
                        <img src = '../images/brands/brand1.jpg' runat='server' />
                        <h3>{1}</h3>
                        Added Date: {2}
                    </div>
                </a>
                    
                ",brand.brand_id,brand.brand_name,brand.addedDate));
                lblError.Text = sb.ToString();
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string keywords = txtSearch.Text;
            Response.Redirect("~/Pages/Search.aspx?keywords=" + keywords);
        }
    }
}