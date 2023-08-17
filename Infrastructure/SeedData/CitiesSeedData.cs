﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SeedData
{
    public static class CitiesSeedData
    {
        public static void AddCitiesData(this ModelBuilder builder)
        {
            builder.Entity<City>().HasData(
                new City { Id = 1, Name = "Baku", CountryId = 1 },
                new City { Id = 2, Name = "Dashkasan", CountryId = 1 },
                new City { Id = 3, Name = "Ganja", CountryId = 1 },
                new City { Id = 4, Name = "Goychay", CountryId = 1 },
                new City { Id = 5, Name = "Ismayilli", CountryId = 1 },
                new City { Id = 6, Name = "Lankaran", CountryId = 1 },
                new City { Id = 7, Name = "Naxchivan", CountryId = 1 },
                new City { Id = 8, Name = "Quba", CountryId = 1 },
                new City { Id = 9, Name = "Shusha", CountryId = 1 },
                new City { Id = 10, Name = "Sumgayit", CountryId = 1 },
                new City { Id = 11, Name = "Batumi", CountryId = 2 },
                new City { Id = 12, Name = "Gori", CountryId = 2 },
                new City { Id = 13, Name = "Kashuri", CountryId = 2 },
                new City { Id = 14, Name = "Kobuleti", CountryId = 2 },
                new City { Id = 15, Name = "Kutaisi", CountryId = 2 },
                new City { Id = 16, Name = "Poti", CountryId = 2 },
                new City { Id = 17, Name = "Rustavi", CountryId = 2 },
                new City { Id = 18, Name = "Senaki", CountryId = 2 },
                new City { Id = 19, Name = "Tbilisi", CountryId = 2 },
                new City { Id = 20, Name = "Zugdidi", CountryId = 2 },
                new City { Id = 21, Name = "Ashdod", CountryId = 3 },
                new City { Id = 22, Name = "Beersheba", CountryId = 3 },
                new City { Id = 23, Name = "Bene Beraq", CountryId = 3 },
                new City { Id = 24, Name = "Haifa", CountryId = 3 },
                new City { Id = 25, Name = "Holon", CountryId = 3 },
                new City { Id = 26, Name = "Jerusalim", CountryId = 3 },
                new City { Id = 27, Name = "Netanya", CountryId = 3 },
                new City { Id = 28, Name = "Petah Tigwa", CountryId = 3 },
                new City { Id = 29, Name = "Rishon LeZiyyon", CountryId = 3 },
                new City { Id = 30, Name = "Tel Aviv-Yafo", CountryId = 3 },
                new City { Id = 31, Name = "Aktau", CountryId = 4 },
                new City { Id = 32, Name = "Aktobe", CountryId = 4 },
                new City { Id = 33, Name = "Almaty", CountryId = 4 },
                new City { Id = 34, Name = "Astana", CountryId = 4 },
                new City { Id = 35, Name = "Karaganda", CountryId = 4 },
                new City { Id = 36, Name = "Oskemen", CountryId = 4 },
                new City { Id = 37, Name = "Pavlodar", CountryId = 4 },
                new City { Id = 38, Name = "Semey", CountryId = 4 },
                new City { Id = 39, Name = "Shymkent", CountryId = 4 },
                new City { Id = 40, Name = "Taraz", CountryId = 4 },
                new City { Id = 41, Name = "Chelyabinsk", CountryId = 5 },
                new City { Id = 42, Name = "Kazan", CountryId = 5 },
                new City { Id = 43, Name = "Krasnoyarsk", CountryId = 5 },
                new City { Id = 44, Name = "Moscow", CountryId = 5 },
                new City { Id = 45, Name = "Nizhny Novgorod", CountryId = 5 },
                new City { Id = 46, Name = "Novosibirsk", CountryId = 5 },
                new City { Id = 47, Name = "Rostov-on-Don", CountryId = 5 },
                new City { Id = 48, Name = "Saint Petersburg", CountryId = 5 },
                new City { Id = 49, Name = "Samara", CountryId = 5 },
                new City { Id = 50, Name = "Yekaterinburg", CountryId = 5 },
                new City { Id = 51, Name = "Bokhtar", CountryId = 6 },
                new City { Id = 52, Name = "Dushanbe", CountryId = 6 },
                new City { Id = 53, Name = "Isfara", CountryId = 6 },
                new City { Id = 54, Name = "Istaravshan", CountryId = 6 },
                new City { Id = 55, Name = "Khujand", CountryId = 6 },
                new City { Id = 56, Name = "Konibodom", CountryId = 6 },
                new City { Id = 57, Name = "Kulob", CountryId = 6 },
                new City { Id = 58, Name = "Panjakent", CountryId = 6 },
                new City { Id = 59, Name = "Tursunzoda", CountryId = 6 },
                new City { Id = 60, Name = "Vahdat", CountryId = 6 },
                new City { Id = 61, Name = "Adana", CountryId = 7 },
                new City { Id = 62, Name = "Ankara", CountryId = 7 },
                new City { Id = 63, Name = "Antalya", CountryId = 7 },
                new City { Id = 64, Name = "Bursa", CountryId = 7 },
                new City { Id = 65, Name = "Gazientep", CountryId = 7 },
                new City { Id = 66, Name = "Istanbul", CountryId = 7 },
                new City { Id = 67, Name = "Izmir", CountryId = 7 },
                new City { Id = 68, Name = "Kayseri", CountryId = 7 },
                new City { Id = 69, Name = "Konya", CountryId = 7 },
                new City { Id = 70, Name = "Mersin", CountryId = 7 },
                new City { Id = 71, Name = "Turkmenbashy", CountryId = 8 },
                new City { Id = 72, Name = "Anau", CountryId = 8 },
                new City { Id = 73, Name = "Ashgabat", CountryId = 8 },
                new City { Id = 74, Name = "Balkanabat", CountryId = 8 },
                new City { Id = 75, Name = "Bayramaly", CountryId = 8 },
                new City { Id = 76, Name = "Dashoguz", CountryId = 8 },
                new City { Id = 77, Name = "Gazojak", CountryId = 8 },
                new City { Id = 78, Name = "Gyzylarbat", CountryId = 8 },
                new City { Id = 79, Name = "Mary", CountryId = 8 },
                new City { Id = 80, Name = "Turkmenabat", CountryId = 8 },
                new City { Id = 81, Name = "Kryvyi Rih", CountryId = 9 },
                new City { Id = 82, Name = "Dnipro", CountryId = 9 },
                new City { Id = 83, Name = "Donetsk", CountryId = 9 },
                new City { Id = 84, Name = "Kharkiv", CountryId = 9 },
                new City { Id = 85, Name = "Kyiv", CountryId = 9 },
                new City { Id = 86, Name = "Lviv", CountryId = 9 },
                new City { Id = 87, Name = "Mykolaiv", CountryId = 9 },
                new City { Id = 88, Name = "Odesa", CountryId = 9 },
                new City { Id = 89, Name = "Sevastopol", CountryId = 9 },
                new City { Id = 90, Name = "Zaporizhzhia", CountryId = 9 },
                new City { Id = 91, Name = "Andijan", CountryId = 10 },
                new City { Id = 92, Name = "Bukhara", CountryId = 10 },
                new City { Id = 93, Name = "Fergana", CountryId = 10 },
                new City { Id = 94, Name = "Kokand", CountryId = 10 },
                new City { Id = 95, Name = "Margilan", CountryId = 10 },
                new City { Id = 96, Name = "Namangan", CountryId = 10 },
                new City { Id = 97, Name = "Nukus", CountryId = 10 },
                new City { Id = 98, Name = "Qarshi", CountryId = 10 },
                new City { Id = 99, Name = "Samarkand", CountryId = 10 },
                new City { Id = 100, Name = "Tashkent", CountryId = 10 }
                );
        }
    }
}
