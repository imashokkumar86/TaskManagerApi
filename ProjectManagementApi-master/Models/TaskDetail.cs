using System;

namespace Entities
{
    public class TaskDetail
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int Priority { get; set; }

        public bool ActiveStatus { get; set; }

        public int? ParentId { get; set; }

       
    }
}
