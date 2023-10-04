using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models
{
    public partial class User
    {

        private myLinqToSqlDataContext dc = new myLinqToSqlDataContext();

        public User(string username, string password, int? groupID, int? trustID, DateTime? date) : this(username, password)
        {
            this.groupID = groupID;
            this.trustID = trustID;
            this.date = date;
        }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public User(string username, string password,int groupId)
        {
            this.username = username;
            this.password = password;
            this.groupID = groupId;
        }
        public User(string username, string password, int groupId,int trustId)
        {
            this.username = username;
            this.password = password;
            this.groupID = groupId;
            this.trustID = trustId;
        }

        // return all users 
        public List<User> getUsers()
        {
            List<User> listUsers = new List<User>();
            listUsers = (from u in dc.Users select u).ToList<User>();

            return listUsers;
        }

        // return one special user
        public User getUser(int id)
        {
          User Us = new User();
            Us = (from u in dc.Users where u.id==id select u).Single();

            return Us;

        } 
        
        public User getUserLog(string username)
        {
          User Us = new User();
            Us = (from u in dc.Users  where u.username == username  select u).Single();

            return Us;
        }

        public void addUser(User u)
        {

            dc.ExecuteCommand("INSERT INTO Users (username,password,groupID,trustID,date) VALUES ({0},{1},{2},{3},{4})",
            u.username,u.password,u.groupID,u.trustID,u.date);

            dc.SubmitChanges();
        }


        public void registerUser(User u)
        {

            dc.ExecuteCommand("INSERT INTO Users (username,password,groupID,trustID,date)  VALUES ({0},{1},{2},{3},{4})",
            u.username,  u.password, u.groupID, 0, DateTime.Now);

            dc.SubmitChanges();
        }

        public void updateUser(User u , int id)
        {
            var us = from use in dc.Users where use.id == id select use; 

            foreach(var use in us)
            {
                use.username = u.username;
                use.password = u.password;
                use.groupID  = u.groupID;
                use.trustID = u.trustID;
                
            }

            dc.SubmitChanges();
        }

        public void deleteUser(User user)
        {
            dc.Users.DeleteOnSubmit(user);
            dc.SubmitChanges();
        }

        public void activeUser(int id)
        {

            dc.ExecuteCommand("update Users set trustID={0} where id={1}", 1,id);

            dc.SubmitChanges();
        }

        public void desactiveUser(int id)
        {

            dc.ExecuteCommand("update Users set trustID={0} where id={1}",
            0, id);

            dc.SubmitChanges();
        }

        public Boolean checkUser(string username)
        {
     
            int n = (from u in dc.Users where u.username==username select u).Count();
            if (n==1)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}