namespace MatrixTraversalAlgorithms.Common;

public class MinPositionResponse : BasicResponse
{
    public (int, int) Minimum { set; get; }
    public Position Position { set; get; }
}