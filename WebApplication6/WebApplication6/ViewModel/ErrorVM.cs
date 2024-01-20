using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Download_API.ViewModel
{
    public class ErrorVM
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = null!;
        public string Path { get; set; } = null!;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
