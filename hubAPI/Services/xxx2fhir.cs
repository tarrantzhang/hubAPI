using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace hubAPI.Services
{
    class xxx2fhir
    {

        public static List<Patient> xxx2Patients(List<Person> pList)
        {
            var patientList = new List<Patient>();
            var sqlInfo = new List<sqlPatient>();

            foreach (Person person in pList)
            {
                Patient patient = new Patient();
                //adding name
                var name = new HumanName();
                name.Family = new List<string> { person.LAST_NAME };
                name.Given = new List<string> { person.FIRST_NAME };
                patient.Name = new List<HumanName> { name };

                //adding address
                Address add = new Address();
                add.Text = person.ADDRESS_1 + person.ADDRESS_2;
                add.City = person.CITY;
                add.State = person.STATE;
                add.PostalCode = person.ZIP_CODE;
                patient.Address = new List<Address> { add };

                //adding phone&email
                ContactPoint phone = new ContactPoint();
                phone.System = ContactPoint.ContactPointSystem.Phone;
                phone.Value = person.TELEPHONE_1;
                ContactPoint email = new ContactPoint();
                email.System = ContactPoint.ContactPointSystem.Email;
                email.Value = person.EMAIL;
                patient.Telecom = new List<ContactPoint> { phone, email };

                patientList.Add(patient);
                sqlInfo.Add(fhir2sql.prepareImportPatient(patient, "03/11/2016", "1"));
            }

            var json = JsonConvert.SerializeObject(sqlInfo);
            Console.Write(json);

            return patientList;
        }

        public static void uploadMedication(List<excelMedication> mList)
        {
            var medList = new List<MedicationOrder>();
            foreach (excelMedication med in mList)
            {
                MedicationOrder prescription = new Hl7.Fhir.Model.MedicationOrder();

                //adding who this prescription is for
                /*ResourceReference rf = new ResourceReference();
                rf.Reference = 
                Patient patient = new Patient();
                var name = new HumanName();
                name.Family = new List<string> { med.LAST_NAME };
                name.Given = new List<string> { med.FIRST_NAME };
                patient.Name = new List<HumanName> { name };
                prescription.Patient = ;*/

                //adding
                ResourceReference rf = new ResourceReference();



            }
        }


        public static Resource jsonFile2Resource(String path)
        {
            JsonTextReader jr = new JsonTextReader(new StreamReader(@path));
            Resource resource = FhirParser.ParseResource(jr);
            return resource;
        }

        public static Resource xmlFile2Resource(String path)
        {
            XmlReader xr = XmlReader.Create(new StreamReader(@path));
            Resource resource = FhirParser.ParseResource(xr);
            return resource;
        }

        public static Resource json2Resource(String json)
        {
            Resource resource = (Resource)FhirParser.ParseFromJson(json);
            return resource;
        }

        public static Resource xml2Resource(String xml)
        {
            Resource resource = (Resource)FhirParser.ParseFromXml(xml);
            return resource;
        }


    }

}

