// var libraryData = LibraryData.CreateLibrary();
// var libraryService = new LibraryService(libraryData);
// var reader = new Reader() { MaSo = "001", Ten = "Quoc Anh" };
// var reader2 = new Reader() { MaSo = "001", Ten = "Quoc Anh" };
// libraryService.ThemReader(reader);
// libraryService.ThemReader(reader2);
// reader.HienThiTatCaSachDangMuong();
// var book = libraryData.dctBooks["001"];
// Console.WriteLine($"So luong sach {book.Ten}: {book.SoLuong} ");
// libraryService.MuonSach("001", "001");

// Console.WriteLine("danh sach sau khi da muon sach");
// reader.HienThiTatCaSachDangMuong();
// Console.WriteLine($"So luong sach {book.Ten}: {book.SoLuong} ");
// libraryService.TraSach("001", "001");
// Console.WriteLine("");
// Console.WriteLine("danh sach sau khi da tra");
// reader.HienThiTatCaSachDangMuong();
// Console.WriteLine($"So luong sach {book.Ten}: {book.SoLuong} ");

Stack<string> stackString = new();
Queue<string> queueString = new();
try
{
    //Console.WriteLine($"stack peek: {abc.Peek()}"); // neu stack rong ma peek thi loi runtime
    Console.WriteLine($"stack capacicy: {stackString.Capacity}");
    Console.WriteLine($"queue capacicy: {queueString.Capacity}");

    stackString.Push("abc");
    stackString.Push("abc");

    queueString.Enqueue("abc");
    queueString.Enqueue("abc");
    Console.WriteLine("Capa truoc khi pop va dequeue");
    Console.WriteLine($"stack capacicy: {stackString.Capacity}");
    Console.WriteLine($"queue capacicy: {queueString.Capacity}");

    Console.WriteLine("Capa sau khi pop va dequeue");
    Console.WriteLine($"stack pop: {stackString.Pop()}");
    Console.WriteLine($"queue dequeue: {queueString.Dequeue()}");
    Console.WriteLine($"stack capacicy: {stackString.Capacity}");
    Console.WriteLine($"queue capacicy: {queueString.Capacity}");

    Console.WriteLine("");
    queueString.Enqueue("abc");
    queueString.Enqueue("abc");
    Console.WriteLine("Capa truoc khi pop va dequeue");
    Console.WriteLine($"stack capacicy: {stackString.Capacity}");
    Console.WriteLine($"queue capacicy: {queueString.Capacity}");
    Console.WriteLine($"stak count: {stackString.Count}");

}
catch (Exception ex)
{
    Console.WriteLine($"Ten loi: {ex.Message}");
}

