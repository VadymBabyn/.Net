namespace MatrixTraversalAlgorithms.Common;

public class MinListLeftRightResponse : BasicResponse
{
    public List<(int, int)> MinimumLeftElements { set; get; }
    public List<(int, int)> MinimumRightElements { set; get; }
}