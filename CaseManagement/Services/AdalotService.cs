using CaseManagement.Models;
using MongoDB.Driver;

namespace CaseManagement.Services
{
    public class AdalotService
    {
        private readonly SharedService _sharedService;

        public AdalotService(SharedService sharedService)
        {
            _sharedService = sharedService;
        }

        public List<Adalot> GetAll(string location) =>
            _sharedService.GetAdalotCollection<Adalot>(location).Find(a => true).ToList();

        public void Create(Adalot adalot) =>
            _sharedService.GetAdalotCollection<Adalot>(adalot.Location).InsertOne(adalot);

        public void Update(Adalot adalot) =>
            _sharedService.GetAdalotCollection<Adalot>(adalot.Location)
                          .ReplaceOne(a => a.Id == adalot.Id, adalot);

        public void Delete(string id, string location) =>
            _sharedService.GetAdalotCollection<Adalot>(location).DeleteOne(a => a.Id == id);
    }
}
