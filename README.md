# BOYZ-Unity-Labirent-Projesi
Bilgisayar Oyunlarda Yapay Zeka Dersinin Ödev 10

# PROJE HAKKINDA GENEL BILGI

A Algoritmasının Temelleri

A* algoritması, en kısa yolu bulmak için kullanılan sezgisel bir arama algoritmasıdır. Toplam maliyet fonksiyonu f(n)=g(n)+h(n)f(n) = g(n) + h(n)f(n)=g(n)+h(n) şu şekilde tanımlanır:

•	g(n)g(n)g(n): Başlangıç noktasından mevcut düğüme kadar olan maliyet.

•	h(n)h(n)h(n): Mevcut düğümden hedefe tahmini maliyet (heuristik).

A* algoritması, hem kesinlikle doğru hem de verimli bir sonuç sunmak için kullanılan güçlü bir tekniktir.

Projenin Hedefleri

•	Rastgele bir labirent oluşturmak.

•	A* algoritmasını kullanarak labirentin başlangıç ve hedef noktası arasında bir yol bulmak.

•	Süreci ve algoritmanın çalışma adımlarını görselleştirmek.

# GEREKLI KURULUM VE AYARLAR

Unity Projesinin Oluşturulması

•	Unity'de yeni bir 3D proje oluşturun.

•	Proje klasörünüzde Assets altında yeni bir klasör oluşturun ve ismini LabirentProjesi olarak belirleyin.

Başlangıç Paketi Entegrasyonu

•	Verilen AStarStarter paketini projenize dahil edin.

•	Scenes klasöründen AStarPath sahnesini açın.

•	Play butonuna basarak labirentin rastgele oluşturulduğunu doğrulayın.

Not: Unity versiyonunuzun en az 2020.3 LTS veya daha yeni bir sürüm olmasına dikkat edin.

# KOD VE UYGULAMA ADIMLARI

FindPathAStar Script’inin Oluşturulması

Projenin temel bileşenlerinden biri olan FindPathAStar script’i, A* algoritmasının uygulanmasını sağlar. Bu script içinde:

•	Açık ve Kapalı Listeler: Açık liste, değerlendirilecek düğümleri; kapalı liste ise değerlendirilmiş düğümleri tutar.

•	Başlangıç ve Hedef Tanımı: Başlangıç ve hedef noktaları rastgele seçilir.

•	Yol Bulma Fonksiyonu: Algoritmanın her adımda en düşük maliyetli düğümü seçerek ilerlemesi sağlanır.

PathMarker Sınıfının Tanımı

PathMarker sınıfı, bir düğümün konumu, maliyet bilgileri (G, H, F), görsel temsilcisi ve ebeveyn düğüm bilgilerini içerir. Bu sınıf, algoritmanın yol takibini kolaylaştırır.

Arama Fonksiyonlarının Implementasyonu

BeginSearch fonksiyonu:

•	Başlangıç ve hedef noktalarını rastgele seçer.

•	Açık ve kapalı listeleri temizler.

Search fonksiyonu:

•	Açık listedeki en düşük maliyetli düğümü seçerek komşu düğümleri değerlendirir.

•	Hedef düğüm bulunduğunda aramayı durdurur.

GetPath fonksiyonu:

•	Son düğümden başlangıç düğümüne doğru ebeveyn bağlantıları takip ederek yolu işaretler.

# TEST VE ÇALISTIRMA

Labirent Oluşturulması

•	Sahnedeki Maze nesnesini seçin.

•	Recursive script’i altında width ve depth değerlerini 10 olarak ayarlayın.

•	Play butonuna basarak rastgele bir labirent oluşturun.

Başlangıç ve Hedef Noktalarının Seçimi

•	P tuşuna basarak başlangıç ve hedef noktalarını oluşturun.

•	Seçilen noktaların görsel olarak işaretlendiğini doğrulayın.

A Algoritmasının Çalıştırılması

•	C tuşuna basarak algoritmayı adım adım çalıştırın.

•	Hedefe ulaşıldığında, M tuşuna basarak bulunan yolu görselleştirin.

# SONUÇ VE ÇALISTIRILMIS HALI

Algoritmanın İşleyişi

Bu proje, A* algoritmasının etkinliğini ve doğruluğunu başarıyla sergiler. Rastgele oluşturulan her labirentte, başlangıç ve hedef noktaları arasındaki en kısa yol etkin bir şekilde bulunur.

Projenin öne çıkan noktaları şunlardır:

•	Hızlı Arama: A* algoritması, minimum maliyetli yolu seçerek hedefe ulaşmayı en kısa sürede tamamlar.

•	Görselleştirme: Yol bulma sürecindeki aşamalar, açık ve kapalı listelerdeki renkli görsel işaretçiler ile net bir şekilde sunulmuştur.

•	Dinamik Labirentler: Algoritmanın rastgele oluşan her labirentte başarıyla çalışması, esnekliğini kanıtlar.

![Ekran görüntüsü 2025-01-05 032757](https://github.com/user-attachments/assets/32e9f451-0217-44a8-aade-9be9f1a340ec)

![Ekran görüntüsü 2025-01-05 034142](https://github.com/user-attachments/assets/c8dfc264-7bfe-4a76-8e90-0d0d4feada04)

![Ekran görüntüsü 2025-01-05 041250](https://github.com/user-attachments/assets/73e02b20-2e46-4493-8b47-6572466af83c)

![Ekran görüntüsü 2025-01-05 042404](https://github.com/user-attachments/assets/a4f24543-e220-47f4-bd3a-6600242aef8d)

![Ekran görüntüsü 2025-01-05 042613](https://github.com/user-attachments/assets/22ebbe2a-37ab-465c-8139-f01a798196ce)

![Ekran görüntüsü 2025-01-05 042943](https://github.com/user-attachments/assets/2739fca8-8fe7-44d6-bb39-6e50d5a5f263)

![Ekran görüntüsü 2025-01-05 043003](https://github.com/user-attachments/assets/b4f9174c-c743-4288-a633-ad2c62c67a54)

![Ekran görüntüsü 2025-01-05 043030](https://github.com/user-attachments/assets/94ddfb28-0d59-4564-a69b-e79f932c96af)


