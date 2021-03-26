using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace UrunKatalog.MvcWebApp.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            {
                new Category() { Name = "Bilgisayar" , Description="Bilgisayar ürünleri" },
                new Category() { Name = "Tablet" , Description="Tablet ürünleri"},
                new Category() { Name = "Telefon" , Description="Telefon ürünleri"},
                new Category() { Name = "Televizyon" , Description="Televizyon ürünleri"},
                new Category() { Name = "Küçük Ev Aletleri" , Description="Küçük Ev Aletleri ürünleri"}
            };

            foreach (var item in kategoriler)
            {
                context.Categories.Add(item);
            }

            context.SaveChanges();

            var urunler = new List<Product>()
            {
                new Product() { Name = "LENOVO Thinkpad X1 Carbon 6 20KH006FTX 4G LTE-A Notebook" , Description="izgi ve baskı endüstrisinde kuerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda " , Price = 1200, Stock = 250, isApproved=true , CategoryId = 1 , isHome= true , Image = "1.jpg" },
                new Product() { Name = "HP EliteBook 830 G5 3JX24EA Notebook" , Description="izgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda " , Price = 2000, Stock = 156, isApproved=true , CategoryId = 2 , isHome= false, Image = "camera.jpg" },
                new Product() {  Name = "Lenovo V110 15IKB 80TH0036TX Notebook" , Description="izgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda " , Price = 8000, Stock = 44, isApproved=false , CategoryId = 3 , isHome= false},
                new Product() {  Name = "Apple MacBook Pro MPXR2TU/A Retina Ekran Gümüş Notebook" , Description="izgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda " , Price = 4200, Stock = 23350, isApproved=true , CategoryId = 5 , isHome= true, Image = "5.jpg" },
                new Product() { Name = "Asus VivoBook X Series X540NA-GO067 Notebook" , Description="izgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda " , Price = 7200, Stock = 123, isApproved=false , CategoryId = 4 , isHome= true, Image = "1.jpg" },
                new Product() { Name = "Samsung UE-55NU8000 4K Ultra, aynı zamanda " , Price = 41200, Stock = 1000, isApproved=true , CategoryId = 1 , isHome= true },
                new Product() { Name = "Samsung UE-49NU8000 4K Ultra HD 49 levizyon" , Description="izgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda " , Price = 6200, Stock = 2000, isApproved=true , CategoryId =2 , isHome= false, Image = "2.jpg" },
                new Product() {  Name = "Samsung QE-75Q60R 4K Ultra HD 75 Uydu Alıcılı Smart QLED Televizyon" , Description="izgi ve baskı endüstrisinde ku adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda " , Price = 9200, Stock = 2050, isApproved=false , CategoryId = 3 , isHome= false, Image = "3.jpg" },
                new Product() {  Name = "Sony KD-55XF9005 4K Ultra HD 55 Uydu Alıcılı Smart LED Televizyon" , Description="izgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda " , Price = 3200, Stock = 2400, isApproved=true , CategoryId = 3 , isHome= true, Image = "1.jpg" },
                new Product() { Name = "Sony KD-55XF9005 4K Ultra HD 55 Uydu Alıcılı Smart LED Televizyon" , Description="izgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda " , Price = 200, Stock = 8000, isApproved=false , CategoryId = 5 , isHome= true, Image = "1.jpg" },
                new Product() { Name = "LENOVO Thinkpad X1 Carbon 6 20KH006FTX 4G LTE-A Notebook" , Description="izgi ve baskı endüstrisinde kuerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda " , Price = 1200, Stock = 250, isApproved=true , CategoryId = 1 , isHome= true , Image = "4.jpg" },
                new Product() { Name = "HP EliteBook 830 G5 3JX24EA Notebook" , Description="izgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda " , Price = 2000, Stock = 156, isApproved=true , CategoryId = 2 , isHome= false, Image = "1.jpg" },
                new Product() {  Name = "Lenovo V110 15IKB 80TH0036TX Notebook" , Description="izgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda " , Price = 8000, Stock = 44, isApproved=false , CategoryId = 3 , isHome= false, Image = "4.jpg" },
                new Product() {  Name = "Apple MacBook Pro MPXR2TU/A Retina Ekran Gümüş Notebook" , Description="izgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda " , Price = 4200, Stock = 23350, isApproved=true , CategoryId = 5 , isHome= true, Image = "4.jpg" },
                new Product() { Name = "Asus VivoBook X Series X540NA-GO067 Notebook" , Description="izgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda " , Price = 7200, Stock = 123, isApproved=false , CategoryId = 4 , isHome= true, Image = "2.jpg" },
                new Product() { Name = "Samsung UE-55NU8000 4K Ultra, aynı zamanda " , Price = 41200, Stock = 1000, isApproved=true , CategoryId = 1 , isHome= true , Image = "1.jpg" },
                new Product() { Name = "Samsung UE-49NU8000 4K Ultra HD 49 levizyon" , Description="izgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda " , Price = 6200, Stock = 2000, isApproved=true , CategoryId =2 , isHome= false, Image = "3.jpg" },
                new Product() {  Name = "Samsung QE-75Q60R 4K Ultra HD 75 Uydu Alıcılı Smart QLED Televizyon" , Description="izgi ve baskı endüstrisinde ku adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda " , Price = 9200, Stock = 2050, isApproved=false , CategoryId = 3 , isHome= false},
                new Product() {  Name = "Sony KD-55XF9005 4K Ultra HD 55 Uydu Alıcılı Smart LED Televizyon" , Description="izgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda " , Price = 3200, Stock = 2400, isApproved=true , CategoryId = 3 , isHome= true},
                new Product() { Name = "Sony KD-55XF9005 4K Ultra HD 55 Uydu Alıcılı Smart LED Televizyon" , Description="izgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda " , Price = 200, Stock = 8000, isApproved=false , CategoryId = 5 , isHome= true}
            };

            foreach (var item in urunler)
            {
                context.Products.Add(item);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}