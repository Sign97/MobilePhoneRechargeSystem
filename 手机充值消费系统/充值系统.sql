create database ��ֵϵͳ
on
(
name='��ֵϵͳ',
filename='d:\��ֵϵͳ.mdf',
size=5,
filegrowth=1
)
log on
(
name='��ֵϵͳ_log',
filename='d:\��ֵϵͳ_log.ldf',
size=5,
filegrowth=1
)
use ��ֵϵͳ
--����Ա��
create table [Admin]
(
AdminNumber int IDentity(1000010,1) primary key,/*����Ա���*/
AdminName nvarchar(5) not null,/*����Ա����*/
AdminIDcard  nvarchar(18) not null,/*����Ա���֤��*/
AdminPwd nvarchar(18) not null /*����Ա��¼����*/
)
--����һ��������
insert into [Admin](AdminName,AdminIDcard,AdminPwd)
select '����','423512053135021' ,'1234'union all
select '����','421351646153125' ,'4444'union all
select '����','442131313133155' ,'8888'

--�û���
create table SIM
(
SIMNumber int IDentity(1,1) ,/*�û����*/
SIMName	nvarchar(20) not null,/*�û�����*/
SIMIDcard	nvarchar(50) ,/*�û����֤��*/
SIMSex		nvarchar(5) not null,/*�û��Ա�*/
SIMAge	int   not null,/*�û�����*/
SIMNative	nvarchar(20) not null,/*�û�����*/
SIMFeel nvarchar(20) primary key ,/*�û��ֻ���*/
QQ nvarchar(20) ,/*�û�qq*/
SIMMail varchar(50) ,/*�û���������*/
SIMBalance Decimal(6,2)  default 0.00 ,/*�û����*/
SIMRemarks nvarchar(200) ,/*�û���ע*/
SIMState nvarchar(20) ,/*�û�״̬*/
SIMClock  nvarchar(100)  default 2016-01-01/*�û�����ʱ��*/
)
--����һ��������
insert into SIM(SIMName,SIMIDcard,SIMSex,SIMAge,SIMNative,SIMFeel,QQ,SIMMail,SIMBalance,SIMState)
values ('����','421665355555555555','��','24','�����Ƹ�','13333333333','66666','1551645@qq.com','48.60','����ʹ��') 
insert into SIM(SIMName,SIMIDcard,SIMSex,SIMAge,SIMNative,SIMFeel,QQ,SIMMail,SIMBalance,SIMState)
values ('����','427315551112121212','Ů','28','�����人','15467557528','622456156','4411115@qq.com','20.00','����ʹ��') 
insert into SIM(SIMName,SIMIDcard,SIMSex,SIMAge,SIMNative,SIMFeel,QQ,SIMMail,SIMBalance,SIMState)
values( '����','532555551555255555','��','46','��������','15334233333','15155151','253461565@qq.com','0','���붳��' )
insert into SIM(SIMName,SIMIDcard,SIMSex,SIMAge,SIMNative,SIMFeel,QQ,SIMMail,SIMBalance,SIMState)
values( '����','562465134561239456','��','32','���ϳ�ɳ','13822555555','223353352','451656526@qq.com','-20.3','Ƿ��ͣ��') 
insert into SIM(SIMName,SIMIDcard,SIMSex,SIMAge,SIMNative,SIMFeel,QQ,SIMMail,SIMBalance,SIMState)
values( '1','1','Ů','1','1','1','','8451854851@qq.com','1','����ʹ��')

--��ֵ��
create table Recharge
(
SIMFeel nvarchar(20)  foreign key references SIM(SIMFeel),/*��ֵ���ֻ���*/
RechargeMoney	Decimal(6,2) , /*��ֵ���*/
RechargeClock  nvarchar(100) ,/*��ֵʱ��*/
)

--���ѡ���¼��
create table Record
(
RechargeNumber int IDentity(1,1) ,/*���Ѽ�¼�ı��*/
SIMFeel       nvarchar(20)  foreign key references SIM(SIMFeel),/*���ѵ��ֻ���*/
RecordeClock  nvarchar(100) ,/*����ʱ��*/
RecordMoney   Decimal(6,2),   /*���ѽ��*/

RecordBeizhu  nvarchar(100), /*��ֵ�����ѵļ�¼����*/
RecordClock  nvarchar(100) , /*��ѯ��¼����Ŀ���ʱ��*/
TianjiaRen nvarchar(100),    /*���и��ֲ����������*/
Tianjiajine Decimal(6,2)     /*��ӽ��*/
)


select RecordMoney from Record where   SIMFeel ='1'
select sum(RechargeMoney) from Recharge where   SIMFeel ='1'
select sum(RecordMoney) from Record where   SIMFeel ='1'

