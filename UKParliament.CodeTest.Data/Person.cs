﻿using System.ComponentModel.DataAnnotations;

namespace UKParliament.CodeTest.Data
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        public string Name { get; set; }

        public DateTime DOB { get; set; }

    }
}