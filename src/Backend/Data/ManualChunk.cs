namespace eShopSupport.Backend.Data;

public class ManualChunk
{
    public int ChunkId { get; set; }
    public int ProductId { get; set; }
    public int PageNumber { get; set; }
    public required string txt { get; set; }
    public required byte[] Embedding { get; set; }
}
