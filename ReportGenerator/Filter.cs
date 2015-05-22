using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportGenerator
{
    // This class is not used now
    class Filter
    {
        struct FilterData
        {
            public string keyword;
            public List<int> id;
        }

        //private FilterData[,] filterData;
        private List<FilterData>[] filterData;
        public Filter(int colNum) {
            filterData = new List<FilterData>[colNum];
            for(int i= 0; i<colNum;i++)
                filterData[i] = new List<FilterData>();
        }

        public void addData(int colID, string newKeyword, int id){
            bool repeatedKeyword = false;
            foreach (FilterData data in filterData[colID])
                if (data.keyword == newKeyword)
                {
                    data.id.Add(id);
                    repeatedKeyword = true;
                    break;
                }
            if (repeatedKeyword ==false)
            {
                FilterData newData = new FilterData();
                newData.id = new List<int>();
                newData.id.Add(id);
                newData.keyword = newKeyword;
                filterData[colID].Add(newData);
            }
        }

    }
}
