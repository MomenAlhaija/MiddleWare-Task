using ServiceContract;
namespace Services
{
    public class CitiesService: ICitiesService
    {
        private List<String> _cities;
        private Guid _serviceInstanceId {  get; set; }
        public Guid ServiceId { 
            get {
                return _serviceInstanceId;    
            } 
        }
        public CitiesService()
        {
            _serviceInstanceId = Guid.NewGuid();
            _cities = new List<String>() { 
                "Jordan","Uk","Japan","USA"
            };
        }
        public List<String> GetCities() { 
        
            return _cities;
        } 

    }
}