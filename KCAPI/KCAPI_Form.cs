using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Codeplex.Data;
using System.Net;
using System.Runtime.Serialization.Json;

namespace KCAPI
{
    public partial class KCAPI_Form : Form
    {
        #region Public
        #region Method

        public KCAPI_Form()
        {
            InitializeComponent();
            this.Initialize();
        }

        #endregion
        #endregion
        #region Private
        #region Method
        private void Initialize()
        {
            //Finddler
            Fiddler.FiddlerApplication.AfterSessionComplete
                        += new Fiddler.SessionStateHandler(FiddlerApplication_AfterSessionComplete);

            //Fiddlerを開始。ポートは自動選択
            Fiddler.FiddlerApplication.Startup(0, Fiddler.FiddlerCoreStartupFlags.RegisterAsSystemProxy);
        }

        private void UpdateTextBox(string message)
        {
            try
            {
                if (this.LogTextBox.InvokeRequired)
                {
                    this.Invoke(new Action<string>(UpdateTextBox), message);
                }
                else
                {
                    this.LogTextBox.Text += message;
                }
            }
            catch (Exception) { }
        }



        #endregion
        #region EventHandler

        void FiddlerApplication_AfterSessionComplete(Fiddler.Session oSession)
        {
            //取得条件
           // try
           // {
                if (oSession.uriContains("203.104.209.55/kcsapi/"))
                {
                    this.UpdateTextBox(string.Format($"Session: {oSession.fullUrl}"));
                    var response = oSession.GetResponseBodyAsString();
                    //Console.WriteLine(response);
                    var result = new DataContractJsonSerializer(typeof(Result));
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(response)))
                    {
                        //var data = (Result)result.ReadObject(ms);
                        Console.WriteLine(ms);
                        this.UpdateTextBox(string.Format(ms.ToString()));
                        
                    }
                }
                else
                {
                  
                }
           // }
           // catch (Exception) { }
        }

        private void KCAPI_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            //プロキシ設定を外す
            Fiddler.URLMonInterop.ResetProxyInProcessToDefault();
            
            //Fiddlerを終了させる
            Fiddler.FiddlerApplication.Shutdown();
        }


        #endregion
        #region Member
        #region Const
        
        public class Result
        {

            public class ApiMaterial
            {
                public int api_member_id { get; set; }
                public int api_id { get; set; }
                public int api_value { get; set; }
            }

            public class ApiDeckPort
            {
                public int api_member_id { get; set; }
                public int api_id { get; set; }
                public string api_name { get; set; }
                public string api_name_id { get; set; }
                public List<object> api_mission { get; set; }
                public string api_flagship { get; set; }
                public List<int> api_ship { get; set; }
            }

            public class ApiNdock
            {
                public int api_member_id { get; set; }
                public int api_id { get; set; }
                public int api_state { get; set; }
                public int api_ship_id { get; set; }
                public object api_complete_time { get; set; }
                public string api_complete_time_str { get; set; }
                public int api_item1 { get; set; }
                public int api_item2 { get; set; }
                public int api_item3 { get; set; }
                public int api_item4 { get; set; }
            }

            public class ApiShip
            {
                public int api_id { get; set; }
                public int api_sortno { get; set; }
                public int api_ship_id { get; set; }
                public int api_lv { get; set; }
                public List<int> api_exp { get; set; }
                public int api_nowhp { get; set; }
                public int api_maxhp { get; set; }
                public int api_leng { get; set; }
                public List<int> api_slot { get; set; }
                public List<int> api_onslot { get; set; }
                public int api_slot_ex { get; set; }
                public List<int> api_kyouka { get; set; }
                public int api_backs { get; set; }
                public int api_fuel { get; set; }
                public int api_bull { get; set; }
                public int api_slotnum { get; set; }
                public int api_ndock_time { get; set; }
                public List<int> api_ndock_item { get; set; }
                public int api_srate { get; set; }
                public int api_cond { get; set; }
                public List<int> api_karyoku { get; set; }
                public List<int> api_raisou { get; set; }
                public List<int> api_taiku { get; set; }
                public List<int> api_soukou { get; set; }
                public List<int> api_kaihi { get; set; }
                public List<int> api_taisen { get; set; }
                public List<int> api_sakuteki { get; set; }
                public List<int> api_lucky { get; set; }
                public int api_locked { get; set; }
                public int api_locked_equip { get; set; }
            }

            public class ApiBasic
            {
                public string api_member_id { get; set; }
                public string api_nickname { get; set; }
                public string api_nickname_id { get; set; }
                public int api_active_flag { get; set; }
                public long api_starttime { get; set; }
                public int api_level { get; set; }
                public int api_rank { get; set; }
                public int api_experience { get; set; }
                public object api_fleetname { get; set; }
                public string api_comment { get; set; }
                public string api_comment_id { get; set; }
                public int api_max_chara { get; set; }
                public int api_max_slotitem { get; set; }
                public int api_max_kagu { get; set; }
                public int api_playtime { get; set; }
                public int api_tutorial { get; set; }
                public List<int> api_furniture { get; set; }
                public int api_count_deck { get; set; }
                public int api_count_kdock { get; set; }
                public int api_count_ndock { get; set; }
                public int api_fcoin { get; set; }
                public int api_st_win { get; set; }
                public int api_st_lose { get; set; }
                public int api_ms_count { get; set; }
                public int api_ms_success { get; set; }
                public int api_pt_win { get; set; }
                public int api_pt_lose { get; set; }
                public int api_pt_challenged { get; set; }
                public int api_pt_challenged_win { get; set; }
                public int api_firstflag { get; set; }
                public int api_tutorial_progress { get; set; }
                public List<int> api_pvp { get; set; }
                public int api_medals { get; set; }
                public int api_large_dock { get; set; }
            }

            public class ApiLog
            {
                public int api_no { get; set; }
                public string api_type { get; set; }
                public string api_state { get; set; }
                public string api_message { get; set; }
            }

            public class ApiData
            {
                public List<ApiMaterial> api_material { get; set; }
                public List<ApiDeckPort> api_deck_port { get; set; }
                public List<ApiNdock> api_ndock { get; set; }
                public List<ApiShip> api_ship { get; set; }
                public ApiBasic api_basic { get; set; }
                public List<ApiLog> api_log { get; set; }
                public int api_p_bgm_id { get; set; }
                public int api_parallel_quest_count { get; set; }
            }

            public int api_result { get; set; }
            public string api_result_msg { get; set; }
            public ApiData api_data { get; set; }


        }

        #endregion
        #endregion
        #endregion
    }
}
