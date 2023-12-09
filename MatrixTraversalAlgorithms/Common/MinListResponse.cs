namespace MatrixTraversalAlgorithms.Common;

public class MinListResponse : BasicResponse
{
    public List<(int, int)> MinimumElements { set; get; }
}