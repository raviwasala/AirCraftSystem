using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Common;

namespace Domain.Entities
{
    public class AirCraft : BaseEntity
    {        
        public string Make { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
        public string Location { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }

        public DateTime TxnDate { get; set; }
    }
}