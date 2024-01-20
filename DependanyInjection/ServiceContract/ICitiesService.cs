namespace ServiceContract
{
    public interface ICitiesService
    {
        Guid ServiceId { get;  }
        List<String> GetCities();
    }
}