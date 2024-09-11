using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCalculation.Domain.Core
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            var entity = (Entity)obj;
            return Id == entity.Id;
        }
        public Guid Id { get; protected set; }
    }
}
