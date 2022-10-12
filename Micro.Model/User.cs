using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Model
{
    public class User
    {
        public User(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Dates
    {
        [Key]
        public int id { get; set; }
        public string maximum { get; set; }
        public string minimum { get; set; }
    }

    public class Movie
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public bool adult { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public double popularity { get; set; }
        public string release_date { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
        public int page { get; set; }
    }

    public class MovieObject
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int page { get; set; }
        public List<Movie> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }


    public class MovieVote
    {

        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }

        [Range(1, 10)]
        public Double Vote { get; set; }
        public string Comment { get; set; }
    }

    public class MailModel
    { 
        public int MovieId { get; set; }
        public string MailAddress { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

    }


}
