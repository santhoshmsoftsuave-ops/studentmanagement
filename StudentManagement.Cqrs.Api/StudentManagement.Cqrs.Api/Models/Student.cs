using Newtonsoft.Json;
namespace StudentManagement.Cqrs.Api.Models
{
    public class Student
    {
        [JsonProperty("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty("firstName")]
        public string FirstName { get; set; } = string.Empty;

        [JsonProperty("lastName")]
        public string LastName { get; set; } = string.Empty;

        [JsonProperty("className")]
        public string ClassName { get; set; } = string.Empty;
    }
}
