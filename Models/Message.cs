namespace MessageBoardApi.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    public string Text { get; set; }
    public string Group { get; set; }
    public DateTime MessageDateTime { get; set; }
    public string UserName { get; set; }
  }
}