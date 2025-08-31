public class QueueService
{
    // một cuốn sách thôi những sé có rất nhiều người chờ
    private Dictionary<string, Queue<string>> hangCho = new();

    public void Enqueue(string bookID, string readerID)
    {
        if (!hangCho.ContainsKey(bookID)) hangCho[bookID] = new Queue<string>();
        hangCho[bookID].Enqueue(readerID);

    }
    public string? Dequeue(string bookID)
    {
        if (hangCho.ContainsKey(bookID) && hangCho[bookID].Count > 0) return hangCho[bookID].Dequeue();
        return null;
    }
    public bool IsWaitingCheck(string bookID)
    {
        return hangCho.ContainsKey(bookID) && hangCho[bookID].Count > 0;
    }
    public List<string>? ListWaitingReadersForBook(string bookID)
    {
        if (hangCho.ContainsKey(bookID)) return hangCho[bookID].ToList();
        return null;
    }

}