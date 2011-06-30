namespace SiriusCybernetics
{
    using System;

    public class VhptIdentification
    {
        public VhptIdentification(Guid id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (VhptIdentification)) return false;
            return Equals((VhptIdentification) obj);
        }

        public bool Equals(VhptIdentification other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id.Equals(this.Id) && Equals(other.Name, this.Name);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (this.Id.GetHashCode() * 397) ^ (this.Name != null ? this.Name.GetHashCode() : 0);
            }
        }
    }
}