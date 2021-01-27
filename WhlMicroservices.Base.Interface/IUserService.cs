using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhlMicroservices.Base.Model;

namespace WhlMicroservices.Base.Interface
{
	public interface IUserService
	{
		/**
        * 校验用户对象数据类型
        * @param data
        * @param type
        * @return
        */
		bool CheckData(string data, int type);

		/**
         * 发送验证码
         * @param phone
         */
		void SendVerifyCode(string phone);

		/**
         * 用户注册
         * @param user
         * @param code
         */
		void Register(Userinfo user, string code);

        /**
         * 根据账号和密码查询用户信息
         * @param username
         * @param password
         * @return
         */
        Userinfo QueryUser(string username, string password);
	}
}
