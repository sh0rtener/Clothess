using Clothess.Core.Clothes;

namespace Clothess.Core;

public static class GuardException
{
    public static void ThrowIfObjectIsNull(object value, string name = "value")
    {
        if (value == null)
            throw new CoreException($"{name} не должно быть пустым");
    }

    public static void ThrowIfStringNullOrEmpty(string? value, string nameValue = "value")
    {
        string ex = $"{nameValue} не должно быть пустым";
        if (string.IsNullOrEmpty(value))
            throw new CoreException(ex);
    }

    public static string FormatString(string value)
    {
        ThrowIfStringNullOrEmpty(value);

        return value.Trim();
    }

    public static void ValidateCost(Money money)
    {
        ThrowIfObjectIsNull(money, nameof(Money));

        if (money.Cost < 0)
            throw new CoreException("Цена товара не может быть меньше нуля!");

        if (Enum.IsDefined(money.Currency))
            throw new CoreException("Неверно определена валюта");
    }

    public static void ValidateEnums(int enumValue, Type enumType, string name = "value")
    {
        if (Enum.IsDefined(enumType, enumValue))
            throw new CoreException($"Неверно определено значения для типа {name}");
    }
}
