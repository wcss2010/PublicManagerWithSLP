using System;
using System.Collections.Generic;
using System.Text;

namespace PublicManager.DB.Entitys
{
    /// <summary>
    /// 类Subject。
    /// </summary>
    [Serializable]
    public partial class Subject : Noear.Weed.IEntity
    {
        public Subject() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("SubjectID", SubjectID);
            query.set("CatalogID", CatalogID);
            query.set("ProjectID", ProjectID);
            query.set("SubjectName", SubjectName);
            query.set("SecretLevel", SecretLevel);
            query.set("TotalTime", TotalTime);
            query.set("TotalMoney", TotalMoney);
            query.set("UnitName", UnitName);
            query.set("UnitAddress", UnitAddress);
            query.set("UnitType2", UnitType2);
            query.set("UnitContact", UnitContact);
            query.set("UnitContactJob", UnitContactJob);
            query.set("UnitContactPhone", UnitContactPhone);

            return query;
        }

        public string SubjectID { get; set; }
        public string CatalogID { get; set; }
        public string ProjectID { get; set; }
        public string SubjectName { get; set; }
        public string SecretLevel { get; set; }
        public int TotalTime { get; set; }
        public decimal TotalMoney { get; set; }
        public string UnitName { get; set; }
        public string UnitAddress { get; set; }
        public string UnitType2 { get; set; }
        public string UnitContact { get; set; }
        public string UnitContactJob { get; set; }
        public string UnitContactPhone { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            SubjectID = source("SubjectID").value<string>("");
            CatalogID = source("CatalogID").value<string>("");
            ProjectID = source("ProjectID").value<string>("");
            SubjectName = source("SubjectName").value<string>("");
            SecretLevel = source("SecretLevel").value<string>("");
            TotalTime = source("TotalTime").value<int>(0);
            TotalMoney = source("TotalMoney").value<decimal>(0);
            UnitName = source("UnitName").value<string>("");
            UnitAddress = source("UnitAddress").value<string>("");
            UnitType2 = source("UnitType2").value<string>("");
            UnitContact = source("UnitContact").value<string>("");
            UnitContactJob = source("UnitContactJob").value<string>("");
            UnitContactPhone = source("UnitContactPhone").value<string>("");
        }

        public override Noear.Weed.IBinder clone()
        {
            return new Subject();
        }
    }
}