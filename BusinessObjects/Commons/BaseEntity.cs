﻿using Microsoft.Data.SqlClient.DataClassification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Commons
{
    public class BaseEntity
    {
        //User automatically gets Id, CreatedAt, and UpdatedAt fields.
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
