
using System;

namespace TimeTracker_ng4.Models
{

    public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? MinutesSpent { get; set; }
        public int Priority { get; set; }
    }

}

