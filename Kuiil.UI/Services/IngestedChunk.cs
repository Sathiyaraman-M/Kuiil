using Microsoft.Extensions.VectorData;

namespace Kuiil.UI.Services;

public class IngestedChunk
{
    [VectorStoreRecordKey]
    public required Guid Key { get; set; }

    [VectorStoreRecordData(IsIndexed = true)]
    public required string DocumentId { get; set; }

    [VectorStoreRecordData]
    public int PageNumber { get; set; }

    [VectorStoreRecordData]
    public required string Text { get; set; }

    [VectorStoreRecordVector(768, DistanceFunction = DistanceFunction.CosineSimilarity)] // 384 is the default vector size for the nomic-embed-text:latest embedding model
    public ReadOnlyMemory<float> Vector { get; set; }
}
