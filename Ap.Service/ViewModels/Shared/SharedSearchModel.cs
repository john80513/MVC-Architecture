using System.Collections.Generic;

namespace AP.Service.ViewModels
{
    public class SharedSearchModel<SearchModel, T>
        where SearchModel : class
        where T : class
    {

        public SearchModel SearchPara { get; set; }

        public IEnumerable<T> DataList { get; set; }

        public int PageIndex { get; set; } = 1;

        // 資料總筆數
        public int Total { get; set; }

        public int PageSize { get; set; } = 20;

        public int IndexNum {
            get { return GetIndexNum(); }
         }

        public int IndexNumDesc
        {
            get { return GetIndexNumDesc(); }
        }

        private int GetIndexNum()
        {
            return (PageIndex - 1) * PageSize;
        }

        private int GetIndexNumDesc()
        {
            return Total - (PageIndex - 1) * PageSize;
        }
    }
}
