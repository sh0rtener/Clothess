namespace Clothess.Core.Clothes;

public sealed class Clothes : Entity
{
    private List<ClothesImage> _images = [];
    public int Id { get; set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public ClothesColor Color { get; private set; }
    public ClothesGender Gender { get; private set; }
    public ClothesSize Size { get; private set; }
    public ClothesType Type { get; private set; }
    public Money Cost { get; private set; }
    public IReadOnlyCollection<ClothesImage> Images => _images;
    public int Stock { get; private set; }

    public Clothes(
        string name,
        string description,
        ClothesColor color,
        ClothesGender gender,
        ClothesSize size,
        ClothesType type,
        Money cost,
        int stock,
        List<ClothesImage> images
    )
    {
        GuardException.ThrowIfStringNullOrEmpty(name, nameof(name));
        GuardException.ThrowIfStringNullOrEmpty(description, nameof(description));
        GuardException.ThrowIfObjectIsNull(cost);
        GuardException.ValidateCost(cost);
        GuardException.ValidateEnums((int)color, typeof(ClothesColor), nameof(ClothesColor));
        GuardException.ValidateEnums((int)gender, typeof(ClothesGender), nameof(ClothesGender));
        GuardException.ValidateEnums((int)size, typeof(ClothesSize), nameof(ClothesSize));
        GuardException.ValidateEnums((int)type, typeof(ClothesType), nameof(ClothesType));

        Name = GuardException.FormatString(name);
        Description = GuardException.FormatString(description);
        Color = color;
        Gender = gender;
        Size = size;
        Type = type;
        Cost = cost;
        Stock = stock;
        _images = images;
    }

    public void ChangeName(string value)
    {
        GuardException.ThrowIfStringNullOrEmpty(value, "Name");
        Name = GuardException.FormatString(value);
    }

    public void ChangeDescription(string value)
    {
        GuardException.ThrowIfStringNullOrEmpty(value, "Description");
        Description = GuardException.FormatString(value);
    }

    public void AddImage(ClothesImage image)
    {
        GuardException.ThrowIfObjectIsNull(image, "Image");
        _images.Add(image);
    }

    public void RemoveImage(ClothesImage image)
    {
        GuardException.ThrowIfObjectIsNull(image, "Image");
        if (!_images.Any(x => x.Id == image.Id))
            throw new CoreException("Изображение не найдено!");
        _images.Remove(image);
    }

    public void ChangeCost(Money cost)
    {
        GuardException.ValidateCost(cost);
        Cost = cost;
    }

    public void AddStocks(int value)
    {
        if (value < 0)
            throw new CoreException("Остатки по товару можно добавлять только положительные");

        Stock += value;
    }

    public bool TryDecrementStock()
    {
        return Stock == 0;
    }

    public void DecrementStock()
    {
        if (!TryDecrementStock())
            throw new CoreException("Остатки по товару уже закончились");

        Stock -= 1;
    }
}
