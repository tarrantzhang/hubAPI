using Hl7.Fhir.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using hubAPI.Models;
using hubAPI.Services;

namespace hubAPI.Controllers
{

    public class imohubController : ApiController
    {
        private static readonly IimohubRepository _patient = new imohubRepository("mongodb://localhost:27017");

        public String Index()
        {
            return "value";
        }

        public String Get()
        {
            //var rt = _patient.GetAllPatients().AsQueryable();
            //return rt;
            return "value";
        }

        public Patient Get(string name)
        {
            Patient patient = _patient.GetPatient(name);
            if (patient == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return patient;
        }

        [Authorize(Roles = "emedonline_user")]
        public Patient Post(Object value)
        {
            var jsonString = value.ToString().Replace("\r\n", string.Empty);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Patient result = ser.Deserialize<Patient>(jsonString);
            Patient patient = _patient.AddPatient(result);
            return patient;
        }

        public void Put(string id, Patient value)
        {
            if (!_patient.UpdatePatient(id, value))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void Delete(string id)
        {
            if (!_patient.RemovePatient(id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}
