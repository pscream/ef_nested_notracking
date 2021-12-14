using System;

namespace Common.Entities
{
    public class Resource
    {

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public bool IsActive { get; set; }

        public override string ToString()
        {
            string user = User == null ? "NULL" : User.ToString();
            return $"{nameof(Id)}='{Id}', {nameof(FirstName)}='{FirstName}', {nameof(LastName)}='{LastName}', " + 
                    $"{nameof(UserId)}='{UserId}'" + 
                    $"\n\t\t {nameof(User)}: {user}";
        }

    }
}