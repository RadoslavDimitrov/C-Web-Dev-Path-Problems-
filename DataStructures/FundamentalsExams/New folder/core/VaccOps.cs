using System;
using System.Collections.Generic;
using System.Linq;

namespace VaccTests
{
    public class VaccOps
    {

        private Dictionary<string, Doctor> docs;
        private Dictionary<string, Patient> patients;
        private Dictionary<string, List<Patient>> docPatients;
        private Dictionary<Doctor, List<Patient>> docsAndPatients;
        public VaccOps()
        {
            this.docs = new Dictionary<string, Doctor>();
            this.docPatients = new Dictionary<string, List<Patient>>();
            this.patients = new Dictionary<string, Patient>();
            this.docsAndPatients = new Dictionary<Doctor, List<Patient>>();
        }

        public void AddDoctor(Doctor d)
        {
            if (this.docs.ContainsKey(d.Name))
            {
                throw new ArgumentException();
            }

            this.docs.Add(d.Name, d);

            this.docPatients.Add(d.Name, new List<Patient>());

            this.docsAndPatients.Add(d, new List<Patient>());
        }

        public void AddPatient(Doctor d, Patient p)
        {
            if (!this.docs.ContainsKey(d.Name))
            {
                throw new ArgumentException();
            }

            this.docPatients[d.Name].Add(p);
            this.patients.Add(p.Name, p);
            this.docsAndPatients[d].Add(p);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            List<Doctor> result = new List<Doctor>();

            if (this.docs.Count > 0)
            {
                result = this.docs.Values.ToList();
            }

            return result;
        }

        public IEnumerable<Patient> GetPatients()
        {
            List<Patient> result = new List<Patient>();

            if (this.patients.Count > 0)
            {
                result = this.patients.Values.ToList();
            }

            return result;
        }

        public bool Exist(Doctor d)
        {
            return this.docs.ContainsKey(d.Name);
        }

        public bool Exist(Patient p)
        {
            return this.patients.ContainsKey(p.Name);
        }


        public Doctor RemoveDoctor(string name)
        {
            if (!this.docs.ContainsKey(name))
            {
                throw new ArgumentException();
            }

            Doctor doc = this.docs[name];
            this.docs.Remove(name);

            foreach (var patient in this.docPatients[name])
            {
                this.patients.Remove(patient.Name);
            }

            this.docPatients.Remove(name);

            this.docsAndPatients.Remove(doc);

            return doc;
        }

        public void ChangeDoctor(Doctor from, Doctor to, Patient p)
        {
            if (!this.docs.ContainsKey(from.Name))
            {
                throw new ArgumentException();
            }

            if (!this.docs.ContainsKey(to.Name))
            {
                throw new ArgumentException();
            }

            if (!this.patients.ContainsKey(p.Name))
            {
                throw new ArgumentException();
            }

            this.docsAndPatients[from].Remove(p);
            this.docsAndPatients[to].Add(p);

            this.docPatients[from.Name].Remove(p);
            this.docPatients[to.Name].Add(p);
        }


        public IEnumerable<Doctor> GetDoctorsByPopularity(int populariry)
        {
            var result = this.docs.Values.Where(x => x.Popularity == populariry).ToList();

            return result;
        }

        public IEnumerable<Patient> GetPatientsByTown(string town)
        {
            return this.patients.Values.Where(x => x.Town == town).ToList();
        }

        public IEnumerable<Patient> GetPatientsInAgeRange(int lo, int hi)
        {
            return this.patients.Values.Where(x => x.Age >= lo && x.Age <= hi).ToList();
        }

        public IEnumerable<Doctor> GetDoctorsSortedByPatientsCountDescAndNameAsc()
        {
            var orderedDocs = this.docPatients.OrderByDescending(x => x.Value.Count).OrderBy(x => x.Key).Select(x => x.Key).ToList();
            List<Doctor> result = null;

            foreach (var docName in orderedDocs)
            {
                result.Add(this.docs[docName]);
            }

            return result;
        }


        public IEnumerable<Patient> GetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAge()
        {
            return null;
        }
    }
}
