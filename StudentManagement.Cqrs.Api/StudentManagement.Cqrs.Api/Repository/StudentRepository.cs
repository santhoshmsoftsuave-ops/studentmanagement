using Microsoft.Azure.Cosmos;
using StudentManagement.Cqrs.Api.Models;
using System.ComponentModel;
using System.Xml.Linq;

namespace StudentManagement.Cqrs.Api.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly Microsoft.Azure.Cosmos.Container _container;
        public StudentRepository(CosmosClient cosmosClient, IConfiguration config)
        {

            var databaseName = config["CosmosDb:DatabaseName"];
            var containerName = config["CosmosDb:ContainerName"];
            _container = cosmosClient.GetContainer(databaseName, containerName);
        }

        public Task<Student> AddAsync(Student student)
        {
            return _container.CreateItemAsync<Student>(student, new PartitionKey(student.Id))
                .ContinueWith(task => task.Result.Resource);
        }

        public async Task DeleteAsync(string id)
        {
            await _container.DeleteItemAsync<Student>(id, new PartitionKey(id));
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            var query = _container.GetItemQueryIterator<Student>("SELECT * FROM c");
            var results = new List<Student>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }
            return results;
        }

        public async Task<Student?> GetByIdAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<Student>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<Student> UpdateAsync(Student student)
        {
            var response = await _container.UpsertItemAsync(student, new PartitionKey(student.Id));
            return response.Resource;
        }
    }
}
