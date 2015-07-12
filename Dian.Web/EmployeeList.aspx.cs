﻿using Dian.Biz;
using Dian.Common.Entity;
using Dian.Common.Interface;
using Dian.Web.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dian.Web
{
    public partial class EmployeeList : BasePage
    {
        public int CurPage { get; set; }
        public int TotalCount { get; set; }
        public int PageCount { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            CurPage = base.ParseInt(Request.QueryString["page"]);

            if (IsPostBack)
                DeleteData();

            BindData();
        }
        private void BindData()
        {
            IEmployee biz = new EmployeeBiz();
            var pds = new PagedDataSource();
            pds.DataSource = biz.GetEmployeesDataTable().DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 8;
            if (CurPage < 1) CurPage = 1;
            if (CurPage > pds.PageCount) CurPage = pds.PageCount;
            pds.CurrentPageIndex = CurPage - 1;
            repeater1.DataSource = pds;
            repeater1.DataBind();
            TotalCount = pds.DataSourceCount;
            PageCount = pds.PageCount;
        }
        private void DeleteData()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.hDeleteId.Value))
                {
                    IEmployee biz = new EmployeeBiz();
                    biz.DeleteEmployeeEntity(new EmployeeEntity() { EMPLOYEE_ID = this.hDeleteId.Value });
                    this.lMsg.InnerText = "删除成功!";
                }
            }
            catch (Exception ex)
            {
                this.lMsg.InnerText = "删除失败，原因：" + ex.ToString();
            }
        }

        public string GetSexName(string val)
        {
            switch (val)
            {
                case "1": return "男";
                case "2": return "女";
                case "3": return "保密";
                default: return "-";
            }
        }

        public string GetIsAdminName(string val)
        {
            switch (val)
            {
                case "False": return "否";
                case "True": return "是";
                default: return "-";
            }
        }

    }
}