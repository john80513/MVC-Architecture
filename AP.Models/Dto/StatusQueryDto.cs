using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESunBank.Models.Dto
{
    /// <summary>
    /// 狀態查詢與變更
    /// </summary>
    public class StatusQueryDto
    {
        /// <summary>
        /// 序號
        /// </summary>
        public int SN { get; set; }
        /// <summary>
        /// 特徵編號
        /// </summary>
        public string Idno { get; set; }
        /// <summary>
        /// 登錄時間
        /// </summary>
        public DateTime ModifiedTime { get; set; }
        /// <summary>
        /// 登錄單位
        /// </summary>
        public string ModifiedUnits { get; set; }
        /// <summary>
        /// 登錄櫃員
        /// </summary>
        public string ModifiedBy { get; set; }
        /// <summary>
        /// 事故代號
        /// </summary>
        public string ModifiedType { get; set; }
    }
}
