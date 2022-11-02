# Movie Store Uygulaması
Bu uygulamada kullanıcılar siteye kayıt olup filmler alabilmektelerdir.Film ekleme işlerini ise sadece Admin olarak atanan user'lar yapabilirler.

## Neden bu projeyi yapıyorum/yaptım ?
Bugün gün olarak 27/10/2022 tarihinde gece vaktinde ilk commiti atıyorum. Yaklaşık 7 aylık yoğun bir eğitimden çıktım. Aktif olarak stajdayım arta kalan vakitlerimde bu projeyi geliştirmeyi ve şimdilik deadline 14/11/2022 olmasını planlıyorum( Umarım bir aksaklık olmaz :)). Amacım aslında burada günlük tutarak karşılaştığım önemli sorunları dile getirmek ve nasıl bir çözüm yolu izlediğimi paylaşmak olacak. Merak etmeyin burada tamamıyla dürüst olacağım.

### Kullanılacak Yaklaşım ve Teknolojiler
- Proje katmanlı mimari ile hazırlanacak 
- Onion Architecture
- Database tarafında InMemory, ORM olarak EntityFrameworkCore
- Backend .NetCore 5 
- FrontEnd tarafında Html,Css ve JavaScript
### Projede hedeflenen kazanım ve pratikler
- Jwt token altyapısı ile kullanıcı Authentication işlemlerinin kurgulanması ve kontrolü
- InMemoryCache kurulumu ve uygulanması
- UnitTest yazımı
- Custom Middleware yazımı ve kullanılması
- Frontend tarafında session veya cookie ile kullanıcı hatırlanılması
- Onion Architecture bu proje ile öğrenmeyi amaçlıyorum. Bu design pattern ile ilk projem :)

---

## Gün 1
* Proje katmanları oluşturuldu
* Kullanılacak Entity'ler oluşturuldu

## Gün 2
* Geleneksel katmanlı mimariden vazgeçerek, projeyi Onion Architecture'a çevirdim. 
* Entitylerde değişikliğe gittim
* InMemory yapısını kurmaya çalışırken Entity Configlerim olmadan başladığım için o kısmı yarıda bırakıp Entity Configlerine yöneldim.

## Gün 3
* Onion Architecture mantığını anlamada biraz zorlandım açıkcası. Bana ana katman tamamıyla Persistance gibi geliyor çünkü repository ve servislerimin concrete nesnelerini orada oluşturuyoruz. Sanırım daha fazla makale okumam gerek
* Architecture uygulamak açıkcası çok fazla canımı sıktı sürekli yeni klasör yeni sınıf cod yazmaya her ne kadar taakatim kalmasa da Customer oluşturmayı sağlıklı bir şekilde bitirdim.
* Validasyonlar için FluentValidation , Mapleme işlemleri için AutoMapper kütüphanelerini ekledim.
* Genel olarak bugün code'lamamı daha hızlı yapabilmek için kütüphaneleri ve servislerimi entegre ettim diyebilirim.

## Gün 4
* Genre service işlemlerini yazdım
* Şu zamana kadar ben yazdığın kodları ViewModel klasörümü business layer iinde tutuyordum. Bu projede Presentation katmanında tutma kararını aldım. Bence daha geliştirilebilir oldu diyebilirim.

## Gün 5
* Custom exception Middleware yapısı projeme entegre ettim. Hata mesajları konsola veya  kullanıcıya nasıl gösterilmeli kararını halen daha vermiş değilim. Şuanda string olarak birleştirdiğim hataları json'a çevirip gönderiyorum. Sanırım ilerleyen günlerde  refactor yapmam gerekecek.
