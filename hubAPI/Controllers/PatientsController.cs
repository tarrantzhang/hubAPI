using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using hubAPI.Models;
using Hl7.Fhir.Model;
using Newtonsoft.Json;
using System.IO;
using Hl7.Fhir.Serialization;
using System.Xml;
using hubAPI.Services;

namespace hubAPI.Controllers
{
    public class PatientsController : ApiController
    {
        class sqlPatient
        {
            public string PERSON_CODE = "0";
            public string FIRST_NAME = "Not Provided";
            public string LAST_NAME = "Not Provided";
            public string GENDER = "0";
            public string ADDRESS = "Not Provided";
            public string STATE_OR_PROVINCE_CODE = "IL";
            public string CITY = "Not Provided";
            public string POSTAL_CODE = "Not Provided";
            public string CONSENT_DATE = "Not Provided";
            public string POPULATION = "Not Provided";
        }

        private ApplicationDbContext db = new ApplicationDbContext();
        //PUT: api/Patients/Json
        [ResponseType(typeof(void))]
        [HttpPut]
        public Patient Json(Object value)
        {
            if (value == null)
                return null;
            var raw = value.ToString();
            JsonTextReader jr = new JsonTextReader(new StringReader(raw));
            try
            {
                Resource resource = FhirParser.ParseResource(jr);
                if (resource.TypeName.Equals("Patient"))
                {
                    var patient = (Patient)resource;
                    fhir2sql.sendPatientRequest(patient, "eMedonline api");
                    return patient;
                }
                else
                    throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return null;
            }
        }


        [HttpPut]
        public Patient Xml()
        {
            string value = Request.Content.ReadAsStringAsync().Result;
            XmlReader jr = XmlReader.Create(new StringReader(value));
            try
            {
                Resource resource = FhirParser.ParseResource(jr);
                if (resource.TypeName.Equals("Patient"))
                    return (Patient)resource;
                else
                    throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
                return null;
            }
        }

        [HttpPut]
        public Patient xsl(Object value)
        {
            if (value == null)
                return null;
            var raw = value.ToString();
            JsonTextReader jr = new JsonTextReader(new StringReader(raw));
            try
            {
                Resource resource = FhirParser.ParseResource(jr);
                if (resource.TypeName.Equals("Patient"))
                    return (Patient)resource;
                else
                    throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
                return null;
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationUserExists(string id)
        {
            return db.ApplicationUsers.Count(e => e.Id == id) > 0;
        }
    }
}