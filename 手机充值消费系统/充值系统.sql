create database 充值系统
on
(
name='充值系统',
filename='d:\充值系统.mdf',
size=5,
filegrowth=1
)
log on
(
name='充值系统_log',
filename='d:\充值系统_log.ldf',
size=5,
filegrowth=1
)
use 充值系统
--管理员表
create table [Admin]
(
AdminNumber int IDentity(1000010,1) primary key,/*管理员编号*/
AdminName nvarchar(5) not null,/*管理员姓名*/
AdminIDcard  nvarchar(18) not null,/*管理员身份证号*/
AdminPwd nvarchar(18) not null /*管理员登录密码*/
)
--导入一部分数据
insert into [Admin](AdminName,AdminIDcard,AdminPwd)
select '王红','423512053135021' ,'1234'union all
select '李明','421351646153125' ,'4444'union all
select '贺州','442131313133155' ,'8888'

--用户表
create table SIM
(
SIMNumber int IDentity(1,1) ,/*用户编号*/
SIMName	nvarchar(20) not null,/*用户姓名*/
SIMIDcard	nvarchar(50) ,/*用户身份证号*/
SIMSex		nvarchar(5) not null,/*用户性别*/
SIMAge	int   not null,/*用户年龄*/
SIMNative	nvarchar(20) not null,/*用户籍贯*/
SIMFeel nvarchar(20) primary key ,/*用户手机号*/
QQ nvarchar(20) ,/*用户qq*/
SIMMail varchar(50) ,/*用户电子邮箱*/
SIMBalance Decimal(6,2)  default 0.00 ,/*用户余额*/
SIMRemarks nvarchar(200) ,/*用户备注*/
SIMState nvarchar(20) ,/*用户状态*/
SIMClock  nvarchar(100)  default 2016-01-01/*用户开户时间*/
)
--导入一部分数据
insert into SIM(SIMName,SIMIDcard,SIMSex,SIMAge,SIMNative,SIMFeel,QQ,SIMMail,SIMBalance,SIMState)
values ('何明','421665355555555555','男','24','湖北黄冈','13333333333','66666','1551645@qq.com','48.60','正常使用') 
insert into SIM(SIMName,SIMIDcard,SIMSex,SIMAge,SIMNative,SIMFeel,QQ,SIMMail,SIMBalance,SIMState)
values ('李四','427315551112121212','女','28','湖北武汉','15467557528','622456156','4411115@qq.com','20.00','正常使用') 
insert into SIM(SIMName,SIMIDcard,SIMSex,SIMAge,SIMNative,SIMFeel,QQ,SIMMail,SIMBalance,SIMState)
values( '张三','532555551555255555','男','46','河南洛阳','15334233333','15155151','253461565@qq.com','0','号码冻结' )
insert into SIM(SIMName,SIMIDcard,SIMSex,SIMAge,SIMNative,SIMFeel,QQ,SIMMail,SIMBalance,SIMState)
values( '王五','562465134561239456','男','32','湖南长沙','13822555555','223353352','451656526@qq.com','-20.3','欠费停机') 
insert into SIM(SIMName,SIMIDcard,SIMSex,SIMAge,SIMNative,SIMFeel,QQ,SIMMail,SIMBalance,SIMState)
values( '1','1','女','1','1','1','','8451854851@qq.com','1','正常使用')

--充值表
create table Recharge
(
SIMFeel nvarchar(20)  foreign key references SIM(SIMFeel),/*充值的手机号*/
RechargeMoney	Decimal(6,2) , /*充值金额*/
RechargeClock  nvarchar(100) ,/*充值时间*/
)

--消费、记录表
create table Record
(
RechargeNumber int IDentity(1,1) ,/*消费记录的编号*/
SIMFeel       nvarchar(20)  foreign key references SIM(SIMFeel),/*消费的手机号*/
RecordeClock  nvarchar(100) ,/*消费时间*/
RecordMoney   Decimal(6,2),   /*消费金额*/

RecordBeizhu  nvarchar(100), /*充值、消费的记录详情*/
RecordClock  nvarchar(100) , /*查询记录号码的开户时间*/
TianjiaRen nvarchar(100),    /*进行各种操作的添加人*/
Tianjiajine Decimal(6,2)     /*添加金额*/
)


select RecordMoney from Record where   SIMFeel ='1'
select sum(RechargeMoney) from Recharge where   SIMFeel ='1'
select sum(RecordMoney) from Record where   SIMFeel ='1'

