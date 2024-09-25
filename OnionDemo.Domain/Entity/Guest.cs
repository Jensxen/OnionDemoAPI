using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Domain.Entity;
public class Guest : DomainEntity
{
    public int Id { get; protected set; }
    public string Name { get; protected set; }

    public Guest(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
