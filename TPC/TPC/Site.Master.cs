using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace TPC
{
    public partial class SiteMaster : MasterPage
    {

        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TPCConnectionString"].ConnectionString);

        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string userSearch = SearchTextBox.Text.ToLower();
            string sqlQuery = "SELECT dbo.Item.Name, dbo.Ingrediens.Name AS Ingrediens FROM dbo.Item INNER JOIN dbo.Item_Ingrediens ON dbo.Item.ID_Item = dbo.Item_Ingrediens.ID_Item INNER JOIN dbo.Ingrediens ON dbo.Ingrediens.ID_Ingrediens = dbo.Item_Ingrediens.ID_Ingrediens WHERE (dbo.Item.ID_Item IN (SELECT Item_1.ID_Item FROM dbo.Item AS Item_1 INNER JOIN dbo.Item_Ingrediens AS Item_Ingrediens_1 ON Item_1.ID_Item = Item_Ingrediens_1.ID_Item INNER JOIN dbo.Ingrediens AS Ingrediens_1 ON Item_Ingrediens_1.ID_Ingrediens = Ingrediens_1.ID_Ingrediens WHERE(Ingrediens_1.Name LIKE '%' + @search + '%')))";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            Debug.WriteLine(userSearch);

            // Checks if the string contains æ, ø or å, and convertes it to ?.
            if (userSearch.Contains("æ") == true || userSearch.Contains("ø") == true || userSearch.Contains("å") == true)
            {
                userSearch = userSearch.Replace('æ', '?');
                userSearch = userSearch.Replace('ø', '?');
                userSearch = userSearch.Replace('å', '?');
            }
            Debug.WriteLine(userSearch);

            sqlCommand.Parameters.Add("@search", SqlDbType.NVarChar).Value = userSearch;

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = sqlCommand;
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataAdapter.Fill(dataSet);
            Debug.WriteLine("dataSet Content: " + dataSet.ToString());
            GridView1.DataSource = dataSet;
            GridView1.DataBind();

            sqlConnection.Close();
        }
    }
}