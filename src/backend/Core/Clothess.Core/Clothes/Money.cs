namespace Clothess.Core.Clothes;

public enum Currencies
{
    Usd = 1,
    Rub = 2,
}

public sealed class Money : IEquatable<Money>
{
    public decimal Cost { get; private set; }
    public Currencies Currency { get; private set; }

    public Money(decimal cost, Currencies currency)
    {
        Cost = cost;
        Currency = currency;
    }

    public bool Equals(Money? other)
    {
        if (other is null)
            return false;
        return other.Cost == Cost && other.Currency == Currency;
    }
}
