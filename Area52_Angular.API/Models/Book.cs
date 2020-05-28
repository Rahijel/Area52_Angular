using System;

namespace Area52_Angular.API.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string CoverUrl { get; set; }
        public string Titel { get; set; }
        public string Author { get; set; }
        public DateTime FinishedDate { get; set; }
        public bool Favorite { get; set; }
        public string Notes { get; set; }     
    }
}