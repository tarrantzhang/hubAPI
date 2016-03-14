using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hubAPI.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using Hl7.Fhir.Model;

namespace hubAPI.Services
{

public interface IimohubRepository
{
    IEnumerable<Patient> GetAllPatients();

    Patient GetPatient(string id);

    Patient AddPatient(Patient item);
     
    bool RemovePatient(string id);

    bool UpdatePatient(string id, Patient item);
}

public class imohubRepository: IimohubRepository
    {
        private MongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<Patient> _patient;
        private int id = 0;

        private const string CacheKey = "ContactStore";

        public imohubRepository(string connection)
        {
            if (string.IsNullOrWhiteSpace(connection))
            {
                connection = "mongodb://localhost:27017";
            }
            _client = new MongoClient(connection);
            _database = _client.GetDatabase("spark");
            _patient = _database.GetCollection<Patient>("resources");

       }

    public IEnumerable<Patient> GetAllPatients()
    {
        var rt = _patient.Find(_ => true);
        return rt.ToEnumerable();
    }

    public Patient GetPatient(string name)
    {
        var filter = Builders<Patient>.Filter.Eq(name, "name.family");
        return _patient.Find(filter).FirstOrDefault();
    }
    
    public Patient AddPatient(Patient patient)
    {
            //patient.Id = ObjectId.GenerateNewId().ToString();
        patient.Id = id.ToString();
        id++;
        _patient.InsertOne(patient);
        return patient;
    }
    
    public bool RemovePatient(string id)
    {
        var filter = Builders<Patient>.Filter.Eq("i", id);
        return _patient.DeleteOne(filter).IsAcknowledged;
    }
    
    public bool UpdatePatient(string id, Patient item)
    {
        var filter = Builders<Patient>.Filter.Eq("i", id);
        return _patient.ReplaceOne(filter,item).IsAcknowledged;
    }

    }
}