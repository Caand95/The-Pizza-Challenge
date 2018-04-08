using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using System.Data;

namespace TPC
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TPCConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MenuMultiView.ActiveViewIndex = 0;
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string userSearch = MenuSearchTextBox.Text.ToLower();
            string sqlQuery = "SELECT dbo.Item.Name, dbo.Ingrediens.Name AS Ingrediens FROM dbo.Item INNER JOIN dbo.Item_Ingrediens ON dbo.Item.ID_Item = dbo.Item_Ingrediens.ID_Item INNER JOIN dbo.Ingrediens ON dbo.Ingrediens.ID_Ingrediens = dbo.Item_Ingrediens.ID_Ingrediens WHERE (dbo.Item.ID_Item IN (SELECT Item_1.ID_Item FROM dbo.Item AS Item_1 INNER JOIN dbo.Item_Ingrediens AS Item_Ingrediens_1 ON Item_1.ID_Item = Item_Ingrediens_1.ID_Item INNER JOIN dbo.Ingrediens AS Ingrediens_1 ON Item_Ingrediens_1.ID_Ingrediens = Ingrediens_1.ID_Ingrediens WHERE(Ingrediens_1.Name LIKE '%' + @search + '%')))order by item.ID_Item";
            SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.Add("@search", SqlDbType.NVarChar).Value = userSearch;

            sqlConnection.Open();
            command.ExecuteNonQuery();

            SqlDataReader dataReader = command.ExecuteReader();

            Debug.WriteLine("Debug: Before while statement");
            if (TextBox1.Text == "")
            {
                while (dataReader.Read())
                {
                    TextBox1.Text += dataReader.GetString(0) + " " + dataReader.GetString(1) + "\r";
                }
            }
            else
            {
                TextBox1.Text = "";
                while (dataReader.Read())
                {
                    TextBox1.Text += dataReader.GetString(0) + " " + dataReader.GetString(1) + "\r";
                }
            }
            Debug.WriteLine("Debug: After while statement");

            dataReader.Close();
            sqlConnection.Close();
            MenuSearchTextBox.Text = "";
        }
    }
}