using System;
using System.Collections.Generic;
using System.Linq;
using WebMaze.DbStuff.Model;

namespace WebMaze.Models.UserTasks
{
    public class UserTaskViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public UserTask.TaskStatus Status { get; set; }

        public UserTask.TaskPriority Priority { get; set; }
    }
}
