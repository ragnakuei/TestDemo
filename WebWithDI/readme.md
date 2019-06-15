## Web API 2

- [Web API Controller 是怎樣建成的](https://huanlintalk.netlify.com/post/2014-08-01-how-does-web-api-create-controllers/)
- [ASP.NET Web API 2 的 Dependency Resolver](https://huanlintalk.netlify.com/post/2014-08-01-aspnet-web-api-2-dependency-resolver/)


## Autofac
- DI Framework


[設定檔 Sample](./AutofacConfig.cs)

常用 生命週期
```
InstancePerDependency  每次呼叫都會建立一個 instance (預設)
InstancePerRequest     一個 Request 只會建立一個 instance
SingleInstance         每次都呼叫同一個 instance
```

##### 參考資料
  - [官方文件](https://autofaccn.readthedocs.io/en/latest/getting-started/index.html)
  - [Autofac 基本介紹](https://ithelp.ithome.com.tw/articles/10156684)
  - [淺談 Autofac 架構](https://dotblogs.com.tw/aken1215/2016/10/30/115651)
  - [.NET 依赖注入 (電子書)](https://leanpub.com/dinet-s) 

##### [Back](../readme.md)