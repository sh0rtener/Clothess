namespace Clothess.Core.Clothes;

public sealed class ClothesImage
{
    public Guid Id { get; private set; }
    public string Url { get; private set; }
    public int SortOrdering { get; private set; }

    public ClothesImage(string url, int sortOrdering)
    {
        GuardException.ThrowIfStringNullOrEmpty(url, nameof(url));
        Url = GuardException.FormatString(url);
        SortOrdering = sortOrdering;
    }
}
