using System;
using System.Collections.Generic;
using System.Text;
using Uyflix.Domain.Entities;

namespace Uyflix.Domain.Models
{
    public class ActorModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ActorModel() { }
        public ActorModel(Actor actor)
        {
            this.Id = actor.Id;
            this.FirstName = actor.FirstName;
            this.LastName = actor.LastName;
        }
        public Actor ToEntity()
        {
            return new Actor
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName
            };
        }
    }
}
