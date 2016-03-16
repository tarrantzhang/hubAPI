using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubAPI.Services
{
    class Person
    {
        public double PERSON_CODE = 0;
        public string FIRST_NAME = "";
        public string LAST_NAME = "";
        public string DOB = "";
        public string ADDRESS_1 = "";
        public string ADDRESS_2 = "";
        public string ADDRESS_TYPE = "";
        public string CITY = "";
        public string STATE = "";
        public string ZIP_CODE = "";
        public string EMAIL = "";
        public string TELEPHONE_1 = "";
        public string ADMIT_DATE = "";
    }

    class excelMedication
    {
        public double PERSON_CODE = 0;
        public string FIRST_NAME = "";
        public string LAST_NAME = "";
        public string DOB = "";
        public string MED_NAME = "";
        public string MEDICATION_TEXT = "";
    }

    class ALLERGY
    {
        public double PERSON_CODE = 0;
        public string FIRST_NAME = "";
        public string LAST_NAME = "";
        public string DOB = "";
        public string ALLERGY_CODE = "";
        public string ALLERGY_TEXT = "";
        public string ALLERGY_ADDED_DATE = "";
        public string ADMIT_DATE = "";
    }

    class sqlPatient
    {
        public string PERSON_CODE = "0";
        public string FIRST_NAME = "Not provided";
        public string LAST_NAME = "Not provided";
        public string GENDER = "0";
        public string ADDRESS = "Not provided";
        public string STATE_OR_PROVINCE_CODE = "Not provided";
        public string CITY = "Not provided";
        public string POSTAL_CODE = "Not provided";
        public string CONSENT_DATE = "Not provided";
        public string POPULATION = "Not provided";
    }

    class PROBLEM
    {
        public double PERSON_CODE = 0;
        public string ADMIT_DATE = "";
        public string PROBLEMM_CODE = "";
        public string VISIT_CODE = "";
        public string PROBLEM_TEXT = "";
        public string PROBLEM_PREV = "";
        public string PROBLEM_ACTIVITY = "";
        public string PROBLEM_ADDED_DATE = "";
        public string PROBLEM_ADD_DDX_MACRO = "";
        public string PROBLEM_ADD_DISCUSSION_MACRO = "";
        public string PROBLEM_ADJUDICATION_TEXT = "";
        public string PROBLEM_ASSESSMENT_TEXT = "";
        public string PROBLEM_CLASSIFICATION = "";
        public string PROBLEM_CODE = "";
        public string PROBLEM_COMMENT = "";
        public string PROBLEM_DEFAULT_SCRIPT = "";
        public string PROBLEM_DESCRIPTION = "";
        public string PROBLEM_DISCUSSION_FREETEXT = "";
        public string PROBLEM_END_DATE = "";
        public string PROBLEM_EXCLUDED_COMMENT = "";
        public string PROBLEM_HISTORY_TEXT = "";
        public string PROBLEM_HX_ACTIVITY = "";
        public string PROBLEM_LAST_MODIFIED_DATE = "";
        public string PROBLEM_NOTE = "";
        public string PROBLEM_OLD_REVISION = "";
        public string PROBLEM_ONSET_DATE = "";
        public string PROBLEM_ORIENTATION_TEXT = "";
        public string PROBLEM_PLANS_TEXT = "";
        public string PROBLEM_REPORT_SHOW = "";
        public string PROBLEM_SHOW_IN_PROBLEMS = "";
        public string PROBLEM_SOURCE = "";
        public string PROBLEM_STATUS = "";
        public string PROBLEM_STATUS1_SUBJECTIVE = "";
        public string PROBLEM_STATUS2 = "";
        public string PROBLEM_STATUS2_SUBJECTIVE = "";
        public string PROBLEM_USER_ID_ADDED = "";
        public string PROBLEM_USER_ID_LAST_MODIF = "";
        public string TAG_ORDER = "";
        public string TAG_CREATEDATE = "";
        public string TAG_SYSTEMDATE = "";
        public string TAG_SYSTEMUSER = "";
        public string PROBLEM_DISCUSSION_TOPIC = "";
        public string PROBLEM_HISTORY_TOPIC = "";
        public string PROBLEM_ONSET_DATE_PARTIAL = "";
        public string PROBLEM_STATUS2_FLAG = "";
        public string PROBLEM_STATUS2_COPY = "";
        public string PROBLEM_DISCUSSION_DIFFERENTIA = "";
        public string PROBLEM_DURATION_TEXT = "";
        public string PROBLEM_SEVERITY_FLAG = "";
    }
}
