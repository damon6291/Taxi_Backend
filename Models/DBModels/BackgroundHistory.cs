﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Taxi_Backend.Models
{
    public class BackgroundHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BackgroundHistoryId { get; set; }
        public bool IsSuccess { get; set; }
        public int CustomerQueueCount { get; set; }
        public int DriverQueueCount { get; set; }
        public int SuccessAmount { get; set; }
        public int ErrorAmount { get; set; }
        public string Process { get; set; }
        public string Error { get; set; } = string.Empty;
        public DateTime CreatedDateTime { get; set; }

    }
}
