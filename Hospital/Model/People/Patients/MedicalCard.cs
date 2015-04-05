using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.DataAccess.Util;

namespace Hospital.Model.People.Patients
{
    public class MedicalCard
    {
        private Database _database;

        public int patientID { get; set; }
        public int medicalCardID { get; set; }
        public List<Entry> entries { get; set; }


        public MedicalCard(int patientID) {
            this.patientID = patientID;
            this._database = new Database();
        }

        public void addEntry(Entry entry) { }

        public int getMedicalCardIDFromDb()
        {
            int id;

            String query = String.Format("SELECT medical_card_id FROM Medical_cards WHERE patientID={0}", this.patientID);
            id = int.Parse(this._database.selectSingleQuery(query));

            return id;
        }
    }
}
