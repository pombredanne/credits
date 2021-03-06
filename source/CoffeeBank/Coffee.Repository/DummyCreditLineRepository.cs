﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Coffee.IRepository;
using Coffee.Entities;

namespace Coffee.Repository
{
    class DummyCreditLineRepository: ICreditLineRepository
    {
        /**
         * Array is just used instead of database.
         * */
        private List<CreditLine> lines = new List<CreditLine>();
        

        private static Object _createLock = new Object();
        private Random random = new Random();
        private static DummyCreditLineRepository instance = null;

        private DummyCreditLineRepository() {
            CreditLine sample = new CreditLine();
            AmountBoundary sampleBoundary = new AmountBoundary(2000000, 6000000);
            sample.Conditions.Add(sampleBoundary);
            sample.Name = "Sample credit product.";
            sample.Id = 1;
            lines.Add(sample);
        }

        public List<CreditLine> getAll() {
            return new List<CreditLine>(lines);
        }

        public static DummyCreditLineRepository getInstance()
        {
            lock (_createLock)
            {
                if (instance == null)
                {
                    instance = new DummyCreditLineRepository();
                }
            }
            return instance;
        }

    }
}
