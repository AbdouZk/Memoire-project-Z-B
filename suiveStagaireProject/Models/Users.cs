using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models
{
    public class Users
    {
        private int id;
        private string username;
        private string password;
        private int groupID;
        private int trustID;
        private DateTime date;

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int GroupID { get => groupID; set => groupID = value; }
        public int TrustID { get => trustID; set => trustID = value; }
        public DateTime Date { get => date; set => date = value; }

        public Users()
        {
        }

        public Users(int id, string username, string password, int groupID, int trustID, DateTime date)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.groupID = groupID;
            this.trustID = trustID;
            this.date = date;
        }

        public Users(string username, string password, int groupID, int trustID, DateTime date)
        {
            this.username = username;
            this.password = password;
            this.groupID = groupID;
            this.trustID = trustID;
            this.date = date;
        }

        public Users(string username, string password)
        {
            this.username = username;
            this.password = password;
        }


    }
}