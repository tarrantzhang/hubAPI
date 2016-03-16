using Hl7.Fhir.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubAPI.Services
{
    class fhir2sql
    {
        public static sqlPatient prepareImportPatient(Patient patient, string consentDate,string population)
        {
            var sqlP = new sqlPatient();
            if (patient.Name.ElementAt(0) != null)
            {
                sqlP.FIRST_NAME = patient.Name.ElementAt(0).Given.First();
                sqlP.LAST_NAME = patient.Name.ElementAt(0).Given.Last();
            }

            sqlP.GENDER = patient.Gender.Value.ToString();
            if (patient.Address.Count != 0)
            {
                    sqlP.ADDRESS = patient.Address.ElementAt(0).LineElement.ElementAt(0).Value;
                    sqlP.STATE_OR_PROVINCE_CODE = patient.Address.ElementAt(0).State;
                    sqlP.POSTAL_CODE = patient.Address.ElementAt(0).PostalCode;
                    sqlP.CITY = patient.Address.ElementAt(0).City;
            }
            
            sqlP.CONSENT_DATE = consentDate;
            sqlP.POPULATION = population;
            return sqlP;
        }

        public static void sendPatientRequest(Patient patient, string url)
        {
            sqlPatient p = prepareImportPatient(patient, "2016/1/1", "test");
            var json = JsonConvert.SerializeObject(p);
            byte[] byteArray = Encoding.UTF8.GetBytes(json);
            WebRequest request = WebRequest.Create("example.com"); //should be the url of eMedonlineAPI post method
            request.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
            request.Method = "POST";
            request.ContentLength = byteArray.Length;
            request.ContentType = "application/json";
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            response.Close();
        }
        /*
        public string[] prepareCreatePopulation(string population, string IRB_approve, string IRB_expire, string min_trigger, string max_trigger,string no_connect_trigger)
        {
            return new string[6] { population, IRB_approve, IRB_expire, min_trigger, max_trigger, no_connect_trigger };
        }
        public string[] prepareAssignPatientPopulation(string patientID, string SiteID,string populationID,string consentdate)
        {
            return new string[4] { patientID, SiteID, populationID, consentdate};
        }

        public string[] prepareImportPrescription(MedicationOrder mo, string population, )
        {
            ResourceReference medRef = (ResourceReference) mo.Medication;
            string reference = medRef.Reference;
        }
    }
    */
    }

}
