using System;

namespace Common.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}='{Id}', {nameof(UserName)}='{UserName}'";
        }

    }
}