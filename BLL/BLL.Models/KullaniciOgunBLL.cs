using BLL.Interfaces;
using DAL.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL.Models
{
    public class KullaniciOgunBLL : ICRUD<KullaniciOgun>
    {
        public KullaniciOgunBLL()
        {
            dbContext = new HubDbContext();
        }

        HubDbContext dbContext;

        public bool Ekle(KullaniciOgun kullaniciOgun)
        {
            dbContext.KullaniciOgunleri.Add(kullaniciOgun);
            return dbContext.SaveChanges() > 0;
        }

        public bool Guncelle(KullaniciOgun entity)
        {
            return false;
        }

        public bool Sil(int id)
        {
            return false;
        }
    }
}
