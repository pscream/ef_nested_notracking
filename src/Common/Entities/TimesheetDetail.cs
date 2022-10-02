using System;

namespace Common.Entities
{

    public class TimesheetDetail
    {

        public Guid Id { get; set; }

        public Guid TimesheetRowId { get; set; }

        public TimesheetRow TimesheetRow { get; set; }

        public DateTime WorkDay { get; set; }

        public decimal Hours { get; set; }

        public Guid CreatedById { get; set; }

        public User CreatedBy { get; set; }

        public Guid UpdatedById { get; set; }

        public User UpdatedBy { get; set; }

        public bool IsActive { get; set; }

    }

}