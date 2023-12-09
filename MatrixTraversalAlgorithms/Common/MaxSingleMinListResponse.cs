namespace MatrixTraversalAlgorithms.Common;

public class MaxSingleMinListResponse : BasicResponse
{
    public (int, int) Maximum { set; get; }
    public List<(int, int)> MinimumElements { set; get; }
}