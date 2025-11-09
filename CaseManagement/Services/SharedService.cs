using MongoDB.Driver;
using CaseManagement.Settings;
using Microsoft.Extensions.Options;

namespace CaseManagement.Services
{
    public class SharedService
    {
        private readonly IMongoDatabase _dhakaDb;
        private readonly IMongoDatabase _barishalDb;

        public SharedService(IOptions<MongoDBSettings> options)
        {
            var settings = options.Value;

            var dhakaClient = new MongoClient(settings.DhakaDb.ConnectionString);
            var barishalClient = new MongoClient(settings.BarishalDb.ConnectionString);

            _dhakaDb = dhakaClient.GetDatabase(settings.DhakaDb.DatabaseName);
            _barishalDb = barishalClient.GetDatabase(settings.BarishalDb.DatabaseName);
        }

        public IMongoCollection<T> GetAdalotCollection<T>(string location) where T : class
        {
            if (!string.IsNullOrEmpty(location))
            {
                var loc = location.ToLower();
                if (loc == "dhaka") return _dhakaDb.GetCollection<T>(typeof(T).Name);
                else if (loc == "barishal") return _barishalDb.GetCollection<T>(typeof(T).Name);
            }
            return _dhakaDb.GetCollection<T>(typeof(T).Name);
        }

        public IMongoCollection<T> GetCaseCollection<T>(string caseType) where T : class
        {
            if (!string.IsNullOrEmpty(caseType))
            {
                var type = caseType.ToLower();
                if (type.Contains("murder")) return _dhakaDb.GetCollection<T>(typeof(T).Name);
                else if (type.Contains("churi")) return _barishalDb.GetCollection<T>(typeof(T).Name);
            }
            return _dhakaDb.GetCollection<T>(typeof(T).Name);
        }
    }
}
