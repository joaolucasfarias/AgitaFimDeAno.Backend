using System;

namespace Domain.Comum
{
    public abstract class Entity : IEquatable<Entity>
    {
        public int Id { get; protected set; }

        protected Entity(int id) =>
            Id = id;

        public override bool Equals(object outroObjeto)
        {
            if (!(outroObjeto is Entity entity))
                return false;

            return Equals(entity);
        }

        public override int GetHashCode() =>
            Id.GetHashCode();

        public bool Equals(Entity outro) =>
            outro != null && !(Id == 0 || outro.Id == 0) && Id.Equals(outro.Id);

        public static bool operator ==(Entity x, Entity y) =>
            x.Equals(y);

        public static bool operator !=(Entity x, Entity y) =>
            !(x == y);
    }
}