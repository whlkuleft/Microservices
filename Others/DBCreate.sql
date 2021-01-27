if exists(select * from sysobjects where name='Userinfo' and xtype='U')
begin
drop table Userinfo
CREATE TABLE Userinfo  (--'用户表'
  id int primary key  identity(1,1),
  username varchar(32) NOT NULL,--'用户名'
  password varchar(32)  NOT NULL,--'密码，加密存储'
  phone varchar(11),--'注册手机号'
  created datetime NOT NULL,--'创建时间'
  salt varchar(32)  NOT NULL,--'密码加密的salt值'
)
end

