using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DO.Objects
{
    public class Tasks
    {
        public int TaskId { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime? DueDate { get; set; }

        public bool? IsCompleted { get; set; }
    }
}
