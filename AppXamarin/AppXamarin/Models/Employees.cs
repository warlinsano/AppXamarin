﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarin.Models
{
    public class Employees
    {

        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string titleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public string Photo { get; set; }
        public string PhotoBase64  { get; set; }  
        public string Notes { get; set; }
        public int? ReportsTo { get; set; }
        public string PhotoPath { get; set; }
        public string ImageFullPath { get; set; }

        //si no tiene Url de imagen en ImageFullPath 
        public string ImageFullPath1=> (ImageFullPath == null ? "http://warlinsano.somee.com/img/no-profile.png" : ImageFullPath);
      
    }
}