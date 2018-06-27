using Flunt.Notifications;
using System;

namespace Werter.ProjetoCassandra.Shared.Entities
{
    public abstract class EntityBase : Notifiable
    {
        public EntityBase()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }


    }
}
