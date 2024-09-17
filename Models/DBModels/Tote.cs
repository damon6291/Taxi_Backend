﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class Tote : Crudable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ToteId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CountMax { get; set; } = 1;
        public bool IsArchived { get; set; } = false;

        public long LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
