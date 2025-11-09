using CaseManagement.Models;
using MongoDB.Driver;
using System.Linq;

namespace CaseManagement.Services
{
    public class AdalotService
    {
        private readonly SharedService _sharedService;

        public AdalotService(SharedService sharedService)
        {
            _sharedService = sharedService;
        }

        // সব ডেটা একসাথে
        public List<Adalot> GetAll()
        {
            var dhakaData = _sharedService.GetAdalotCollection<Adalot>("dhaka").Find(_ => true).ToList();
            var barishalData = _sharedService.GetAdalotCollection<Adalot>("barishal").Find(_ => true).ToList();
            return dhakaData.Concat(barishalData).ToList();
        }

        // Optional: location অনুযায়ী filter
        public List<Adalot> GetAll(string location)
        {
            if (string.IsNullOrEmpty(location)) return GetAll();
            location = location.ToLower();
            if (location == "dhaka")
                return _sharedService.GetAdalotCollection<Adalot>("dhaka").Find(_ => true).ToList();
            else if (location == "barishal")
                return _sharedService.GetAdalotCollection<Adalot>("barishal").Find(_ => true).ToList();
            return GetAll();
        }

        public void Create(Adalot adalot) =>
            _sharedService.GetAdalotCollection<Adalot>(adalot.Location).InsertOne(adalot);

        public void Update(Adalot adalot) =>
            _sharedService.GetAdalotCollection<Adalot>(adalot.Location)
                          .ReplaceOne(a => a.Id == adalot.Id, adalot);

        public void Delete(string id, string location) =>
            _sharedService.GetAdalotCollection<Adalot>(location)
                          .DeleteOne(a => a.Id == id);
    }
}
