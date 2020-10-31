using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P4BorderControl
{
    public class EntryList
    {
        private List<CheckIds> list;

        public EntryList()
        {
            this.list = new List<CheckIds>();
        }

        public void Add(CheckIds currPpl)
        {
            this.list.Add(currPpl);
        }
        public List<CheckIds> GetFakeIds(string fakeId)
        {
            List<CheckIds> fakeIds = this.list.Where(x => x.IsFakeId(fakeId) == true).ToList();
            return fakeIds;
        }
    }
}
