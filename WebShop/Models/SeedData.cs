using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebShop.Data;
using System;
using System.Linq;
using System.Collections.Generic;

namespace WebShop.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Webshopdbcontext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Webshopdbcontext>>()))
            {
                int fl = 1;
                if (context.Customer.Any())
                {
                    fl = 0;   // DB has been seeded
                }
                if(fl == 1){
                    context.Customer.AddRange(
                        new Customer{
                            UserName="skyrose",
                            PassWord="4297f44b13955235245b2497399d7a93",
                            FirstName="tinhtinh",
                            LastName="tinhphan",
                            Phone="0973092631",
                            Email="tinhphan31199@gmail.com",
                            Address="119/38 Dạ nam",
                            Birthdate=Convert.ToDateTime("1999-03-11 00:00:00.0000000"),
                            Gender="Male",
                            JoinDate= Convert.ToDateTime("2020-12-05 18:28:12.5416978"),
                            isNew=true,
                            status="Block"
                        }
                    );
                    context.SaveChanges();
                }
                fl = 1;
                //taxonomy
                if (context.Type.Any())
                {
                    fl = 0;   // DB has been seeded
                }
                if(fl == 1){
                    context.Type.AddRange(
                        new Type{                         
                            TypeName = "Điện thoại"
                        },
                        new Type{         
                            TypeName = "Laptop"
                        },
                        new Type{   
                            TypeName = "Tablet"
                        },
                        new Type{                     
                            TypeName = "Phụ kiện"
                        }
                    ); 
                    context.SaveChanges();
                }
                
                fl = 1;
                //category 
                if (context.Category.Any())
                {
                    fl = 0;   // DB has been seeded
                }
                if(fl == 1){
                    context.Category.AddRange(
                        //dienthoai
                        new Category{
                            CategoryName = "Iphone",
                            Type_Id= 1
                            
                        },
                        new Category{
                            CategoryName = "Samsung",
                            Type_Id= 1
                            
                        },
                        new Category{
                            CategoryName = "Oppo",
                            Type_Id= 1
                            
                        },
                        new Category{
                            CategoryName = "Xiaomi",
                            Type_Id= 1
                        },
                        //laptop
                        new Category{
                            CategoryName = "Macbook",
                            Type_Id= 2
                        },
                        new Category{
                            CategoryName = "ASUS",
                            Type_Id= 2
                        },
                        //tablet
                        new Category{                         
                            CategoryName = "IPad",
                            Type_Id= 3
                        },
                        new Category{
                            CategoryName = "Samsung",
                            Type_Id= 3
                        },
                        //phukien
                        new Category{
                            CategoryName = "Pin",
                            Type_Id= 4
                        },
                        new Category{
                            CategoryName = "Sạc",
                            Type_Id= 4
                        },
                        new Category{
                            CategoryName = "Tai nghe",
                            Type_Id= 4
                        },
                        new Category{
                            CategoryName = "USB",
                            Type_Id= 4
                        }
                    );  
                     context.SaveChanges(); 
                }  
               
                fl = 1;
                // Look for any.
                if (context.Product.Any())
                {
                    fl = 0;   // DB has been seeded
                }
                if(fl == 1){
                    context.Product.AddRange(
                        //iphone
                        new Product
                        {
                            Productname = "iPhone 11 64GB (Hộp mới)",
                            Category_ID = 4,
                            Amount = 100,
                            Price = 19990000,
                            Detail= "Màn hình: 6.1', Liquid Retina,Chip: Apple A13 Bionic 6 nhân,RAM: 4 GB, Bộ nhớ trong: 64 GB,Camera sau: 2 camera 12 MP",
                            Image = "iPhone 11 64GB (Hộp mới).jpg"
                        },
                        new Product
                        {
                            Productname = "iPhone 12 Pro Max 512GB",
                            Category_ID = 4,
                            Amount = 100,
                            Price = 43990000,
                            Detail="Màn hình: 6.7', Super Retina XDR,Chip: Apple A14 Bionic 6 nhân,Camera sau: 3 camera 12 MP,Camera trước: 12 MP",
                            Image = "iPhone 12 Pro Max 512GB.jpg"
                        },
                        new Product
                        {
                            Productname = "iPhone 12 Pro 512GB",
                            Category_ID = 4,
                            Amount = 100,
                            Price = 40990000,
                            Detail= "Màn hình: 6.1', Super Retina XDR,Chip: Apple A14 Bionic 6 nhân,RAM: 6 GB, Bộ nhớ trong: 512 GB,Camera sau: 3 camera 12 MP,Camera trước: 12 MP",
                            Image = "iPhone 12 Pro 512GB.jpg"
                        },
                        new Product
                        {
                            Productname = "iPhone 12 Pro Max 256GB",
                            Category_ID = 4,
                            Amount = 100,
                            Price = 37990000,
                            Detail= "Màn hình: 6.7', Super Retina XDR,Chip: Apple A14 Bionic 6 nhân,RAM: 6 GB, Bộ nhớ trong: 256 GB,Camera sau: 3 camera 12 MP,Camera trước: 12 MP",
                            Image = "iPhone 12 Pro Max 256GB.jpg"
                        }, 
                        new Product
                        {
                            Productname = "iPhone 11 Pro Max 512GB",
                            Category_ID = 4,
                            Amount = 100,
                            Price = 37990000,
                            Detail= "Màn hình: 6.5', Super Retina XDR,Chip: Apple A13 Bionic 6 nhân,RAM: 4 GB, Bộ nhớ trong: 512 GB,Camera sau: 3 camera 12 MP,Camera trước: 12 MP",
                            Image = "iPhone 11 Pro Max 512GB.jpg"
                        }, 
                        new Product
                        {
                            Productname = "iPhone 12 Pro 256GB",
                            Category_ID = 4,
                            Amount = 100,
                            Price = 34990000,
                            Detail= "Màn hình: 6.1', Super Retina XDR,Chip: Apple A14 Bionic 6 nhân,RAM: 6 GB, Bộ nhớ trong: 256 GB,Camera sau: 3 camera 12 MP,Camera trước: 12 MP",
                            Image = "iPhone 12 Pro 256GB.jpg"
                        },     
                        new Product
                        {
                            Productname = "iPhone 12 Pro Max 128GB",
                            Category_ID = 4,
                            Amount = 100,
                            Price = 33990000,
                            Detail= "Màn hình: 6.7', Super Retina XDR,Chip: Apple A14 Bionic 6 nhân,RAM: 6 GB, Bộ nhớ trong: 128 GB,Camera sau: 3 camera 12 MP,Camera trước: 12 MP",
                            Image = "iPhone 12 Pro Max 128GB.jpg"
                        }, 
                        new Product
                        {
                            Productname = "iPhone 11 Pro Max 256GB",
                            Category_ID = 4,
                            Amount = 100,
                            Price = 33990000,
                            Detail= "Màn hình: 6.5', Super Retina XDR,Chip: Apple A13 Bionic 6 nhân,RAM: 4 GB, Bộ nhớ trong: 256 GB,Camera sau: 3 camera 12 MP,Camera trước: 12 MP",
                            Image = "iPhone 11 Pro Max 256GB.jpg"
                        }, 
                        new Product
                        {
                            Productname = "iPhone 11 Pro 256GB",
                            Category_ID = 4,
                            Amount = 100,
                            Price = 30990000,
                            Detail= "Màn hình: 6.5', Super Retina XDR,Chip: Apple A13 Bionic 6 nhân,RAM: 4 GB, Bộ nhớ trong: 256 GB,Camera sau: 3 camera 12 MP,Camera trước: 12 MP",
                            Image = "iPhone 11 Pro 256GB.jpg"
                        }, 
                        new Product
                        {
                            Productname = "iPhone 12 Pro 128GB",
                            Category_ID = 4,
                            Amount = 100,
                            Price = 30990000,
                            Detail= "Màn hình: 6.1', Liquid Retina,Chip: Apple A13 Bionic 6 nhân,RAM: 4 GB, Bộ nhớ trong: 64 GB,Camera sau: 2 camera 12 MP",
                            Image = "iPhone 12 Pro 128GB.jpg"
                        }, 
                        new Product
                        {
                            Productname = "iPhone 11 Pro Max 64GB",
                            Category_ID = 4,
                            Amount = 100,
                            Price = 29990000,
                            Detail= "Màn hình: 6.1', Liquid Retina,Chip: Apple A13 Bionic 6 nhân,RAM: 4 GB, Bộ nhớ trong: 64 GB,Camera sau: 2 camera 12 MP",
                            Image = "iPhone 11 Pro Max 64GB.jpg"
                        }, 
                        new Product
                        {
                            Productname = "iPhone 12 256GB",
                            Category_ID = 4,
                            Amount = 100,
                            Price = 28990000,
                            Detail="Màn hình: 6.7', Super Retina XDR,Chip: Apple A14 Bionic 6 nhân,Camera sau: 3 camera 12 MP,Camera trước: 12 MP",
                            Image = "iPhone 12 256GB.jpg"
                        }, 
                        new Product
                        {
                            Productname = "iPhone 11 Pro 64GB",
                            Category_ID = 4,
                            Amount = 100,
                            Price = 26990000,
                            Detail="Màn hình: 6.7', Super Retina XDR,Chip: Apple A14 Bionic 6 nhân,Camera sau: 3 camera 12 MP,Camera trước: 12 MP",
                            Image = "iPhone 11 Pro 64GB.jpg"
                        }, 
                        new Product
                        {
                            Productname = "iPhone 12 128GB",
                            Category_ID = 4,
                            Amount = 100,
                            Price = 26990000,
                            Detail= "Màn hình: 6.5', Super Retina XDR,Chip: Apple A13 Bionic 6 nhân,RAM: 4 GB, Bộ nhớ trong: 256 GB,Camera sau: 3 camera 12 MP,Camera trước: 12 MP",
                            Image = "iPhone 12 128GB.jpg"
                        }, 
                        new Product
                        {
                            Productname = "iPhone 12 mini 256GB",
                            Category_ID = 4,
                            Amount = 100,
                            Price = 25990000,
                            Detail= "Màn hình: 6.5', Super Retina XDR,Chip: Apple A13 Bionic 6 nhân,RAM: 4 GB, Bộ nhớ trong: 256 GB,Camera sau: 3 camera 12 MP,Camera trước: 12 MP",
                            Image = "iPhone 12 mini 256GB.jpg"
                        }, 
                        new Product
                        {
                            Productname = "iPhone 12 64GB",
                            Category_ID = 4,
                            Amount = 100,
                            Price = 24990000,
                            Detail= "Màn hình: 6.5', Super Retina XDR,Chip: Apple A13 Bionic 6 nhân,RAM: 4 GB, Bộ nhớ trong: 256 GB,Camera sau: 3 camera 12 MP,Camera trước: 12 MP",
                            Image = "iPhone 12 64GB.jpg"
                        },
                        //samsung
                        new Product
                        {
                            Productname = "Samsung Galaxy Note 20 Ultra 5G white",
                            Category_ID = 3,
                            Amount = 100,
                            Price = 32990000,
                            Detail= "Màn hình: 6.9', Quad HD+ (2K+),Chip: Exynos 990 8 nhân,RAM: 12 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 12 MP, 12 MP, cảm biến Laser AF,Camera trước: 10 MP,Pin: 4500 mAh, có sạc nhanh",
                            Image = "Samsung Galaxy Note 20 Ultra 5G white.jpg"
                        },
                        new Product
                        {
                            Productname = "Samsung Galaxy S20 FE",
                            Category_ID = 3,
                            Amount = 100,
                            Price = 15990000,
                            Detail= "Màn hình: 6.5', Full HD+,Chip: Exynos 990 8 nhân,RAM: 8 GB, Bộ nhớ trong: 128 GB,Camera sau: Chính 12 MP & Phụ 12 MP, 8 MP,Camera trước: 32 MP,Pin: 4500 mAh, có sạc nhanh",
                            Image = "Samsung Galaxy S20 FE.jpg"
                        },
                        new Product
                        {
                            Productname = "Samsung Galaxy M51",
                            Category_ID = 3,
                            Amount = 100,
                            Price = 8990000,
                            Detail= "Màn hình: 6.7', Full HD+,Chip: Snapdragon 730 8 nhân,RAM: 8 GB, Bộ nhớ trong: 128 GB,Camera sau: Chính 64 MP & Phụ 12 MP, 5 MP, 5 MP,Camera trước: 32 MP,Pin: 7000 mAh, có sạc nhanh",
                            Image = "Samsung Galaxy M51.jpg"
                        },
                        new Product
                        {
                            Productname = "Samsung Galaxy Z Fold2 5G",
                            Category_ID = 3,
                            Amount = 100,
                            Price = 50000000,
                            Detail= "Màn hình: Chính 7.59' & Phụ 6.23', Full HD+,Chip: Snapdragon 865+ 8 nhân,RAM: 12 GB, Bộ nhớ trong: 256 GB,Camera sau: 3 camera 12 MP,Camera trước: 10 MP,Pin: 4500 mAh, có sạc nhanh",
                            Image = "Samsung Galaxy Z Fold2 5G.jpg"
                        },
                        new Product
                        {
                            Productname = "Samsung Galaxy Note 20 Ultra 5G",
                            Category_ID = 3,
                            Amount = 100,
                            Price = 28990000,
                            Detail= "Màn hình: 6.9', Quad HD+ (2K+),Chip: Exynos 990 8 nhân,RAM: 12 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 12 MP, 12 MP, cảm biến Laser AF,Camera trước: 10 MP,Pin: 4500 mAh, có sạc nhanh",
                            Image = "Samsung Galaxy Note 20 Ultra 5G.jpg"
                        },
                        new Product
                        {
                            Productname = "Samsung Galaxy Note 20 Ultra",
                            Category_ID = 3,
                            Amount = 100,
                            Price = 24990000,
                            Detail= "Màn hình: 6.9', Quad HD+ (2K+),Chip: Exynos 990 8 nhân,RAM: 12 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 12 MP, 12 MP, cảm biến Laser AF,Camera trước: 10 MP,Pin: 4500 mAh, có sạc nhanh",
                            Image = "Samsung Galaxy Note 20 Ultra.jpg"
                        },
                        new Product
                        {
                            Productname = "Samsung Galaxy S10 Lite",
                            Category_ID = 3,
                            Amount = 100,
                            Price = 12990000,
                            Detail= "Màn hình: 6.9', Quad HD+ (2K+),Chip: Exynos 990 8 nhân,RAM: 12 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 12 MP, 12 MP, cảm biến Laser AF,Camera trước: 10 MP,Pin: 4500 mAh, có sạc nhanh",
                            Image = "Samsung Galaxy S10 Lite.jpg"
                        },
                        new Product
                        {
                            Productname = "Samsung Galaxy Note 20",
                            Category_ID = 3,
                            Amount = 100,
                            Price = 19990000,
                            Detail= "Màn hình: 6.9', Quad HD+ (2K+),Chip: Exynos 990 8 nhân,RAM: 12 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 12 MP, 12 MP, cảm biến Laser AF,Camera trước: 10 MP,Pin: 4500 mAh, có sạc nhanh",
                            Image = "Samsung Galaxy Note 20.jpg"
                        },
                        new Product
                        {
                            Productname = "Samsung Galaxy S20+",
                            Category_ID = 3,
                            Amount = 100,
                            Price = 23990000,
                            Detail= "Màn hình: 6.9', Quad HD+ (2K+),Chip: Exynos 990 8 nhân,RAM: 12 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 12 MP, 12 MP, cảm biến Laser AF,Camera trước: 10 MP,Pin: 4500 mAh, có sạc nhanh",
                            Image = "Samsung Galaxy S20+.jpg"
                        },
                        new Product
                        {
                            Productname = "Samsung Galaxy S20",
                            Category_ID = 3,
                            Amount = 100,
                            Price = 21990000,
                            Detail= "Màn hình: 6.9', Quad HD+ (2K+),Chip: Exynos 990 8 nhân,RAM: 12 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 12 MP, 12 MP, cảm biến Laser AF,Camera trước: 10 MP,Pin: 4500 mAh, có sạc nhanh",
                            Image = "Samsung Galaxy S20.jpg"
                        },
                        new Product
                        {
                            Productname = "Samsung Galaxy Z Flip",
                            Category_ID = 3,
                            Amount = 100,
                            Price = 36990000,
                            Detail= "Màn hình: 6.9', Quad HD+ (2K+),Chip: Exynos 990 8 nhân,RAM: 12 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 12 MP, 12 MP, cảm biến Laser AF,Camera trước: 10 MP,Pin: 4500 mAh, có sạc nhanh",
                            Image = "Samsung Galaxy Z Flip.jpg"
                        },
                        new Product
                        {
                            Productname = "Samsung Galaxy Note 10+",
                            Category_ID = 3,
                            Amount = 100,
                            Price = 15290000,
                            Detail= "Màn hình: 6.9', Quad HD+ (2K+),Chip: Exynos 990 8 nhân,RAM: 12 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 12 MP, 12 MP, cảm biến Laser AF,Camera trước: 10 MP,Pin: 4500 mAh, có sạc nhanh",
                            Image = "Samsung Galaxy Note 10+.jpg"
                        },
                        //oppo
                        new Product
                        {
                            Productname = "OPPO A93",
                            Category_ID = 2,
                            Amount = 100,
                            Price = 6990000,
                            Detail= "Màn hình: 6.9', Quad HD+ (2K+),Chip: Exynos 990 8 nhân,RAM: 12 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 12 MP, 12 MP, cảm biến Laser AF,Camera trước: 10 MP,Pin: 4500 mAh, có sạc nhanh",
                            Image = "OPPO A93.jpg"   
                        },
                        new Product
                        {
                            Productname = "OPPO Reno4",
                            Category_ID = 2,
                            Amount = 100,
                            Price = 24990000,
                            Detail= "Màn hình: 6.9', Quad HD+ (2K+),Chip: Exynos 990 8 nhân,RAM: 12 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 12 MP, 12 MP, cảm biến Laser AF,Camera trước: 10 MP,Pin: 4500 mAh, có sạc nhanh",
                            Image = "OPPO Reno4.jpg"
                        },
                        new Product
                        {
                            Productname = "OPPO Reno3 Pro",
                            Category_ID = 2,
                            Amount = 100,
                            Price = 24990000,
                            Detail= "Màn hình: 6.9', Quad HD+ (2K+),Chip: Exynos 990 8 nhân,RAM: 12 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 12 MP, 12 MP, cảm biến Laser AF,Camera trước: 10 MP,Pin: 4500 mAh, có sạc nhanh",
                            Image = "OPPO Reno3 Pro.jpg"
                        },
                        new Product
                        {
                            Productname = "OPPO Find X2",
                            Category_ID = 2,
                            Amount = 100,
                            Price = 24990000,
                            Detail= "Màn hình: 6.9', Quad HD+ (2K+),Chip: Exynos 990 8 nhân,RAM: 12 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 12 MP, 12 MP, cảm biến Laser AF,Camera trước: 10 MP,Pin: 4500 mAh, có sạc nhanh",
                            Image = "OPPO Find X2.jpg"
                        },
                        //xiaomi
                        new Product
                        {
                            Productname = "Xiaomi Mi 10T Pro 5G",
                            Category_ID = 1,
                            Amount = 100,
                            Price = 11990000,
                            Detail= "Màn hình: 6.67', Full HD+,Chip: Snapdragon 865 8 nhân,RAM: 8 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 13 MP, 5 MP,Camera trước: 20 MP,Pin: 5000 mAh, có sạc nhanh",
                            Image = "Xiaomi Mi 10T Pro 5G.jpg"
                        },
                        new Product
                        {
                            Productname = "Xiaomi POCO X3 NFC",
                            Category_ID = 1,
                            Amount = 100,
                            Price = 6990000,
                            Detail= "Màn hình: 6.67', Full HD+,Chip: Snapdragon 865 8 nhân,RAM: 8 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 13 MP, 5 MP,Camera trước: 20 MP,Pin: 5000 mAh, có sạc nhanh",
                            Image = "Xiaomi POCO X3 NFC.jpg"
                        },
                        new Product
                        {
                            Productname = "Xiaomi Redmi 9C (3GB-64GB)",
                            Category_ID = 1,
                            Amount = 100,
                            Price = 2990000,
                            Detail= "Màn hình: 6.67', Full HD+,Chip: Snapdragon 865 8 nhân,RAM: 8 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 13 MP, 5 MP,Camera trước: 20 MP,Pin: 5000 mAh, có sạc nhanh",
                            Image = "Xiaomi Redmi 9C (3GB-64GB).jpg"
                        },
                        new Product
                        {
                            Productname = "Xiaomi Redmi 9A",
                            Category_ID = 1,
                            Amount = 100,
                            Price = 1990000,
                            Detail= "Màn hình: 6.67', Full HD+,Chip: Snapdragon 865 8 nhân,RAM: 8 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 13 MP, 5 MP,Camera trước: 20 MP,Pin: 5000 mAh, có sạc nhanh",
                            Image = "Xiaomi Redmi 9A.jpg"
                        },
                        new Product
                        {
                            Productname = "Xiaomi Redmi 9 (4GB-64GB)",
                            Category_ID = 1,
                            Amount = 100,
                            Price = 3990000,
                            Detail= "Màn hình: 6.67', Full HD+,Chip: Snapdragon 865 8 nhân,RAM: 8 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 13 MP, 5 MP,Camera trước: 20 MP,Pin: 5000 mAh, có sạc nhanh",
                            Image = "Xiaomi Redmi 9 (4GB-64GB).jpg"
                        },
                        new Product
                        {
                            Productname = "Xiaomi Redmi 9 (3GB-32GB)",
                            Category_ID = 1,
                            Amount = 100,
                            Price = 3990000,
                            Detail= "Màn hình: 6.67', Full HD+,Chip: Snapdragon 865 8 nhân,RAM: 8 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 13 MP, 5 MP,Camera trước: 20 MP,Pin: 5000 mAh, có sạc nhanh",
                            Image = "Xiaomi Redmi 9 (3GB-32GB).jpg"
                        },
                        new Product
                        {
                            Productname = "Xiaomi Redmi 9C (2GB-32GB)",
                            Category_ID = 1,
                            Amount = 100,
                            Price = 24990000,
                            Detail= "Màn hình: 6.67', Full HD+,Chip: Snapdragon 865 8 nhân,RAM: 8 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 13 MP, 5 MP,Camera trước: 20 MP,Pin: 5000 mAh, có sạc nhanh",
                            Image = "Xiaomi Redmi 9C (2GB-32GB).jpg"
                        },
                        new Product
                        {
                            Productname = "Xiaomi Redmi Note 9",
                            Category_ID = 1,
                            Amount = 100,
                            Price = 4990000,
                            Detail= "Màn hình: 6.67', Full HD+,Chip: Snapdragon 865 8 nhân,RAM: 8 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 13 MP, 5 MP,Camera trước: 20 MP,Pin: 5000 mAh, có sạc nhanh",
                            Image = "Xiaomi Redmi Note 9.jpg"
                        },
                        new Product
                        {
                            Productname = "Xiaomi Redmi Note 9 Pro (6GB-128GB)",
                            Category_ID = 1,
                            Amount = 100,
                            Price = 6990000,
                            Detail= "Màn hình: 6.67', Full HD+,Chip: Snapdragon 865 8 nhân,RAM: 8 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 13 MP, 5 MP,Camera trước: 20 MP,Pin: 5000 mAh, có sạc nhanh",
                            Image = "Xiaomi Redmi Note 9 Pro (6GB-128GB).jpg"
                        },new Product
                        {
                            Productname = "Xiaomi Redmi Note 9 Pro (6GB-64GB)",
                            Category_ID = 1,
                            Amount = 100,
                            Price = 6990000,
                            Detail= "Màn hình: 6.67', Full HD+,Chip: Snapdragon 865 8 nhân,RAM: 8 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 13 MP, 5 MP,Camera trước: 20 MP,Pin: 5000 mAh, có sạc nhanh",
                            Image = "Xiaomi Redmi Note 9 Pro (6GB-64GB).jpg"
                        },
                        new Product
                        {
                            Productname = "Xiaomi Redmi Note 9S",
                            Category_ID = 1,
                            Amount = 100,
                            Price = 5990000,
                            Detail= "Màn hình: 6.67', Full HD+,Chip: Snapdragon 865 8 nhân,RAM: 8 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 13 MP, 5 MP,Camera trước: 20 MP,Pin: 5000 mAh, có sạc nhanh",
                            Image = "Xiaomi Redmi Note 9S.jpg"
                        },
                        new Product
                        {
                            Productname = "Xiaomi Redmi Note 8 Pro (6GB-128GB)",
                            Category_ID = 1,
                            Amount = 100,
                            Price = 5990000,
                            Detail= "Màn hình: 6.67', Full HD+,Chip: Snapdragon 865 8 nhân,RAM: 8 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 13 MP, 5 MP,Camera trước: 20 MP,Pin: 5000 mAh, có sạc nhanh",
                            Image = "Xiaomi Redmi Note 8 Pro (6GB-128GB).jpg"
                        },
                        new Product
                        {
                            Productname = "Xiaomi Redmi Note 8 (4GB-128GB)",
                            Category_ID = 1,
                            Amount = 100,
                            Price = 4990000,
                            Detail= "Màn hình: 6.67', Full HD+,Chip: Snapdragon 865 8 nhân,RAM: 8 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 13 MP, 5 MP,Camera trước: 20 MP,Pin: 5000 mAh, có sạc nhanh",
                            Image = "Xiaomi Redmi Note 8 (4GB-128GB).jpg"
                        },
                        new Product
                        {
                            Productname = "Xiaomi Redmi Note 8 (3GB-32GB)",
                            Category_ID = 1,
                            Amount = 100,
                            Price = 3990000,
                            Detail= "Màn hình: 6.67', Full HD+,Chip: Snapdragon 865 8 nhân,RAM: 8 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 13 MP, 5 MP,Camera trước: 20 MP,Pin: 5000 mAh, có sạc nhanh",
                            Image = "Xiaomi Redmi Note 8 (3GB-32GB).jpg"
                        },
                        new Product
                        {
                            Productname = "Xiaomi Redmi Note 8 (4GB-64GB)",
                            Category_ID = 1,
                            Amount = 100,
                            Price = 4990000,
                            Detail= "Màn hình: 6.67', Full HD+,Chip: Snapdragon 865 8 nhân,RAM: 8 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 13 MP, 5 MP,Camera trước: 20 MP,Pin: 5000 mAh, có sạc nhanh",
                            Image = "Xiaomi Redmi Note 8 (4GB-64GB).jpg"
                        },
                        new Product
                        {
                            Productname = "Xiaomi Redmi Note 7 (4GB-64GB)",
                            Category_ID = 1,
                            Amount = 100,
                            Price = 3990000,
                            Detail= "Màn hình: 6.67', Full HD+,Chip: Snapdragon 865 8 nhân,RAM: 8 GB, Bộ nhớ trong: 256 GB,Camera sau: Chính 108 MP & Phụ 13 MP, 5 MP,Camera trước: 20 MP,Pin: 5000 mAh, có sạc nhanh",
                            Image = "Xiaomi Redmi Note 7 (4GB-64GB).jpg"
                        },
                        //laptop
                        //mac
                        new Product
                        {
                            Productname = "MacBook Air 2017 128GB (MQD32SA-A)",
                            Category_ID = 5,
                            Amount = 100,
                            Price = 2090000,
                            Detail= "Màn hình: 13.3 inch, WXGA+(1440 x 900),CPU: Intel Core i5 Broadwell, 1.80 GHz,Đồ họa: Intel HD Graphics 6000,Mac OS",
                            Image = "MacBook Air 2017 128GB (MQD32SA-A).jpg"
                        },
                        new Product
                        {
                            Productname = "MacBook Air 2020 i3 256GB (MWTL2SA-A)",
                            Category_ID = 5,
                            Amount = 100,
                            Price = 22990000,
                            Detail= "Màn hình: 13.3 inch, WXGA+(1440 x 900),CPU: Intel Core i5 Broadwell, 1.80 GHz,Đồ họa: Intel HD Graphics 6000,Mac OS",
                            Image = "MacBook Air 2020 i3 256GB (MWTL2SA-A).jpg"
                        },
                        new Product
                        {
                            Productname = "Apple MacBook Air 2020 i3 256GB (MWTJ2SA-A)",
                            Category_ID = 5,
                            Amount = 100,
                            Price = 20000000,
                            Detail= "Màn hình: 13.3 inch, WXGA+(1440 x 900),CPU: Intel Core i5 Broadwell, 1.80 GHz,Đồ họa: Intel HD Graphics 6000,Mac OS",
                            Image = "Apple MacBook Air 2020 i3 256GB (MWTJ2SA-A).jpg"
                        },
                        //asus
                       new Product
                        {
                            Productname = "Asus VivoBook X409JA i5 1035G1 (EK052T)",
                            Category_ID = 6,
                            Amount = 100,
                            Price = 15490000,
                            Detail= "Màn hình: 14 inch, Full HD (1920 x 1080),CPU: Intel Core i5 Ice Lake, 1.00 GHz,Đồ họa: Intel UHD Graphics,Windows 10 Home SL",
                            Image = "Asus VivoBook X409JA i5 1035G1 (EK052T).jpg"
                        },
                        new Product
                        {
                            Productname = "Asus VivoBook X409JA i3 1005G1 (EK015T)",
                            Category_ID = 6,
                            Amount = 100,
                            Price = 11590000,
                            Detail= "Màn hình: 14 inch, Full HD (1920 x 1080),CPU: Intel Core i5 Ice Lake, 1.00 GHz,Đồ họa: Intel UHD Graphics,Windows 10 Home SL",
                            Image = "Asus VivoBook X409JA i3 1005G1 (EK015T).jpg"
                        },
                        new Product
                        {
                            Productname = "Asus VivoBook X509JP i5 1035G1 (EJ023T)",
                            Category_ID = 6,
                            Amount = 100,
                            Price = 17900000,
                            Detail= "Màn hình: 14 inch, Full HD (1920 x 1080),CPU: Intel Core i5 Ice Lake, 1.00 GHz,Đồ họa: Intel UHD Graphics,Windows 10 Home SL",
                            Image = "Asus VivoBook X509JP i5 1035G1 (EJ023T).jpg"
                        },
                        new Product
                        {
                            Productname = "Asus VivoBook X509MA N4020 (BR271T)",
                            Category_ID = 6,
                            Amount = 100,
                            Price = 6900000,
                            Detail= "Màn hình: 14 inch, Full HD (1920 x 1080),CPU: Intel Core i5 Ice Lake, 1.00 GHz,Đồ họa: Intel UHD Graphics,Windows 10 Home SL",
                            Image = "Asus VivoBook X509MA N4020 (BR271T).jpg"
                        },
                        //tablet
                        //ipab
                        new Product
                        {
                            Productname = "iPad 8 Wifi 32GB (2020)",
                            Category_ID = 7,
                            Amount = 100,
                            Price = 10900000,
                            Detail= "Màn hình: 10.2', Retina IPS LCD,Chip: Apple A12 Bionic 6 nhân, iPadOS 14,RAM: 3 GB, Bộ nhớ trong: 128 GB",
                            Image = "iPad 8 Wifi 32GB (2020).jpg"
                        },
                        new Product
                        {
                            Productname = "iPad Mini 7.9 inch Wifi 64GB (2019)",
                            Category_ID = 7,
                            Amount = 100,
                            Price = 8900000,
                            Detail= "Màn hình: 10.2', Retina IPS LCD,Chip: Apple A12 Bionic 6 nhân, iPadOS 14,RAM: 3 GB, Bộ nhớ trong: 128 GB",
                            Image = "iPad Mini 7.9 inch Wifi 64GB (2019).jpg"
                        },
                        new Product
                        {
                            Productname = "iPad Pro 11 inch Wifi 128GB (2020)",
                            Category_ID = 7,
                            Amount = 100,
                            Price = 21900000,
                            Detail= "Màn hình: 10.2', Retina IPS LCD,Chip: Apple A12 Bionic 6 nhân, iPadOS 14,RAM: 3 GB, Bộ nhớ trong: 128 GB",
                            Image = "iPad Pro 11 inch Wifi 128GB (2020).jpg"
                        },
                        new Product
                        {
                            Productname = "iPad Pro 12.9 inch Wifi Cellular 128GB (2020)",
                            Category_ID = 7,
                            Amount = 100,
                            Price = 30900000,
                            Detail= "Màn hình: 10.2', Retina IPS LCD,Chip: Apple A12 Bionic 6 nhân, iPadOS 14,RAM: 3 GB, Bộ nhớ trong: 128 GB",
                            Image = "iPad Pro 12.9 inch Wifi Cellular 128GB (2020).jpg"
                        },
                        //samsung
                        new Product
                        {
                            Productname = "Samsung Galaxy Tab A7 (2020)",
                            Category_ID = 8,
                            Amount = 100,
                            Price = 7900000,
                            Detail= "Màn hình: 10.4', TFT LCD,Chip: Snapdragon 662 8 nhân, Android 10,RAM: 3 GB, Bộ nhớ trong: 64 GB,Camera sau: 8 MP, Camera trước: 5 MP",
                            Image = "Samsung Galaxy Tab A7 (2020).jpg"
                        },
                        new Product
                        {
                            Productname = "Samsung Galaxy Tab S7",
                            Category_ID = 8,
                            Amount = 100,
                            Price = 18900000,
                            Detail= "Màn hình: 10.4', TFT LCD,Chip: Snapdragon 662 8 nhân, Android 10,RAM: 3 GB, Bộ nhớ trong: 64 GB,Camera sau: 8 MP, Camera trước: 5 MP",
                            Image = "Samsung Galaxy Tab S7.jpg"
                        },
                        new Product
                        {
                            Productname = "Samsung Galaxy Tab S6 Lite",
                            Category_ID = 8,
                            Amount = 100,
                            Price = 9900000,
                            Detail= "Màn hình: 10.4', TFT LCD,Chip: Snapdragon 662 8 nhân, Android 10,RAM: 3 GB, Bộ nhớ trong: 64 GB,Camera sau: 8 MP, Camera trước: 5 MP",
                            Image = "Samsung Galaxy Tab S6 Lite.jpg"
                        },
                        new Product
                        {
                            Productname = "Samsung Galaxy Tab S6",
                            Category_ID = 8,
                            Amount = 100,
                            Price = 18900000,
                            Detail= "Màn hình: 10.4', TFT LCD,Chip: Snapdragon 662 8 nhân, Android 10,RAM: 3 GB, Bộ nhớ trong: 64 GB,Camera sau: 8 MP, Camera trước: 5 MP",
                            Image = "Samsung Galaxy Tab S6.jpg"
                        },
                        //phukien
                        //pin
                        new Product
                        {
                            Productname = "Pin sạc dự phòng 7500mAh AVA DS630",
                            Category_ID = 9,
                            Amount = 100,
                            Price = 255000,
                            Detail= "",
                            Image = "Pin sạc dự phòng 7500mAh AVA DS630.jpg"
                        },
                        new Product
                        {
                            Productname = "Pin sạc dự phòng Polymer 10.000mAh AVA PJ JP191S",
                            Category_ID = 9,
                            Amount = 100,
                            Price = 382000,
                            Detail= "",
                            Image = "Pin sạc dự phòng Polymer 10.000mAh AVA PJ JP191S.jpg"
                        },
                        new Product
                        {
                            Productname = "Pin sạc dự phòng Polymer 10.000mAh AVA PJ JP207 Xám",
                            Category_ID = 9,
                            Amount = 100,
                            Price = 382000,
                            Detail= "",
                            Image = "Pin sạc dự phòng Polymer 10.000mAh AVA PJ JP207 Xám.jpg"
                        },
                        new Product
                        {
                            Productname = "Pin sạc dự phòng Polymer 10.000mAh không dây Type C PD QC3.0 Xmobile PowerLite P106WD Đen",
                            Category_ID = 9,
                            Amount = 100,
                            Price = 255000,
                            Detail= "",
                            Image = "Pin sạc dự phòng Polymer 10.000mAh không dây Type C PD QC3.0 Xmobile PowerLite P106WD Đen.jpg"
                        },
                        //sac
                        new Product
                        {
                            Productname = "Adapter Sạc 2 cổng USB 2.4A Type C 3A Xmobile DS165X Trắng",
                            Category_ID = 10,
                            Amount = 100,
                            Price = 290000,
                            Detail= "",
                            Image = "Adapter Sạc 2 cổng USB 2.4A Type C 3A Xmobile DS165X Trắng.jpg"
                        },
                        new Product
                        {
                            Productname = "Adapter Sạc 1A AVA DS432X",
                            Category_ID = 10,
                            Amount = 100,
                            Price = 90000,
                            Detail= "",
                            Image = "Adapter Sạc 1A AVA DS432X.jpg"
                        },
                        new Product
                        {
                            Productname = "Cáp 3 đầu Lightning Type C Micro 1m eValu Spanker B 2",
                            Category_ID = 10,
                            Amount = 100,
                            Price = 220000,
                            Detail= "",
                            Image = "Cáp 3 đầu Lightning Type C Micro 1m eValu Spanker B 2.jpg"
                        },
                        new Product
                        {
                            Productname = "Adapter Sạc Type C 20W dùng cho iPhone,iPad Apple MHJE3 Trắng",
                            Category_ID = 10,
                            Amount = 100,
                            Price = 999000,
                            Detail= "",
                            Image = "Adapter Sạc Type C 20W dùng cho iPhone,iPad Apple MHJE3 Trắng.jpg"
                        },
                        //tainghe
                        new Product
                        {
                            Productname = "Tai nghe Bluetooth Roman R553X Đen",
                            Category_ID = 11,
                            Amount = 100,
                            Price = 1499000,
                            Detail= "",
                            Image = "Tai nghe Bluetooth Roman R553X Đen.jpg"
                        },
                        new Product
                        {
                            Productname = "Tai nghe đàm thoại Bluetooth Jabra Talk 5 Đen",
                            Category_ID = 11,
                            Amount = 100,
                            Price = 1199000,
                            Detail= "",
                            Image = "Tai nghe đàm thoại Bluetooth Jabra Talk 5 Đen.jpg"
                        },
                        new Product
                        {
                            Productname = "Tai nghe Bluetooth True Wireless Mozard TS13 Đen",
                            Category_ID = 11,
                            Amount = 100,
                            Price = 699000,
                            Detail= "",
                            Image = "Tai nghe Bluetooth True Wireless Mozard TS13 Đen.jpg"
                        },
                        new Product
                        {
                            Productname = "Tai nghe Bluetooth True Wireless Mozard Air 3 Đen",
                            Category_ID = 11,
                            Amount = 100,
                            Price = 800000,
                            Detail= "",
                            Image = "Tai nghe Bluetooth True Wireless Mozard Air 3 Đen.jpg"
                        },
                        //USB
                        new Product
                        {
                            Productname = "USB OTG 3.1 128GB Type C Sandisk SDDDC3 Đen",
                            Category_ID = 12,
                            Amount = 100,
                            Price = 699000,
                            Detail= "",
                            Image = "USB OTG 3.1 128GB Type C Sandisk SDDDC3 Đen.jpg"
                        },
                        new Product
                        {
                            Productname = "USB 2.0 8GB Sandisk SDCZ33 Đen",
                            Category_ID = 12,
                            Amount = 100,
                            Price = 150000,
                            Detail= "",
                            Image = "USB 2.0 8GB Sandisk SDCZ33 Đen.jpg"
                        },
                        new Product
                        {
                            Productname = "USB OTG 3.1 64GB Type C Sandisk SDDDC3 Đen",
                            Category_ID = 12,
                            Amount = 100,
                            Price = 499000,
                            Detail= "",
                            Image = "USB OTG 3.1 64GB Type C Sandisk SDDDC3 Đen.jpg"
                        },
                        new Product
                        {
                            Productname = "USB OTG 3.1 32GB Type C Sandisk SDDDC3 Đen",
                            Category_ID = 12,
                            Amount = 100,
                            Price = 359000,
                            Detail= "",
                            Image = "USB OTG 3.1 32GB Type C Sandisk SDDDC3 Đen.jpg"
                        }
                    );
                    context.SaveChanges();
                }
                fl=1;
                if (context.Combo.Any())
                {
                    fl = 0;   // DB has been seeded
                }
                if(fl == 1){
                    context.Combo.AddRange(
                        new Combo{
                            ComboName = "Giảm sập sàn",
                            DayStart = DateTime.Now,
                            DayEnd = Convert.ToDateTime("12-12-2020"),
                            Total = 30000000,
                            Discount = "1",
                            DiscountMoney = "100000",
                            Image="Giảm sập sàn.png"
                        },
                        new Combo{
                            ComboName = "Giảm nửa giá",
                            DayStart = DateTime.Now,
                            DayEnd = Convert.ToDateTime("20-12-2020"),
                            Total = 30000000,
                            Discount = "2",
                            DiscountMoney = "100000",
                            Image = "Giảm nửa giá.png"
                        },
                        new Combo{
                            ComboName = "Giảm toàn bộ",
                            DayStart = DateTime.Now,
                            DayEnd = Convert.ToDateTime("31-12-2020"),
                            Total = 30000000,
                            Discount = "3",
                            DiscountMoney = "100000",
                            Image = "Giảm toàn bộ.png"
                        },
                        new Combo{
                            ComboName = "Giảm khủng",
                            DayStart = DateTime.Now,
                            DayEnd = Convert.ToDateTime("27-12-2020"),
                            Total = 30000000,
                            Discount = "4",
                            DiscountMoney = "100000",
                            Image = "Giảm khủng.png"
                        },
                        new Combo{
                            ComboName = "Giảm nhẹ",
                            DayStart = DateTime.Now,
                            DayEnd = Convert.ToDateTime("24-12-2020"),
                            Total = 50000000,
                            Discount = "5",
                            DiscountMoney = "100000",
                            Image = "Giảm nhẹ.png"
                        }
                    );
                    context.SaveChanges();
                }

                fl=1;
                if (context.ComboProduct.Any())
                {
                    fl = 0;   // DB has been seeded
                }
                if(fl == 1){
                    context.ComboProduct.AddRange(
                        new ComboProduct{
                            Combo_Id = 1,
                            Product_Id = 1                 
                        },
                        new ComboProduct{
                            Combo_Id = 1,
                            Product_Id = 20                
                        },
                         new ComboProduct{
                            Combo_Id = 1,
                            Product_Id = 2                        
                        },
                        new ComboProduct{
                            Combo_Id = 1,
                            Product_Id = 3                    
                        },
                        new ComboProduct{
                            Combo_Id = 1,
                            Product_Id = 4                       
                        },
                        new ComboProduct{
                            Combo_Id = 2,
                            Product_Id = 5                        
                        },
                        new ComboProduct{
                            Combo_Id = 2,
                            Product_Id = 6                      
                        },
                        new ComboProduct{
                            Combo_Id = 2,
                            Product_Id = 7                       
                        },
                        new ComboProduct{
                            Combo_Id = 2,
                            Product_Id = 8                      
                        },
                        new ComboProduct{
                            Combo_Id = 3,
                            Product_Id = 9                       
                        },
                        new ComboProduct{
                            Combo_Id = 3,
                            Product_Id = 10                   
                        },
                        new ComboProduct{
                            Combo_Id = 3,
                            Product_Id = 11             
                        },
                        new ComboProduct{
                            Combo_Id = 3,
                            Product_Id = 12                
                        },
                        new ComboProduct{
                            Combo_Id = 4,
                            Product_Id = 13                  
                        },
                        new ComboProduct{
                            Combo_Id = 3,
                            Product_Id = 14                    
                        },
                        new ComboProduct{
                            Combo_Id = 5,
                            Product_Id = 15                 
                        },
                        new ComboProduct{
                            Combo_Id = 5,
                            Product_Id = 16               
                        },
                        new ComboProduct{
                            Combo_Id = 5,
                            Product_Id = 17                  
                        },
                        new ComboProduct{
                            Combo_Id = 3,
                            Product_Id = 18                   
                        },
                        new ComboProduct{
                            Combo_Id = 2,
                            Product_Id = 19                   
                        },
                        new ComboProduct{
                            Combo_Id = 2,
                            Product_Id = 19                   
                        },
                        new ComboProduct{
                            Combo_Id = 2,
                            Product_Id = 21                  
                        },
                        new ComboProduct{
                            Combo_Id = 1,
                            Product_Id = 22                   
                        },
                        new ComboProduct{
                            Combo_Id = 3,
                            Product_Id = 23                  
                        },
                        new ComboProduct{
                            Combo_Id = 3,
                            Product_Id = 24                  
                        },
                        new ComboProduct{
                            Combo_Id = 4,
                            Product_Id = 25                   
                        },
                        new ComboProduct{
                            Combo_Id = 4,
                            Product_Id = 79                   
                        },
                        new ComboProduct{
                            Combo_Id = 5,
                            Product_Id = 78                   
                        },
                        new ComboProduct{
                            Combo_Id = 4,
                            Product_Id = 77                   
                        },
                        new ComboProduct{
                            Combo_Id = 3,
                            Product_Id = 76                   
                        } 
                    );
                    context.SaveChanges();
                }
                
                if(fl == 0){
                    return;
                }
                
            }
        }
    }
}