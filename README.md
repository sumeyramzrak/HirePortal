# Hakkında
HirePortal  Personel yönetimi, performans değerlendirme, bordro ve vardiya yönetimi gibi birçok İK süreçlerini tek yazılımla yönetmeyi ve verimli hale getirmeyi amaçlar. 
# Başlangıç
Projenin 'API' katmanı ```'ASP.NetCore Web API'``` ile oluşturulmuştur. 
```'Code First' ``` anlayışı benimsenmiştir. 
Veri işlemlerinde ``` Microsoft.EntityFrameworkCore``` kütüphanesi kullanılmıştır. 
```SOLID``` prensiblerine uyulmuştur. 
Uygulamanın kullanıma hazırlanması için gereksinimler :
```
-Visual Studio 2022
```
```
-'SQL SERVER' ile bağlantılı herhangi bir Database uygulaması
```
```
-Visual Studio Code 
```
. 
# Uygulamanın Kullanımı
**API Katmanı için**:
-Repositoriden locale klonlayınız.
-```'src'``` dosyası içerisindeki ```'api'``` klasöründen ```'Hireportal.sln'``` uygulamasını çalıştırınız. 
-Açılan uygulamada api katmanında bulunan ```'Hireportal.Api'``` projesinin içerisindeki ```'appsettings.Development.json'``` ve ```'appsettings.json'``` dosyalarında yazılı olan server bağlantı kodunu kendi ```'SQL SERVER'``` bağlantınıza göre ayarlayınız.
```("Server=localhost,[port bilgisi];Database=HireportalDb;User Id=[kullanıcı Id];Password=[şifre]")```
	
- ```'data/Hireportal.Data.Seed'``` içerisinde kullanılmak üzere seed veriler hazırlanmıştır.
-Migration dosyası projenin içerisinde hazır olduğundan dolayı gerekli verileri database aktarmak için ```'_docs/Migration.txt'``` içerisindeki 
```
"Update-Database -P Hireportal.Data -Context HireportalDbContext -S Hireportal.Api"
```
komut kopyalanıp ```"Package Manager Console" ```bölümünde çalıştırılmalıdır. 
-Update-Database komutu çalıştırıldıktan sonra API katmanı ve database hazır olacaktır. 
```
-Örnek kullanıcı mailleri :"admin@thireportal.com",şifre "123."
```
-Bu adımları tamamladıktan sonra uygulamayı üst sekmede bulunan yeşil ok simgeli Run butonu ile çalıştırınız. 
-'API' browser **açmadan** çalışmaya başlayacaktır