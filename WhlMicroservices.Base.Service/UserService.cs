using System;
using System.Linq;
using WhlMicroservices.Base.Interface;
using WhlMicroservices.Base.Model;
using WhlServices.Common.Common;

namespace WhlMicroservices.Base.Service
{
    public class UserService : IUserService
	{
		private WhlMicroservicesDBContext _dbContext;
		private CacheClientDB _cacheClientDB;
		public UserService(WhlMicroservicesDBContext dbContext, CacheClientDB cacheClientDB)
		{
			_dbContext = dbContext;
			_cacheClientDB = cacheClientDB;
		}
		private static readonly string KEY_PREFIX = "user:verify:code:";
		public bool CheckData(string data, int type)
		{
			Userinfo user = new Userinfo();
			//判断校验数据的类型
			switch (type)
			{
				case 1:
					user.Username = data;
					break;
				case 2:
					user.Phone = data;
					break;
				default:
					throw new Exception("参数不合法，校验未通过");
			}
			var list = _dbContext.Userinfos.AsQueryable();
			if (!string.IsNullOrWhiteSpace(user.Username))
			{
				list = list.Where(m => m.Username == user.Username);
			}
			if (!string.IsNullOrWhiteSpace(user.Phone))
			{
				list = list.Where(m => m.Username == user.Phone);
			}
			return (list.Count() == 0);
		}

		public Userinfo QueryUser(string username, string password)
		{

			//首先根据用户名查询用户
			Userinfo user = _dbContext.Userinfos.Where(m => m.Username == username).FirstOrDefault();

			if (user == null)
			{
				throw new Exception("查询的用户不存在！");
			}

			if (PasswordHelper.MD5Encoding(password, user.Salt) != user.Password)
			{
				//密码不正确
				throw new Exception("密码错误");
			}


			return user;
		}
		public void Register(Userinfo user, string code)
		{
			string key = KEY_PREFIX + user.Phone;
            string value = _cacheClientDB.Get<string>(key);
            if (!code.Equals(value))
            {
                //验证码不匹配
                throw new Exception("验证码不匹配");
            }
			user.Salt = PasswordHelper.MD5EncodingWithoutSalt(user.Username);

			////生成盐
			//String salt = CodecUtils.generateSalt();
			//user.setSalt(salt);
			////生成密码
			string md5Pwd = PasswordHelper.MD5Encoding(user.Password, user.Salt);
			user.Password = md5Pwd;
			////保存到数据库
			//int count = userMapper.insert(user);
			_dbContext.Add(user);
			int count = _dbContext.SaveChanges();
			if (count != 1)
			{
				throw new Exception("用户注册失败");
			}
			////把验证码从Redis中删除
			//redisTemplate.delete(key);
		}

		/// <summary>
		/// 发送验证码方法
		/// </summary>
		/// <param name="phone"></param>
		public void SendVerifyCode(string phone)
		{
			// 生成随机6位数字验证码
			Random random = new Random();
			string code = random.Next(100000, 999999).ToString();
			// 把验证码存储到redis中
			string key = KEY_PREFIX + phone;
			_cacheClientDB.Set(key, code,TimeSpan.FromMinutes(5));
			// 调用发送短信的方法
			SmsHelper.SendMessage(phone, code);
		}
	}
}
