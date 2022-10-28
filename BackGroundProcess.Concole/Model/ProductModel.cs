namespace BackGroundProcess.Console.Model
{
    public record ProductModel
    (
        int Id,
        string Name,
        string? Description,
        DateTime CreationDate,
        bool IsActive
    );
    
}
