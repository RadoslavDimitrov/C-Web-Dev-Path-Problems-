using System;
using System.Collections.Generic;
using System.Linq;

namespace VaccTests
{
    public class VaccOps
    {

        public VaccOps()
        {
        }

        public void AddDoctor(Doctor d)
        {
        }

        public void AddPatient(Doctor d, Patient p)
        {
        }

        public IEnumerable<Doctor> GetDoctors()
        {
        }

        public IEnumerable<Patient> GetPatients()
        {
            return null;
        }

        public bool Exist(Doctor d)
        {
            return null;
        }

        public bool Exist(Patient p)
        {
            return null;
        }


        public Doctor RemoveDoctor(string name)
        {
            return null;
        }

        public void ChangeDoctor(Doctor from, Doctor to, Patient p)
        {
        }

        public IEnumerable<Doctor> GetDoctorsByPopularity(int populariry)
        {
            return null;
        }

        public IEnumerable<Patient> GetPatientsByTown(string town)
        {
            return null;
        }

        public IEnumerable<Patient> GetPatientsInAgeRange(int lo, int hi)
        {
            return null;
        }

        public IEnumerable<Doctor> GetDoctorsSortedByPatientsCountDescAndNameAsc()
        {
            return null;
        }


        public IEnumerable<Patient> GetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAge()
        {
            return null;
        }
    }
}
