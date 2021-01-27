using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;
using System;

namespace WhlServices.Common.Common
{
    /// <summary>
    /// 1、需要导入aliyun-net-sdk-core依赖
    /// 2、在阿里云配置签名+模板
    /// https://dysms.console.aliyun.com/dysms.htm?spm=5176.b60019767.ProductAndService--ali--widget-home-product-recent.dre0.525216d03rcBLN#/domestic/text/template
    /// </summary>
    public class SmsHelper
    {
        public static void SendMessage(string phoneNumber, string code)
        {
            /*
                accessKeyId: LTAI4GB4yjjrQzr7TuYEiVa6
                accessKeySecret: b5JVF50XjGU3tmxcHE5lgcHc3jyMvF
             */
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", "LTAI4GB4yjjrQzr7TuYEiVa6", "b5JVF50XjGU3tmxcHE5lgcHc3jyMvF");
            DefaultAcsClient client = new DefaultAcsClient(profile);
            CommonRequest request = new CommonRequest();
            request.Method = MethodType.POST;
            request.Domain = "dysmsapi.aliyuncs.com";
            request.Version = "2017-05-25";
            request.Action = "SendSms";
            // request.Protocol = ProtocolType.HTTP;
            request.AddQueryParameters("PhoneNumbers", phoneNumber); // 电话号码
            request.AddQueryParameters("SignName", "朝夕教育Eleven"); // 签名模板的名称
            request.AddQueryParameters("TemplateCode", "SMS_210070060"); // 验证码模板ID
            request.AddQueryParameters("TemplateParam", "{\"code\":\""+code+"\"}"); // 验证码
            try
            {
                CommonResponse response = client.GetCommonResponse(request);
                Console.WriteLine(System.Text.Encoding.Default.GetString(response.HttpResponse.Content));
            }
            catch (ServerException e)
            {
                Console.WriteLine(e);
            }
            catch (ClientException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
