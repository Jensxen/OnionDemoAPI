using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Domain.Entity
{
    public class Host : DomainEntity
    {
        public int HostId { get; protected set; }
        public string HostName {get; protected set; }
        public string HostEmail {get; protected set; }
        public int HostPhoneNumber {get; protected set; }
        public List<Accommodation> Accommodations {get; protected set; }

    }
}
