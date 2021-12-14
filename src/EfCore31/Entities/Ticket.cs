using System;

namespace EfCore31.Entities
{

    public class Ticket
    {

        public Guid Id { get; set; }

        public string Code { get; set; }

        public Guid OpenedById { get; set; }

        public Resource OpenedBy { get; set; }

        public Guid CreatedById { get; set; }

        public User CreatedBy { get; set; }

        public Guid UpdatedById { get; set; }

        public User UpdatedBy { get; set; }
        
        public bool IsActive { get; set; }

    }

}