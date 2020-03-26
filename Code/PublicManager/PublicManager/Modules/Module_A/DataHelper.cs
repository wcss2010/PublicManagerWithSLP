using System;
using System.Collections.Generic;
using System.Text;

namespace PublicManager.Modules.Module_A
{
    public class DataHelper
    {
        /// <summary>
        /// 大单位列表
        /// </summary>
        /// <returns></returns>
        public static List<string> getUnitList()
        {
            List<string> results = new List<string>();
            if (MainConfig.Config.ObjectDict.ContainsKey("责任单位"))
            {
                try
                {
                    Newtonsoft.Json.Linq.JArray teams = (Newtonsoft.Json.Linq.JArray)MainConfig.Config.ObjectDict["责任单位"];
                    foreach (string s in teams)
                    {
                        results.Add(s);
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
            }
            return results;
        }

        /// <summary>
        /// 主题方向字典
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string[]> getSubjectList()
        {
            Dictionary<string, string[]> results = new Dictionary<string, string[]>();
            if (MainConfig.Config.ObjectDict.ContainsKey("主题方向"))
            {
                try
                {
                    Newtonsoft.Json.Linq.JObject teams = (Newtonsoft.Json.Linq.JObject)MainConfig.Config.ObjectDict["主题方向"];
                    foreach (KeyValuePair<string, Newtonsoft.Json.Linq.JToken> dd in teams)
                    {
                        List<string> dddd = new List<string>();
                        Newtonsoft.Json.Linq.JArray arrayTeams = (Newtonsoft.Json.Linq.JArray)dd.Value;
                        foreach (string s in arrayTeams)
                        {
                            dddd.Add(s);
                        }
                        results[dd.Key] = dddd.ToArray();
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
            }
            return results;
        }
    }
}