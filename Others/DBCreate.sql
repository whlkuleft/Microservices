if exists(select * from sysobjects where name='Userinfo' and xtype='U')
begin
drop table Userinfo
CREATE TABLE Userinfo  (--'�û���'
  id int primary key  identity(1,1),
  username varchar(32) NOT NULL,--'�û���'
  password varchar(32)  NOT NULL,--'���룬���ܴ洢'
  phone varchar(11),--'ע���ֻ���'
  created datetime NOT NULL,--'����ʱ��'
  salt varchar(32)  NOT NULL,--'������ܵ�saltֵ'
)
end

