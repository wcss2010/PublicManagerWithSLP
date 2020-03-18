using System;
using System.Data;
using System.Text;

namespace PublicManager.DB.Entitys 
{
    /// <summary>
    /// 类Project。
    /// </summary>
    [Serializable]
    public partial class Project : Noear.Weed.IEntity
    {
        public Project() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ProjectID", ProjectID);
            query.set("CatalogID", CatalogID);
            query.set("ProjectName", ProjectName);
            query.set("ProjectTopic", ProjectTopic);
            query.set("ProjectDirection", ProjectDirection);
            query.set("ProjectSecretLevel", ProjectSecretLevel);
            query.set("ProjectMasterName", ProjectMasterName);
            query.set("ProjectMasterSex", ProjectMasterSex);
            query.set("ProjectMasterBirthday", ProjectMasterBirthday);
            query.set("ProjectMasterJob", ProjectMasterJob);
            query.set("ProjectMasterTelephone", ProjectMasterTelephone);
            query.set("ProjectMasterMobilephone", ProjectMasterMobilephone);
            query.set("TeamContactName", TeamContactName);
            query.set("TeamContactSex", TeamContactSex);
            query.set("TeamContactBirthday", TeamContactBirthday);
            query.set("TeamContactJob", TeamContactJob);
            query.set("TeamContactTelephone", TeamContactTelephone);
            query.set("TeamContactMobilephone", TeamContactMobilephone);
            query.set("TeamContactAddress", TeamContactAddress);
            query.set("UnitName", UnitName);
            query.set("UnitRealName", UnitRealName);
            query.set("UnitAddress", UnitAddress);
            query.set("UnitType2", UnitType2);
            query.set("UnitContact", UnitContact);
            query.set("UnitContactJob", UnitContactJob);
            query.set("UnitContactPhone", UnitContactPhone);
            query.set("TotalTime", TotalTime);
            query.set("TotalMoney", TotalMoney);
            query.set("RequestTime", RequestTime);

            return query;
        }

        public string ProjectID { get; set; }
        public string CatalogID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectTopic { get; set; }
        public string ProjectDirection { get; set; }
        public string ProjectSecretLevel { get; set; }
        public string ProjectMasterName { get; set; }
        public string ProjectMasterSex { get; set; }
        public DateTime ProjectMasterBirthday { get; set; }
        public string ProjectMasterJob { get; set; }
        public string ProjectMasterTelephone { get; set; }
        public string ProjectMasterMobilephone { get; set; }
        public string TeamContactName { get; set; }
        public string TeamContactSex { get; set; }
        public DateTime TeamContactBirthday { get; set; }
        public string TeamContactJob { get; set; }
        public string TeamContactTelephone { get; set; }
        public string TeamContactMobilephone { get; set; }
        public string TeamContactAddress { get; set; }
        public string UnitName { get; set; }
        public string UnitRealName { get; set; }
        public string UnitAddress { get; set; }
        public string UnitType2 { get; set; }
        public string UnitContact { get; set; }
        public string UnitContactJob { get; set; }
        public string UnitContactPhone { get; set; }
        public int TotalTime { get; set; }
        public decimal TotalMoney { get; set; }
        public DateTime RequestTime { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ProjectID = source("ProjectID").value<string>("");
            CatalogID = source("CatalogID").value<string>("");
            ProjectName = source("ProjectName").value<string>("");
            ProjectTopic = source("ProjectTopic").value<string>("");
            ProjectDirection = source("ProjectDirection").value<string>("");
            ProjectSecretLevel = source("ProjectSecretLevel").value<string>("");
            ProjectMasterName = source("ProjectMasterName").value<string>("");
            ProjectMasterSex = source("ProjectMasterSex").value<string>("");
            ProjectMasterBirthday = source("ProjectMasterBirthday").value<DateTime>(DateTime.Now);
            ProjectMasterJob = source("ProjectMasterJob").value<string>("");
            ProjectMasterTelephone = source("ProjectMasterTelephone").value<string>("");
            ProjectMasterMobilephone = source("ProjectMasterMobilephone").value<string>("");
            TeamContactName = source("TeamContactName").value<string>("");
            TeamContactSex = source("TeamContactSex").value<string>("");
            TeamContactBirthday = source("TeamContactBirthday").value<DateTime>(DateTime.Now);
            TeamContactJob = source("TeamContactJob").value<string>("");
            TeamContactTelephone = source("TeamContactTelephone").value<string>("");
            TeamContactMobilephone = source("TeamContactMobilephone").value<string>("");
            TeamContactAddress = source("TeamContactAddress").value<string>("");
            UnitName = source("UnitName").value<string>("");
            UnitRealName = source("UnitRealName").value<string>("");
            UnitAddress = source("UnitAddress").value<string>("");
            UnitType2 = source("UnitType2").value<string>("");
            UnitContact = source("UnitContact").value<string>("");
            UnitContactJob = source("UnitContactJob").value<string>("");
            UnitContactPhone = source("UnitContactPhone").value<string>("");
            TotalTime = source("TotalTime").value<int>(0);
            TotalMoney = source("TotalMoney").value<decimal>(0);
            RequestTime = source("RequestTime").value<DateTime>(DateTime.Now);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new Project();
        }
    }
}
