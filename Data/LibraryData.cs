class LibraryData
{
    private static bool isCreated = false;
    private static LibraryData? libraryData = null;
    private LibraryData()
    {
        foreach (var Sach in TatCaSachHienCo)
        {
            dctBooks.Add(Sach.MaSo!, Sach);
        }
    }
    public static LibraryData CreateLibrary()
    {
        if (!isCreated)
        {
            isCreated = true;
            libraryData = new LibraryData();
            return libraryData;

        }
        else
        {
            return libraryData!;
        }

    }
    public string? Name { get; set; }
    public List<Book> TatCaSachHienCo = new()
    {
        new Book(){MaSo="001",Ten="HarryPotter",SoLuong=5},
        new Book(){MaSo="002",Ten="Rich Dad, Poor Dad",SoLuong=13},
        new Book(){MaSo="003",Ten="How to win fluent friend",SoLuong=5},
        new Book(){MaSo="004",Ten="Lap Trinh Co Ban",SoLuong=3},
        new Book(){MaSo="005",Ten="Steve Job back story",SoLuong=3},
    };

    public Dictionary<string, Reader> dctReaders = new();
    public Dictionary<string, Book> dctBooks = new();


    
}