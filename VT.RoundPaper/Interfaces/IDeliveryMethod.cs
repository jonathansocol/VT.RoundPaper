namespace VT.RoundPaper.Interfaces
{
    interface IDeliveryMethod
    {
        int[] HouseNumbers { get; }
        int NumberOfCrossings { get; }
    }
}
