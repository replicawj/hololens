<%@ webhandler language="C#" class="ImageHandler" %>
using System; 
using System.Web; 
using System.Data; 
using System.Data.SqlClient;
using System.Configuration;
public class ImageHandler : IHttpHandler 
{ 
	public bool IsReusable { get { return true; } } 
    
    public void ProcessRequest(HttpContext ctx) 
    {
        string sql = "SELECT Image FROM ForImages WHERE ID = '" + ctx.Request.QueryString["ID"] + "'";
		
		string constr = ConfigurationManager.ConnectionStrings["image"].ToString();
        SqlConnection con = new SqlConnection(constr);

		SqlCommand command = new SqlCommand(sql, con);
        con.Open();
        SqlDataReader dr = command.ExecuteReader();

        if(dr.Read()){
        
        ctx.Response.Clear();
		ctx.Response.AddHeader("Content-Type","image/jpg");
        ctx.Response.BinaryWrite((byte[])dr["Image"]);
		}

        dr.Close();
        con.Close();
    } 
} 