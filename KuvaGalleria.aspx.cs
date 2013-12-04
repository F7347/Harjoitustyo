using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class KuvaGalleria : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LataaKuvat();
        
    }
   

    public DataTable LataaKuvat() 
    {
        

        MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection();

        con.ConnectionString = ConfigurationManager.ConnectionStrings["Elokuva"].ConnectionString;

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM Kuvat", con))
            {
                adapter.Fill(dt);
                gvKuvat.DataSource = dt;
                gvKuvat.DataBind();
            }

            con.Close();

            return dt;
            

        }
        catch (Exception)
        {
            throw;
            
        }
    }



    protected void btnLisaaKuva_Click(object sender, EventArgs e)
    {
        MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection();

        con.ConnectionString = ConfigurationManager.ConnectionStrings["Elokuva"].ConnectionString;


        try
        {
            
            
            string nimi = txtNimi.Text;
            

            System.IO.Stream fs = FileUpload1.PostedFile.InputStream;
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);

            
            
            con.Open();

            MySqlCommand cmd = new MySqlCommand();
            
            cmd.Connection = con;

            

            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@Nimi", nimi);
            cmd.Parameters.AddWithValue("@Kuva", bytes);


            cmd.CommandText = ("INSERT INTO Kuvat (Nimi,Kuva) VALUES (@Nimi,@Kuva);");


            cmd.ExecuteNonQuery();
            con.Close();

            label1.Text = bytes.ToString();
            
            LataaKuvat();
            


        }
        catch (Exception)
        {
            
            
        }

    }
}