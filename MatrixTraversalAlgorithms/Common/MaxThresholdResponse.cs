namespace MatrixTraversalAlgorithms.Common;

public class MaxThresholdResponse : BasicResponse
{
    public (int, int) Maximum { set; get; }
    public List<(int, int)> ElementsAboveThreshold { set; get; }
}