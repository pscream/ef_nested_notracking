using System;

namespace EfCore31.Entities
{
    public class Resource
    {

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public bool IsActive { get; set; }

    }
}