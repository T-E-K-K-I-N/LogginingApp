using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogginingApp.Data.Models;
using System.Web.ModelBinding;
using LogginingApp.Data;

namespace LogginingApp
{
    public partial class Registration : System.Web.UI.Page
    {
        private SqlConnection sqlConnection = null;

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Participant participant = new Participant();

                if (TryUpdateModel(participant, new FormValueProvider(ModelBindingExecutionContext)))
                {
                    ParticipantController.GetController().AddParticipant(participant);
                }
            }

            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();
          
        }

        protected async void Button1_Click(object sender, EventArgs e)
        {

            Dictionary<string, string> db = new Dictionary<string, string>();
            SqlCommand sqlCommand = new SqlCommand("SELECT [Email], [Password] FROM [Participants]", sqlConnection);
            SqlDataReader sqlReader = null;

            using(sqlReader = await sqlCommand.ExecuteReaderAsync())
            {
                while (await sqlReader.ReadAsync())
                {
                    db.Add(Convert.ToString(sqlReader["Email"]), Convert.ToString(sqlReader["Password"]));
                }
            }

            if (!db.Keys.Contains(TextBox2.Text))
            {
                SqlCommand regParticipant = new SqlCommand("INSERT INTO [Participants] (Name, Gender, Age," +
                    " Experience, ResidenceCity, Email, Password) VALUES (@Name, @Gender, @Age, " +
                    "@Experience, @ResidenceCity, @Email, @Password)", sqlConnection);

                regParticipant.Parameters.AddWithValue("Name", TextBox1.Text);
                regParticipant.Parameters.AddWithValue("Gender", Select1.Value);
                regParticipant.Parameters.AddWithValue("Age", TextBox3.Text);
                regParticipant.Parameters.AddWithValue("Experience", TextBox4.Text);
                regParticipant.Parameters.AddWithValue("ResidenceCity", TextBox5.Text);
                regParticipant.Parameters.AddWithValue("Email", TextBox2.Text);
                regParticipant.Parameters.AddWithValue("Password", TextBox6.Text);

                await regParticipant.ExecuteNonQueryAsync();
            }
            else
            {
                string script = "alert('Пользователь с таким Email уже есть');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "MessageBox", script, true);
            }
        }

    
    }
}