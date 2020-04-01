using Noear.Weed;
using PublicManager.DB;
using PublicManager.DB.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicManager.Modules.Module_A.PkgImporter
{
    public class DBImporter : BaseDBImporter
    {
        /// <summary>
        /// 导入数据库
        /// </summary>
        /// <returns></returns>
        protected override string importDB(string zipFile, string catalogNumber, string sourceFile, Noear.Weed.DbContext localContext)
        {
            //数据库版本号
            string catalogVersionStr = "v1.0";

            //附件目录
            string filesDir = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(sourceFile), "Files");

            //处理项目信息
            DataItem diProject = localContext.table("Projects").select("*").getDataItem();
            if (diProject != null && diProject.count() >= 1)
            {
                #region 读取版本号并更新Catalog信息
                //读取版本号
                try
                {
                    catalogVersionStr = localContext.table("Version").select("VersionNum").getValue<string>(catalogVersionStr);
                }
                catch (Exception ex) { }

                //更新Catalog
                Catalog catalog = updateAndClearCatalog(catalogNumber, diProject.getString("ProjectName"), "战略先导", catalogVersionStr, zipFile);
                #endregion

                #region 导入项目
                //添加项目信息
                Project proj = new Project();
                proj.ProjectID = catalog.CatalogID;
                proj.CatalogID = catalog.CatalogID;
                proj.ProjectName = catalog.CatalogName;

                try
                {
                    proj.ProjectTopic = diProject.get("ProjectTopic") != null ? diProject.get("ProjectTopic").ToString() : string.Empty;
                }
                catch (Exception ex) { }

                try
                {
                    proj.ProjectDirection = diProject.get("ProjectDirection") != null ? diProject.get("ProjectDirection").ToString() : string.Empty;
                }
                catch (Exception ex) { }

                try
                {
                    proj.ProjectSecretLevel = diProject.get("ProjectSecretLevel") != null ? diProject.get("ProjectSecretLevel").ToString() : string.Empty;
                }
                catch (Exception ex) { }

                try
                {
                    proj.ProjectMasterName = diProject.get("ProjectMasterName") != null ? diProject.get("ProjectMasterName").ToString() : string.Empty;
                }
                catch (Exception ex) { }

                try
                {
                    proj.ProjectMasterSex = diProject.get("ProjectMasterSex") != null ? diProject.get("ProjectMasterSex").ToString() : string.Empty;
                }
                catch (Exception ex) { }

                try
                {
                    proj.ProjectMasterBirthday = diProject.get("ProjectMasterBirthday") != null ? DateTime.Parse(diProject.get("ProjectMasterBirthday").ToString()) : DateTime.Now;
                }
                catch (Exception ex) { }

                try
                {
                    proj.ProjectMasterJob = diProject.get("ProjectMasterJob") != null ? diProject.get("ProjectMasterJob").ToString() : string.Empty;
                }
                catch (Exception ex) { }

                try
                {
                    proj.ProjectMasterTelephone = diProject.get("ProjectMasterTelephone") != null ? diProject.get("ProjectMasterTelephone").ToString() : string.Empty;
                }
                catch (Exception ex) { }

                try
                {
                    proj.ProjectMasterMobilephone = diProject.get("ProjectMasterMobilephone") != null ? diProject.get("ProjectMasterMobilephone").ToString() : string.Empty;
                }
                catch (Exception ex) { }

                try
                {
                    proj.TeamContactName = diProject.get("TeamContactName") != null ? diProject.get("TeamContactName").ToString() : string.Empty;
                }
                catch (Exception ex) { }

                try
                {
                    proj.TeamContactSex = diProject.get("TeamContactSex") != null ? diProject.get("TeamContactSex").ToString() : string.Empty;
                }
                catch (Exception ex) { }

                try
                {
                    proj.TeamContactBirthday = diProject.get("TeamContactBirthday") != null ? DateTime.Parse(diProject.get("TeamContactBirthday").ToString()) : DateTime.Now;
                }
                catch (Exception ex) { }

                try
                {
                    proj.TeamContactJob = diProject.get("TeamContactJob") != null ? diProject.get("TeamContactJob").ToString() : string.Empty;
                }
                catch (Exception ex) { }

                try
                {
                    proj.TeamContactTelephone = diProject.get("TeamContactTelephone") != null ? diProject.get("TeamContactTelephone").ToString() : string.Empty;
                }
                catch (Exception ex) { }

                try
                {
                    proj.TeamContactMobilephone = diProject.get("TeamContactMobilephone") != null ? diProject.get("TeamContactMobilephone").ToString() : string.Empty;
                }
                catch (Exception ex) { }

                try
                {
                    proj.TeamContactAddress = diProject.get("TeamContactAddress") != null ? diProject.get("TeamContactAddress").ToString() : string.Empty;
                }
                catch (Exception ex) { }

                try
                {
                    proj.UnitName = diProject.get("UnitName") != null ? diProject.get("UnitName").ToString() : string.Empty;
                }
                catch (Exception ex) { }

                try
                {
                    proj.UnitRealName = diProject.get("UnitRealName") != null ? diProject.get("UnitRealName").ToString() : string.Empty;
                }
                catch (Exception ex) { }

                try
                {
                    proj.UnitAddress = diProject.get("UnitAddress") != null ? diProject.get("UnitAddress").ToString() : string.Empty;
                }
                catch (Exception ex) { }

                try
                {
                    proj.UnitType2 = diProject.get("UnitType2") != null ? diProject.get("UnitType2").ToString() : string.Empty;
                }
                catch (Exception ex) { }

                try
                {
                    proj.UnitContact = diProject.get("UnitContact") != null ? diProject.get("UnitContact").ToString() : string.Empty;
                }
                catch (Exception ex) { }

                try
                {
                    proj.UnitContactJob = diProject.get("UnitContactJob") != null ? diProject.get("UnitContactJob").ToString() : string.Empty;
                }
                catch (Exception ex) { }

                try
                {
                    proj.UnitContactPhone = diProject.get("UnitContactPhone") != null ? diProject.get("UnitContactPhone").ToString() : string.Empty;
                }
                catch (Exception ex) { }

                try
                {
                    proj.TotalTime = diProject.get("TotalTime") != null ? int.Parse(diProject.get("TotalTime").ToString()) : 0;
                }
                catch (Exception ex) { }

                try
                {
                    proj.TotalMoney = diProject.get("TotalMoney") != null ? decimal.Parse(diProject.get("TotalMoney").ToString()) : 0;
                }
                catch (Exception ex) { }

                try
                {
                    proj.RequestTime = diProject.get("RequestTime") != null ? DateTime.Parse(diProject.get("RequestTime").ToString()) : DateTime.Now;
                }
                catch (Exception ex) { }
                
                proj.copyTo(ConnectionManager.Context.table("Project")).insert();
                #endregion
                
                return catalog.CatalogID;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 清除表格
        /// </summary>
        /// <param name="catalogID"></param>
        public override void clearProjectDataWithCatalogID(string catalogID)
        {
            ConnectionManager.Context.table("Project").where("CatalogID='" + catalogID + "'").delete();
            //ConnectionManager.Context.table("Person").where("CatalogID='" + catalogID + "'").delete();
            //ConnectionManager.Context.table("Moneys").where("CatalogID='" + catalogID + "'").delete();
            //ConnectionManager.Context.table("Professions").where("CatalogID='" + catalogID + "'").delete();
        }

        protected override bool isExistsTables(DbContext context)
        {
            try
            {
                DataItem diProject = context.table("Projects").select("*").getDataItem();
                if (diProject != null && diProject.count() >= 1 && !string.IsNullOrEmpty(diProject.getString("ProjectName")))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}