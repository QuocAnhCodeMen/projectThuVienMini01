class LibraryService
{
    LibraryData libraryData;
    QueueService? queueService=null;
    public Stack<string> ReturnHistory { get; private set; } = new();
    public LibraryService(LibraryData libraryData)
    {
        this.libraryData = libraryData;
    }

    public void SetQueueService(QueueService queueService)
    {
        this.queueService = queueService;
    }


    //crud book
    public void ThemSach(Book book)
    {
        if (libraryData.dctBooks!.ContainsKey(book.MaSo!))
        {
            libraryData.dctBooks.Add(book.MaSo!, book);
            libraryData.TatCaSachHienCo.Add(book);
        }

    }
    public void Xoa(string bookID)
    {
        if (libraryData.dctBooks!.ContainsKey(bookID))
        {
            var book = libraryData.dctBooks[bookID];
            Console.WriteLine("---Đã xóa---");
            book.HienThi();
            libraryData.dctBooks.Remove(bookID);
            libraryData.TatCaSachHienCo.Remove(book);
        }
        else
        {
            Console.WriteLine($"Danh sách không có sách nào có Mã là: {bookID}");
        }
    }
    public void HienThiSachHienCo()
    {
        if (libraryData.TatCaSachHienCo.Count != 0)
        {
            foreach (var book in libraryData.TatCaSachHienCo)
            {
                book.HienThi();
            }
        }
        else
        {
            Console.WriteLine("Thư viện rỗng sách");
        }
    }
    public void ThemReader(Reader reader)
    {
        if (!libraryData.dctReaders.ContainsKey(reader.MaSo!))
        {
            libraryData.dctReaders.Add(reader.MaSo!, reader);
            Console.WriteLine($"Đã thêm đọc giả: {reader.Ten} vào danh sách");

        }
        else
        {
            Console.WriteLine($"Đọc giả: {reader.Ten} hiện đã có trong danh sách ");
        }
    }
    public void TimReader(string readerID)
    {
        var reader = TimReaderr(readerID);
        if (reader != null)
        {
            reader.Hienthi();
        }
        else
        {
            Console.WriteLine($"không có đọc giả với Mã: {readerID}");
        }
    }
    Book? TimSachh(string bookID)=>(libraryData.dctBooks.ContainsKey(bookID)) ? libraryData.dctBooks[bookID] : null;
    public void TimSach(string bookID)
    {
        var book = TimSachh(bookID);
        if (book != null)
        {
            book.HienThi();
        }
        else
        {
            Console.WriteLine($"Không có sách với Mã: {bookID}");
        }
        
    }
    Reader? TimReaderr(string readerID)=>(libraryData.dctReaders.ContainsKey(readerID))?libraryData.dctReaders[readerID]:null;
    public void MuonSach(string readerID, string bookID)
    {
        //giảm số lượng, thêm vào Reader
        // nếu hết thì gọi queueService.Enqueue để đưa Reader vào hàng đợi
        var reader = TimReaderr(readerID);
        var book = TimSachh(bookID);
        if (reader == null || book == null)
        {

            return;
        }
        if (!reader.NhungSachDangMuongID.Contains(bookID) && book.SoLuong > 0)
        {
            reader.NhungSachDangMuongID.Add(bookID);
            book.SoLuong -= 1;
        }
        else if (book.SoLuong == 0&&this.queueService!=null)
        {
            // cho reader vào hàng đợi
            queueService.Enqueue(bookID, readerID);
            
        }

        

    }
    public void TraSach(string readerID, string bookID)
    {
        // tăng số lượng, xóa khỏi Reader, đẩy vào Stack
        // gọi queueService.Dequeue nếu có người chờ
        var reader = TimReaderr(readerID);
        var book = TimSachh(bookID);
        if (reader == null || book == null)
        {

            return;
        }

        if (reader.NhungSachDangMuongID.Contains(bookID))
        {
            reader.NhungSachDangMuongID.Remove(bookID);
            book.SoLuong += 1;
            ReturnHistory.Push(bookID);
        }
        if (queueService!.IsWaitingCheck(bookID) && TimReaderr(queueService.Dequeue(bookID)!) != null)
        {
            // áp dụng quy tắc là không có Nested IF
            var readerWaiting = TimReaderr(queueService.Dequeue(bookID)!);
            // if (readerWaiting != null)
            // {
            //     readerWaiting.NhungSachDangMuongID.Add(bookID);
            //     book.SoLuong -= 1;
            // }
            readerWaiting!.NhungSachDangMuongID.Add(bookID);
            book.SoLuong -= 1;
            ReturnHistory.Pop();
            
        }
        
    }
    

}