namespace BackGroundProcess.Console.Model
{
    public record ProductModel
    (
        string Name,
        string? Description,
        DateTime CreationDate,
        bool IsActive
    );
    
}
