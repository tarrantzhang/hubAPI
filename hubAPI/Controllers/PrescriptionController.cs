using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;

namespace hubAPI.Controllers
{
    public class PrescriptionController : ApiController
    {
        [HttpPut]
        public MedicationOrder Json(Object rawPrescription)
        {
            var raw = rawPrescription.ToString();
            JsonTextReader jr = new JsonTextReader(new StringReader(raw));
            Resource resource = FhirParser.ParseResource(jr);
            if (resource.TypeName.Equals("MedicationOrder"))
                return (MedicationOrder)resource;
            else
                return null;
        }


        [HttpPut]
        public MedicationOrder Xml()
        {
            string value = Request.Content.ReadAsStringAsync().Result;
            XmlReader jr = XmlReader.Create(new StringReader(value));
            try
            {
                Resource resource = FhirParser.ParseResource(jr);
                if (resource.TypeName.Equals("MedicationOrder"))
                    return (MedicationOrder)resource;
                else
                    throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
                return null;
            }
        }

    }
}
