using System;
using System.Collections.Generic;
using System.Linq;

namespace WebMaze.DbStuff.Model
{
    public class UserTask : BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public TaskStatus Status { get; set; }

        public TaskPriority Priority { get; set; }

        public enum TaskStatus
        {
            Planned = 0,
            InProgress = 1,
            Complete = 2,
            Overdue = 3
        }

        public enum TaskPriority
        {
            Low = 0,
            Medium = 1,
            High = 2
        }
    }
}
