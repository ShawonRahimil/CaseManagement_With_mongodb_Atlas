using CaseManagement.Models;
using MongoDB.Driver;

namespace CaseManagement.Services
{
    public class CaseService
    {
        private readonly SharedService _sharedService;

        public CaseService(SharedService sharedService)
        {
            _sharedService = sharedService;
        }

        public List<Case> GetAll(string caseType) =>
            _sharedService.GetCaseCollection<Case>(caseType).Find(c => true).ToList();

        public void Create(Case caseItem) =>
            _sharedService.GetCaseCollection<Case>(caseItem.CaseType).InsertOne(caseItem);

        public void Update(Case caseItem) =>
            _sharedService.GetCaseCollection<Case>(caseItem.CaseType)
                          .ReplaceOne(c => c.Id == caseItem.Id, caseItem);

        public void Delete(string id, string caseType) =>
            _sharedService.GetCaseCollection<Case>(caseType).DeleteOne(c => c.Id == id);
    }
}
