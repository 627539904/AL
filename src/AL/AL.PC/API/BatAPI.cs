using Arvin.Extensions;
using Arvin.PC;
using Arvin.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arvin.Helpers;
using AL.PC.Models;
using AL.PC.SysTools;
using Arvin.API;
using Arvin.LogHelper;

namespace Arvin.PC
{
    public class BatBaseAPI: BaseAPI
    {
        /// <summary>
        /// Bat文件路径
        /// </summary>
        public string BatPath { get;protected set; }
        /// <summary>
        /// 健康检查地址
        /// </summary>
        protected string HealthUrl { get; set; }
        public CallProcessBatAPIModel CallProcModel { get; set; }

        public BatBaseAPI(string batPath,string heath="")
        {
            this.BatPath = batPath;
            this.HealthUrl = heath;
            this.CallProcModel = new CallProcessBatAPIModel() { BatPath = batPath };
        }

        /// <summary>
        /// 启动API
        /// </summary>
        /// <param name="ignoreHealth">忽略健康检查，默认不忽略</param>
        public virtual void StartAPI(bool ignoreHealth=false)
        {
            if (HealthUrl.IsNullOrWhiteSpace()|| ignoreHealth)
            {
                ALog.WriteLine("【忽略健康检查】");
                //啥都不做
            }
            else
            {
                ALog.WriteLine("【配置健康检查】");
                this.CallProcModel.CheckAPIHealth =()=>this.IsHealth().Result;
            }
            ProcessHelper.CallProcessBatAPI(this.CallProcModel);
        }
        /// <summary>
        /// 退出API
        /// </summary>
        /// <param name="url"></param>
        public async virtual Task StopAPI(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // 发送GET请求  
                    HttpResponseMessage response = await client.GetAsync(url);

                    // 检查响应状态码  
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("API调用成功，可能已成功退出或关闭服务。");
                    }
                    else
                    {
                        // 如果API调用失败，则打印错误信息  
                        Console.WriteLine($"API调用失败，状态码: {response.StatusCode}");
                    }

                    // 读取响应内容（如果需要的话）  
                    // string responseBody = await response.Content.ReadAsStringAsync();  
                    // Console.WriteLine(responseBody);  
                }
            }
            catch (HttpRequestException e)
            {
                // 处理请求异常  
                // Console.WriteLine($"\n异常捕获: {e.Message}");
                Console.WriteLine($"服务进程已被Kill");
            }
        }

        /// <summary>
        /// 健康检查
        /// </summary>
        /// <returns></returns>
        public async virtual Task<bool> IsHealth()
        {
            return await base.HttpGetAsync(HealthUrl);
        }
    }
}
