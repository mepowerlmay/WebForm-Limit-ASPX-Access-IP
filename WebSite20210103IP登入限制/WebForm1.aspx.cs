using Alonso.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite20210103IP登入限制.DAL;
using WebSite20210103IP登入限制.Model;

namespace WebSite20210103IP登入限制
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SYSAADAL DAL = new SYSAADAL();
                var test = GetCurrentPageName();
                SYSAA m = DAL.GetModelByCond(string.Format(" AA002='{0}' ", test));

                //抓目前IP
                string sIP = Tool.GetAddressIP_CS();

                //抓出允取IP
                bool IsAllow = false;
                string[] ArrayAA003 = m.AA003.Split(';');
                foreach (string AA003 in ArrayAA003)
                {
                   string temp  = AA003.Replace("\r\n","");
                    if (temp == sIP)
                    {
                        IsAllow = true;
                        break;
                    }

                    //* 表示全部.. 可能會有191.168.1.* 192.168.*.*
                    if (temp.Contains("*"))
                    {
                        temp = temp.Replace(".*", "");
                    }

                    if (sIP.Contains(temp))
                    {
                        IsAllow = true;
                        break;
                    }
                }
            }
        }

        public string GetCurrentPageName()
        {
            string sPath = Request.Url.AbsolutePath;
            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            string sRet = oInfo.Name;
            sRet = sRet.Replace(".aspx", "");
            return sRet;
        }
    }
}