﻿namespace asp_empty.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public IEnumerable<User> Users { get; set; }
    }
}
