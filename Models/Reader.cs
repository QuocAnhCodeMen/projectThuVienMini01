class Reader
{
    public string? MaSo { get; set; }
    public string? Ten { get; set; }
    public HashSet<string> NhungSachDangMuongID = new();

    public void Hienthi()
    {
        Console.WriteLine($"Ma: {MaSo}, Ten: {Ten}");
    }
    public void HienThiTatCaSachDangMuong()
    {
        if (NhungSachDangMuongID.Count == 0)
        {
            Console.WriteLine("Hiện tại danh sách đang rỗng");
        }
        else
        {
            foreach (var sachID in NhungSachDangMuongID)
            {
                Console.WriteLine(sachID);
            }
        }
    }
}