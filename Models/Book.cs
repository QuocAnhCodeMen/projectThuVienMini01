class Book
{
    public string? MaSo { set; get; }
    public string? Ten { set; get; }
    public int SoLuong { set; get; }

    public void HienThi()
    {
        Console.WriteLine($"Mã sách: {MaSo}, Tên sách: {Ten}, Số lượng còn: {SoLuong}");
    }
    
    
}