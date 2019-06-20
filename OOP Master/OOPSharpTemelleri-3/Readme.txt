	----Ders 1

	/Operasyonlar Veri Ýletiþim Katmanýndadýr. Class library Class'larý içerisinde barýndýran Kütüphane, Dll Dosyasý ==> 
    //Bütün Platformalrýn (Web, Mobil, Destkop) == Veri Ýletiþim Katmanýna Yazýrlýr.

    //Bir Kural Getirerek Örneðin Ürünleri Listeleyecek ama þu birimde Çalýþýyor ise Listeyebilir. Yani Ýnsan kaynaklarý Ürünleri Listeleyemesin
    //Ama Üretim Birimi Ürünleri listeyebilsin. Burada Bizim Süreçlerimiz ile ilgili kodlar oluþuyor bunada iþ katmaný deniliyor.

    //Temel Olarak Üç Katman Vardýr.
    //Arayüz Katmaný        ==> Textbox'lar, Label'lar, Gridler vs.
    //Ýþ Katmaný Katmaný    ==> Ýþ Katmaný bizim iþ kurallarýmýzý içerir. Örneðin Ýnsan Kaynaklarý Data'lara Eriþebilsin ama diðerleri eriþemessin gibi.
    //Veri Ýletiþim Katmaný ==> Veriyi listelediðimiz yerdir. Yani Veritabanýna kodu gönderdiðimiz yerdir.

    //Üsteki katmanlar temel 3 katmanlý mimarilerdir.


    //Zamanla araya Servis odaklý mimariler geldiðinde, aralara bu katmanlarda koyulabildiði için, Artýk o 3 katmanlý mimari çok katmanlý mimari 
    //yani nLayer application ==! Çok katmanlý mimariler denir.
    //Arayüz katmaný == Müþteri Listeler Görüntüler, Bilgileri Alýr vs.
    //Ýþ Katmaný Müþterinin == o kurala uyup uymadýðýný kontrol eder.
    //Veri Ýletiþim Katmaný == Data access ise veritabanýna müþteri kayýt eder, Siler yada günceller.





	----Ders 2 
	//Boþ bir solotion açýlýr. Ders ==£ 122
	//Class Library (.Net Framework)

	//Bir Arayüz Katmaný, Bir Varlýk Katmaný, Bir Ýþ Katmaný, Bir VeriÝletiþim Katmaný
	//Proje Ýsmi (Northwind.Entites) Þeklinde Olmalý.  ===Proje Ýsmi.Katman ismi=== (Pascal Case)

	//ProductDal == Dal ==> Data Access Layer

	//DataAccess Katmanýnda Entity Framework Eklemek Ýçin "Northwind.DataAccess" Üzerine Sað Týklayýp "Manage Nuget Packages" Ýçersinden "Browse" Sekmesinden EntityFrameWork'den Seçmemiz Gerekir.
	//Sonra Altýndan Using Diyerek Kod Ýçerinde Tanýmlanmasý yapýlýr.
	//Sonrasýnda Northwind.WebFormsUI Üzerinde Add diyip Sonrasýnda Referans bölümünden Project Ýçerisinde Enties'i Eklememiz Gerekir.

	----Ders 3
	//Yazýlý Geliþtirme Süreçleri Solid Prensibindeki O Harfi ==> Open Closed Principle ==! Bir uygulamaya yeni bir özellik eklendiðinde Mevcutta olan kodlara dokunulmaz, Conmfigrasyon hariç.
	//Yazýlý Geliþtirme Süreçleri Solid Prensibindeki D Harfi ==> Bir Katman Diðer Katmaný New'leyemez yani instance üretemez. Baðýmlý olursunuz, Ve Baðýmlýlýðý ortadan kaldýrýn demek istiyor.
	//Code Smell Refactoring Ýþlemi kodlarýn düzenlenmesi anlamýna gelir.

	----Ders 4
	//Dependency Containe == Form1'de Newleme Yapmayýz

	----Ders 5
	//129. Dersi Muhakkak bir daha izle


	----Ders 6
	//Category Göre Search Etme
	//Entities ==> Concrete ==>> Category.cs : IEntity Ýmplemente Etmeyi Unutma .... Generic Kýsýtlamalar Ýçin Gereklidir.
	//Entities ==> Concrete ==>> Category.cs Veritabanýna Karþýlýk Gelecek Sutunlarý Eklemeyi Unutma
	//DataAccess ==> Abstract ==> ICategoryDal.cs : IEntityRepository Imlemente Edilecek
	//DataAccess ==> Concrete ==> EntityFramework ==> NorthwindContext.cs >>>>>>>>>>Public DBSet<Category> Categories {get; set;} Entity Framework Mapping Ýþlemi
	//DataAccess ==> Concrete ==> EntityFramework  ==> EfCategoryDal.cs : EfEntityRepositoryBase yada Ýnherit Edilecek
	/*************Ýnterface'ler Ýmplementasyon , Abstract Class'lar Ýnherit(Ýnheritasyon) Edilir.*************/
	//Business ==> Abstract ==> ICategoryServices.cs (interface) >>>>>>>>> Ýþ Katmaný Operasyonunu Tanýmla
	//Business ==> Concrete ==> ICategoryManager.cs : ICategoryService Ýmplemente Et
	//Business ==> Concrete ==> ICategoryManager.cs : Constructors'den ICategoryDal Field'ýný Referans Ver.


	----Ders 7
	//Defansing Programing == Null Deðerli kontrolü
	//Fori key hatasý == bakýlacak
	//Business Katmanýna Entity FrameWork Eklenmez SAdece Kod Bütünliði için Ekledik...
	//Hata Yönetimi sadece Arayüzde göstermek için kullanýlýr.
	//Kurunmsal Mimarilerde Hata Yönetimi Business Katmanýna Yazýlýr. == Sadece Göstermek için arayüze koyulur.
	//Bu prensip Solid'den Gelir.

	----Ders 8 
	//Validation
	//Arayüz katmanýnda input giriþlerine sýnýrlamalar koyma iþlemine validation denir. Ýþ katmanýna yazýlýr. Örneðin Ýsminin 10 harfli olucak gibi.
	//Kurallar ==> fluentValidation aracý ile yapýlýr.
	//Business katmanýna bu kurallar yazýlýr.
	//Ctor Constructor ifade eder // Tab Tab :) == (Visual Studio Snippet) diye bir kavramdýr.
	//Fluent Validation için Fluent Validation Dökümantasyonuna Bakýlacak



	
