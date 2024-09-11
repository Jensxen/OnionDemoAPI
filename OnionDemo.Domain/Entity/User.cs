using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Domain.Entity
{
    public class User : DomainEntity
    {
        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public string Email { get; protected set; }

        public int PhoneNumber {get; protected set; }

        public DateOnly BirthDate { get; protected set; }
    }
}
