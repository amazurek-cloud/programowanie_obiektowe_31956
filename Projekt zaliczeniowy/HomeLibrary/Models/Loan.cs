namespace HomeLibrary.Models;

public class Loan : BaseEntity
{
    public Guid BookId { get; set; }
    public string BorrowedTo { get; set; } = string.Empty;
    public DateTime LoanDate { get; set; } = DateTime.Now;
    public DateTime? ReturnDate { get; set; }

    public void CloseLoan()
    {
        ReturnDate = DateTime.Now;
    }

    public override void PrintInfo() //wywolanie metody z klasy basowej: Book.cs
    {
        base.PrintInfo();
        Console.WriteLine($"Borrowed to: {BorrowedTo}, From: {LoanDate:yyyy-MM-dd}, To: {ReturnDate:yyyy-MM-dd}");
    }
}