﻿namespace asp_empty.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int CompanyId { get; set; }
        public Company Company{ get; set; }
    }
}
