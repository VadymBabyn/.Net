namespace MatrixTraversalAlgorithms.Common;

public class MinMaxBySegmentResponse : BasicResponse
{
    public (int, int) TopMaximum { set; get; }
    public (int, int) TopMinimum { set; get; }
    public (int, int) BottomMaximum { set; get; }
    public (int, int) BottomMinimum { set; get; }
    public (int, int) DiagonalMaximum { set; get; }
    public (int, int) DiagonalMinimum { set; get; }
}