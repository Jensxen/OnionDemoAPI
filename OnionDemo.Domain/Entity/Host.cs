using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Domain.Entity
{
    public class Host : User
    {
        public int HostId { get; protected set; }
        public string HostName {get; protected set; }
    }
}
