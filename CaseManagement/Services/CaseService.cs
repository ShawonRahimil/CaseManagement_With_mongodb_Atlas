using CaseManagement.Models;
using MongoDB.Driver;
using System.Linq;

namespace CaseManagement.Services
{
    public class CaseService
    {
        private readonly SharedService _sharedService;

        public CaseService(SharedService sharedService)
        {
            _sharedService = sharedService;
        }

        // সব ডেটা একসাথে (Dhaka + Barishal)
        public List<Case> GetAll()
        {
            var dhakaCases = _sharedService.GetCaseCollection<Case>("murder").Find(_ => true).ToList();
            var barishalCases = _sharedService.GetCaseCollection<Case>("churi").Find(_ => true).ToList();

            return dhakaCases.Concat(barishalCases).ToList();
        }

        // Optional: caseType অনুযায়ী filter
        public List<Case> GetAll(string caseType)
        {
            if (string.IsNullOrEmpty(caseType)) return GetAll();

            caseType = caseType.ToLower();
            if (caseType.Contains("murder"))
                return _sharedService.GetCaseCollection<Case>("murder").Find(_ => true).ToList();
            else if (caseType.Contains("churi"))
                return _sharedService.GetCaseCollection<Case>("churi").Find(_ => true).ToList();

            return GetAll();
        }

        public void Create(Case caseItem) =>
            _sharedService.GetCaseCollection<Case>(caseItem.CaseType).InsertOne(caseItem);

        public void Update(Case caseItem) =>
            _sharedService.GetCaseCollection<Case>(caseItem.CaseType)
                          .ReplaceOne(c => c.Id == caseItem.Id, caseItem);

        public void Delete(string id, string caseType) =>
            _sharedService.GetCaseCollection<Case>(caseType)
                          .DeleteOne(c => c.Id == id);
    }
}
