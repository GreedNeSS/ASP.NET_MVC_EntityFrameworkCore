﻿namespace _6_DataFiltering.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public Company? Company { get; set; }
        public int CompanyId { get; set; }
    }
}
