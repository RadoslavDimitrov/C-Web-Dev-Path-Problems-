using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P4.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> stones;

        public Lake()
        {
            this.stones = new List<int>();
        }

        public Lake(List<int> stones)
        {
            this.stones = stones;
        }
        public IEnumerator<int> GetEnumerator()
        {
            //List<int> result = new List<int>();

            //for (int i = 0; i < this.stones.Count; i += 2)
            //{
            //    result.Add(this.stones[i]);
            //}

            //for (int i = this.stones.Count - 1; i > 0; i--)
            //{
            //    if(i % 2 != 0)
            //    {
            //        result.Add(this.stones[i]);
            //    }
            //}

            //return result;

            for (int i = 0; i < this.stones.Count; i++)
            {
                if (i % 2 == 0 || i == 0)
                {
                    yield return this.stones[i];
                }

                if (i == this.stones.Count-1)
                {
                    for (int j = this.stones.Count - 1; j > 0; j--)
                    {
                        if(j % 2 != 0)
                        {
                            yield return this.stones[j];
                        }
                        
                    }

                    break;
                }

                
                
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
