# ShowTimeCodeCSharpWebapi
# 项目介绍
开发框架Asp.net6 webapi，<br/>
<br/>
<b>B站全程Codeing过程链接</b><a href="https://www.bilibili.com/video/BV1ib4y1e7Yd?spm_id_from=333.999.0.0">GO </a>，<br/>
<br/>
对应前端Git地址<a href="https://github.com/FuGuangzhi1/showtimecodeweb">前端</a>
# 项目运行(需要安装.net6SDK)
![image](https://user-images.githubusercontent.com/87634542/163017947-3f1258c9-e1d0-4739-b186-6d5303185d8d.png)
配置数据库连接字符串<br/>
在appsettings.json文件里面更换打码处字符串即可<br/>
字符串例子"Data Source=127.0.0.1;Initial Catalog=StudyWebApi;User ID=sa;password=？？？？？;" <br/>
这里的StudyWebApi就是即将生成的数据库名字 127.0.0.1是地址 ID后面是账号 ？？换成密码<br/>
换成需要连接的数据库的注意项目默认配置支持的数据库是Sqlsever同样更改配置文件可换成MYSql，其他关系数据库暂时没有写支持<br/>
接着启动项目，调用api，上面是创建数据库，下面是删除<br/>
![image](https://user-images.githubusercontent.com/87634542/160977918-fbd0a413-a7ad-4b6c-bc21-71f412700e46.png)
 
![image](https://user-images.githubusercontent.com/87634542/160977027-df0a43c7-d5d5-4058-b253-9bce2455baed.png)
# 项目分层介绍
1.Api入口 <br/>
2.业务逻辑层写业务的抽象和实现 <br/>
3.数据库管理层 ORM框架数据库的配置 <br/>
4.实体层 领域模型 视图模型 DTo <br/>
5.工具层 一些功能方法 公共配置等 <br/>
6.测试 听名知意 <br/>
遵循上层可以调用下层而且可以隔层 下层不可以调用下层 类似于“经典四层” <br/>
# 状态
项目持续更新，优化中....
# 给孩子一个小星星![T_ZKW6KJ_X{% %P_AY$`( X](https://user-images.githubusercontent.com/87634542/160980828-5dd6691b-db15-4152-9916-8acd2c4cf324.png)

乞讨一下说不定就有了，右上角的星星![T_ZKW6KJ_X{% %P_AY$`( X](https://user-images.githubusercontent.com/87634542/160980815-b0cb4003-41e0-4b8b-8d50-6dbe07e9ce85.png)
![T_ZKW6KJ_X{% %P_AY$`( X](https://user-images.githubusercontent.com/87634542/160980816-8e0042f5-3115-463c-8580-c4a22a1df18f.png)
![T_ZKW6KJ_X{% %P_AY$`( X](https://user-images.githubusercontent.com/87634542/160980817-a17fd390-e031-4dff-a907-26b5634545ed.png)
