using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public class ForumSqlDAO : IForumDAO
    {

        private string connectionString;

        public ForumSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }


        /// <summary>
        /// Gets all posts to the forum page stored inside the database.
        /// </summary>
        /// <returns>IList of ForumPost.</ForumPost></returns>
        public IList<ForumPost> GetAllPosts()
        {
            List<ForumPost> forumList = new List<ForumPost>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"SELECT * FROM Forum_Post order by id desc";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ForumPost forum = new ForumPost();
                        forum.Id = Convert.ToInt32(reader["id"]);
                        forum.Subject = Convert.ToString(reader["subject"]);
                        forum.User = Convert.ToString(reader["username"]);
                        forum.Message = Convert.ToString(reader["message"]);
                        forum.Post_Date = Convert.ToDateTime(reader["postdate"]);
                        forumList.Add(forum);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return forumList;
        }


        /// <summary>
        /// This method allows us to save the forum post to our database. Which can later be accessed to display.
        /// </summary>
        /// <param name="forum"></param>
        /// <returns>Id of the forum post.</returns>
        public void SaveNewPost(ForumPost forum)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = $"insert into Forum_Post (username, subject, message, postDate) values (@username, @subject, @message, @post_date);";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", forum.User);
                    cmd.Parameters.AddWithValue("@subject", forum.Subject);
                    cmd.Parameters.AddWithValue("@message", forum.Message);
                    cmd.Parameters.AddWithValue("@post_date", DateTime.Now);
                    cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public ForumPost GetPostById(int id)
        {
            ForumPost post = new ForumPost();
            post.Id = id;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Forum_Post WHERE id = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", post.Id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        post.Id = Convert.ToInt32(reader["id"]);
                        post.Subject = Convert.ToString(reader["subject"]);
                        post.Message = Convert.ToString(reader["message"]);
                        post.User = Convert.ToString(reader["username"]);
                        post.Post_Date = Convert.ToDateTime(reader["postDate"]);
                    }
                }

                return post;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
