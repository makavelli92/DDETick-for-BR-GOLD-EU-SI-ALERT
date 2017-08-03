using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDETicks.Models
{
    class Ticks
    {
        public string Name { get; set; }
        public List<TimeSpan> date;
        public List<double> price;
        public List<int> count;


        public Ticks(string name)
        {
            Name = name;
            date = new List<TimeSpan>();
            price = new List<double>();
            count = new List<int>();
        }
        public SortedDictionary<double, int> LastClaster(int timeFrame)
        {
            SortedDictionary<double, int> claster = new SortedDictionary<double, int>();
            TimeSpan tempTime = date.Last().Add(new TimeSpan(0, 0, -timeFrame));
            int temp = date.Count - 1;
            while (tempTime < date[temp] && temp > 0)
            {
                if (claster.ContainsKey(price[temp]))
                    claster[price[temp]] += count[temp];
                else
                    claster.Add(price[temp], count[temp]);
                temp--;
            }
            return claster;
        }
    }
}
