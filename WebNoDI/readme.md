目前的情況
> [OrgRecordBL](./BL/OrgRecordBL.cs) 需要使用其他 class 的 method 時，就在 class 內部直接產生 instance，導致無法讓測試程式把假資料物件提供給被 OrgRecordBL 使用，所以無法對 OrgRecordBL 進行測試。 

[控制反轉 IoC (Inversion of Control)](https://www.huanlintalk.com/2011/10/dependency-injection-1.html)
> 當你自己去開冰箱拿東西時，很可能會闖禍。你可能忘了關冰箱門、可能會拿了爸媽不想讓你碰的東西，甚至冰箱裡根本沒有你想要找的食物，又或者它們早已過了保存期限。
  你應該把自己需要的東西說出來就好，例如：「我想要一些可以搭配午餐的飲料。」然後，當你坐下用餐時，我們會準備好這些東西。

IoC 優點
- 方便加上隔離測試 
- 軟體演化有更好的靈活性，能快速響應需求變化，維護代價更小
 

[PaRecordBL](./BL/PaRecordBL.cs) 以 IoC 的方式處理後
> 測試程式就可以把假資料物件提供給 PaRecordBL 進行測試。但是，會造成 [PaRecordController](./Controllers/PaRecordController.cs) 會呼叫了未使用到的 class ( DAO )。此時可以使用 DI Framework 來改善這個情況。

##### [Back](../readme.md)