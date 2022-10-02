using System;
using System.Collections.Generic;

namespace Common.Entities
{

    public class TimesheetRow
    {

        public Guid Id { get; set; }

        public bool IsBillable { get; set; }

        public Guid CreatedById { get; set; }

        public User CreatedBy { get; set; }

        public Guid UpdatedById { get; set; }

        public User UpdatedBy { get; set; }

        public bool IsActive { get; set; }

        public List<TimesheetDetail> Details { get; set; }

    }

}
