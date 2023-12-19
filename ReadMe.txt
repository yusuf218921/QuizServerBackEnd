BackEnd Kısmında Değiştirilecek Kısımlar: 

Sql Bağlantı stringi -> Sql bağlantısını kendi PC'nizdeki veritabanı için ayrıca düzenleyin (Parola, DB adı, Sql Server Adı vb)

LocalHost -> Bu Backend Localhost:3000 ile api bağlantısı kurmaktadır. sadece localhost:3000 den gelen isteklere cevap verir. 
Frontendiniz hangi portta çalışıyorsa ona göre düzenlenmesi lazım. WebApi kısmında Program.cs sınıfında builder.services.addCors kısmında
düzeltilebilir

BackEndi Çalıştırma -> Backendi çalıştırmak için StartUp project olarak Web Api seçilmeli ve IIS Express olarak çalıştırılmalı, İstekler 
localhost:29722 portuna atılmaktadır farklı portta çalışması durumunda frontend ile düzgün bağlantı kurulumaz WebApi kısmında Properties 
dosyasının içinde launchSettings.json dosyasında application URL kısımlarında "http://localhost:29722" yazdığından emin olun