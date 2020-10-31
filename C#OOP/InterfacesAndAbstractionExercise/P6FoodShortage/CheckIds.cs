using System;
using System.Collections.Generic;
using System.Text;

namespace P4BorderControl
{
    public abstract class CheckIds
    {
        public string Id { get; set; }

        public virtual bool IsFakeId(string fakeId)
        {
            int fakeIdLength = fakeId.Length;
            if(this.Id.Length > fakeId.Length)
            {
                int startIndex = this.Id.Length - fakeIdLength;
                string currIdPart = string.Empty;

                for (int i = startIndex; i < this.Id.Length; i++)
                {
                    currIdPart += this.Id[i];
                }

                if(currIdPart == fakeId)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }
    }
}
