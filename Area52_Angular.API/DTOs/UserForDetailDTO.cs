using System;
using System.Collections.Generic;
using Area52_Angular.API.Models;

namespace Area52_Angular.API.DTOs
{
    public class UserForDetailDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nickname { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}