namespace Tracker.Domain.Primitives;

public abstract class Entity : IEquatable<Entity>
{
    protected Entity() { }

    protected Entity(Guid id) => Id = id;

    public Guid Id { get; protected init; }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;

        if (obj.GetType() != GetType()) return false;

        if (obj is not Entity entity) return false;

        return Id == entity.Id;
    }

    public static bool operator ==(Entity? a, Entity? b)
    {
        return a is not null && b is not null && a.Id == b.Id;
    }

    public static bool operator !=(Entity a, Entity b) => !(a == b);

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public bool Equals(Entity? other)
    {
        if (other is null) return false;

        if (other.GetType() != GetType()) return false;

        return Id == other.Id;
    }
}
