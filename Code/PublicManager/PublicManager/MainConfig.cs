using SuperCodeFactoryLib.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PublicManager
{
    /// <summary>
    /// 程序配置文件
    /// </summary>
    public class MainConfig
    {
        /// <summary>
        /// 行分割符
        /// </summary>
        public const string rowFlag = "{(<r>)}";

        /// <summary>
        /// 单元格分割符
        /// </summary>
        public const string cellFlag = "{(<c>)}";

        /// <summary>
        /// 配置文件路径
        /// </summary>
        public static string constConfigFile = string.Empty;

        /// <summary>
        /// 配置
        /// </summary>
        public static MainConfig Config { get; set; }

        private SerialDictionary<string, string> stringDict = new SerialDictionary<string, string>();
        /// <summary>
        /// 字符数据字典
        /// </summary>
        public SerialDictionary<string, string> StringDict
        {
            get { return stringDict; }
        }

        private SerialDictionary<string, object> objectDict = new SerialDictionary<string, object>();
        /// <summary>
        /// 对象数据字典
        /// </summary>
        public SerialDictionary<string, object> ObjectDict
        {
            get { return objectDict; }
        }
        
        /// <summary>
        /// 载入配置
        /// </summary>
        public static void loadConfig()
        {
            try
            {
                //检查是不是存在配置文件
                if (File.Exists(constConfigFile))
                {
                    //读取配置文件
                    Config = Newtonsoft.Json.JsonConvert.DeserializeObject<MainConfig>(File.ReadAllText(constConfigFile));
                }
                else
                {
                    //初始化
                    initConfig();
                }
            }
            catch (Exception ex)
            {
                //初始化
                initConfig();
            }
        }

        /// <summary>
        /// 初始化配置
        /// </summary>
        public static void initConfig()
        {
            Config = new MainConfig();

            Config.StringDict["先导总目录"] = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            Config.StringDict["先导解压目录"] = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            Config.StringDict["报告验证_目录"] = "files";
            Config.StringDict["报告验证_文件"] = "static.db";

            Config.ObjectDict.Add("责任单位", new string[] { "陆军", "海军", "空军", "火箭军", "战略支援部队", "联勤保障部队", "军委机关直属单位", "军事科学院", "国防大学", "国防科技大学", "武警部队", "教育部", "工信部", "中国科学院", "中国核工业集团有限公司", "中国航天科技集团有限公司", "中国航天科工集团有限公司", "中国航空工业集团有限公司", "中国船舶集团有限公司", "中国兵器工业集团有限公司", "中国兵器装备集团有限公司", "中国电子科技集团有限公司", "中国航空发动机集团有限公司", "中国电子信息产业集团有限公司", "中国工程物理研究院", "其它" });

            //保存初始化内容
            saveConfig();

            //重新加载一次
            loadConfig();
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        public static void saveConfig()
        {
            string cnt = Newtonsoft.Json.JsonConvert.SerializeObject(Config, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(constConfigFile, cnt);
        }
    }
}