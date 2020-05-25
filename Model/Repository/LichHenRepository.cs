﻿using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class LichHenRepository
    {
        PetStoreDbContext db = null;
        public LichHenRepository()
        {
            db = new PetStoreDbContext();
        }
        public int Insert(LichHen lichHen)
        {
            lichHen.CreateDate = DateTime.Now;
            db.LichHens.Add(lichHen);
            db.SaveChanges();
            return lichHen.LichHen_ID;
        }

    }
}