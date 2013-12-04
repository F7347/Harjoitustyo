using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class ElokuvaRekisteri : System.Web.UI.Page
{

    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        LataaElokuvat();
        
    }
    
    public DataTable LataaElokuvat()
    {
        MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection();

        con.ConnectionString = ConfigurationManager.ConnectionStrings["Elokuva"].ConnectionString;
    
        try
        {
            con.Open();
          
            Label1.Text = "yhteys avattu";

            DataTable dt = new DataTable();

            using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM Elokuva",con))
            {
                adapter.Fill(dt);
                gv.DataSource = dt;
                gv.DataBind();
            }

            con.Close();

            return dt;
            
            
        
        }
        catch (Exception)
        {
            Label1.Text = "yhteys ei toimi";
            throw;
        }
    
    }

    public DataTable PaivitaElokuvat()
    {
        MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection();

        con.ConnectionString = ConfigurationManager.ConnectionStrings["Elokuva"].ConnectionString;



        try
        {
            con.Open();

            

            DataTable dt = new DataTable();

            using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM Elokuva", con))
            {
                adapter.Fill(dt);
                gv.DataSource = dt;
                gv.DataBind();
            }

            con.Close();

            return dt;



        }
        catch (Exception)
        {
            Label1.Text = "yhteys ei toimi";
            throw;
        }

    }



    protected void btnLaheta_Click(object sender, EventArgs e)
    {

        MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection();

        con.ConnectionString = ConfigurationManager.ConnectionStrings["Elokuva"].ConnectionString;
        try
        {
            
            
            con.Open();
            
             
            
             string nimi = txtElokuvanNimi.Text;
             string ohjaaja = txtOhjaaja.Text;
             string vuosi = txtVuosi.Text;
             
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

             cmd.Parameters.Clear();

             cmd.Parameters.AddWithValue("@Nimi", nimi);
             cmd.Parameters.AddWithValue("@Ohjaaja", ohjaaja);
             cmd.Parameters.AddWithValue("@Vuosi", vuosi);

             
            
            cmd.CommandText=("INSERT INTO Elokuva (ElokuvaNimi,Ohjaaja,Vuosi) VALUES (@Nimi,@Ohjaaja,@Vuosi);");

            
            cmd.ExecuteNonQuery();
            con.Close();
        
            Label1.Text = "Elokuva lisätty!";
            PaivitaElokuvat();

        }
        catch (Exception ex)
        {

            Label1.Text = ex.ToString();
        }


    }
    protected void btnPoista_Click(object sender, EventArgs e)
    {
        MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection();

        con.ConnectionString = ConfigurationManager.ConnectionStrings["Elokuva"].ConnectionString;
        try
        {
            con.Open();

            string nimi = txtElokuvanNimi.Text;
            string ohjaaja = txtOhjaaja.Text;
            string vuosi = txtVuosi.Text;

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@Nimi", nimi);
                cmd.Parameters.AddWithValue("@Ohjaaja", ohjaaja);
                cmd.Parameters.AddWithValue("@Vuosi", vuosi);



                cmd.CommandText = ("DELETE FROM Elokuva WHERE ElokuvaNimi=(@Nimi) AND Ohjaaja=(@Ohjaaja) AND Vuosi=(@Vuosi);");


                cmd.ExecuteNonQuery();
                con.Close();

                Label1.Text = "Elokuva poistettu!";
                PaivitaElokuvat();

        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
            
        }
    }
}