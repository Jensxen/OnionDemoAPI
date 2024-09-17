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
        public string Name { get; protected set; }
        public List<Accommodation> Accommodations {get; protected set; }

        public Host()
        {
        }

       
        public Host(int hostId)
        {
            HostId = hostId;
        }

        public void Delete()
        {

        }

        public void Update()
        {

        }
        public static Host Create(int id)
        {
            return new Host(id);
        }
    }

    
}
