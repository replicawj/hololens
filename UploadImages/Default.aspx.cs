using System;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace UploadImages
{
    public partial class Default : System.Web.UI.Page
    {
        public SqlConnection con;


        public void Connection()
        {
            //General Connection (Not Img/Vid yet)
            string constr = ConfigurationManager.ConnectionStrings["image"].ToString();
            con = new SqlConnection(constr);
            con.Open();

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;


            //Loop Label and Text to be visible = false      
            Image0.Visible = false;

            Image1.Visible = false;            
            Image2.Visible = false;
            Image3.Visible = false;

            Image4.Visible = false;
            Image5.Visible = false;
            Image6.Visible = false;

            Image7.Visible = false;
            Image8.Visible = false;
            Image9.Visible = false;

            FileList.Visible = false;

            if (!IsPostBack) //Prevent Bug where list keep adding after Submit
            {
                Img.Checked = true;

                //Display List
                DisplayList.Items.Add("Top Left");
                DisplayList.Items.Add("Top Middle");
                DisplayList.Items.Add("Top Right");

                DisplayList.Items.Add("Middle Left");
                DisplayList.Items.Add("Middle Middle");
                DisplayList.Items.Add("Middle Right");

                DisplayList.Items.Add("Bottom Left");
                DisplayList.Items.Add("Bottom Middle");
                DisplayList.Items.Add("Bottom Right");

                //Display Content
                DisplayContent.Items.Add("ALL");

                DisplayContent.Items.Add("Top Left");
                DisplayContent.Items.Add("Top Middle");
                DisplayContent.Items.Add("Top Right");

                DisplayContent.Items.Add("Middle Left");
                DisplayContent.Items.Add("Middle Middle");
                DisplayContent.Items.Add("Middle Right");

                DisplayContent.Items.Add("Bottom Left");
                DisplayContent.Items.Add("Bottom Middle");
                DisplayContent.Items.Add("Bottom Right");
            }            
        }       

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (!FileUpload1.HasFile)
            {
                Label1.Visible = true;
                Label1.Text = "Please Select Image File";

            }
            else
            {

                //For Display Dropdown List
                string position = DisplayList.SelectedItem.ToString();

                //For both uploads
                int length = FileUpload1.PostedFile.ContentLength;
                byte[] content = new byte[length];
                FileUpload1.PostedFile.InputStream.Read(content, 0, length);

                if (Img.Checked == true) //New Code To seperate Img and Video Upload via If/Else
                {
                    try
                    {
                        // New Update Command WORKING                    
                        Connection();
                        SqlCommand com = new SqlCommand("UPDATE ForImages " + "SET Image=@photo WHERE Position=@position;", con);
                        com.Parameters.AddWithValue("@photo", content);
                        com.Parameters.AddWithValue("@position", position);
                        com.ExecuteNonQuery();
                        Label1.Visible = true;
                        Label1.Text = "Image Uploaded Sucessfully";
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                else
                {
                    try
                    {
                        // New Update Command                 
                        Connection();
                        SqlCommand com = new SqlCommand("UPDATE ForVideos " + "SET  Video=@vid WHERE Position=@position;", con);
                        com.Parameters.AddWithValue("@vid", content);
                        com.Parameters.AddWithValue("@position", position);
                        com.ExecuteNonQuery();
                        Label1.Visible = true;
                        Label1.Text = "Video Uploaded Sucessfully";
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (RadioButton1.Checked == true) //Codes for Image
            {
                //For Display Dropdown List
                string position = DisplayContent.SelectedItem.ToString();
                
                if (position == "ALL") //Special Case where display ALL
                {
                    // Display all pic code

                    Connection();
                    SqlCommand com1 = new SqlCommand("SELECT Position, Image FROM ForImages;", con);
                    SqlDataReader reader1 = com1.ExecuteReader();
                    
                    dynamic[] array = new dynamic[] { Image1, Image2 , Image3 , Image4 , Image5, Image6, Image7, Image8, Image9};
                    var counter = 0;
                    while (reader1.Read())
                    {
                        array[counter].Visible = true;
                        byte[] displayimg = (byte[])(reader1[1]);
                        string base64StringImg = Convert.ToBase64String(displayimg);
                        array[counter].ImageUrl = String.Format("data:image/jpg;base64,{0}", base64StringImg);
                        counter++;
                    }
                    con.Close();
                }
                else
                {
                    Image0.Visible = true;
                    try
                    {
                        Connection();
                        SqlCommand com = new SqlCommand("SELECT Position, Image FROM ForImages WHERE Position=@position;", con);
                        com.Parameters.AddWithValue("@position", position);
                        SqlDataReader reader = com.ExecuteReader();
                        reader.Read();
                        if (reader.HasRows)
                        {   
                            byte[] displayimg = (byte[])(reader[1]);
                            string base64StringImg = Convert.ToBase64String(displayimg);
                            Image0.ImageUrl = String.Format("data:image/jpg;base64,{0}", base64StringImg);
                        }                       
                    }
                    finally
                    {
                        con.Close();
                    }
                }

            } else if (RadioButton2.Checked == true)//Codes for Video
            {
                FileList.Visible = true;
                Connection();
                string sql = "SELECT Position, ID FROM ForVideos";
                SqlCommand command = new SqlCommand(sql, con);
                
                FileList.DataSource = command.ExecuteReader();
                FileList.DataBind();
                con.Close();
            }
        }
    }
}