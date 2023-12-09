namespace MatrixTraversalAlgorithms.Common;

public class MinMaxListResponse : BasicResponse
{
    public List<(int, int)> MaximumElements { set; get; }
    public List<(int, int)> MinimumElements { set; get; }
}