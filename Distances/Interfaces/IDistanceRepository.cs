


namespace Distances.Interfaces
{
    public interface IDistanceRepository
    {
        Task<string> calculateDistanceBetweenTwoPoints(long point1Id, long poin2Id);
    }
}
