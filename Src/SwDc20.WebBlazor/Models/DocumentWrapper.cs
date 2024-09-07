namespace SwDc20.WebBlazor.Models;

public class DocumentWrapper<T> where T : class
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string DocumentType { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public DateTime DateUpdated { get; set; } = DateTime.UtcNow;
    public Guid ContentId { get; set; }
    public string ContentVersion { get; set; }
    public T Document { get; set; }

    public DocumentWrapper()
    {
    }

    public DocumentWrapper(T document)
    {
        Document = document;
        if (document is Character.V0._08.Character character)
        {
            ContentId = character.Id;
            ContentVersion = character.Version;
        }
    }
}