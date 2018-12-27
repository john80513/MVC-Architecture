namespace AP.Service.ViewModels
{
    public class ExportFile
    {
        public enum Type
        {
            StatusQuery = 1,            //狀態查詢與變更
            StatusChangRecord,          //狀態異動紀錄
            FeatureComparisonRecord,    //特徵比對紀錄
            EstablishRecord,            //建檔記錄
            EstablishSimilarRecord,     //建檔相似紀錄
            LiveDetectionRecord,        //活體偵測紀錄
        };
    }
}
