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

            //字典
            Dictionary<string, string[]> sdDict = new Dictionary<string, string[]>();
            sdDict["国防科技发展综合研究"] = new string[] { "国防科技安全问題研究", "美科技封锁动态与应对策略研究", "国防科技重点领域发展战略问題研究", "国防科技发展评估研究", "军控问題研究", "联合作战科学技术问題研究" };
            sdDict["军事智能科技发展研究"] = new string[] { "军事智能科技发展评估研究", "智能化战争技术预见", "人工智能安全战略问題研究", "国外智能科技系列译丛" };
            sdDict["国防关健技术发展研究"] = new string[] { "国防科技重点领域技术发展路线图研究", "关键技术短板瓶颈问题研究", "联合作战实验技术发展研究" };
            sdDict["国防前沿技术发展研究"] = new string[] { "前沿技术动态发展研究", "国防前沿与颠覆性技术清单研究" };
            sdDict["国防基础研究发展研究"] = new string[] { "国防基础研究重大问題研究" };
            sdDict["国防科技扫描预警研究"] = new string[] { "国防科技热点问題研究", "技术监测预警研究", "美国防部现代化优先事项跟踪评估", "外军作战概念关键技术预测分析" };
            sdDict["国防科技信息资源开发利用"] = new string[] { "国防科技知识图谱开发", "军事科普创意产品开发", "国防科技新概念新名词" };
            sdDict["国防科技管理创新研究"] = new string[] { "国防科技管理创新研究" };

            Config.ObjectDict.Add("主题方向", sdDict);

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