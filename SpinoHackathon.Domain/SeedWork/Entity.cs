namespace SpinoHackathon.Domain.SeedWork
{
    public abstract class Entity
    {
        private int? _requestedHashCode;
        private int _Id;

        public int Id 
        { 
            get => _Id;
            protected set => _Id = value; 
        }

        private List<INotification> _domainEvent;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvent?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvent = _domainEvent ?? new List<INotification>();
            _domainEvent.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvent?.Remove(eventItem);
        }

        public void ClearDomainEvents() 
        {
            _domainEvent?.Clear();
        }

        public bool IsTransient()
        {
            return this.Id == default;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            Entity item = (Entity)obj;

            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31;

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Equals(left, null))
                return (Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}
